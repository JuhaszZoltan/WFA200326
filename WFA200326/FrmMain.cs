using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA200326
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.cfIcon;

            rbKv.CheckedChanged += RbsNCbs_CheckedChanged;
            rbCsoki.CheckedChanged += RbsNCbs_CheckedChanged;
            rbTea.CheckedChanged += RbsNCbs_CheckedChanged;
            cbCukor.CheckedChanged += RbsNCbs_CheckedChanged;
            cbTej.CheckedChanged += RbsNCbs_CheckedChanged;
            cbPohar.CheckedChanged += RbsNCbs_CheckedChanged;

            rbKv.Checked = true;
        }

        private void RbsNCbs_CheckedChanged(object sender, EventArgs e)
        {
            int ar = 0;

            cbTej.Enabled = true;

            if (rbKv.Checked) ar = 100;
            else if (rbCsoki.Checked) ar = 120;
            else if (rbTea.Checked)
            {
                ar = 80;
                cbTej.Checked = false;
                cbTej.Enabled = false;
            }

            if (cbTej.Checked) ar += 10;
            if (cbCukor.Checked) ar += 20;
            if (cbPohar.Checked) ar -= 10;

            lblAr.Text = $"{ar} Ft";
        }

        private void BtnKeszit_Click(object sender, EventArgs e)
        {
            pbKeszul.Visible = true;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if(pbKeszul.Value == 100)
            {
                timer.Stop();
                lblEgs.Visible = true;
            }
            else pbKeszul.Value += 20;
        }
    }
}
