using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static DS_Filter_Customizer.FilterProfile;

namespace DS_Filter_Customizer
{
    public partial class FormNewProfile : Form
    {
        public FilterProfile Result = null;

        public FormNewProfile()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (rbnGlobal.Checked)
                Result = CreateFilterProfile(FilterProfileType.Global, txtName.Text);
            else if (rbnMultiplier.Checked)
                Result = CreateFilterProfile(FilterProfileType.Multiplier, txtName.Text);
            else if (rbnDetailed.Checked)
                Result = CreateFilterProfile(FilterProfileType.Detailed, txtName.Text);
            else if (rbnFullControl.Checked)
                Result = CreateFilterProfile(FilterProfileType.FullControl, txtName.Text);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.TextLength > 0 && Regex.IsMatch(txtName.Text, @"[\w\d]"))
                btnConfirm.Enabled = true;
            else
                btnConfirm.Enabled = false;
        }
    }
}
