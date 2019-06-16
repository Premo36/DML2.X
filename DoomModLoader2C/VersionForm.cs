using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
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


        }

        public bool isLatestVersion()
        {
            return GetLatestVersionInfo().Equals(SharedVar.LOCAL_VERSION) ? true : false;
        }
        private string GetLatestVersionInfo()
        {

            string serverVersion;

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
                        urlDownloadChangeLog = versionInfo[1];//Url to download changelog
                        urlDownloadLatestVersion = versionInfo[2];
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
                //CHANGELOG
                if (urlDownloadChangeLog != string.Empty && urlDownloadChangeLog != null)
                {
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
            catch (Exception ex)
            {
                MessageBox.Show("Could not get the latest version info..." + Environment.NewLine +
                                "Please check your internet connection..." + Environment.NewLine +
                                "ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkUpdate_CheckedChanged(object sender, EventArgs e)
        {
            SharedVar.CHECK_FOR_UPDATE = chkUpdate.Checked;
        }

        private void cmdOpenDownload_Click(object sender, EventArgs e)
        {
            Process.Start(urlDownloadLatestVersion);
        }
    }
}
