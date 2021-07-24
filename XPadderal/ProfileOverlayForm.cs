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

namespace XPadderal
{
    public partial class ProfileOverlayForm : Form
    {
        #region settings
        public int screenpadding_sides = 15;
        public int screenpadding_top = 15;
        public int overlay_timeout_ms = 2000;
        #endregion 

        public string profileName = "%profile%";

        public ProfileOverlayForm()
        {
            InitializeComponent();
        }

        private void ProfileOverlayForm_Load(object sender, EventArgs e)
        {
            int x = Screen.FromControl(this).Bounds.Width - this.Size.Width - this.screenpadding_sides;
            this.Location = new Point(x, this.screenpadding_top);
            lbl_profileName.Text = this.profileName;

            Timer t = new Timer();
            t.Interval = this.overlay_timeout_ms;
            t.Tick += new EventHandler(ProfileOverlayForm_Hide);
            t.Start();
        }

        private void ProfileOverlayForm_Hide(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProfileOverlayForm_Click(object sender, EventArgs e)
        {
            // open xpadder window
            Process xpadderProc = new Process();
            xpadderProc.StartInfo.FileName = "C:\\Program Files (x86)\\xpadder\\Xpadder [5.7].exe";
            xpadderProc.Start();
            xpadderProc.WaitForExit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
