namespace DS_Filter_Customizer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.gbxFilter = new System.Windows.Forms.GroupBox();
            this.cbxContrastSync = new System.Windows.Forms.CheckBox();
            this.cbxBrightnessSync = new System.Windows.Forms.CheckBox();
            this.lblHueNote = new System.Windows.Forms.Label();
            this.lblBlue = new System.Windows.Forms.Label();
            this.lblGreen = new System.Windows.Forms.Label();
            this.lblRed = new System.Windows.Forms.Label();
            this.lblHue = new System.Windows.Forms.Label();
            this.lblSaturation = new System.Windows.Forms.Label();
            this.lblContrast = new System.Windows.Forms.Label();
            this.lblBrightness = new System.Windows.Forms.Label();
            this.nudHue = new System.Windows.Forms.NumericUpDown();
            this.nudSaturation = new System.Windows.Forms.NumericUpDown();
            this.nudContrastB = new System.Windows.Forms.NumericUpDown();
            this.nudContrastG = new System.Windows.Forms.NumericUpDown();
            this.nudContrastR = new System.Windows.Forms.NumericUpDown();
            this.nudBrightnessB = new System.Windows.Forms.NumericUpDown();
            this.nudBrightnessG = new System.Windows.Forms.NumericUpDown();
            this.nudBrightnessR = new System.Windows.Forms.NumericUpDown();
            this.lblProcess = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblProcessValue = new System.Windows.Forms.Label();
            this.lblVersionValue = new System.Windows.Forms.Label();
            this.lblWorld = new System.Windows.Forms.Label();
            this.lblFilterID = new System.Windows.Forms.Label();
            this.lblWorldValue = new System.Windows.Forms.Label();
            this.lblFilterIDValue = new System.Windows.Forms.Label();
            this.lblProfile = new System.Windows.Forms.Label();
            this.cmbProfile = new System.Windows.Forms.ComboBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnClone = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.cbxForce = new System.Windows.Forms.CheckBox();
            this.cbxDisable = new System.Windows.Forms.CheckBox();
            this.cbxShowActive = new System.Windows.Forms.CheckBox();
            this.txtError = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.llbNewVersion = new System.Windows.Forms.LinkLabel();
            this.lblCheckVersion = new System.Windows.Forms.Label();
            this.gbxFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSaturation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudContrastB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudContrastG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudContrastR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrightnessB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrightnessG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrightnessR)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxFilter
            // 
            this.gbxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxFilter.AutoSize = true;
            this.gbxFilter.Controls.Add(this.cbxContrastSync);
            this.gbxFilter.Controls.Add(this.cbxBrightnessSync);
            this.gbxFilter.Controls.Add(this.lblHueNote);
            this.gbxFilter.Controls.Add(this.lblBlue);
            this.gbxFilter.Controls.Add(this.lblGreen);
            this.gbxFilter.Controls.Add(this.lblRed);
            this.gbxFilter.Controls.Add(this.lblHue);
            this.gbxFilter.Controls.Add(this.lblSaturation);
            this.gbxFilter.Controls.Add(this.lblContrast);
            this.gbxFilter.Controls.Add(this.lblBrightness);
            this.gbxFilter.Controls.Add(this.nudHue);
            this.gbxFilter.Controls.Add(this.nudSaturation);
            this.gbxFilter.Controls.Add(this.nudContrastB);
            this.gbxFilter.Controls.Add(this.nudContrastG);
            this.gbxFilter.Controls.Add(this.nudContrastR);
            this.gbxFilter.Controls.Add(this.nudBrightnessB);
            this.gbxFilter.Controls.Add(this.nudBrightnessG);
            this.gbxFilter.Controls.Add(this.nudBrightnessR);
            this.gbxFilter.Location = new System.Drawing.Point(12, 160);
            this.gbxFilter.Name = "gbxFilter";
            this.gbxFilter.Size = new System.Drawing.Size(538, 175);
            this.gbxFilter.TabIndex = 0;
            this.gbxFilter.TabStop = false;
            // 
            // cbxContrastSync
            // 
            this.cbxContrastSync.AutoSize = true;
            this.cbxContrastSync.Location = new System.Drawing.Point(446, 60);
            this.cbxContrastSync.Name = "cbxContrastSync";
            this.cbxContrastSync.Size = new System.Drawing.Size(84, 17);
            this.cbxContrastSync.TabIndex = 17;
            this.cbxContrastSync.Text = "Synchronize";
            this.cbxContrastSync.UseVisualStyleBackColor = true;
            this.cbxContrastSync.CheckedChanged += new System.EventHandler(this.cbxContrastSync_CheckedChanged);
            // 
            // cbxBrightnessSync
            // 
            this.cbxBrightnessSync.AutoSize = true;
            this.cbxBrightnessSync.Location = new System.Drawing.Point(446, 35);
            this.cbxBrightnessSync.Name = "cbxBrightnessSync";
            this.cbxBrightnessSync.Size = new System.Drawing.Size(84, 17);
            this.cbxBrightnessSync.TabIndex = 16;
            this.cbxBrightnessSync.Text = "Synchronize";
            this.cbxBrightnessSync.UseVisualStyleBackColor = true;
            this.cbxBrightnessSync.CheckedChanged += new System.EventHandler(this.cbxBrightnessSync_CheckedChanged);
            // 
            // lblHueNote
            // 
            this.lblHueNote.Location = new System.Drawing.Point(194, 110);
            this.lblHueNote.Name = "lblHueNote";
            this.lblHueNote.Size = new System.Drawing.Size(336, 46);
            this.lblHueNote.TabIndex = 15;
            this.lblHueNote.Text = "Note: because hue is always 0 in vanilla, this option is simply an override in mu" +
    "ltiplier mode.";
            this.lblHueNote.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblBlue
            // 
            this.lblBlue.AutoSize = true;
            this.lblBlue.Location = new System.Drawing.Point(317, 16);
            this.lblBlue.Name = "lblBlue";
            this.lblBlue.Size = new System.Drawing.Size(28, 13);
            this.lblBlue.TabIndex = 14;
            this.lblBlue.Text = "Blue";
            // 
            // lblGreen
            // 
            this.lblGreen.AutoSize = true;
            this.lblGreen.Location = new System.Drawing.Point(191, 16);
            this.lblGreen.Name = "lblGreen";
            this.lblGreen.Size = new System.Drawing.Size(36, 13);
            this.lblGreen.TabIndex = 13;
            this.lblGreen.Text = "Green";
            // 
            // lblRed
            // 
            this.lblRed.AutoSize = true;
            this.lblRed.Location = new System.Drawing.Point(65, 16);
            this.lblRed.Name = "lblRed";
            this.lblRed.Size = new System.Drawing.Size(27, 13);
            this.lblRed.TabIndex = 12;
            this.lblRed.Text = "Red";
            // 
            // lblHue
            // 
            this.lblHue.AutoSize = true;
            this.lblHue.Location = new System.Drawing.Point(35, 138);
            this.lblHue.Name = "lblHue";
            this.lblHue.Size = new System.Drawing.Size(27, 13);
            this.lblHue.TabIndex = 11;
            this.lblHue.Text = "Hue";
            // 
            // lblSaturation
            // 
            this.lblSaturation.AutoSize = true;
            this.lblSaturation.Location = new System.Drawing.Point(7, 112);
            this.lblSaturation.Name = "lblSaturation";
            this.lblSaturation.Size = new System.Drawing.Size(55, 13);
            this.lblSaturation.TabIndex = 10;
            this.lblSaturation.Text = "Saturation";
            // 
            // lblContrast
            // 
            this.lblContrast.AutoSize = true;
            this.lblContrast.Location = new System.Drawing.Point(16, 60);
            this.lblContrast.Name = "lblContrast";
            this.lblContrast.Size = new System.Drawing.Size(46, 13);
            this.lblContrast.TabIndex = 9;
            this.lblContrast.Text = "Contrast";
            // 
            // lblBrightness
            // 
            this.lblBrightness.AutoSize = true;
            this.lblBrightness.Location = new System.Drawing.Point(6, 34);
            this.lblBrightness.Name = "lblBrightness";
            this.lblBrightness.Size = new System.Drawing.Size(56, 13);
            this.lblBrightness.TabIndex = 8;
            this.lblBrightness.Text = "Brightness";
            // 
            // nudHue
            // 
            this.nudHue.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudHue.Location = new System.Drawing.Point(68, 136);
            this.nudHue.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudHue.Name = "nudHue";
            this.nudHue.Size = new System.Drawing.Size(120, 20);
            this.nudHue.TabIndex = 7;
            this.nudHue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudHue.ValueChanged += new System.EventHandler(this.filterEdited);
            // 
            // nudSaturation
            // 
            this.nudSaturation.DecimalPlaces = 2;
            this.nudSaturation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudSaturation.Location = new System.Drawing.Point(68, 110);
            this.nudSaturation.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudSaturation.Name = "nudSaturation";
            this.nudSaturation.Size = new System.Drawing.Size(120, 20);
            this.nudSaturation.TabIndex = 6;
            this.nudSaturation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudSaturation.ValueChanged += new System.EventHandler(this.filterEdited);
            // 
            // nudContrastB
            // 
            this.nudContrastB.DecimalPlaces = 2;
            this.nudContrastB.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudContrastB.Location = new System.Drawing.Point(320, 58);
            this.nudContrastB.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudContrastB.Name = "nudContrastB";
            this.nudContrastB.Size = new System.Drawing.Size(120, 20);
            this.nudContrastB.TabIndex = 5;
            this.nudContrastB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudContrastB.ValueChanged += new System.EventHandler(this.filterEdited);
            // 
            // nudContrastG
            // 
            this.nudContrastG.DecimalPlaces = 2;
            this.nudContrastG.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudContrastG.Location = new System.Drawing.Point(194, 58);
            this.nudContrastG.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudContrastG.Name = "nudContrastG";
            this.nudContrastG.Size = new System.Drawing.Size(120, 20);
            this.nudContrastG.TabIndex = 4;
            this.nudContrastG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudContrastG.ValueChanged += new System.EventHandler(this.filterEdited);
            // 
            // nudContrastR
            // 
            this.nudContrastR.DecimalPlaces = 2;
            this.nudContrastR.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudContrastR.Location = new System.Drawing.Point(68, 58);
            this.nudContrastR.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudContrastR.Name = "nudContrastR";
            this.nudContrastR.Size = new System.Drawing.Size(120, 20);
            this.nudContrastR.TabIndex = 3;
            this.nudContrastR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudContrastR.ValueChanged += new System.EventHandler(this.filterEdited);
            // 
            // nudBrightnessB
            // 
            this.nudBrightnessB.DecimalPlaces = 2;
            this.nudBrightnessB.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudBrightnessB.Location = new System.Drawing.Point(320, 32);
            this.nudBrightnessB.Name = "nudBrightnessB";
            this.nudBrightnessB.Size = new System.Drawing.Size(120, 20);
            this.nudBrightnessB.TabIndex = 2;
            this.nudBrightnessB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudBrightnessB.ValueChanged += new System.EventHandler(this.filterEdited);
            // 
            // nudBrightnessG
            // 
            this.nudBrightnessG.DecimalPlaces = 2;
            this.nudBrightnessG.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudBrightnessG.Location = new System.Drawing.Point(194, 32);
            this.nudBrightnessG.Name = "nudBrightnessG";
            this.nudBrightnessG.Size = new System.Drawing.Size(120, 20);
            this.nudBrightnessG.TabIndex = 1;
            this.nudBrightnessG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudBrightnessG.ValueChanged += new System.EventHandler(this.filterEdited);
            // 
            // nudBrightnessR
            // 
            this.nudBrightnessR.DecimalPlaces = 2;
            this.nudBrightnessR.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudBrightnessR.Location = new System.Drawing.Point(68, 32);
            this.nudBrightnessR.Name = "nudBrightnessR";
            this.nudBrightnessR.Size = new System.Drawing.Size(120, 20);
            this.nudBrightnessR.TabIndex = 0;
            this.nudBrightnessR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudBrightnessR.ValueChanged += new System.EventHandler(this.filterEdited);
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.Location = new System.Drawing.Point(12, 9);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(48, 13);
            this.lblProcess.TabIndex = 1;
            this.lblProcess.Text = "Process:";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(12, 22);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(45, 13);
            this.lblVersion.TabIndex = 2;
            this.lblVersion.Text = "Version:";
            // 
            // lblProcessValue
            // 
            this.lblProcessValue.AutoSize = true;
            this.lblProcessValue.Location = new System.Drawing.Point(66, 9);
            this.lblProcessValue.Name = "lblProcessValue";
            this.lblProcessValue.Size = new System.Drawing.Size(33, 13);
            this.lblProcessValue.TabIndex = 4;
            this.lblProcessValue.Text = "None";
            // 
            // lblVersionValue
            // 
            this.lblVersionValue.AutoSize = true;
            this.lblVersionValue.Location = new System.Drawing.Point(66, 22);
            this.lblVersionValue.Name = "lblVersionValue";
            this.lblVersionValue.Size = new System.Drawing.Size(33, 13);
            this.lblVersionValue.TabIndex = 5;
            this.lblVersionValue.Text = "None";
            // 
            // lblWorld
            // 
            this.lblWorld.AutoSize = true;
            this.lblWorld.Location = new System.Drawing.Point(133, 9);
            this.lblWorld.Name = "lblWorld";
            this.lblWorld.Size = new System.Drawing.Size(38, 13);
            this.lblWorld.TabIndex = 7;
            this.lblWorld.Text = "World:";
            // 
            // lblFilterID
            // 
            this.lblFilterID.AutoSize = true;
            this.lblFilterID.Location = new System.Drawing.Point(139, 22);
            this.lblFilterID.Name = "lblFilterID";
            this.lblFilterID.Size = new System.Drawing.Size(32, 13);
            this.lblFilterID.TabIndex = 9;
            this.lblFilterID.Text = "Filter:";
            // 
            // lblWorldValue
            // 
            this.lblWorldValue.AutoSize = true;
            this.lblWorldValue.Location = new System.Drawing.Point(177, 9);
            this.lblWorldValue.Name = "lblWorldValue";
            this.lblWorldValue.Size = new System.Drawing.Size(33, 13);
            this.lblWorldValue.TabIndex = 10;
            this.lblWorldValue.Text = "None";
            // 
            // lblFilterIDValue
            // 
            this.lblFilterIDValue.AutoSize = true;
            this.lblFilterIDValue.Location = new System.Drawing.Point(177, 22);
            this.lblFilterIDValue.Name = "lblFilterIDValue";
            this.lblFilterIDValue.Size = new System.Drawing.Size(33, 13);
            this.lblFilterIDValue.TabIndex = 12;
            this.lblFilterIDValue.Text = "None";
            // 
            // lblProfile
            // 
            this.lblProfile.AutoSize = true;
            this.lblProfile.Location = new System.Drawing.Point(12, 48);
            this.lblProfile.Name = "lblProfile";
            this.lblProfile.Size = new System.Drawing.Size(36, 13);
            this.lblProfile.TabIndex = 13;
            this.lblProfile.Text = "Profile";
            // 
            // cmbProfile
            // 
            this.cmbProfile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfile.FormattingEnabled = true;
            this.cmbProfile.Location = new System.Drawing.Point(12, 64);
            this.cmbProfile.Name = "cmbProfile";
            this.cmbProfile.Size = new System.Drawing.Size(538, 21);
            this.cmbProfile.TabIndex = 14;
            this.cmbProfile.SelectedIndexChanged += new System.EventHandler(this.cmbProfile_SelectedIndexChanged);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(232, 91);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 15;
            this.btnNew.Text = "New";
            this.toolTip1.SetToolTip(this.btnNew, "Create a new profile with default values");
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnClone
            // 
            this.btnClone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClone.Location = new System.Drawing.Point(394, 91);
            this.btnClone.Name = "btnClone";
            this.btnClone.Size = new System.Drawing.Size(75, 23);
            this.btnClone.TabIndex = 16;
            this.btnClone.Text = "Clone";
            this.toolTip1.SetToolTip(this.btnClone, "Create a copy of the current profile");
            this.btnClone.UseVisualStyleBackColor = true;
            this.btnClone.Click += new System.EventHandler(this.btnClone_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(475, 91);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "Delete";
            this.toolTip1.SetToolTip(this.btnDelete, "Delete the current profile");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cmbFilter
            // 
            this.cmbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Location = new System.Drawing.Point(12, 133);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(538, 21);
            this.cmbFilter.TabIndex = 18;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(12, 117);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(29, 13);
            this.lblFilter.TabIndex = 19;
            this.lblFilter.Text = "Filter";
            // 
            // cbxForce
            // 
            this.cbxForce.AutoSize = true;
            this.cbxForce.Location = new System.Drawing.Point(255, 341);
            this.cbxForce.Name = "cbxForce";
            this.cbxForce.Size = new System.Drawing.Size(118, 17);
            this.cbxForce.TabIndex = 20;
            this.cbxForce.Text = "Force selected filter";
            this.cbxForce.UseVisualStyleBackColor = true;
            this.cbxForce.CheckedChanged += new System.EventHandler(this.cbxForce_CheckedChanged);
            // 
            // cbxDisable
            // 
            this.cbxDisable.AutoSize = true;
            this.cbxDisable.Location = new System.Drawing.Point(12, 341);
            this.cbxDisable.Name = "cbxDisable";
            this.cbxDisable.Size = new System.Drawing.Size(124, 17);
            this.cbxDisable.TabIndex = 21;
            this.cbxDisable.Text = "Disable filter override";
            this.cbxDisable.UseVisualStyleBackColor = true;
            this.cbxDisable.CheckedChanged += new System.EventHandler(this.cbxDisable_CheckedChanged);
            // 
            // cbxShowActive
            // 
            this.cbxShowActive.AutoSize = true;
            this.cbxShowActive.Checked = true;
            this.cbxShowActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxShowActive.Location = new System.Drawing.Point(142, 341);
            this.cbxShowActive.Name = "cbxShowActive";
            this.cbxShowActive.Size = new System.Drawing.Size(107, 17);
            this.cbxShowActive.TabIndex = 22;
            this.cbxShowActive.Text = "Show active filter";
            this.cbxShowActive.UseVisualStyleBackColor = true;
            this.cbxShowActive.CheckedChanged += new System.EventHandler(this.cbxShowActive_CheckedChanged);
            // 
            // txtError
            // 
            this.txtError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtError.BackColor = System.Drawing.SystemColors.Control;
            this.txtError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtError.ForeColor = System.Drawing.Color.Red;
            this.txtError.Location = new System.Drawing.Point(12, 364);
            this.txtError.Name = "txtError";
            this.txtError.ReadOnly = true;
            this.txtError.Size = new System.Drawing.Size(538, 20);
            this.txtError.TabIndex = 23;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(313, 91);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Save";
            this.toolTip1.SetToolTip(this.btnSave, "Save changes to the current profile");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Enabled = true;
            this.tmrUpdate.Interval = 33;
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // llbNewVersion
            // 
            this.llbNewVersion.Location = new System.Drawing.Point(304, 9);
            this.llbNewVersion.Name = "llbNewVersion";
            this.llbNewVersion.Size = new System.Drawing.Size(246, 23);
            this.llbNewVersion.TabIndex = 26;
            this.llbNewVersion.TabStop = true;
            this.llbNewVersion.Text = "New version available!";
            this.llbNewVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.llbNewVersion.Visible = false;
            this.llbNewVersion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbNewVersion_LinkClicked);
            // 
            // llbCheckVersion
            // 
            this.lblCheckVersion.Location = new System.Drawing.Point(301, 9);
            this.lblCheckVersion.Name = "llbCheckVersion";
            this.lblCheckVersion.Size = new System.Drawing.Size(249, 23);
            this.lblCheckVersion.TabIndex = 25;
            this.lblCheckVersion.Text = "Checking for new version...";
            this.lblCheckVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 397);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtError);
            this.Controls.Add(this.cbxShowActive);
            this.Controls.Add(this.cbxDisable);
            this.Controls.Add(this.cbxForce);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.cmbFilter);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClone);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.cmbProfile);
            this.Controls.Add(this.lblProfile);
            this.Controls.Add(this.lblFilterIDValue);
            this.Controls.Add(this.lblWorldValue);
            this.Controls.Add(this.lblFilterID);
            this.Controls.Add(this.lblWorld);
            this.Controls.Add(this.lblVersionValue);
            this.Controls.Add(this.lblProcessValue);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblProcess);
            this.Controls.Add(this.gbxFilter);
            this.Controls.Add(this.llbNewVersion);
            this.Controls.Add(this.lblCheckVersion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "DS Filter Customizer <version>";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gbxFilter.ResumeLayout(false);
            this.gbxFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSaturation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudContrastB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudContrastG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudContrastR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrightnessB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrightnessG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrightnessR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxFilter;
        private System.Windows.Forms.Label lblBlue;
        private System.Windows.Forms.Label lblGreen;
        private System.Windows.Forms.Label lblRed;
        private System.Windows.Forms.Label lblHue;
        private System.Windows.Forms.Label lblSaturation;
        private System.Windows.Forms.Label lblContrast;
        private System.Windows.Forms.Label lblBrightness;
        private System.Windows.Forms.NumericUpDown nudHue;
        private System.Windows.Forms.NumericUpDown nudSaturation;
        private System.Windows.Forms.NumericUpDown nudContrastB;
        private System.Windows.Forms.NumericUpDown nudContrastG;
        private System.Windows.Forms.NumericUpDown nudContrastR;
        private System.Windows.Forms.NumericUpDown nudBrightnessB;
        private System.Windows.Forms.NumericUpDown nudBrightnessG;
        private System.Windows.Forms.NumericUpDown nudBrightnessR;
        private System.Windows.Forms.Label lblProcess;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblProcessValue;
        private System.Windows.Forms.Label lblVersionValue;
        private System.Windows.Forms.Label lblWorld;
        private System.Windows.Forms.Label lblFilterID;
        private System.Windows.Forms.Label lblWorldValue;
        private System.Windows.Forms.Label lblFilterIDValue;
        private System.Windows.Forms.Label lblHueNote;
        private System.Windows.Forms.Label lblProfile;
        private System.Windows.Forms.ComboBox cmbProfile;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnClone;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.CheckBox cbxForce;
        private System.Windows.Forms.CheckBox cbxDisable;
        private System.Windows.Forms.CheckBox cbxShowActive;
        private System.Windows.Forms.TextBox txtError;
        private System.Windows.Forms.CheckBox cbxContrastSync;
        private System.Windows.Forms.CheckBox cbxBrightnessSync;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Timer tmrUpdate;
        private System.Windows.Forms.LinkLabel llbNewVersion;
        private System.Windows.Forms.Label lblCheckVersion;
    }
}

