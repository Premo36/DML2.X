using P36_UTILITIES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DoomModLoader2
{
    public partial class Options : Form
    {
        private string cfgPath;

        public Options(string cfgPath)
        {
            InitializeComponent();
            chk_SHOW_END_MESSAGE.Checked = SharedVar.SHOW_END_MESSAGE;
            chk_SHOW_OVERWRITE_MESSAGE.Checked = SharedVar.SHOW_OVERWRITE_MESSAGE;
            chk_SHOW_SUCCESS_MESSAGE.Checked = SharedVar.SHOW_SUCCESS_MESSAGE;
            chk_SHOW_DELETE_MESSAGE.Checked = SharedVar.SHOW_DELETE_MESSAGE;
            this.Text += " - DML v" + SharedVar.LOCAL_VERSION;
            this.cfgPath = cfgPath;
        }


        private void cmdSaveOptions_Click(object sender, EventArgs e)
        {
            SharedVar.SHOW_END_MESSAGE = chk_SHOW_END_MESSAGE.Checked;
            SharedVar.SHOW_OVERWRITE_MESSAGE = chk_SHOW_OVERWRITE_MESSAGE.Checked;
            SharedVar.SHOW_SUCCESS_MESSAGE = chk_SHOW_SUCCESS_MESSAGE.Checked;
            SharedVar.SHOW_DELETE_MESSAGE = chk_SHOW_DELETE_MESSAGE.Checked;

            Storage storage = new Storage(cfgPath);

            storage.DeleteValue("SHOW_END_MESSAGE");
            storage.SaveValue("SHOW_END_MESSAGE", SharedVar.SHOW_END_MESSAGE.ToString());

            storage.DeleteValue("SHOW_OVERWRITE_MESSAGE");
            storage.SaveValue("SHOW_OVERWRITE_MESSAGE", SharedVar.SHOW_OVERWRITE_MESSAGE.ToString());

            storage.DeleteValue("SHOW_SUCCESS_MESSAGE");
            storage.SaveValue("SHOW_SUCCESS_MESSAGE", SharedVar.SHOW_SUCCESS_MESSAGE.ToString());

            storage.DeleteValue("SHOW_DELETE_MESSAGE");
            storage.SaveValue("SHOW_DELETE_MESSAGE", SharedVar.SHOW_DELETE_MESSAGE.ToString());
            this.Close();
        }

        private void cmdQuitOptions_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
