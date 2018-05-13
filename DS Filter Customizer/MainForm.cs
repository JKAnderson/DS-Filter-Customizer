using Octokit;
using Semver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;
using static DS_Filter_Customizer.FilterProfile;

namespace DS_Filter_Customizer
{
    public partial class MainForm : Form
    {
        private const int FADE_TIME = 2000;
        private static Properties.Settings settings = Properties.Settings.Default;

        private DSProcess dsProcess;
        private bool loaded = false;
        private int lastWorld, lastFilter;
        private List<FilterFile> filterFiles;
        private bool editing = false;
        private Filter oldFilter, newFilter;
        private long startTime, endTime;

        public MainForm()
        {
            InitializeComponent();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            Text = "DS Filter Customizer " + System.Windows.Forms.Application.ProductVersion;
            Location = settings.WindowLocation;
            cbxDisable.Checked = settings.DisableFilterOverride;
            cbxShowActive.Checked = settings.ShowActiveFilter;
            cbxForce.Checked = settings.ForceSelectedFilter;

            filterFiles = new List<FilterFile>();
            if (Directory.Exists("profiles"))
            {
                foreach (string path in Directory.EnumerateFiles("profiles"))
                {
                    if (Path.GetExtension(path) == ".xml")
                    {
                        FilterProfile filterProfile = LoadFilterProfile(path);
                        FilterFile filterFile = new FilterFile(filterProfile, path);
                        filterFiles.Add(filterFile);
                    }
                }
            }
            reloadCmbProfile();

            if (filterFiles.Count == 0)
            {
                disableFilters();
            }
            else
            {
                int lastProfile = settings.LastFilterProfile;
                if (lastProfile >= cmbProfile.Items.Count || lastProfile == -1)
                    lastProfile = 0;
                cmbProfile.SelectedIndex = lastProfile;
            }

            GitHubClient gitHubClient = new GitHubClient(new ProductHeaderValue("DS-Filter-Customizer"));
            try
            {
                Release release = await gitHubClient.Repository.Release.GetLatest("JKAnderson", "DS-Filter-Customizer");
                if (SemVersion.Parse(release.TagName) > System.Windows.Forms.Application.ProductVersion)
                {
                    lblCheckVersion.Visible = false;
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = "https://www.nexusmods.com/darksouls/mods/1411";
                    llbNewVersion.Links.Add(link);
                    llbNewVersion.Visible = true;
                }
                else
                {
                    lblCheckVersion.Text = "App up to date";
                }
            }
            catch (Exception ex) when (ex is HttpRequestException || ex is ApiException || ex is ArgumentException)
            {
                lblCheckVersion.Text = "Current app version unknown";
            }
        }

