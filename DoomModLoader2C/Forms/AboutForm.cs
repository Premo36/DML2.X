using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace DoomModLoader2
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            this.Text += " - DML v" + SharedVar.LOCAL_VERSION;
            txtInfo.Text = 
$@"Doom Mod Loader v{SharedVar.LOCAL_VERSION}
Copyright © P36 Software(Matteo P.)  2016 - {DateTime.Today.Year}

To check if a new version is available, click on 'Check for update....'
Click on the DML logo below to open the modDB page.
Click on the P36 Software logo to open the p36software.net website.

EMAIL:    info@p36software.net
TWITTER:  @premo36"
; 
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.moddb.com/mods/doom-mod-loader");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("https://p36software.net");
        }
    }
}
