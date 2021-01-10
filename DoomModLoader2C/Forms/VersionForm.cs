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
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace DoomModLoader2
{
    /// <summary>
    /// Form used to check for new DML 2.X version, display the most updated changelog and let the user download the latest version.
    /// The check for update on DML 2.X startup can be disabled here.
    /// </summary>
    public partial class VersionForm : Form
    {
        private string urlDownloadChangeLog;
        private string urlDownloadLatestVersion;

        public VersionForm()
        {
            InitializeComponent();
            this.Text += " - DML v" + SharedVar.LOCAL_VERSION;

        }

        /// <summary>
        /// Return true if the application is up to date with the latest public avaible version.
        /// </summary>
        /// <returns></returns>
        public bool isLatestVersion()
        {
            return GetLatestVersionInfo().Equals(SharedVar.LOCAL_VERSION) ? true : false;
        }

        /// <summary>
        /// Return the latest version public avaible.<br></br>
        /// It also update all the relative properties in the VersionForm
        /// </summary>
        /// <returns></returns>
        private string GetLatestVersionInfo()
        {

            string serverVersion ="";
            lblServerVersion.Text = "???";
           

            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString(SharedVar.UrlVersion);

                json = json.Replace("{", "");
                json = json.Replace("}", "");
                json = json.Replace("\"", "");


                string[] versionInfo = json.Split(',');

                Dictionary<string, string> info = new Dictionary<string, string>();
                info = versionInfo.ToKeyValueDictionary();

                serverVersion = info["version"];
                lblServerVersion.Text = serverVersion;
                urlDownloadChangeLog = info["url_changelog"].Replace(@"\", @"").Replace(@"\", @""); ;
                urlDownloadLatestVersion = info["url_download_page"].Replace(@"\", @"").Replace(@"\", @""); ;

            }

            return serverVersion;
        }

        private void VersionForm_Load(object sender, EventArgs e)
        {
            try
            {
                lblLocalVersion.Text = SharedVar.LOCAL_VERSION;
                chkUpdate.Checked = SharedVar.CHECK_FOR_UPDATE;
                GetLatestVersionInfo();

                if (!string.IsNullOrEmpty(urlDownloadChangeLog))
                {
                    //Download the changelog and write it to txtChangeLog text.
                    WebRequest webRequest = WebRequest.Create(urlDownloadChangeLog);
                    using (var response = webRequest.GetResponse())
                    {
                        using (var content = response.GetResponseStream())
                        {
                            using (var reader = new StreamReader(content))
                            {
                                string[] changelogRaw = reader.ReadToEnd().Split('\n');
                                StringBuilder changeLog = new StringBuilder();
                                foreach (string s in changelogRaw)
                                {
                                    changeLog.AppendLine(s);
                                }
                                txtChangeLog.Text = changeLog.ToString();
                            }
                        }
                    }
                }

            }
            catch
            {
                cmdOpenDownload.Enabled = false;
                MessageBox.Show("Could not get the latest version info..." + Environment.NewLine +
                                "Please check your internet connection...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Enable/Disable the check for newer version at the application startup.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkUpdate_CheckedChanged(object sender, EventArgs e)
        {
            SharedVar.CHECK_FOR_UPDATE = chkUpdate.Checked;
        }

        /// <summary>
        /// Open the URL for latest version.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOpenDownload_Click(object sender, EventArgs e)
        {
            Process.Start(urlDownloadLatestVersion);
        }
    }
}