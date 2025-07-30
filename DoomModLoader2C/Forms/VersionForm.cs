// Copyright (c) 2016 - 2022, Matteo Premoli (P36 Software)
// All rights reserved.

#region LICENSE
/*
BSD 3-Clause License

Copyright (c) 2016 - 2022, Matteo Premoli (P36 Software)
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
using System.Drawing;
using System.IO;
using System.Net;
using System.Security;
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
            cmdOpenDownload.Enabled = false;
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            this.Text += " - DML v" + SharedVar.LOCAL_VERSION;
        }

        /// <summary>
        /// Return true if the application is up to date with the latest public avaible version.
        /// </summary>
        /// <returns></returns>
        public bool isLatestVersion()
        {
            string latestVersion = GetLatestVersionInfo();
            
            //If latest version == ??? it means that for any reason, we couldn't fetch the last public version, so we return true.
            if (latestVersion == "???")
                return true;
            
            return latestVersion.Equals(SharedVar.LOCAL_VERSION) ? true : false;
        }

        /// <summary>
        /// Return the latest version public avaible.<br></br>
        /// It also update all the relative properties in the VersionForm
        /// </summary>
        /// <returns></returns>
        private string GetLatestVersionInfo()
        {
            string serverVersion = "???";
            lblServerVersion.Text = serverVersion;
            cmdOpenDownload.Enabled = false;
            try
            {
                using (WebClient wc = new WebClient())
                {
                    string json = wc.DownloadString(SharedVar.UrlVersion);

                    json = json.Replace("{", "");
                    json = json.Replace("}", "");
                    json = json.Replace("\"", "");


                    string[] versionInfo = json.Split(',');

                    Dictionary<string, string> info = new Dictionary<string, string>();
                    info = versionInfo.ToKeyValueDictionary();


                    if (!info.ContainsKey("version") ||
                        !info.ContainsKey("url_changelog") ||
                        !info.ContainsKey("url_download_page"))
                    {
                        throw new FormatException("Incomplete version data from server.");
                    }

                    //This is required due to me messing up the url escaping in the json...
                    string tmpUrlChangelog = info["url_changelog"]?.Replace(@"\/", "/").Replace(@"\\", @"\");
                    string tmpUrlDownloadPage = info["url_download_page"]?.Replace(@"\/", "/").Replace(@"\\", @"\");

             

                    // Validate URLs
                    if (!IsValidHttpsUrl(tmpUrlChangelog))
                        throw new UriFormatException("Invalid 'url_changelog' URL\nPlease send an email at info@p36software.net");

                    if (!IsValidHttpsUrl(tmpUrlDownloadPage))
                        throw new UriFormatException("Invalid 'url_download_page' URL\nPlease send an email at info@p36software.net");

                    // Restrict to p36software domains
                    if (!IsTrustedHost(tmpUrlChangelog))
                        throw new SecurityException("'url_changelog' host is not from p36software.net.\nPlease send an email at info@p36software.net");

                    if (!IsTrustedHost(tmpUrlDownloadPage))
                        throw new SecurityException("'url_download_page' host is not from p36software.net\nPlease send an email at info@p36software.net");

                    serverVersion = info["version"];
                    lblServerVersion.Text = serverVersion;
                    urlDownloadChangeLog = tmpUrlChangelog;
                    urlDownloadLatestVersion = tmpUrlDownloadPage;

                    if (!string.IsNullOrEmpty(urlDownloadLatestVersion))
                    {
                        ToolTip toolTip1 = new ToolTip();
                        toolTip1.SetToolTip(cmdOpenDownload, "Open " + urlDownloadLatestVersion);
                        cmdOpenDownload.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking for update:\n" + ex.Message,
                                "Update Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                
            }

            return serverVersion;
        }

     

        //Check if url is https
        private bool IsValidHttpsUrl(string url)
        {
            Uri uriResult;
            return Uri.TryCreate(url, UriKind.Absolute, out uriResult)
                   && uriResult.Scheme == Uri.UriSchemeHttps;
        }

        //Check if url is from a p36software.net domain
        private bool IsTrustedHost(string url)
        {
            Uri uriResult;
            if (!Uri.TryCreate(url, UriKind.Absolute, out uriResult))
                return false;

            // Whitelist p36software domains
            string[] trustedHosts = new string[]
            {
                "p36software.net",
                "www.p36software.net"
            };

            foreach (string host in trustedHosts)
            {
                if (uriResult.Host.Equals(host, StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            return false;
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
            try
            {
                if (!string.IsNullOrEmpty(urlDownloadLatestVersion) && IsValidHttpsUrl(urlDownloadLatestVersion) && IsTrustedHost(urlDownloadLatestVersion))
                {
                    Process.Start(urlDownloadLatestVersion);
                }
                else
                {
                    MessageBox.Show("Download link is either empty, invalid or untrusted.\nPlease send an email at info@p36software.net", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open browser: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}