// Copyright (c) 2016 - 2021, Matteo Premoli (P36 Software)
// All rights reserved.

#region LICENSE
/*
BSD 3-Clause License

Copyright (c) 2016 - 2020, Matteo Premoli (P36 Software)
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:

1. Redistributions of source code must retain the above copyright notice, this
   list of conditions and the following disclaimer.

2. Redistributions in binary form must reproduce the above copyright notice,
   this list of conditions and the following disclaimer in the documentation
   and/or other materials provided with the distribution.

3. Neither the name of the copyright holder nor the names of its
   contributors may be used to endorse or promote products derived from
   this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
#endregion

using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace DoomModLoader2
{
    /// <summary>
    /// Form with info about DML 2.X, contacts information, link to P36 Software website and DML moddb page.
    /// </summary>
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

Want to play an endless run and gun game for Android? 
Click on the Tank icon for more info about Tank Rider, my new free Android game.

Click on the DML 2.X logo to visit the modDB page.
Click on the P36 Software logo to visit the p36software.net website.
Click on the Twitter logo to visit the @p36software twitter

EMAIL:    support@p36software.net (for reporting bugs/give feedback/ask for technical help...)
EMAIL:    info@p36software.net (for everything else)
TWITTER:  @p36software / @premo36"
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Process.Start("https://twitter.com/p36software");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Process.Start("https://p36software.net/projects/TankRider");
        }
    }
}
