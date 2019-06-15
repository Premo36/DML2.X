using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private static string urlDownloadChangeLog;
        public VersionForm()
        {
            InitializeComponent();
           
           
        }
       
        public bool isLatestVersion() {
            return GetLatestVersionInfo().Equals(SharedVar.LOCAL_VERSION) ? true : false;
        }
        private string GetLatestVersionInfo()
        {
              string serverVersion;
            try
            {
                //VERSION NUMBER AND CHANGELOG URL DOWNLOAD
                WebRequest webRequest = WebRequest.Create(SharedVar.UrlVersion);

                using (var response = webRequest.GetResponse())
                {
                    using (var content = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(content))
                        {
                            string[] versionInfo  = reader.ReadToEnd().Split(';');
                            lblServerVersion.Text = versionInfo[0];//Version
                            serverVersion = versionInfo[0];
                            urlDownloadChangeLog = versionInfo[1];//Url to download changelog
                        }
                    }
                }

             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

            return serverVersion;
        }

        private void VersionForm_Load(object sender, EventArgs e)
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

        private void chkUpdate_CheckedChanged(object sender, EventArgs e)
        {
            SharedVar.CHECK_FOR_UPDATE = chkUpdate.Checked;
        }
    }
}
