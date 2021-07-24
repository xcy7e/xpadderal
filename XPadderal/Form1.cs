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
using XPadderal;

namespace XPadderal
{
    public partial class Form1 : Form
    {
        public bool cycleProfileCheatEnabled = true;

        public ProfileOverlayForm ProfileOverlay;
        private string currentProfileName = "%profile%";

        public Form1()
        {
            InitializeComponent();

            // start xpadder
            Process xpadder = new Process();
            xpadder.StartInfo.FileName = "C:\\Program Files (x86)\\xpadder\\Xpadder [5.7].exe";
            //xpadder.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            xpadder.Start();

            timerXpadderCloseDelay.Enabled = true;

            // listen controller 
            ControllerEngine e = new ControllerEngine();
        }

        private void btn_openProfileOverlay_Click(object sender, EventArgs e)
        {
            ProfileOverlay = new ProfileOverlayForm();

            // make this nice with "profile" objects when you can get the REAL profile
            if (cycleProfileCheatEnabled)
            {
                if (this.currentProfileName == "%profile%" || this.currentProfileName == "Youtube")
                {
                    this.currentProfileName = "VLC";
                }
                else
                {
                    this.currentProfileName = "Youtube";
                }
            }
            else
            {
                if (this.currentProfileName == "%profile%")
                {
                    this.currentProfileName = "VLC";
                }
                else
                {
                    // how to get REAL profile name here?
                }
            }

            ProfileOverlay.profileName = this.currentProfileName;


            ProfileOverlay.Show();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.WindowState = FormWindowState.Minimized;
            closeXpadderWindow();
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void öffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showMainWindow();
        }

        private void timerXpadderCloseDelay_Tick(object sender, EventArgs e)
        {
            timerXpadderCloseDelay.Enabled = false;
            closeXpadderWindow();
        }

        private void closeXpadderWindow()
        {
            // send Ctrl+Alt+i
            //SendKeys.Send("^%{i}");
        }

        public void showMainWindow()
        {
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            showMainWindow();
        }
    }
}
