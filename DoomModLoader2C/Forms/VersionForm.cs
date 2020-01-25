using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace DoomModLoader2
{
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

            string serverVersion;
            lblServerVersion.Text = "???";
            //VERSION NUMBER, CHANGELOG URL AND DOWNLOAD URL
            WebRequest webRequest = WebRequest.Create(SharedVar.UrlVersion);
            using (var response = webRequest.GetResponse())
            {
                using (var content = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(content))
                    {
                        string[] versionInfo = reader.ReadToEnd().Split(';');
                        lblServerVersion.Text = versionInfo[0];//Version
                        serverVersion = versionInfo[0];
                        urlDownloadChangeLog = versionInfo[1];//Url used to download the changelog
                        urlDownloadLatestVersion = versionInfo[2]; //URL 
                    }
                }
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