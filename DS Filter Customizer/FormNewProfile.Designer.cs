namespace DS_Filter_Customizer
{
    partial class FormNewProfile
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblNamePrompt = new System.Windows.Forms.Label();
            this.rbnGlobal = new System.Windows.Forms.RadioButton();
            this.lblTypePrompt = new System.Windows.Forms.Label();
            this.rbnMultiplier = new System.Windows.Forms.RadioButton();
            this.rbnDetailed = new System.Windows.Forms.RadioButton();
            this.rbnFullControl = new System.Windows.Forms.RadioButton();
            this.lblFullControl = new System.Windows.Forms.Label();
            this.lblGlobal = new System.Windows.Forms.Label();
            this.lblMultiplier = new System.Windows.Forms.Label();
            this.lblDetailed = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(475, 153);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Location = new System.Drawing.Point(394, 153);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(12, 25);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(538, 20);
            this.txtName.TabIndex = 0;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lblNamePrompt
            // 
            this.lblNamePrompt.AutoSize = true;
            this.lblNamePrompt.Location = new System.Drawing.Point(12, 9);
            this.lblNamePrompt.Name = "lblNamePrompt";
            this.lblNamePrompt.Size = new System.Drawing.Size(160, 13);
            this.lblNamePrompt.TabIndex = 4;
            this.lblNamePrompt.Text = "Enter a name for the new profile:";
            // 
            // rbnGlobal
            // 
            this.rbnGlobal.AutoSize = true;
            this.rbnGlobal.Checked = true;
            this.rbnGlobal.Location = new System.Drawing.Point(12, 64);
            this.rbnGlobal.Name = "rbnGlobal";
            this.rbnGlobal.Size = new System.Drawing.Size(55, 17);
            this.rbnGlobal.TabIndex = 1;
            this.rbnGlobal.TabStop = true;
            this.rbnGlobal.Text = "Global";
            this.rbnGlobal.UseVisualStyleBackColor = true;
            // 
            // lblTypePrompt
            // 
            this.lblTypePrompt.AutoSize = true;
            this.lblTypePrompt.Location = new System.Drawing.Point(12, 48);
            this.lblTypePrompt.Name = "lblTypePrompt";
            this.lblTypePrompt.Size = new System.Drawing.Size(62, 13);
            this.lblTypePrompt.TabIndex = 9;
            this.lblTypePrompt.Text = "Profile type:";
            // 
            // rbnMultiplier
            // 
            this.rbnMultiplier.AutoSize = true;
            this.rbnMultiplier.Location = new System.Drawing.Point(12, 87);
            this.rbnMultiplier.Name = "rbnMultiplier";
            this.rbnMultiplier.Size = new System.Drawing.Size(66, 17);
            this.rbnMultiplier.TabIndex = 2;
            this.rbnMultiplier.Text = "Multiplier";
            this.rbnMultiplier.UseVisualStyleBackColor = true;
            // 
            // rbnDetailed
            // 
            this.rbnDetailed.AutoSize = true;
            this.rbnDetailed.Location = new System.Drawing.Point(12, 110);
            this.rbnDetailed.Name = "rbnDetailed";
            this.rbnDetailed.Size = new System.Drawing.Size(64, 17);
            this.rbnDetailed.TabIndex = 3;
            this.rbnDetailed.Text = "Detailed";
            this.rbnDetailed.UseVisualStyleBackColor = true;
            // 
            // rbnFullControl
            // 
            this.rbnFullControl.AutoSize = true;
            this.rbnFullControl.Location = new System.Drawing.Point(12, 133);
            this.rbnFullControl.Name = "rbnFullControl";
            this.rbnFullControl.Size = new System.Drawing.Size(77, 17);
            this.rbnFullControl.TabIndex = 4;
            this.rbnFullControl.Text = "Full Control";
            this.rbnFullControl.UseVisualStyleBackColor = true;
            // 
            // lblFullControl
            // 
            this.lblFullControl.AutoSize = true;
            this.lblFullControl.Location = new System.Drawing.Point(95, 135);
            this.lblFullControl.Name = "lblFullControl";
            this.lblFullControl.Size = new System.Drawing.Size(231, 13);
            this.lblFullControl.TabIndex = 13;
            this.lblFullControl.Text = "Every filter in the game is available to be edited.";
            // 
            // lblGlobal
            // 
            this.lblGlobal.AutoSize = true;
            this.lblGlobal.Location = new System.Drawing.Point(95, 66);
            this.lblGlobal.Name = "lblGlobal";
            this.lblGlobal.Size = new System.Drawing.Size(201, 13);
            this.lblGlobal.TabIndex = 14;
            this.lblGlobal.Text = "One filter will be used for the entire game.";
            // 
            // lblMultiplier
            // 
            this.lblMultiplier.AutoSize = true;
            this.lblMultiplier.Location = new System.Drawing.Point(95, 89);
            this.lblMultiplier.Name = "lblMultiplier";
            this.lblMultiplier.Size = new System.Drawing.Size(341, 13);
            this.lblMultiplier.TabIndex = 15;
            this.lblMultiplier.Text = "Define a single set of multipliers that will be applied to each vanilla filter.";
            // 
            // lblDetailed
            // 
            this.lblDetailed.AutoSize = true;
            this.lblDetailed.Location = new System.Drawing.Point(95, 112);
            this.lblDetailed.Name = "lblDetailed";
            this.lblDetailed.Size = new System.Drawing.Size(187, 13);
            this.lblDetailed.TabIndex = 16;
            this.lblDetailed.Text = "Define one or two filters for each area.";
            // 
            // FormNewProfile
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(563, 188);
            this.Controls.Add(this.lblDetailed);
            this.Controls.Add(this.lblMultiplier);
            this.Controls.Add(this.lblGlobal);
            this.Controls.Add(this.lblFullControl);
            this.Controls.Add(this.rbnFullControl);
            this.Controls.Add(this.rbnDetailed);
            this.Controls.Add(this.rbnMultiplier);
            this.Controls.Add(this.lblTypePrompt);
            this.Controls.Add(this.rbnGlobal);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblNamePrompt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormNewProfile";
            this.Text = "Create a Profile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblNamePrompt;
        private System.Windows.Forms.RadioButton rbnGlobal;
        private System.Windows.Forms.Label lblTypePrompt;
        private System.Windows.Forms.RadioButton rbnMultiplier;
        private System.Windows.Forms.RadioButton rbnDetailed;
        private System.Windows.Forms.RadioButton rbnFullControl;
        private System.Windows.Forms.Label lblFullControl;
        private System.Windows.Forms.Label lblGlobal;
        private System.Windows.Forms.Label lblMultiplier;
        private System.Windows.Forms.Label lblDetailed;
    }
}