using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using DoomModLoader2.Entity;
using P36_UTILITIES;

namespace DoomModLoader2
{

    public partial class MainForm : Form
    {
        private string fold_APPDATA;
        private string fold_P36SOFTWARE;
        private string fold_DMLv2;
        private string cfgPreference;
        private string cfgIWAD;
        private string cfgPWAD;
        private string cfgPORT;
        private string cfgPORT_CONFIG;
        private string foldPRESET;

        #region FORM 
        public MainForm()
        {

            InitializeComponent();
            this.Text += " v" + SharedVar.LOCAL_VERSION;
            InitializeConfiguration();
            LoadResources();
            txtMap_TextChanged(null, null);
            chkCustomConfiguration_CheckedChanged(null, null);
            cmbSkill.SelectedIndex = 3;
            if (SharedVar.CHECK_FOR_UPDATE)
            {
                try
                {
                    CheckUpdate(true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not get the latest version info..." + Environment.NewLine +
                                    "Please check your internet connection...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }


        }

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
                var items = lstPWAD.SelectedItems;
                string param = GetParameters();

                //If the user select less than 2 mods it's useless display the mod order dialog
                if (items != null && items.Count > 1)
                {
                    List<PathName> pwads = new List<PathName>();
                    FormMod formMod = new FormMod(foldPRESET);
                    formMod.parameters = param;

                    foreach (PathName p in items)
                        pwads.Add(p);

                    formMod.pwads = pwads;
                    formMod.sourcePort = (PathName)cmbSourcePort.SelectedItem;
                    PathName selectedPreset = (PathName)cmbPreset.SelectedItem;

                    if (!selectedPreset.name.Trim().Equals("-"))
                        formMod.presetName = selectedPreset.name;
                    formMod.ShowDialog();

                    CaricaPreset();
                    if (formMod.presetName != null)
                    {
                        PathName pn = cmbPreset.Items.Cast<PathName>().Where(P => P.name == formMod.presetName.ToUpper()).FirstOrDefault();
                        if (pn != null)
                            cmbPreset.SelectedItem = pn;
                    }
                }
                else
                {
                    if (items.Count == 1)
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
                            CaricaIWAD();
                            cmbIWAD.SelectedItem = cmbIWAD.Items.Cast<PathName>().LastOrDefault();
                        }
                    }


                }
            }
        }

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
                        CaricaPort();
                        cmbSourcePort.SelectedItem = cmbSourcePort.Items.Cast<PathName>().LastOrDefault();
                    }
                }
            }
        }

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
                        CaricaPortConfig();
                        cmbPortConfig.SelectedItem = cmbPortConfig.Items.Cast<PathName>().LastOrDefault();
                    }
                }
            }
        }

        private void chkCustomConfiguration_CheckedChanged(object sender, EventArgs e)
        {
            bool siEnabled = chkCustomConfiguration.Checked;
            cmdAddConfiguration.Enabled = siEnabled;
            cmdRemoveConfiguration.Enabled = siEnabled;
            cmbPortConfig.Enabled = siEnabled;
        }

        private void cmdRemoveIWAD_Click(object sender, EventArgs e)
        {
            PathName wad = (PathName)cmbIWAD.SelectedItem;
            Storage storage = new Storage(cfgIWAD);
            storage.RemoveConfig(wad.path, SharedVar.SHOW_DELETE_MESSAGE);
            cmbIWAD.Text = "";
            CaricaIWAD();
        }

        private void cmdRemoveSourcePort_Click(object sender, EventArgs e)
        {
            PathName PN = (PathName)cmbSourcePort.SelectedItem;
            Storage storage = new Storage(cfgPORT);
            storage.RemoveConfig(PN.path, SharedVar.SHOW_DELETE_MESSAGE);
            cmbSourcePort.Text = "";
            CaricaPort();
        }

        private void cmdRemoveConfiguration_Click(object sender, EventArgs e)
        {
            PathName PN = (PathName)cmbPortConfig.SelectedItem;
            Storage storage = new Storage(cfgPORT_CONFIG);
            storage.RemoveConfig(PN.path, SharedVar.SHOW_DELETE_MESSAGE);
            cmbPortConfig.Text = "";
            CaricaPortConfig();
        }




        private void cmbPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
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




                    foreach (KeyValuePair<string, string> s in values)
                    {
                        foreach (PathName p in lstPWAD.Items)
                        {
                            if (p.path.Contains(s.Value))
                            {
                                int i = lstPWAD.Items.IndexOf(p);
                                p.loadOrder = int.Parse(s.Key);
                                lstPWAD.SetSelected(i, true);
                                break;
                            }
                        }
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

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CheckUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not get the latest version info..." + Environment.NewLine +
                                "Please check your internet connection..." + Environment.NewLine +
                                "ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm ab = new AboutForm();
            ab.ShowDialog();
        }

        private void cmdOpenFileManager_Click(object sender, EventArgs e)
        {
            FileManager fm = new FileManager(cfgPWAD, cfgPreference);
            this.Hide();
            fm.ShowDialog();
            this.Show();
            CaricaPWAD();
        }

        private void reloadResourcesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SavePreferences();
            LoadResources();
        }

        #endregion

        #region METODI

        private void LoadResources()
        {
            CaricaIWAD();
            CaricaPort();
            CaricaPortConfig();
            CaricaPreset();
            CaricaCFG();
            CaricaPWAD();
        }

        private void CaricaPreset()
        {
            string[] pathPreset = Directory.GetFiles(foldPRESET);
            List<PathName> presets = new List<PathName>();

            presets = presets.Where(p => p.name != "-").ToList();
            foreach (string p in pathPreset)
            {
                PathName preset = new PathName();
                preset.path = p;
                preset.name = Path.GetFileNameWithoutExtension(p).ToUpper();
                presets.Add(preset);
            }
            cmbPreset.DataSource = presets;
            cmbPreset.SelectedItem = cmbPreset.Items.Cast<PathName>().Where(P => P.name.Equals("-")).FirstOrDefault();


        }

        private void CaricaPortConfig()
        {
            string[] pathPORT_config = File.ReadAllLines(cfgPORT_CONFIG);
            List<PathName> configs = new List<PathName>();
            foreach (string p in pathPORT_config)
            {
                PathName config = new PathName();
                config.path = p;
                config.name = Path.GetFileNameWithoutExtension(p).ToUpper();
                configs.Add(config);
            }
            cmbPortConfig.DataSource = configs;
        }

        private void CaricaPort()
        {
            string[] pathPORT = File.ReadAllLines(cfgPORT);
            List<PathName> ports = new List<PathName>();
            foreach (string p in pathPORT)
            {
                PathName port = new PathName();
                port.path = p;
                port.name = Path.GetFileNameWithoutExtension(p).ToUpper();
                ports.Add(port);
            }
            cmbSourcePort.DataSource = ports;
        }

        private void CaricaPWAD()
        {
            try
            {
                string[] validExtensions = { ".wad", ".pk3", ".zip", ".pak", ".pk7", ".grp", ".rff", ".deh" };
                string[] pathPWAD = File.ReadAllLines(cfgPWAD);
                List<PathName> wads = new List<PathName>();
                foreach (string p in pathPWAD)
                {
                    if (File.Exists(p))
                    {
                        PathName wad = new PathName();
                        wad.path = p;
                        wad.name = Path.GetFileName(p).ToUpper();
                        wads.Add(wad);
                    }
                    else if (Directory.Exists(p))
                    {
                        string[] files = Directory.GetFiles(p).Where(F => validExtensions.Contains(Path.GetExtension(F).ToLower())).ToArray();
                        foreach (string file in files)
                        {
                            PathName wad = new PathName();
                            wad.path = file;
                            wad.name = Path.GetFileName(file).ToUpper();
                            wads.Add(wad);
                        }
                        if (SharedVar.LOAD_SUBFOLDERS)
                        {
                            string[] folders = Directory.GetDirectories(p, "*", SearchOption.AllDirectories);
                            foreach (string f in folders)
                            {
                                files = Directory.GetFiles(f).Where(F => validExtensions.Contains(Path.GetExtension(F).ToLower())).ToArray();
                                foreach (string file in files)
                                {
                                    PathName wad = new PathName();
                                    wad.path = file;
                                    wad.name = Path.GetFileName(file).ToUpper();
                                    wads.Add(wad);
                                }
                            }
                        }

                    }
                }

                lstPWAD.DataSource = new List<PathName>();


                if (wads != null && wads.Count > 0)
                {
                    lstPWAD.DataSource = wads.GroupBy(p => p.path)
                                        .Select(g => g.First())
                                        .ToList();

                }

                lstPWAD.SelectedItem = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong while trying to load your mods..." + Environment.NewLine + "Error: \"" + ex.Message + "\"", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CaricaIWAD()
        {
            string[] pathIWAD = File.ReadAllLines(cfgIWAD);
            List<PathName> wads = new List<PathName>();
            foreach (string p in pathIWAD)
            {
                PathName wad = new PathName();
                wad.path = p;
                wad.name = Path.GetFileNameWithoutExtension(p).ToUpper();
                wads.Add(wad);
            }

            cmbIWAD.DataSource = wads;
        }

        private void CaricaCFG()
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
                        cmbIWAD.SelectedItem = cmbIWAD.Items.Cast<PathName>().Where(p => p.path.Equals(value)).FirstOrDefault();
                    }
                    else
                    {
                        errors.Add("IWAD");
                    }
                    #endregion

                    #region PORT
                    if (cfg.TryGetValue("PORT", out value)) //cfg["PORT"]
                    {
                        cmbSourcePort.SelectedItem = cmbSourcePort.Items.Cast<PathName>().Where(p => p.path.Equals(value)).FirstOrDefault();
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

                    #region LOAD_SUBFOLDERS
                    if (cfg.TryGetValue("LOAD_SUBFOLDERS", out value)) //cfg["LOAD_SUBFOLDERS"]
                    {
                        SharedVar.LOAD_SUBFOLDERS = Convert.ToBoolean(value);
                    }
                    else
                    {
                        errors.Add("LOAD_SUBFOLDERS");
                        SharedVar.LOAD_SUBFOLDERS = false;
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

                    if (errors.Count > 0)
                    {
                        SavePreferences();
                        StringBuilder errorText = new StringBuilder();
                        errorText.AppendLine("The following settings could not be read from '" + cfgPreference + "' and have been resetted to the default value:");
                        foreach(string s in errors)
                        {
                            errorText.AppendLine("-" + s);
                        }
                        errorText.AppendLine("If you just upgraded to a new version and those settings are listed in the changelog, you can ignore this message.");
                        MessageBox.Show(errorText.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    cmb_vidrender.SelectedIndex = 5;
                    SharedVar.CHECK_FOR_UPDATE = true;
                    SharedVar.LOAD_SUBFOLDERS = false;
                    SharedVar.SHOW_END_MESSAGE = true;
                    SharedVar.SHOW_DELETE_MESSAGE = true;
                    SharedVar.SHOW_END_MESSAGE = true;
                    SharedVar.SHOW_SUCCESS_MESSAGE = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong while trying to load your preferences..." + Environment.NewLine + "Flags have been resetted to default value." + Environment.NewLine + "Error: \"" + ex.Message + "\"", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb_vidrender.SelectedIndex = 5;
                SharedVar.CHECK_FOR_UPDATE = true;
                SharedVar.LOAD_SUBFOLDERS = false;
                SharedVar.SHOW_END_MESSAGE = true;
                SharedVar.SHOW_DELETE_MESSAGE = true;
                SharedVar.SHOW_OVERWRITE_MESSAGE = true;
                SharedVar.SHOW_SUCCESS_MESSAGE = true;
            }
        }

        private void InitializeConfiguration()
        {
            try
            {
                fold_APPDATA = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                fold_P36SOFTWARE = Path.Combine(fold_APPDATA, @"P36_Software");
                fold_DMLv2 = Path.Combine(fold_P36SOFTWARE, @"DMLv2");
                foldPRESET = Path.Combine(fold_DMLv2, @"Presets");
                cfgPreference = Path.Combine(fold_DMLv2, @"DMLv2.ini");
                cfgIWAD = Path.Combine(fold_DMLv2, @"IWAD.ini");
                cfgPWAD = Path.Combine(fold_DMLv2, @"PWAD.ini");
                cfgPORT = Path.Combine(fold_DMLv2, @"PORT.ini");
                cfgPORT_CONFIG = Path.Combine(fold_DMLv2, @"PORT_CONFIG_PATH.ini");

                if (!Directory.Exists(fold_P36SOFTWARE))
                    Directory.CreateDirectory(fold_P36SOFTWARE);

                if (!Directory.Exists(fold_DMLv2))
                    Directory.CreateDirectory(fold_DMLv2);

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


            }
            catch (Exception ex)
            {
                StringBuilder errore = new StringBuilder();
                errore.AppendLine("Could not create a .cfg file or folder!");
                errore.AppendLine("Please check if your account have the permission to write in:");
                errore.AppendLine(@"""" + fold_APPDATA + @"""");
                errore.AppendLine();
                errore.AppendLine("Error Message:");
                errore.AppendLine(ex.Message);

                MessageBox.Show(errore.ToString(), "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                //Chex3 seems marked as PWAD while actually is a stand-alone game... so I just skip the bytes check
                if (Path.GetFileName(path).ToUpper().Equals("CHEX3.WAD"))
                {
                    return true;
                }
                else
                {
                    byte[] wadData = File.ReadAllBytes(path).Take(4).ToArray();
                    string s = Encoding.ASCII.GetString(wadData);
                    return s.Equals("IWAD") ? true : false;
                }
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

            //FULLSCREEN?
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

            //RENDERER
            if (cmb_vidrender.SelectedIndex != 5)
                parm.AppendFormat(" +vid_rendermode {0} ", cmb_vidrender.SelectedIndex);

            //CUSTOM COMMAND
            parm.Append(" " + txtCommandLine.Text + " ");
            return parm.ToString();

        }

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



        private void cmdRemovePreset_Click(object sender, EventArgs e)
        {
            PathName pn = (PathName)cmbPreset.SelectedItem;
            try
            {

                if (pn != null && !pn.name.Equals("-"))
                {
                    DialogResult ris = DialogResult.OK;
                    if (SharedVar.SHOW_DELETE_MESSAGE)
                    {
                        ris = MessageBox.Show("Are you sure you want to remove \"" + pn.name + "\""
                                          + Environment.NewLine
                                          + "(Path: \"" + pn.path + "\")"
                                          , "REMOVE " + pn.name.ToUpper(), MessageBoxButtons.OKCancel);
                    }
                    if (ris == DialogResult.OK)
                    {
                        File.Delete(pn.path);
                        CaricaPreset();
                    }

                }
            }
            catch (Exception Ex)
            {
                StringBuilder errore = new StringBuilder();
                errore.AppendLine("Something went wrong while trying to delete a preset...");
                errore.AppendLine("Please check if your account have the permission to write in:");
                errore.AppendLine(@"""" + pn.path + @"""");
                errore.AppendLine();
                errore.AppendLine("Error Message:");
                errore.AppendLine(Ex.Message);

                MessageBox.Show(errore.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SharedVar.SHOW_END_MESSAGE)
            {
                string[] EXIT_MESSAGES = new string[] {
                //DOOM
                "Please don't leave, there's more demons to toast!",
                "Let's beat it -- This is turning into a bloodbath!",
                "I wouldn't leave if I were you. DOS is much worse.",
                "You're trying to say you like DOS better than me, right?",
                "Don't leave yet -- There's a demon around that corner!",
                "Ya know, next time you come in here I'm gonna toast ya.",
                "Go ahead and leave. See if I care.",
                "Are you sure you want to quit this great game? ",
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

        private void SavePreferences()
        {
            try
            {
                Dictionary<string, string> preferences = new Dictionary<string, string>();
                Storage storage = new Storage(cfgPreference);

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

                //Video 2 2
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

                //fullscreen 1 3
                if (chkFullscreen.Checked)
                {
                    preferences.Add("FULLSCREEN", "TRUE");
                }
                else
                {
                    preferences.Add("FULLSCREEN", "FALSE");
                }


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


                preferences.Add("COMMANDLINE", txtCommandLine.Text);


                PathName iwad = (PathName)cmbIWAD.SelectedItem;


                PathName port = (PathName)cmbSourcePort.SelectedItem;

                if (iwad != null)
                {
                    preferences.Add("IWAD", iwad.path);
                }
                else
                {
                    preferences.Add("IWAD", "");
                }


                if (port != null)
                {
                    preferences.Add("PORT", port.path);
                }
                else
                {
                    preferences.Add("PORT", "");
                }

                preferences.Add("RENDERER", cmb_vidrender.SelectedIndex.ToString());

                preferences.Add("CHECK_FOR_UPDATE", SharedVar.CHECK_FOR_UPDATE.ToString().ToUpper());

                preferences.Add("LOAD_SUBFOLDERS", SharedVar.LOAD_SUBFOLDERS.ToString().ToUpper());

                preferences.Add("SHOW_END_MESSAGE", SharedVar.SHOW_END_MESSAGE.ToString().ToUpper());

                preferences.Add("SHOW_OVERWRITE_MESSAGE", SharedVar.SHOW_OVERWRITE_MESSAGE.ToString().ToUpper());

                preferences.Add("SHOW_SUCCESS_MESSAGE", SharedVar.SHOW_SUCCESS_MESSAGE.ToString().ToUpper());

                preferences.Add("SHOW_DELETE_MESSAGE", SharedVar.SHOW_DELETE_MESSAGE.ToString().ToUpper());

                preferences.Add("USE_ADVANCED_SELECTION_MODE", SharedVar.USE_ADVANCED_SELECTION_MODE.ToString().ToUpper());

                storage.SaveValues(preferences, true);
            }
            catch (Exception ex)
            {
                StringBuilder errore = new StringBuilder();
                errore.AppendLine("Something went wrong while trying to save your preference...");
                errore.AppendLine("Please check if your account have the permission to write in:");
                errore.AppendLine(@"""" + cfgPreference + @"""");
                errore.AppendLine();
                errore.AppendLine("Error Message:");
                errore.AppendLine(ex.Message);

                MessageBox.Show(errore.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckUpdate(bool start = false)
        {
            try
            {
                VersionForm vf = new VersionForm();
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
            catch (Exception ex)
            {
                MessageBox.Show("Could not get the latest version info..." + Environment.NewLine +
                                "Please check your internet connection...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        #endregion

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options options = new Options(cfgPreference);
            options.ShowDialog();
            if (SharedVar.USE_ADVANCED_SELECTION_MODE)
            {
                lstPWAD.SelectionMode = SelectionMode.MultiExtended;
            } else
            {
                lstPWAD.SelectionMode = SelectionMode.MultiSimple;
            }
        }
    }
}