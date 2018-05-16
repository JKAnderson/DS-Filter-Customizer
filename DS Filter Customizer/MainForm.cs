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
        // Duration of fade between filters
        private const int FADE_TIME = 2000;
        // URL when you click the update link label
        private const string UPDATE_LINK = "https://www.nexusmods.com/darksouls/mods/1411?tab=files";
        // Frames of delay before reporting an unknown filter; sometimes the world and filter ID are out of sync briefly, etc
        private const int UNKNOWN_FILTER_TIMEOUT = 5;

        private static Properties.Settings settings = Properties.Settings.Default;

        private DSProcess dsProcess;
        private bool loaded = false;
        private bool editingNUDs = false;
        private bool editingFilter = false;

        private List<FilterProfile> filterProfiles;
        private FilterProfile activeProfile;
        private int lastWorld, lastFilter;
        private Filter oldFilter, newFilter;
        private long startTime, endTime;
        private int unknownFilter = -1;

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

            filterProfiles = new List<FilterProfile>();
            if (Directory.Exists("profiles"))
            {
                foreach (string path in Directory.EnumerateFiles("profiles"))
                {
                    if (Path.GetExtension(path) == ".xml")
                    {
                        filterProfiles.Add(LoadFilterProfile(path));
                    }
                }
            }
            reloadCmbProfile();

            if (filterProfiles.Count == 0)
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
                    link.LinkData = UPDATE_LINK;
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

            if (dsProcess != null)
            {
                if (loaded)
                    dsProcess.OverrideFilter(false);
                dsProcess.Close();
            }
        }

        private void resetFilter()
        {
            lastWorld = -1;
            lastFilter = -1;
            oldFilter = null;
            newFilter = null;
        }

        private void disableFilters()
        {
            activeProfile = null;
            cmbProfile.Enabled = false;
            btnSave.Enabled = false;
            btnClone.Enabled = false;
            btnDelete.Enabled = false;
            cmbFilter.Enabled = false;
            gbxFilter.Enabled = false;
            lblHueNote.Visible = false;
        }

        private void addFilterProfile(FilterProfile profile)
        {
            filterProfiles.Add(profile);
            reloadCmbProfile();
            cmbProfile.SelectedItem = profile;
            if (cmbProfile.Items.Count == 1)
            {
                cmbProfile.Enabled = true;
                btnSave.Enabled = true;
                btnClone.Enabled = true;
                btnDelete.Enabled = true;
                gbxFilter.Enabled = true;
            }
            profile.Save();
        }

        private void reloadCmbProfile()
        {
            cmbProfile.Items.Clear();
            filterProfiles.Sort((a, b) =>
            {
                if (a.Type == b.Type)
                    return a.Name.CompareTo(b.Name);
                else
                    return a.Type.CompareTo(b.Type);
            });
            foreach (FilterProfile filterProfile in filterProfiles)
                cmbProfile.Items.Add(filterProfile);
        }

        private void cmbProfile_SelectedValueChanged(object sender, EventArgs e)
        {
            activeProfile = (FilterProfile)cmbProfile.SelectedItem;

            editingFilter = true;
            cmbFilter.Items.Clear();
            foreach (Filter filter in activeProfile.Filters)
                cmbFilter.Items.Add(filter);
            cmbFilter.SelectedIndex = 0;
            editingFilter = false;

            if (activeProfile.Type == FilterProfileType.Global || activeProfile.Type == FilterProfileType.Multiplier)
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
            lblHueNote.Visible = activeProfile.Type == FilterProfileType.Multiplier;
            resetFilter();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormNewProfile formNewProfile = new FormNewProfile();
            formNewProfile.ShowDialog();
            FilterProfile result = formNewProfile.Result;
            if (result != null)
                addFilterProfile(result);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            activeProfile.Save();
        }

        private void btnClone_Click(object sender, EventArgs e)
        {
            FormCloneProfile formCloneProfile = new FormCloneProfile(activeProfile);
            formCloneProfile.ShowDialog();
            FilterProfile result = formCloneProfile.Result;
            if (result != null)
                addFilterProfile(result);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = cmbProfile.SelectedIndex;
            File.Delete(activeProfile.Path);
            filterProfiles.Remove(activeProfile);
            cmbProfile.Items.Remove(activeProfile);

            if (cmbProfile.Items.Count == 0)
                disableFilters();
            else if (index == cmbProfile.Items.Count)
                cmbProfile.SelectedIndex = index - 1;
            else
                cmbProfile.SelectedIndex = index;
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            editingNUDs = true;
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
            editingNUDs = false;

            if (cbxForce.Checked)
                resetFilter();

            if (!editingFilter)
                cbxShowActive.Checked = false;
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

        private void filterEdited(object sender, EventArgs e)
        {
            if (!editingNUDs)
            {
                editingNUDs = true;
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
                resetFilter();
                editingNUDs = false;
            }
        }

        private void cbxDisable_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxDisable.Checked)
                dsProcess?.OverrideFilter(false);
            else
                resetFilter();
        }

        private void cbxShowActive_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxShowActive.Checked)
            {
                cbxForce.Checked = false;
                if (lastWorld != -1 && lastFilter != -1)
                {
                    if (activeProfile != null)
                    {
                        editingFilter = true;
                        cmbFilter.SelectedItem = activeProfile.GetActiveFilter(lastWorld, lastFilter);
                        editingFilter = false;
                    }
                }
            }
        }

        private void cbxForce_CheckedChanged(object sender, EventArgs e)
        {
            resetFilter();
            if (cbxForce.Checked)
                cbxShowActive.Checked = false;
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
                            resetFilter();
                            loaded = true;
                        }
                        else
                        {
                            lblWorldValue.Text = dsProcess.GetWorld().ToString();
                            lblFilterIDValue.Text = dsProcess.GetFilter().ToString();
                            if (activeProfile != null)
                                updateFilters();
                        }
                    }
                    else if (loaded && !dsProcess.Loaded())
                    {
                        lblWorldValue.Text = "None";
                        lblFilterIDValue.Text = "None";
                        loaded = false;
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

        private void updateFilters()
        {
            int world, id;
            if (cbxForce.Enabled && cbxForce.Checked)
            {
                Filter filter = (Filter)cmbFilter.SelectedItem;
                world = filter.World;
                id = filter.ID;
            }
            else
            {
                world = dsProcess.GetWorld();
                id = dsProcess.GetFilter();
            }

            if (world != 255 && (world != lastWorld || id != lastFilter))
            {
                lastWorld = world;
                lastFilter = id;

                Filter activeFilter = activeProfile.GetActiveFilter(world, id);
                Filter appliedFilter = activeProfile.GetAppliedFilter(world, id);
                if (activeFilter == null || appliedFilter == null)
                {
                    if (unknownFilter > 0)
                        unknownFilter--;
                    else if (unknownFilter == 0)
                    {
                        txtError.Text = "Unknown filter: " + world + ", " + id;
                        unknownFilter = -1;
                    }
                }
                else
                {
                    unknownFilter = UNKNOWN_FILTER_TIMEOUT;

                    if (cbxShowActive.Checked)
                    {
                        editingFilter = true;
                        cmbFilter.SelectedItem = activeFilter;
                        editingFilter = false;
                    }

                    Filter filter;
                    if (cbxForce.Enabled && cbxForce.Checked)
                        filter = (Filter)cmbFilter.SelectedItem;
                    else
                        filter = appliedFilter;

                    long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                    // Instant reset
                    if (newFilter == null)
                    {
                        newFilter = filter;
                    }
                    // Normal fade
                    else if (oldFilter == null)
                    {
                        oldFilter = newFilter;
                        newFilter = filter;
                    }
                    // Interrupt fade in progress
                    else
                    {
                        oldFilter = Filter.Lerp(oldFilter, newFilter, (float)(now - startTime) / (endTime - startTime));
                        newFilter = filter;
                    }
                    startTime = now;
                    endTime = now + FADE_TIME;
                }
            }

            if (newFilter != null)
            {
                long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                Filter filter;
                if (oldFilter == null || now > endTime)
                {
                    filter = newFilter;
                    oldFilter = null;
                }
                else
                    filter = Filter.Lerp(oldFilter, newFilter, (float)(now - startTime) / (endTime - startTime));

                if (!cbxDisable.Checked)
                {
                    dsProcess.SetBrightness(filter.BrightnessR, filter.BrightnessG, filter.BrightnessB);
                    dsProcess.SetContrast(filter.ContrastR, filter.ContrastG, filter.ContrastB);
                    dsProcess.SetSaturation(filter.Saturation);
                    dsProcess.SetHue(filter.Hue);
                    dsProcess.OverrideFilter(true);
                }
            }
        }
    }
}
