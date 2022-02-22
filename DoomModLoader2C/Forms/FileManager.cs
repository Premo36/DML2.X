﻿// Copyright (c) 2016 - 2022, Matteo Premoli (P36 Software)
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
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace DoomModLoader2
{
    /// <summary>
    /// Form used to imports files/folders
    /// </summary>
    public partial class FileManager : Form
    {
        private string cfgPWAD { get; }
        public FileManager(string modsPath)
        {
            InitializeComponent();
            this.Text += " - DML v" + SharedVar.LOCAL_VERSION;
            cfgPWAD = modsPath;
        }

        private void FileManager_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        /// <summary>
        /// Load the listbox "lstPath" with all the paths written in the "PWAD.ini" file.
        /// </summary>
        private void LoadList()
        {
            lstPath.Items.Clear();

            string[] pathPWAD = File.ReadAllLines(cfgPWAD);

            foreach (string p in pathPWAD)
            {
                lstPath.Items.Add(p);
            }
        }

        /// <summary>
        /// Open a file dialog to import a single file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Remove any selected file/folder.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdRemove_Click(object sender, EventArgs e)
        {
            foreach (string p in lstPath.SelectedItems)
            {
                Storage storage = new Storage(cfgPWAD);
                storage.RemoveConfig(p, SharedVar.SHOW_DELETE_MESSAGE);
            }
            LoadList();
        }

        /// <summary>
        /// Open a folder dialog to import a single folder.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Imports in DML 2.X any file/folder dragged in the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstPath_DragDrop(object sender, DragEventArgs e)
        {
            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string p in paths)
            {
                if (File.Exists(p))
                {
                    string[] validExtensions = { ".wad", ".pk3", ".zip", ".pak", ".pk7", ".7z", ".grp", ".rff", ".deh" };
                    if (validExtensions.Contains(Path.GetExtension(p).ToLower()))
                    {
                        AddFiles(new string[] { p });
                    }
                    else
                    {
                        MessageBox.Show($"'{p}' is not a valid file");
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

        /// <summary>
        /// Update the "PWAD.ini" file by adding all the paths passed trough the "paths" param.
        /// </summary>
        /// <param name="paths"></param>
        private void AddFiles(string[] paths)
        {
            foreach (string p in paths)
            {
                Storage storage = new Storage(cfgPWAD);
                storage.UpdateConfig(p);
                LoadList();
            }
        }

        /// <summary>
        /// Update the "PWAD.ini" file by adding the folder path passed trough the "path" param.
        /// </summary>
        /// <param name="path"></param>
        private void AddFolder(string path)
        {
            try
            {
                Storage storage = new Storage(cfgPWAD);
                storage.UpdateConfig(path, true);
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
    }
}
#endregion