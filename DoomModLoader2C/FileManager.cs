using DoomModLoader2.Entity;
using P36_UTILITIES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace DoomModLoader2
{
    public partial class FileManager : Form
    {
        private string cfgPreference;
        private string cfgPWAD;
        public FileManager(string modsPath, string preferencesPath)
        {
            InitializeComponent();
            this.Text += " - DML v" + SharedVar.LOCAL_VERSION;
            cfgPreference = preferencesPath;
            cfgPWAD = modsPath;
            chkSubfolder.Checked = SharedVar.LOAD_SUBFOLDERS;
        }

        private void FileManager_Load(object sender, EventArgs e)
        {
           
            LoadList();

        }


        private void LoadList()
        {
            lstPath.Items.Clear();
            
            string[] pathPWAD = File.ReadAllLines(cfgPWAD);

            foreach (string p in pathPWAD)
            {

                lstPath.Items.Add(p);
            }
        }
       
        private void cmdAddSingleFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {

                openFileDialog.Filter = "All files|*.wad;*.pk3;*.zip;*.pak;*.pk7;*.7z;*.grp;*.rff;*.deh|" +
                                        "Where's All the Data? (*.wad)|*.wad|" +
                                        "ZIP archive (*.pk3)|*.pk3|" +
                                        "ZIP archive (*.zip)|*.zip|" +
                                        "ZIP archive (*.pak)|*.pak|" +
                                        "7z archive (*.pk7)|*.pk7|" +
                                        "7z archive (*.7z)| *.7z|" +
                                        "Build Engine file (*.grp)|*.grp|" +
                                        "Blood file (*.rff)|*.rff|" +
                                        "Dehacked file (*.deh)|*.deh";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    AddFiles(openFileDialog.FileNames);

                }
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdRemove_Click(object sender, EventArgs e)
        {

            foreach (string p in lstPath.SelectedItems)
            {
                Storage storage = new Storage(cfgPWAD);
                storage.RemoveConfig(p, SharedVar.SHOW_DELETE_MESSAGE);
            }
            LoadList();

        }


        private void cmdAddFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog openFolderDialog = new FolderBrowserDialog())
            {
                if (openFolderDialog.ShowDialog() == DialogResult.OK)
                {
                    AddFolder(openFolderDialog.SelectedPath);
                }
            }
        }

        private void lstPath_DragDrop(object sender, DragEventArgs e)
        {
            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string p in paths)
            {
                if (File.Exists(p))
                {
                    string[] validExtensions = { ".wad", ".pk3", ".zip", ".pak", ".pk7", ".7z", ".grp", ".rff", ".deh" };
                    if (validExtensions.Contains(Path.GetExtension(p).ToLower())) { 
                        AddFiles(new string[] { p });
                    } else
                    {
                        //Messagebox?
                    }
                }
                else if (Directory.Exists(p))
                {
                    AddFolder(p);
                }
            }
        }

        private void lstPath_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        #region LOGIC
        private void AddFiles(string[] paths)
        {
            foreach (string p in paths)
            {
                Storage storage = new Storage(cfgPWAD);
                storage.UpdateConfig(p);
                LoadList();
            }
        }

        private void AddFolder(string path)
        {
            try
            {
                //string[] folders = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);


                //DialogResult dialogResult = DialogResult.No;
                //if (folders.Length > 0)
                //{
                //    dialogResult = MessageBox.Show("Would you like to load also ALL subdirectories of '" + path + "'", "DML - LOAD SUBDIRECTORIES", MessageBoxButtons.YesNo);
                //}

                Storage storage = new Storage(cfgPWAD);

                storage.UpdateConfig(path, true);
                //if (SharedVar.LOAD_SUBFOLDERS)
                //{
                //    foreach (string f in folders)
                //    {
                //        storage.UpdateConfig(f,true);
                //    }
                //}
                LoadList();
            }
            catch (Exception ex)
            {
                StringBuilder errore = new StringBuilder();
                errore.AppendLine("Something went wrong while trying to read the following folder (or a subfolder of it)");
                errore.AppendLine("Please check if your account have the permission to read from (including subfolders):");
                errore.AppendLine(@"""" + path + @"""");
                errore.AppendLine();
                errore.AppendLine("Error Message:");
                errore.AppendLine(ex.Message);

                MessageBox.Show(errore.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkSubfolder_CheckedChanged(object sender, EventArgs e)
        {
            SharedVar.LOAD_SUBFOLDERS = chkSubfolder.Checked;

            Storage storage = new Storage(cfgPreference);
            storage.DeleteValue("LOAD_SUBFOLDERS");
            storage.SaveValue("LOAD_SUBFOLDERS", chkSubfolder.Checked.ToString());

        }
    }
}
#endregion