        private void llbNewVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData.ToString());
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                settings.WindowLocation = Location;
            else
                settings.WindowLocation = RestoreBounds.Location;
            settings.LastFilterProfile = cmbProfile.SelectedIndex;
            settings.DisableFilterOverride = cbxDisable.Checked;
            settings.ShowActiveFilter = cbxShowActive.Checked;
            settings.ForceSelectedFilter = cbxForce.Checked;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (loaded)
                dsProcess?.OverrideFilter(false);
            dsProcess?.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormNewProfile formNewProfile = new FormNewProfile();
            formNewProfile.ShowDialog();
            FilterProfile result = formNewProfile.Result;
            if (result != null)
                createFilterFile(result);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FilterFile filterFile = (FilterFile)cmbProfile.SelectedItem;
            filterFile.Profile.Save(filterFile.Path);
        }

        private void btnClone_Click(object sender, EventArgs e)
        {
            FilterFile filterFile = (FilterFile)cmbProfile.SelectedItem;
            FormCloneProfile formCloneProfile = new FormCloneProfile(filterFile.Profile);
            formCloneProfile.ShowDialog();
            FilterProfile result = formCloneProfile.Result;
            if (result != null)
                createFilterFile(result);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = cmbProfile.SelectedIndex;
            FilterFile filterFile = (FilterFile)cmbProfile.SelectedItem;
            filterFiles.Remove(filterFile);
            cmbProfile.Items.Remove(filterFile);
            if (cmbProfile.Items.Count == 0)
                disableFilters();
            else if (index == cmbProfile.Items.Count)
                cmbProfile.SelectedIndex = index - 1;
            else
                cmbProfile.SelectedIndex = index;
            File.Delete(filterFile.Path);
        }

        private void cmbProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterFile filterFile = (FilterFile)cmbProfile.SelectedItem;
            cmbFilter.Items.Clear();
            foreach (Filter filter in filterFile.Profile.Filters)
                cmbFilter.Items.Add(filter);
            cmbFilter.SelectedIndex = 0;
            if (filterFile.Profile.Type == FilterProfileType.Global || filterFile.Profile.Type == FilterProfileType.Multiplier)
            {
                cmbFilter.Enabled = false;
                cbxShowActive.Enabled = false;
                cbxForce.Enabled = false;
            }
            else
            {
                cmbFilter.Enabled = true;
                cbxShowActive.Enabled = true;
                cbxForce.Enabled = true;
            }
            lblHueNote.Visible = filterFile.Profile.Type == FilterProfileType.Multiplier;
            lastWorld = -1;
            lastFilter = -1;
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!editing)
                loadNUDs();
            if (cbxForce.Checked)
            {
                lastWorld = -1;
                lastFilter = -1;
            }
        }

        private void loadNUDs()
        {
            editing = true;
            Filter filter = (Filter)cmbFilter.SelectedItem;
            cbxBrightnessSync.Checked = filter.BrightnessSync;
            nudBrightnessR.Value = (decimal)filter.BrightnessR;
            nudBrightnessG.Value = (decimal)filter.BrightnessG;
            nudBrightnessB.Value = (decimal)filter.BrightnessB;
            cbxContrastSync.Checked = filter.ContrastSync;
            nudContrastR.Value = (decimal)filter.ContrastR;
            nudContrastG.Value = (decimal)filter.ContrastG;
            nudContrastB.Value = (decimal)filter.ContrastB;
            nudSaturation.Value = (decimal)filter.Saturation;
            nudHue.Value = (decimal)filter.Hue;
            editing = false;
        }

        private void filterEdited(object sender, EventArgs e)
        {
            if (!editing)
            {
                editing = true;
                Filter filter = (Filter)cmbFilter.SelectedItem;
                if (cbxBrightnessSync.Checked)
                {
                    nudBrightnessG.Value = nudBrightnessR.Value;
                    nudBrightnessB.Value = nudBrightnessR.Value;
                }
                filter.BrightnessR = (float)nudBrightnessR.Value;
                filter.BrightnessG = (float)nudBrightnessG.Value;
                filter.BrightnessB = (float)nudBrightnessB.Value;
                if (cbxContrastSync.Checked)
                {
                    nudContrastG.Value = nudContrastR.Value;
                    nudContrastB.Value = nudContrastR.Value;
                }
                filter.ContrastR = (float)nudContrastR.Value;
                filter.ContrastG = (float)nudContrastG.Value;
                filter.ContrastB = (float)nudContrastB.Value;
                filter.Saturation = (float)nudSaturation.Value;
                filter.Hue = (float)nudHue.Value;
                newFilter = null;
                lastWorld = -1;
                lastFilter = -1;
                editing = false;
            }
        }

        private void cbxBrightnessSync_CheckedChanged(object sender, EventArgs e)
        {
            Filter filter = (Filter)cmbFilter.SelectedItem;
            filter.BrightnessSync = cbxBrightnessSync.Checked;
            nudBrightnessG.Enabled = !cbxBrightnessSync.Checked;
            nudBrightnessB.Enabled = !cbxBrightnessSync.Checked;
            if (cbxBrightnessSync.Checked)
            {
                nudBrightnessG.Value = nudBrightnessR.Value;
                nudBrightnessB.Value = nudBrightnessR.Value;
            }
        }

        private void cbxContrastSync_CheckedChanged(object sender, EventArgs e)
        {
            Filter filter = (Filter)cmbFilter.SelectedItem;
            filter.ContrastSync = cbxContrastSync.Checked;
            nudContrastG.Enabled = !cbxContrastSync.Checked;
            nudContrastB.Enabled = !cbxContrastSync.Checked;
            if (cbxContrastSync.Checked)
            {
                nudContrastG.Value = nudContrastR.Value;
                nudContrastB.Value = nudContrastR.Value;
            }
        }

        private void cbxDisable_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxDisable.Checked)
                dsProcess?.OverrideFilter(false);
            else
            {
                lastWorld = -1;
                lastFilter = -1;
            }
        }

        private void cbxShowActive_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxShowActive.Checked)
            {
                cbxForce.Checked = false;
                if (lastWorld != -1 && lastFilter != -1)
                {
                    FilterFile filterFile = (FilterFile)cmbProfile.SelectedItem;
                    if (filterFile != null)
                        cmbFilter.SelectedItem = filterFile.Profile.GetActiveFilter(lastWorld, lastFilter);
                }
            }
        }

        private void cbxForce_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxForce.Checked)
            {
                cbxShowActive.Checked = false;
                lastWorld = -1;
                lastFilter = -1;
            }
        }

        private void disableFilters()
        {
            cmbProfile.Enabled = false;
            btnSave.Enabled = false;
            btnClone.Enabled = false;
            btnDelete.Enabled = false;
            cmbFilter.Enabled = false;
            gbxFilter.Enabled = false;
            lblHueNote.Visible = false;
        }

        private void reloadCmbProfile()
        {
            cmbProfile.Items.Clear();
            filterFiles.Sort((a, b) =>
            {
                if (a.Profile.Type == b.Profile.Type)
                    return a.Profile.Name.CompareTo(b.Profile.Name);
                else
                    return a.Profile.Type.CompareTo(b.Profile.Type);
            });
            foreach (FilterFile filterFile in filterFiles)
                cmbProfile.Items.Add(filterFile);
        }

        private void createFilterFile(FilterProfile profile)
        {
            string path = profile.MakePath("profiles");
            profile.Save(path);
            FilterFile filterFile = new FilterFile(profile, path);
            filterFiles.Add(filterFile);
            reloadCmbProfile();
            cmbProfile.SelectedItem = filterFile;
            if (cmbProfile.Items.Count == 1)
            {
                cmbProfile.Enabled = true;
                btnSave.Enabled = true;
                btnClone.Enabled = true;
                btnDelete.Enabled = true;
                gbxFilter.Enabled = true;
            }
        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            if (dsProcess == null)
            {
                DSProcess result = DSProcess.GetProcess();
                if (result != null)
                {
                    lblProcessValue.Text = result.ID.ToString();
                    lblVersionValue.Text = result.Version;
                    lblVersionValue.ForeColor = result.Valid ? Color.DarkGreen : Color.DarkRed;
                    dsProcess = result;
                }
            }
            else
            {
                if (dsProcess.Alive())
                {
                    if (dsProcess.Loaded())
                    {
                        if (!loaded)
                        {
                            dsProcess.LoadPointers();
                            lastWorld = -1;
                            lastFilter = -1;
                            loaded = true;
                        }
                        else
                        {
                            lblWorldValue.Text = dsProcess.GetWorld().ToString();
                            lblFilterIDValue.Text = dsProcess.GetFilter().ToString();
                            if (!cbxDisable.Checked)
                                updateFilters();
                        }
                    }
                    else if (loaded && !dsProcess.Loaded())
                    {
                        lblWorldValue.Text = "None";
                        lblFilterIDValue.Text = "None";
                        loaded = false;
                        newFilter = null;
                    }
                }
                else
                {
                    dsProcess.Close();
                    dsProcess = null;
                    lblProcessValue.Text = "None";
                    lblVersionValue.Text = "None";
                    lblVersionValue.ForeColor = Color.Black;
                    lblWorldValue.Text = "None";
                    lblFilterIDValue.Text = "None";
                    loaded = false;
                }
            }
        }

        private bool unknownFilter = false;

        private Filter lerpFilter(Filter startFilter, Filter endFilter, float progress)
        {
            Filter result = startFilter.Clone();
            result.BrightnessR += (endFilter.BrightnessR - startFilter.BrightnessR) * progress;
            result.BrightnessG += (endFilter.BrightnessG - startFilter.BrightnessG) * progress;
            result.BrightnessB += (endFilter.BrightnessB - startFilter.BrightnessB) * progress;
            result.ContrastR += (endFilter.ContrastR - startFilter.ContrastR) * progress;
            result.ContrastG += (endFilter.ContrastG - startFilter.ContrastG) * progress;
            result.ContrastB += (endFilter.ContrastB - startFilter.ContrastB) * progress;
            result.Saturation += (endFilter.Saturation - startFilter.Saturation) * progress;
            result.Hue += (endFilter.Hue - startFilter.Hue) * progress;
            return result;
        }

        private void updateFilters()
        {
            int world = dsProcess.GetWorld();
            int id = dsProcess.GetFilter();
            if (world != 255 && (world != lastWorld || id != lastFilter))
            {
                lastWorld = world;
                lastFilter = id;

                FilterFile filterFile = (FilterFile)cmbProfile.SelectedItem;
                if (filterFile != null)
                {
                    Filter activeFilter = filterFile.Profile.GetActiveFilter(world, id);
                    if (activeFilter == null)
                    {
                        if (unknownFilter)
                            txtError.Text = "Unknown filter: " + world + ", " + id;
                        else
                            unknownFilter = true;
                    }
                    else
                    {
                        unknownFilter = false;

                        if (cbxShowActive.Checked)
                            cmbFilter.SelectedItem = activeFilter;

                        Filter filter;
                        if (cbxForce.Checked && filterFile.Profile.Type != FilterProfileType.Multiplier)
                            filter = (Filter)cmbFilter.SelectedItem;
                        else
                            filter = filterFile.Profile.GetAppliedFilter(world, id);

                        long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                        if (newFilter != null)
                            oldFilter = lerpFilter(oldFilter, newFilter, (float)(now - startTime) / (endTime - startTime));
                        newFilter = filter;
                        startTime = now;
                        endTime = now + FADE_TIME;
                    }
                }
            }

            if (newFilter != null)
            {
                long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                Filter filter;
                if (oldFilter == null || now > endTime)
                {
                    filter = newFilter;
                    oldFilter = newFilter;
                    newFilter = null;
                }
                else
                    filter = lerpFilter(oldFilter, newFilter, (float)(now - startTime) / (endTime - startTime));
                dsProcess.SetBrightness(filter.BrightnessR, filter.BrightnessG, filter.BrightnessB);
                dsProcess.SetContrast(filter.ContrastR, filter.ContrastG, filter.ContrastB);
                dsProcess.SetSaturation(filter.Saturation);
                dsProcess.SetHue(filter.Hue);
                dsProcess.OverrideFilter(true);
            }
        }
    }
}
