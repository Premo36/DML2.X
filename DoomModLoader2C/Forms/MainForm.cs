// Copyright (c) 2016 - 2020, Matteo Premoli (P36 Software)
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

using DoomModLoader2.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace DoomModLoader2
{
    /// <summary>
    /// Main form of DML 2.X, most of the software logic it's here.
    /// </summary>
    public partial class MainForm : Form
    {

        private string dmlConfigPath;
        private string userFiles_path;

        private string IWADfolderPath;
        private string PWADfolderPath;
        private string PORTfolderPath;
        private string PORT_CONFIGfolderPath;

        private string cfgPreference;
        private string cfgIWAD;
        private string cfgPWAD;
        private string cfgPORT;
        private string cfgPORT_CONFIG;
        private string foldPRESET;

        private readonly string[] validWadExtensions = { ".wad",
                                                         ".pk3",
                                                         ".zip",
                                                         ".pak",
                                                         ".pk7",
                                                         ".grp",
                                                         ".rff",
                                                         ".deh" };

        List<string> saveWithPreset = new List<string>();

        private List<PathName> cachedPWADs;

        private List<PathName> _selectedItems;
        private List<PathName> SelectedItems
        {
            get { return _selectedItems; }

            set
            {
                if (_selectedItems == null)
                    _selectedItems = new List<PathName>();
                _selectedItems.AddRange(value.Where(X => !_selectedItems.Any(Y => X.name == Y.name)).ToList());
            }
        }

        #region FORM 
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text += " v" + SharedVar.LOCAL_VERSION;
            SelectedItems = new List<PathName>();
            InitializeConfiguration();

            txtMap_TextChanged(null, null);
            chkCustomConfiguration_CheckedChanged(null, null);
            cmbSkill.SelectedIndex = 3;
            string[] filterValues = { "ALL" };
            filterValues = filterValues.Concat(validWadExtensions).ToArray();
            cmbFileFilter.DataSource = filterValues;
            cmbOrder.SelectedIndex = 0;
            LoadResources();
            if (SharedVar.CHECK_FOR_UPDATE)
            {
                CheckForUpdate(true);
            }
        }

        /// <summary>
        /// "PLAY" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdPlay_Click(object sender, EventArgs e)
        {
            bool err = false;
            if (cmbSourcePort.SelectedItem == null)
            {
                err = true;
                MessageBox.Show("MISSING SOURCE PORT!" + Environment.NewLine + "Please add one...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (cmbIWAD.SelectedItem == null)
            {
                err = true;
                MessageBox.Show("MISSING IWAD!" + Environment.NewLine + "Please add one...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!err)
            {
                UpdateSelectedPWADitems(mode.SAVE);

                var items = SelectedItems;
                string param = GetParameters();

                //If the user select less than 2 mods it's useless display the mod order dialog
                if (items != null && items.Count > 1)
                {

                    List<PathName> pwads = new List<PathName>();
                    KeyValuePair<int, string> renderer = new KeyValuePair<int, string>(cmb_vidrender.SelectedIndex, cmb_vidrender.Text);

                    PathName config = (PathName)(chkCustomConfiguration.Checked == true ? cmbPortConfig.SelectedItem : null);

                    using (FormMod formMod = new FormMod(foldPRESET, (PathName)cmbIWAD.SelectedItem, renderer, config, saveWithPreset, txtCommandLine.Text, param))
                    {

                        foreach (PathName p in items)
                            pwads.Add(p);

                        formMod.pwads = pwads;
                        formMod.sourcePort = (PathName)cmbSourcePort.SelectedItem;
                        PathName selectedPreset = (PathName)cmbPreset.SelectedItem;

                        if (!selectedPreset.name.Trim().Equals("-"))
                            formMod.presetName = selectedPreset.name;

                        formMod.ShowDialog();

                        LoadPresetList();
                        if (formMod.presetName != null)
                        {
                            PathName pn = cmbPreset.Items.Cast<PathName>().Where(P => P.name == formMod.presetName).FirstOrDefault();
                            if (pn != null)
                                cmbPreset.SelectedItem = pn;
                        }
                    }

                }
                else
                {
                    if (items != null && items.Count == 1)
                        param += " -file \"" + items.Cast<PathName>().FirstOrDefault().path + "\"";

                    StartGame(param);
                }
            }
        }

        private void chkNoMonster_CheckedChanged(object sender, EventArgs e)
        {
            chkFast.Enabled = !chkNoMonster.Checked;
            chkRespawn.Enabled = !chkNoMonster.Checked;
        }

        private void txtMap_TextChanged(object sender, EventArgs e)
        {
            bool isEnable = !txtMap.Text.Equals(string.Empty);

            chkFast.Enabled = isEnable;
            chkRespawn.Enabled = isEnable;
            cmbSkill.Enabled = isEnable;
            chkNoMonster.Enabled = isEnable;
        }

        private void cmdAddIWAD_Click(object sender, EventArgs e)
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
                                        "Blood file (*.rff)|*.rff";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    string[] path = openFileDialog.FileNames;
                    foreach (string p in path)
                    {
                        DialogResult resp;
                        if (!CheckIWAD(p))
                        {
                            resp = MessageBox.Show("\"" + Path.GetFileName(p) + "\" does not look like an IWAD..." + Environment.NewLine +
                                             "This means that it's indeed a mod (so should be loaded as \"PWAD\"), or it does not follow the iwad standard (First four bytes conveted to ASCII = \"iwad\")," + Environment.NewLine +
                                             "do you still want to load it as an IWAD?", "Load IWAD?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        }
                        else
                        {
                            resp = DialogResult.Yes;
                        }

                        if (resp == DialogResult.Yes)
                        {
                            Storage storage = new Storage(cfgIWAD);
                            storage.UpdateConfig(p);
                            LoadIWADs();
                            cmbIWAD.SelectedItem = cmbIWAD.Items.Cast<PathName>().LastOrDefault();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Import a sourceport trough the "ADD..." button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddSourcePort_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "*.exe|*.exe";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] path = openFileDialog.FileNames;
                    foreach (string p in path)
                    {
                        Storage storage = new Storage(cfgPORT);
                        storage.UpdateConfig(p);
                        LoadPorts();
                        cmbSourcePort.SelectedItem = cmbSourcePort.Items.Cast<PathName>().LastOrDefault();
                    }
                }
            }
        }

        /// <summary>
        /// Import an alternative sourceport's configuration file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddConfiguration_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Initialization file |*.ini| Configuration file| *.cfg";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] path = openFileDialog.FileNames;
                    foreach (string p in path)
                    {
                        Storage storage = new Storage(cfgPORT_CONFIG);
                        storage.UpdateConfig(p);
                        LoadPortsConfigs();
                        cmbPortConfig.SelectedItem = cmbPortConfig.Items.Cast<PathName>().LastOrDefault();
                    }
                }
            }
        }

        /// <summary>
        /// Enable/Disable the loading of the alternative configuration file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkCustomConfiguration_CheckedChanged(object sender, EventArgs e)
        {
            bool siEnabled = chkCustomConfiguration.Checked;
            cmdAddConfiguration.Enabled = siEnabled;
            cmdRemoveConfiguration.Enabled = siEnabled;
            cmbPortConfig.Enabled = siEnabled;
        }

        /// <summary>
        /// Remove the select IWAD from the imported ones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdRemoveIWAD_Click(object sender, EventArgs e)
        {
            PathName wad = (PathName)cmbIWAD.SelectedItem;
            if (wad != null)
            {
                Storage storage = new Storage(cfgIWAD);
                storage.RemoveConfig(wad.path, SharedVar.SHOW_DELETE_MESSAGE);
                cmbIWAD.Text = "";
                LoadIWADs();
            }
        }

        /// <summary>
        /// Remove the selected presets from the imported ones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdRemoveSourcePort_Click(object sender, EventArgs e)
        {
            PathName PN = (PathName)cmbSourcePort.SelectedItem;
            if (PN != null)
            {
                Storage storage = new Storage(cfgPORT);
                storage.RemoveConfig(PN.path, SharedVar.SHOW_DELETE_MESSAGE);
                cmbSourcePort.Text = "";
                LoadPorts();
            }
        }

        /// <summary>
        /// Remove the selected alternative configuration from the imported ones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdRemoveConfiguration_Click(object sender, EventArgs e)
        {
            PathName PN = (PathName)cmbPortConfig.SelectedItem;
            if (PN != null)
            {
                Storage storage = new Storage(cfgPORT_CONFIG);
                storage.RemoveConfig(PN.path, SharedVar.SHOW_DELETE_MESSAGE);
                cmbPortConfig.Text = "";
                LoadPortsConfigs();
            }
        }

        /// <summary>
        /// Read all data from the selected preset
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            saveWithPreset.Clear();
            cmbFileFilter.SelectedIndex = 0;
            txtSearch.Text = string.Empty;

            for (int i = 0; i < lstPWAD.Items.Count; i++)
            {
                lstPWAD.SetSelected(i, false);

            }
            PathName selectedItem = (PathName)cmbPreset.SelectedItem;

            if (selectedItem.name.Trim().Equals("-"))
            {
                cmdRemovePreset.Enabled = false;
            }
            else
            {
                try
                {
                    PathName preset = (PathName)cmbPreset.SelectedItem;
                    Storage storage = new Storage(preset.path);
                    Dictionary<string, string> values = storage.ReadAllValues();

                    List<string> missingFiles = new List<string>();

                    foreach (KeyValuePair<string, string> s in values)
                    {
                        PathName file = null;
                        switch (s.Key)
                        {
                            case "IWAD":
                            case "-1":
                                if (s.Value == string.Empty)
                                    continue;
                                file = cmbIWAD.Items.Cast<PathName>().Where(P => P.name.ToUpper().Equals(Path.GetFileName(s.Value).ToUpper())).FirstOrDefault();
                                cmbIWAD.SelectedItem = file;
                                saveWithPreset.Add(s.Key);
                                break;
                            case "PORT":
                                if (s.Value == string.Empty)
                                    continue;
                                file = cmbSourcePort.Items.Cast<PathName>().Where(P => P.name.ToUpper().Equals(Path.GetFileName(s.Value).ToUpper())).FirstOrDefault();
                                cmbSourcePort.SelectedItem = file;
                                saveWithPreset.Add(s.Key);
                                break;
                            case "PORT_CONFIG":
                                if (s.Value == string.Empty)
                                {
                                    chkCustomConfiguration.Checked = false;
                                    continue;
                                }
                                chkCustomConfiguration.Checked = true;
                                file = cmbPortConfig.Items.Cast<PathName>().Where(P => P.name.ToUpper().Equals(Path.GetFileName(s.Value).ToUpper())).FirstOrDefault();
                                cmbPortConfig.SelectedItem = file;
                                saveWithPreset.Add(s.Key);
                                break;
                            case "RENDERER":
                                if (s.Value == string.Empty)
                                    continue;
                                cmb_vidrender.SelectedIndex = int.Parse(s.Value);
                                saveWithPreset.Add(s.Key);
                                file = new PathName();
                                break;

                            case "COMMANDLINE":
                                if (s.Value == string.Empty)
                                    continue;
                                txtCommandLine.Text = s.Value;
                                saveWithPreset.Add(s.Key);
                                file = new PathName();
                                break;

                            default:
                                file = lstPWAD.Items.Cast<PathName>().Where(P => P.name.ToUpper().Equals(Path.GetFileName(s.Value).ToUpper())).FirstOrDefault();
                                if (file != null)
                                {
                                    file.loadOrder = int.Parse(s.Key);
                                    lstPWAD.SetSelected(lstPWAD.Items.IndexOf(file), true);
                                }
                                break;
                        }

                        if (file == null)
                        {
                            missingFiles.Add(s.Value);
                            if (s.Key == "PORT_CONFIG")
                                chkCustomConfiguration.Checked = false;
                        }
                    }


                    if (missingFiles.Count > 0)
                    {
                        StringBuilder missingFilesError = new StringBuilder();
                        missingFilesError.AppendLine("The following files in the preset are missing:");

                        foreach (string file in missingFiles)
                        {
                            missingFilesError.AppendLine($"-'{file}'");
                        }

                        missingFilesError.AppendLine("This may happend because they have been renamed, moved or deleted.");
                        missingFilesError.AppendLine("If you have intentionally removed them, just save again the preset to update it.");
                        missingFilesError.AppendLine("If not, you can either import them again, rename them with the original name or just add them again and save the preset to update it.");

                        MessageBox.Show(missingFilesError.ToString());
                    }


                    cmdRemovePreset.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something went wrong while trying to load your preset..." + Environment.NewLine +
                                   "ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckForUpdate();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutForm ab = new AboutForm())
            {
                ab.ShowDialog();
            }
        }

        /// <summary>
        /// Open the FileManger window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOpenFileManager_Click(object sender, EventArgs e)
        {
            using (FileManager fm = new FileManager(cfgPWAD))
            {
                this.Hide();
                fm.ShowDialog();
            }
            this.Show();
            UpdateSelectedPWADitems(mode.DELETE);
            cachedPWADs = null;
            LoadPWAD();
            cmbPreset.SelectedItem = cmbPreset.Items.Cast<PathName>().Where(P => P.name.Equals("-")).FirstOrDefault();

        }

        /// <summary>
        /// Reload all the DML 2.X resources
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reloadResourcesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SavePreferences();
            cachedPWADs = null;
            LoadResources();
            UpdateSelectedPWADitems(mode.DELETE);
        }

        /// <summary>
        /// Delete the current selected preset
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdRemovePreset_Click(object sender, EventArgs e)
        {
            PathName pn = (PathName)cmbPreset.SelectedItem;
            try
            {

                if (pn != null && !pn.name.Equals("-"))
                {
                    DialogResult answer = DialogResult.OK;
                    if (SharedVar.SHOW_DELETE_MESSAGE)
                    {
                        answer = MessageBox.Show("Are you sure you want to remove \"" + pn.name + "\""
                                          + Environment.NewLine
                                          + "(Path: \"" + pn.path + "\")"
                                          , "REMOVE " + pn.name.ToUpper(), MessageBoxButtons.OKCancel);
                    }
                    if (answer == DialogResult.OK)
                    {
                        File.Delete(pn.path);
                        LoadPresetList();
                    }

                }
            }
            catch (Exception Ex)
            {
                StringBuilder error = new StringBuilder();
                error.AppendLine("Something went wrong while trying to delete a preset...");
                error.AppendLine("Please check if your account have the permission to write in:");
                error.AppendLine(@"""" + pn.path + @"""");
                error.AppendLine();
                error.AppendLine("Error Message:");
                error.AppendLine(Ex.Message);

                MessageBox.Show(error.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// When the user try to close the application, if the flag "SHOW_END_MESSAGE" is true a confirmation message with a random doom quitting quote will be displayed. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SharedVar.SHOW_END_MESSAGE)
            {
                string[] EXIT_MESSAGES = new string[] {
                    
                    #region DOOM
                    "Please don't leave, there's more demons to toast!",
                    "Let's beat it -- This is turning into a bloodbath!",
                    "I wouldn't leave if I were you. DOS is much worse.",
                    "You're trying to say you like DOS better than me, right?",
                    "Don't leave yet -- There's a demon around that corner!",
                    "Ya know, next time you come in here I'm gonna toast ya.",
                    "Go ahead and leave. See if I care.",
                    "Are you sure you want to quit this great game?",
                    #endregion

                    #region DOOM II
                    "You want to quit? Then, thou hast lost an eighth!",
                    "Don't go now, there's a dimensional shambler waiting at the dos prompt!",
                    "Get outta here and go back to your boring programs.",
                    "If I were your boss, I'd deathmatch ya in a minute!",
                    "Look, bud. You leave now and you forfeit your body count!",
                    "Just leave. When you come back, I'll be waiting with a bat.",
                    "You're lucky I don't smack you for thinking about leaving.",
                    #endregion
                };

                Random R = new Random();

                DialogResult ris = MessageBox.Show(EXIT_MESSAGES[R.Next(0, EXIT_MESSAGES.Length)], "QUIT?", MessageBoxButtons.YesNo);

                if (ris == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            SavePreferences();
        }

        /// <summary>
        /// Open the options window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Options options = new Options(cfgPreference))
            {
                options.ShowDialog();
            }

            if (SharedVar.USE_ADVANCED_SELECTION_MODE)
            {
                lstPWAD.SelectionMode = SelectionMode.MultiExtended;
            }
            else
            {
                lstPWAD.SelectionMode = SelectionMode.MultiSimple;
            }
        }


        private void cmbFileFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSelectedPWADitems(mode.SAVE);
            LoadPWAD(txtSearch.Text);
            UpdateSelectedPWADitems(mode.RESTORE);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            UpdateSelectedPWADitems(mode.SAVE);
            LoadPWAD(txtSearch.Text);
            UpdateSelectedPWADitems(mode.RESTORE);
        }

        private void cmbOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSelectedPWADitems(mode.SAVE);
            LoadPWAD(txtSearch.Text);
            UpdateSelectedPWADitems(mode.RESTORE);
        }
        #endregion

        #region METHODS

        /// <summary>
        /// Load all resources
        /// </summary>
        private void LoadResources()
        {
            LoadIWADs();
            LoadPorts();
            LoadPortsConfigs();
            LoadPresetList();
            LoadPWAD();
            LoadDMLconfiguration();
        }

        /// <summary>
        /// <br>Load all the presets from the presets folder </br>
        /// <br>NOTE: This will load just the paths (and names) of the preset.</br>
        /// </summary>
        private void LoadPresetList()
        {
            string[] pathPreset = Directory.GetFiles(foldPRESET);
            List<PathName> presets = new List<PathName>();

            presets = presets.Where(p => p.name != "-").ToList();
            foreach (string p in pathPreset)
            {
                presets.Add(GetPathName(p, true, false));
            }
            cmbPreset.DataSource = presets;
            cmbPreset.SelectedItem = cmbPreset.Items.Cast<PathName>().Where(P => P.name.Equals("-")).FirstOrDefault();
        }

        /// <summary>
        /// Load all the alternative port configuration files
        /// </summary>
        private void LoadPortsConfigs()
        {
            List<string> pathPORT_config = File.ReadAllLines(cfgPORT_CONFIG).ToList();
            pathPORT_config.Add(PORT_CONFIGfolderPath);
            cmbPortConfig.DataSource = GetAllPaths(pathPORT_config, new string[] { ".ini", ".cfg" }); ;
        }

        /// <summary>
        /// Load all sourceports
        /// </summary>
        private void LoadPorts()
        {
            List<string> pathPORT = File.ReadAllLines(cfgPORT).ToList();
            pathPORT.Add(PORTfolderPath);
            cmbSourcePort.DataSource = GetAllPaths(pathPORT, new string[] { ".exe" }, true);
        }

        /// <summary>
        /// <br>Load all pwads from disk(or RAM) and populate the lstPWAD list.</br>
        /// </summary>
        /// <param name="filter"></param>
        private void LoadPWAD(string filter = null)
        {
            try
            {
                lstPWAD.DataSource = new List<PathName>();

                List<PathName> wads;

                if (cachedPWADs == null)
                {
                    List<string> pathPWAD = File.ReadAllLines(cfgPWAD).ToList();
                    pathPWAD.Add(PWADfolderPath);

                    cachedPWADs = GetAllPaths(pathPWAD, validWadExtensions);
                }

                if (cmbFileFilter.Text.ToUpper().Equals("ALL"))
                {
                    wads = cachedPWADs;
                }
                else
                {
                    wads = cachedPWADs.Where(F => Path.GetExtension(F.path) == cmbFileFilter.Text).ToList();
                }

                if (wads != null && wads.Count > 0)
                {
                    wads = wads.GroupBy(p => p.name).Select(g => g.First()).ToList();

                    if (filter != null)
                    {
                        wads = wads.Where(p => p.name.ToUpper().Contains(filter.ToUpper())).ToList();
                    }

                    wads = wads.OrderFile((order)cmbOrder.SelectedIndex);

                    lstPWAD.DataSource = wads;
                }

                lstPWAD.SelectedItem = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong while trying to load your mods..." + Environment.NewLine +
                                "Error: \"" + ex.Message + "\"", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load the IWAD list.
        /// </summary>
        private void LoadIWADs()
        {
            List<string> pathIWAD = File.ReadAllLines(cfgIWAD).ToList();
            pathIWAD.Add(IWADfolderPath);
            cmbIWAD.DataSource = GetAllPaths(pathIWAD, validWadExtensions);
        }

        /// <summary>
        /// Load DML 2.X prefrences and the latest used launch parameters.
        /// </summary>
        private void LoadDMLconfiguration()
        {
            try
            {
                string value;
                List<string> errors = new List<string>();
                Storage storage = new Storage(cfgPreference);

                Dictionary<string, string> cfg = storage.ReadAllValues();

                if (cfg.Count > 0)
                {
                    #region AUDIO
                    if (cfg.TryGetValue("AUDIO", out value)) //cfg["AUDIO"]
                    {
                        switch (value)
                        {
                            case "1":
                                radAudioNoMusic.Checked = true;
                                break;
                            case "2":
                                radAudioNoSFX.Checked = true;
                                break;
                            case "3":
                                radAudioNoSounds.Checked = true;
                                break;
                        }
                    }
                    else
                    {
                        errors.Add("AUDIO");
                    }
                    #endregion

                    #region SCREEN_WIDTH/SCREEN_HEIGHT/FULLSCREEN

                    //SCREEN WIDTH VALUE
                    if (cfg.TryGetValue("SCREEN_WIDTH", out value)) //cfg["SCREEN_WIDTH"]
                    {
                        txtScreenWidth.Text = value;
                    }
                    else
                    {
                        errors.Add("SCREEN_WIDTH");
                    }

                    //SCREEN HEIGHT VALUE
                    if (cfg.TryGetValue("SCREEN_HEIGHT", out value)) //cfg["SCREEN_HEIGHT"]
                    {
                        txtScreenHeight.Text = value;
                    }
                    else
                    {
                        errors.Add("SCREEN_HEIGHT");
                    }

                    //FULLSCREEN FLAG
                    if (cfg.TryGetValue("FULLSCREEN", out value)) //cfg["FULLSCREEN"]
                    {
                        chkFullscreen.Checked = Convert.ToBoolean(value);
                    }
                    else
                    {
                        errors.Add("FULLSCREEN");
                    }


                    #endregion

                    #region CUSTOM PORT CONFIGURATION
                    //CUSTOM_PORT_CFG FLAG
                    if (cfg.TryGetValue("CUSTOM_PORT_CFG", out value)) //cfg["CUSTOM_PORT_CFG"]
                    {
                        chkCustomConfiguration.Checked = Convert.ToBoolean(value);
                        if (cfg.TryGetValue("CUSTOM_PORT_PATH", out value)) //cfg["CUSTOM_PORT_PATH"]
                        {
                            cmbPortConfig.SelectedItem = cmbPortConfig.Items.Cast<PathName>().Where(p => p.path == value).FirstOrDefault();
                        }
                        else
                        {
                            errors.Add("CUSTOM_PORT_PATH");
                        }
                    }
                    else
                    {
                        errors.Add("CUSTOM_PORT_PATH");
                    }
                    #endregion

                    #region COMMANDLINE
                    //COMMANDLINE TEXT
                    if (cfg.TryGetValue("COMMANDLINE", out value)) //cfg["COMMANDLINE"]
                    {
                        txtCommandLine.Text = value;
                    }
                    else
                    {
                        errors.Add("COMMANDLINE");
                    }
                    #endregion

                    #region IWAD
                    if (cfg.TryGetValue("IWAD", out value)) //cfg["IWAD"]
                    {
                        cmbIWAD.SelectedItem = cmbIWAD.Items.Cast<PathName>().Where(p => p.name.Equals(value)).FirstOrDefault();
                    }
                    else
                    {
                        errors.Add("IWAD");
                    }
                    #endregion

                    #region PORT
                    if (cfg.TryGetValue("PORT", out value)) //cfg["PORT"]
                    {

                        cmbSourcePort.SelectedItem = cmbSourcePort.Items.Cast<PathName>().Where(p => p.name.Equals(value)).FirstOrDefault();
                    }
                    else
                    {
                        errors.Add("PORT");
                    }
                    #endregion

                    #region RENDERER
                    if (cfg.TryGetValue("RENDERER", out value)) //cfg["RENDERER"]
                    {
                        cmb_vidrender.SelectedIndex = Convert.ToInt32(value);
                    }
                    else
                    {
                        errors.Add("RENDERER");
                        cmb_vidrender.SelectedIndex = 5;
                    }
                    #endregion

                    #region CHECK_FOR_UPDATE
                    if (cfg.TryGetValue("CHECK_FOR_UPDATE", out value)) //cfg["CHECK_FOR_UPDATE"]
                    {
                        SharedVar.CHECK_FOR_UPDATE = Convert.ToBoolean(value);
                    }
                    else
                    {
                        errors.Add("CHECK_FOR_UPDATE");
                        SharedVar.CHECK_FOR_UPDATE = true;
                    }
                    #endregion

                    #region SHOW_END_MESSAGE
                    if (cfg.TryGetValue("SHOW_END_MESSAGE", out value)) //cfg["SHOW_END_MESSAGE"]
                    {
                        SharedVar.SHOW_END_MESSAGE = Convert.ToBoolean(value);
                    }
                    else
                    {
                        errors.Add("SHOW_END_MESSAGE");
                        SharedVar.SHOW_END_MESSAGE = true;
                    }
                    #endregion

                    #region SHOW_DELETE_MESSAGE
                    if (cfg.TryGetValue("SHOW_DELETE_MESSAGE", out value)) //cfg["SHOW_DELETE_MESSAGE"]
                    {
                        SharedVar.SHOW_DELETE_MESSAGE = Convert.ToBoolean(value);
                    }
                    else
                    {
                        errors.Add("SHOW_DELETE_MESSAGE");
                        SharedVar.SHOW_DELETE_MESSAGE = true;
                    }
                    #endregion

                    #region SHOW_OVERWRITE_MESSAGE
                    if (cfg.TryGetValue("SHOW_OVERWRITE_MESSAGE", out value)) //cfg["SHOW_OVERWRITE_MESSAGE"]
                    {
                        SharedVar.SHOW_OVERWRITE_MESSAGE = Convert.ToBoolean(value);
                    }
                    else
                    {
                        errors.Add("SHOW_OVERWRITE_MESSAGE");
                        SharedVar.SHOW_OVERWRITE_MESSAGE = true;
                    }
                    #endregion

                    #region SHOW_SUCCESS_MESSAGE
                    if (cfg.TryGetValue("SHOW_SUCCESS_MESSAGE", out value)) //cfg["SHOW_SUCCESS_MESSAGE"]
                    {
                        SharedVar.SHOW_SUCCESS_MESSAGE = Convert.ToBoolean(value);
                    }
                    else
                    {
                        errors.Add("SHOW_SUCCESS_MESSAGE");
                        SharedVar.SHOW_SUCCESS_MESSAGE = true;
                    }
                    #endregion

                    #region USE_ADVANCED_SELECTION_MODE
                    if (cfg.TryGetValue("USE_ADVANCED_SELECTION_MODE", out value)) //cfg["SHOW_SUCCESS_MESSAGE"]
                    {
                        SharedVar.USE_ADVANCED_SELECTION_MODE = Convert.ToBoolean(value);
                    }
                    else
                    {
                        errors.Add("USE_ADVANCED_SELECTION_MODE");
                        SharedVar.USE_ADVANCED_SELECTION_MODE = false;
                    }
                    #endregion

                    #region PRESET
                    if (cfg.TryGetValue("PRESET", out value))
                    {
                        cmbPreset.SelectedItem = cmbPreset.Items.Cast<PathName>().Where(P => P.name == value).FirstOrDefault();
                    }
                    else
                    {
                        errors.Add("PRESET");
                        cmbPreset.SelectedItem = cmbPreset.Items.Cast<PathName>().Where(P => P.name == "-").FirstOrDefault();
                    }
                    #endregion

                    if (errors.Count > 0)
                    {
                        SavePreferences();
                        StringBuilder errorText = new StringBuilder();
                        errorText.AppendLine("The following settings could not be read from '" + cfgPreference + "' and have been resetted to the default value:");
                        foreach (string s in errors)
                        {
                            errorText.AppendLine("-" + s);
                        }
                        errorText.AppendLine("If you just upgraded to a new version and those settings are listed in the changelog, you can ignore this message.");
                        MessageBox.Show(errorText.ToString(), "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    LoadDefaultValues();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong while trying to load your preferences..." + Environment.NewLine + "Flags have been resetted to default value." + Environment.NewLine + "Error: \"" + ex.Message + "\"", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadDefaultValues();
            }
        }

        /// <summary>
        /// Load the default values for the application
        /// </summary>
        private void LoadDefaultValues()
        {
            cmb_vidrender.SelectedIndex = 5;
            SharedVar.CHECK_FOR_UPDATE = true;
            SharedVar.SHOW_END_MESSAGE = true;
            SharedVar.SHOW_DELETE_MESSAGE = true;
            SharedVar.SHOW_OVERWRITE_MESSAGE = true;
            SharedVar.SHOW_SUCCESS_MESSAGE = true;
        }

        /// <summary>
        /// Create all the needed configuration files
        /// </summary>
        private void InitializeConfiguration()
        {
            try
            {

                dmlConfigPath = Path.Combine(Application.StartupPath, "CONFIG");

                foldPRESET = Path.Combine(dmlConfigPath, "Presets");
                cfgPreference = Path.Combine(dmlConfigPath, "DMLv2.ini");
                cfgIWAD = Path.Combine(dmlConfigPath, "IWAD.ini");
                cfgPWAD = Path.Combine(dmlConfigPath, "PWAD.ini");
                cfgPORT = Path.Combine(dmlConfigPath, "PORT.ini");
                cfgPORT_CONFIG = Path.Combine(dmlConfigPath, "PORT_CONFIG_PATH.ini");

                if (!Directory.Exists(dmlConfigPath))
                    Directory.CreateDirectory(dmlConfigPath);

                if (!Directory.Exists(foldPRESET))
                    Directory.CreateDirectory(foldPRESET);

                string placeholder = Path.Combine(foldPRESET, "-.dml");
                if (!File.Exists(placeholder))
                {
                    FileStream F = File.Create(placeholder);
                    F.Dispose();
                }

                if (!File.Exists(cfgIWAD))
                {
                    FileStream F = File.Create(cfgIWAD);
                    F.Dispose();
                }
                if (!File.Exists(cfgPWAD))
                {
                    FileStream F = File.Create(cfgPWAD);
                    F.Dispose();
                }

                if (!File.Exists(cfgPORT))
                {
                    FileStream F = File.Create(cfgPORT);
                    F.Dispose();
                }

                if (!File.Exists(cfgPreference))
                {
                    FileStream F = File.Create(cfgPreference);
                    F.Dispose();
                }

                if (!File.Exists(cfgPORT_CONFIG))
                {
                    FileStream F = File.Create(cfgPORT_CONFIG);
                    F.Dispose();
                }

                userFiles_path = Path.Combine(Application.StartupPath, "FILE");
                IWADfolderPath = Path.Combine(userFiles_path, "IWAD");
                PWADfolderPath = Path.Combine(userFiles_path, "PWAD");
                PORTfolderPath = Path.Combine(userFiles_path, "PORT");
                PORT_CONFIGfolderPath = Path.Combine(userFiles_path, "PORT_CONFIG");

                if (!Directory.Exists(userFiles_path))
                    Directory.CreateDirectory(userFiles_path);

                if (!Directory.Exists(IWADfolderPath))
                    Directory.CreateDirectory(IWADfolderPath);

                if (!Directory.Exists(PWADfolderPath))
                    Directory.CreateDirectory(PWADfolderPath);

                if (!Directory.Exists(PORTfolderPath))
                    Directory.CreateDirectory(PORTfolderPath);

                if (!Directory.Exists(PORT_CONFIGfolderPath))
                    Directory.CreateDirectory(PORT_CONFIGfolderPath);

                string blacklistIWADpath = Path.Combine(IWADfolderPath, "BLACKLIST.TXT");
                string blacklistPWADpath = Path.Combine(PWADfolderPath, "BLACKLIST.TXT");
                string blacklistPORTpath = Path.Combine(PORTfolderPath, "BLACKLIST.TXT");
                string blacklistPORT_CONFIGpath = Path.Combine(PORT_CONFIGfolderPath, "BLACKLIST.TXT");

                if (!File.Exists(blacklistIWADpath))
                {
                    FileStream F = File.Create(blacklistIWADpath);
                    F.Dispose();
                }

                if (!File.Exists(blacklistPWADpath))
                {
                    FileStream F = File.Create(blacklistPWADpath);
                    F.Dispose();
                }

                if (!File.Exists(blacklistPORTpath))
                {
                    FileStream F = File.Create(blacklistPORTpath);
                    F.Dispose();
                }

                if (!File.Exists(blacklistPORT_CONFIGpath))
                {
                    FileStream F = File.Create(blacklistPORT_CONFIGpath);
                    F.Dispose();
                }
            }
            catch (Exception ex)
            {
                StringBuilder error = new StringBuilder();
                error.AppendLine("Could not create a .cfg file or folder!");
                error.AppendLine("Please check if your account have the permission to write in:");
                error.AppendLine(@"""" + Application.StartupPath + @"""");
                error.AppendLine();
                error.AppendLine("Error Message:");
                error.AppendLine(ex.Message);

                MessageBox.Show(error.ToString(), "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }

        }

        private bool CheckIWAD(string path = "")
        {
            try
            {
                if (path.Equals(""))
                {
                    PathName wad = (PathName)cmbIWAD.SelectedItem;
                    path = wad.path;

                }

                byte[] wadData = File.ReadAllBytes(path);
                string s = Encoding.ASCII.GetString(wadData.Take(4).ToArray());

                if (s.Equals("IWAD"))
                {
                    return true;
                }

                //MD5 hash for CHEX3.WAD v1.4 & v1.0
                const string chex3v1_4_MD5 = "bce163d06521f9d15f9686786e64df13";
                const string chex3v1_0_MD5 = "59c985995db55cd2623c1893550d82b3";
                string fileMD5;

                using (var md5 = MD5.Create())
                {
                    fileMD5 = BitConverter.ToString(md5.ComputeHash(wadData)).Replace("-", "").ToLowerInvariant();
                }

                //Chex3 seems marked as PWAD while actually is a stand-alone game. So I check it by hash.
                if (chex3v1_4_MD5.Equals(fileMD5) || chex3v1_0_MD5.Equals(fileMD5))
                {
                    return true;
                }

                return false;

            }
            catch
            {
                return false;
            }
        }

        private string GetParameters()
        {
            StringBuilder parm = new StringBuilder();

            //IWAD
            PathName IWAD = (PathName)cmbIWAD.SelectedItem;
            parm.AppendFormat(@" -IWAD ""{0}"" ", IWAD.path);


            //VIDEO
            //RESOLUTION  (Seems broken in gzdoom)
            if (txtScreenHeight.Text != string.Empty && txtScreenWidth.Text != string.Empty)
            {
                parm.AppendFormat(" -width {0} ", txtScreenWidth.Text);
                parm.AppendFormat(" -height {0} ", txtScreenHeight.Text);
            }

            //FULLSCREEN
            parm.AppendFormat(" +fullscreen {0} ", chkFullscreen.Checked);

            //AUDIO
            if (!radAudioAllSounds.Checked)
            {
                if (radAudioNoMusic.Checked)
                {
                    parm.Append(" -nomusic ");
                }
                else
                if (radAudioNoSFX.Checked)
                {
                    parm.Append(" -nosfx ");
                }
                else
                if (radAudioNoSounds.Checked)
                {
                    parm.Append(" -nosound ");
                }
            }



            //Level 
            if (txtMap.Text != string.Empty)
            {
                //Map
                parm.AppendFormat(@" +map ""{0}"" ", txtMap.Text);

                //Skill
                parm.AppendFormat(" -skill {0} ", cmbSkill.SelectedIndex + 1);

                if (chkNoMonster.Checked)
                {
                    //No Monster
                    parm.Append(" -nomonsters ");
                }
                else
                {
                    //Fast Monster (like Nightmare)
                    if (chkFast.Checked)
                        parm.Append(" -fast ");

                    //Monster respawn (like Nightmare)
                    if (chkRespawn.Checked)
                        parm.Append(" -respawn ");
                }
            }

            if (chkCustomConfiguration.Checked)
            {
                PathName p = (PathName)cmbPortConfig.SelectedItem;
                if (p != null)
                {
                    parm.AppendFormat(@" -config ""{0}""", p.path);
                }
            }

            //RENDERER, 5 it's the "DO NOT OVVERRIDE"
            if (cmb_vidrender.SelectedIndex != 5)
                parm.AppendFormat(" +vid_rendermode {0} ", cmb_vidrender.SelectedIndex);

            //CUSTOM COMMAND
            parm.Append(" " + txtCommandLine.Text + " ");
            return parm.ToString();

        }

        /// <summary>
        /// <br>Start the game without mods or with just one.</br>
        /// The logic to start the game with 2 or more mods it's inside "FormMod.cs"
        /// </summary>
        /// <param name="param"></param>
        public void StartGame(string param)
        {
            try
            {
                PathName sp = (PathName)cmbSourcePort.SelectedItem;
                Process.Start(sp.path, param);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot start the game!" + Environment.NewLine +
                                "ERROR: \"" + ex.Message + "\"", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Save DML 2.X preferences and launch options.
        /// </summary>
        private void SavePreferences()
        {
            try
            {
                Dictionary<string, string> preferences = new Dictionary<string, string>();
                Storage storage = new Storage(cfgPreference);

                #region AUDIO
                if (radAudioAllSounds.Checked)
                {
                    preferences.Add("AUDIO", "0");
                }
                else
                    if (radAudioNoMusic.Checked)
                {
                    preferences.Add("AUDIO", "1");
                }
                else
                    if (radAudioNoSFX.Checked)
                {
                    preferences.Add("AUDIO", "2");
                }
                else
                    if (radAudioNoSounds.Checked)
                {
                    preferences.Add("AUDIO", "3");
                }
                #endregion

                #region VIDEO
                if (txtScreenHeight.Text != string.Empty && txtScreenWidth.Text != string.Empty)
                {
                    preferences.Add("SCREEN_WIDTH", txtScreenWidth.Text);
                    preferences.Add("SCREEN_HEIGHT", txtScreenHeight.Text);
                }
                else
                {
                    preferences.Add("SCREEN_WIDTH", "");
                    preferences.Add("SCREEN_HEIGHT", "");
                }

                if (chkFullscreen.Checked)
                {
                    preferences.Add("FULLSCREEN", "TRUE");
                }
                else
                {
                    preferences.Add("FULLSCREEN", "FALSE");
                }
                #endregion

                #region ALTERNATIVE SOURCEPORT CONFIGURATION
                if (chkCustomConfiguration.Checked)
                {
                    preferences.Add("CUSTOM_PORT_CFG", "TRUE");
                    PathName p = (PathName)cmbPortConfig.SelectedItem;
                    if (p != null)
                    {
                        preferences.Add("CUSTOM_PORT_PATH", p.path);
                    }
                    else
                    {
                        preferences.Add("CUSTOM_PORT_PATH", "");
                    }
                }
                else
                {
                    preferences.Add("CUSTOM_PORT_CFG", "FALSE");
                    preferences.Add("CUSTOM_PORT_PATH", "");
                }
                #endregion

                preferences.Add("COMMANDLINE", txtCommandLine.Text);

                #region IWAD
                PathName iwad = (PathName)cmbIWAD.SelectedItem;
                if (iwad != null)
                {
                    preferences.Add("IWAD", iwad.name);
                }
                else
                {
                    preferences.Add("IWAD", "");
                }
                #endregion

                #region PWAD
                PathName port = (PathName)cmbSourcePort.SelectedItem;
                if (port != null)
                {
                    preferences.Add("PORT", port.name);
                }
                else
                {
                    preferences.Add("PORT", "");
                }
                #endregion

                preferences.Add("PRESET", cmbPreset.Text);


                preferences.Add("RENDERER", cmb_vidrender.SelectedIndex.ToString());

                preferences.Add("CHECK_FOR_UPDATE", SharedVar.CHECK_FOR_UPDATE.ToString().ToUpper());

                preferences.Add("SHOW_END_MESSAGE", SharedVar.SHOW_END_MESSAGE.ToString().ToUpper());

                preferences.Add("SHOW_OVERWRITE_MESSAGE", SharedVar.SHOW_OVERWRITE_MESSAGE.ToString().ToUpper());

                preferences.Add("SHOW_SUCCESS_MESSAGE", SharedVar.SHOW_SUCCESS_MESSAGE.ToString().ToUpper());

                preferences.Add("SHOW_DELETE_MESSAGE", SharedVar.SHOW_DELETE_MESSAGE.ToString().ToUpper());

                preferences.Add("USE_ADVANCED_SELECTION_MODE", SharedVar.USE_ADVANCED_SELECTION_MODE.ToString().ToUpper());

                storage.SaveValues(preferences, true);
            }
            catch (Exception ex)
            {
                StringBuilder error = new StringBuilder();
                error.AppendLine("Something went wrong while trying to save your preference...");
                error.AppendLine("Please check if your account have the permission to write in:");
                error.AppendLine(@"""" + cfgPreference + @"""");
                error.AppendLine();
                error.AppendLine("Error Message:");
                error.AppendLine(ex.Message);

                MessageBox.Show(error.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Open the VersionForm window and check for newer application version.
        /// </summary>
        /// <param name="start"></param>
        private void CheckForUpdate(bool start = false)
        {
            try
            {
                using (VersionForm vf = new VersionForm())
                {
                    if (start)
                    {
                        if (!vf.isLatestVersion())
                        {
                            vf.ShowDialog();
                        }
                    }
                    else
                    {
                        vf.ShowDialog();
                    }
                }

            }
            catch
            {
                MessageBox.Show("Could not get the latest version info..." + Environment.NewLine +
                                "Please check your internet connection...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        /// <summary>
        /// Convert the given path in a PathName object
        /// </summary>
        /// <param name="path"></param>
        /// <param name="removeExtension"></param>
        /// <param name="toUpper"></param>
        /// <returns></returns>
        private PathName GetPathName(string path, bool removeExtension, bool toUpper)
        {
            PathName obj = new PathName
            {
                path = path
            };

            if (removeExtension)
            {
                obj.name = Path.GetFileNameWithoutExtension(path);
            }
            else
            {
                obj.name = Path.GetFileName(path);
            }

            if (toUpper)
                obj.name = obj.name.ToUpper();

            return obj;
        }

        /// <summary>
        /// <br>Convert each element found in a given array of paths with a given extension in a PathName object.</br> 
        /// <br>If the path is a directory, all files inside the directory and subdirectories will be examined.</br>
        /// <br>If the path is a directory, and contains a "BLACKLIST.TXT", any file with a name contained in the blacklist file will be ignored.</br>
        /// </summary>
        /// <param name="paths"></param>
        /// <param name="validExtensions"></param>
        /// <param name="removeExtension"></param>
        /// <returns></returns>
        private List<PathName> GetAllPaths(List<string> paths, string[] validExtensions, bool removeExtension = false)
        {
            List<PathName> ret = new List<PathName>();
            foreach (string p in paths)
            {
                if (File.Exists(p))
                {
                    ret.Add(GetPathName(p, removeExtension, true));
                }
                else if (Directory.Exists(p))
                {
                    string[] allFiles = Directory.GetFiles(p);
                    string[] files = allFiles.Where(F => validExtensions.Contains(Path.GetExtension(F).ToLower())).ToArray();

                    string blacklistPath = allFiles.Where(B => Path.GetFileName(B).ToUpper().Equals("BLACKLIST.TXT")).FirstOrDefault();
                    List<string> blacklistFiles = new List<string>();

                    if (blacklistPath != null)
                    {
                        blacklistFiles = File.ReadAllLines(blacklistPath).ToList();
                    }

                    foreach (string file in files)
                    {
                        ret.Add(GetPathName(file, removeExtension, true));
                    }

                    string[] folders = Directory.GetDirectories(p, "*", SearchOption.AllDirectories);
                    foreach (string f in folders)
                    {
                        files = Directory.GetFiles(f);
                        foreach (string file in files)
                        {
                            ret.Add(GetPathName(file, removeExtension, true));
                        }
                    }

                    //Remove all blacklisted file
                    ret.RemoveAll(F => blacklistFiles.Any(B => Path.GetFileName(B).ToUpper() == F.name.ToUpper()));

                    //Remove all file without a valid extension
                    ret.RemoveAll(F => !validExtensions.Contains(Path.GetExtension(F.path).ToLower()));
                }
            }

            return ret;
        }

        /// <summary>
        /// Custom handle for "lstPWAD" selected items because if the list is filtered the current ones will get lost otherwise
        /// </summary>
        /// <param name="mode"></param>
        private void UpdateSelectedPWADitems(mode mode)
        {
            List<PathName> allFiles = lstPWAD.Items.Cast<PathName>().ToList();
            if (mode == mode.SAVE)
            {
                List<PathName> selectedFiles = lstPWAD.SelectedItems.Cast<PathName>().ToList();
                List<PathName> unselectedFiles = allFiles.Where(X => !selectedFiles.Any(Y => Y.name == X.name)).ToList();
                SelectedItems.RemoveAll(X => unselectedFiles.Any(Y => Y.name == X.name));
                SelectedItems = lstPWAD.SelectedItems.Cast<PathName>().ToList();
                return;
            }

            if (mode == mode.RESTORE)
            {
                foreach (PathName file in allFiles)
                {
                    lstPWAD.SetSelected(lstPWAD.Items.IndexOf(file), SelectedItems.Any(X => X.name == file.name));
                }
                return;
            }

            if (mode == mode.DELETE)
            {
                SelectedItems.Clear();
            }
        }
        #endregion
    }
}