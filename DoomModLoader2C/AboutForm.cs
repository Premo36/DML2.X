using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
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
Copyright © P36 Software(Matteo P.)  2016 - 2019

To check if a new version is available, click on 'Check for update....'
Click on the DML logo below to open the modDB page.

E-MAIL:    p36software@mail.com
TWITTER:   @premo36"; 
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.moddb.com/mods/doom-mod-loader");
        }

       
    }
}
