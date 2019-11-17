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

namespace DoomModLoader2.Forms
{
    public partial class SavePresetForm : Form
    {
        private PathName IWAD;
        private PathName config;
        private string presetPath;
        private KeyValuePair<int, string> renderer;
        private string commandLine;
        private PathName sourcePort;
        private List<PathName> pwads;
        private List<string> saveWithPresetBackup;
        private bool isUpdate = true;

        public List<string> saveWithPreset;
        public string presetName;
        public bool play;

        public SavePresetForm(string presetPath,
                              PathName config,
                              PathName IWAD,
                              PathName sourcePort,
                              KeyValuePair<int, string> renderer,
                              List<string> saveWithPreset,
                              string commandLine,
                              List<PathName> pwads,
                              string presetName
                             )
        {
            InitializeComponent();
            this.Text += " - DML v" + SharedVar.LOCAL_VERSION;
            this.presetPath = presetPath;
            this.config = config;
            this.IWAD = IWAD;
            this.renderer = renderer;
            this.saveWithPreset = saveWithPreset;
            this.commandLine = commandLine.Trim();
            this.pwads = pwads;
            this.sourcePort = sourcePort;
            this.presetName = presetName;
            txtPresetName.Text = presetName;

            if (presetName == null || presetName.Trim() == string.Empty)
            {
                cmdSavePreset.Visible = false;
                cmdSavePlay.Text = "SAVE AND PLAY";
                isUpdate = false;
            }

            saveWithPresetBackup = saveWithPreset;
        }

        private void cmdSavePreset_Click(object sender, EventArgs e)
        {
            Save(true);
        }

        private void cmdSaveNew_Click(object sender, EventArgs e)
        {
            Save(false);
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {

            saveWithPreset = saveWithPresetBackup;
            this.Close();
        }

        private void cmdSavePlay_Click(object sender, EventArgs e)
        {
           
            play = Save(isUpdate);
        }

        private void SavePresetForm_Load(object sender, EventArgs e)
        {
            txtPresetName.Text = presetName;

            StringBuilder txtReplacer = new StringBuilder();
            txtReplacer.AppendFormat(chkSaveIWAD.Text, IWAD.name);
            chkSaveIWAD.Text = txtReplacer.ToString();
            chkSaveIWAD.Checked = saveWithPreset.Any(X => X == "IWAD");

            txtReplacer = new StringBuilder();
            txtReplacer.AppendFormat(chkPORT.Text, sourcePort.name);
            chkPORT.Text = txtReplacer.ToString();
            chkPORT.Checked = saveWithPreset.Any(X => X == "PORT");

            txtReplacer = new StringBuilder();
            txtReplacer.AppendFormat(chkRenderer.Text, renderer.Value);
            chkRenderer.Text = txtReplacer.ToString();
            chkRenderer.Checked = saveWithPreset.Any(X => X == "RENDERER");

            if (config != null)
            {
                txtReplacer = new StringBuilder();
                txtReplacer.AppendFormat(chkConfiguration.Text, config.name);
                chkConfiguration.Text = txtReplacer.ToString();
                chkConfiguration.Checked = saveWithPreset.Any(X => X == "PORT_CONFIG");
            }
            else
            {
                chkConfiguration.Enabled = false;
                chkConfiguration.Text = "CONFIGURATION: NONE";
            }


            if (commandLine != null && commandLine != string.Empty)
            {
                txtReplacer = new StringBuilder();
                txtReplacer.AppendFormat(chkCommand.Text, commandLine);
                chkCommand.Text = txtReplacer.ToString();
                chkCommand.Checked = saveWithPreset.Any(X => X == "COMMANDLINE");
            }
            else
            {
                chkCommand.Enabled = false;
                chkCommand.Text = "COMMANDLINE: NONE";
            }


        }

        private bool Save(bool update)
        {
            try
            {

                string name = txtPresetName.Text;
                if (name.Length > 0)
                {
                    name = string.Join("_", name.Split(Path.GetInvalidFileNameChars()));
                    if (name.ToUpper().Equals("-"))
                    {
                        txtPresetName.Text = "";
                        throw new Exception("'-' is not a valid name!");

                    }

                    string path = Path.Combine(presetPath, name + ".dml");
                    DialogResult answer = DialogResult.Yes;

                    //If i've changed the preset name, and there is already a preset with the same name, if the user want this kind of message to be displayed, it will get a warning.
                    if (File.Exists(path))
                    {
                        if (!name.ToUpper().Equals(presetName.ToUpper()) && SharedVar.SHOW_OVERWRITE_MESSAGE)
                        {
                            answer = MessageBox.Show("A preset named '" + Path.GetFileNameWithoutExtension(path) + "' already exists." + Environment.NewLine +
                                                     "Do you want to overwrite it?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        }
                    }


                    if (answer == DialogResult.Yes)
                    {

                        FileStream f = File.Create(path);
                        f.Dispose();
                        Storage storage = new Storage(path);
                        Dictionary<string, string> values = new Dictionary<string, string>();
                        int C = 0;
                
                           
                        saveWithPreset.Clear();
                        #region IWAD
                        if (chkSaveIWAD.Checked)
                        {
                            values.Add("IWAD", IWAD.name);
                            saveWithPreset.Add("IWAD");
                        }
                        else
                        {
                            values.Add("IWAD", string.Empty);
                           
                        }
                        #endregion

                        #region PORT
                        if (chkPORT.Checked)
                        {
                            values.Add("PORT", sourcePort.name);
                            saveWithPreset.Add("PORT");
                        }
                        else
                        {
                            values.Add("PORT", string.Empty);
                        }
                        #endregion

                        #region PORT_CONFIG
                        if (chkConfiguration.Checked)
                        {
                            values.Add("PORT_CONFIG", config.name);
                            saveWithPreset.Add("PORT_CONFIG");
                        }
                        else
                        {
                            values.Add("PORT_CONFIG", string.Empty);
                        }
                        #endregion

                        #region RENDERER
                        if (chkRenderer.Checked)
                        {
                            values.Add("RENDERER", renderer.Key.ToString());
                            saveWithPreset.Add("RENDERER");
                        }
                        else
                        {
                            values.Add("RENDERER", string.Empty);
                        }
                        #endregion

                        #region COMMANDLINE
                        if (chkCommand.Checked)
                        {
                            values.Add("COMMANDLINE", commandLine);
                            saveWithPreset.Add("COMMANDLINE");
                        }
                        else
                        {
                            values.Add("COMMANDLINE", string.Empty);
                        }
                        #endregion

                        foreach (PathName p in pwads)
                        {
                            values.Add(C.ToString(), p.name);
                            C++;
                        }

                        storage.SaveValues(values, true);

                        //If the user have changed the preset name, i delete the original preset
                        if (update == true && presetName != null && !name.ToUpper().Equals(presetName.ToUpper()))
                        {
                            string originalPresetPath = Path.Combine(presetPath, presetName + ".dml");
                            if (File.Exists(originalPresetPath))
                            {
                                File.Delete(originalPresetPath);
                            }
                        }

                        txtPresetName.Text = name;
                        presetName = name;
                        if (SharedVar.SHOW_SUCCESS_MESSAGE)
                        {
                            MessageBox.Show("Preset '" + name + "' has been saved.", "DML", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           
                        }
                        this.Close();
                        return true;
                    } else
                    {
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a preset name.", $"DML v{SharedVar.LOCAL_VERSION}" , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong while tryng to save your mod preset..." + Environment.NewLine +
                                "ERROR: \"" + ex.Message + "\"" + Environment.NewLine +
                                "Please try again", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    
    }
}
