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
        private string cfgPWAD;
        public FileManager(string path)
        {
            InitializeComponent();
            cfgPWAD = path;
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

                openFileDialog.Filter = "Where's All the Data? (*.wad)|*.wad|" +
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

                    string[] path = openFileDialog.FileNames;
                    foreach (string p in path)
                    {
                        Storage storage = new Storage(cfgPWAD);
                        storage.UpdateConfig(p);
                        LoadList();
                    }
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
                storage.RemoveConfig(p);
            }
            LoadList();

        }

        //TODO: add try catch
        private void cmdAddFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog openFolderDialog = new FolderBrowserDialog())
            {
                if (openFolderDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] folders = Directory.GetDirectories(openFolderDialog.SelectedPath, "*", SearchOption.AllDirectories);


                    DialogResult dialogResult = DialogResult.No;
                    if(folders.Length > 0)
                    {
                        dialogResult = MessageBox.Show("Would you like to load also ALL subdirectories of '" + openFolderDialog.SelectedPath + "'","DML - LOAD SUBDIRECTORIES", MessageBoxButtons.YesNo);
                    }

                    Storage storage = new Storage(cfgPWAD);

                    storage.UpdateConfig(openFolderDialog.SelectedPath);
                    if (dialogResult == DialogResult.Yes)
                    {
                        foreach(string f in folders)
                        {
                            storage.UpdateConfig(f);
                        }
                    }
                    LoadList();
                }
            }
        }
    }
}
