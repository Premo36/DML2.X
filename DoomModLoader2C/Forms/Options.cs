using System;
using System.Windows.Forms;

namespace DoomModLoader2
{
    public partial class Options : Form
    {
        private string cfgPath;
        /// <summary>
        /// Initialize the options menu ("preferences...").
        /// </summary>
        /// <param name="cfgPath"></param>
        public Options(string cfgPath)
        {
            InitializeComponent();
            chk_SHOW_END_MESSAGE.Checked = SharedVar.SHOW_END_MESSAGE;
            chk_SHOW_OVERWRITE_MESSAGE.Checked = SharedVar.SHOW_OVERWRITE_MESSAGE;
            chk_SHOW_SUCCESS_MESSAGE.Checked = SharedVar.SHOW_SUCCESS_MESSAGE;
            chk_SHOW_DELETE_MESSAGE.Checked = SharedVar.SHOW_DELETE_MESSAGE;
            chk_USE_ADVANCED_SELECTION_MODE.Checked = SharedVar.USE_ADVANCED_SELECTION_MODE;

            this.Text += " - DML v" + SharedVar.LOCAL_VERSION;
            this.cfgPath = cfgPath;
        }

        /// <summary>
        /// Save the options and close the dialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSaveOptions_Click(object sender, EventArgs e)
        {
            SharedVar.SHOW_END_MESSAGE = chk_SHOW_END_MESSAGE.Checked;
            SharedVar.SHOW_OVERWRITE_MESSAGE = chk_SHOW_OVERWRITE_MESSAGE.Checked;
            SharedVar.SHOW_SUCCESS_MESSAGE = chk_SHOW_SUCCESS_MESSAGE.Checked;
            SharedVar.SHOW_DELETE_MESSAGE = chk_SHOW_DELETE_MESSAGE.Checked;
            SharedVar.USE_ADVANCED_SELECTION_MODE = chk_USE_ADVANCED_SELECTION_MODE.Checked;

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

        /// <summary>
        /// Close the option dialog without saving.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdQuitOptions_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
