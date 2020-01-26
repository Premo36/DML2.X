// Copyright (c) 2016 - 2020, Matteo Premoli (P36 Software)
// All rights reserved.

#region LICENSE
/*
    BSD 4-Clause License
    
    Copyright (c) 2016 - 2020, Matteo Premoli (P36 Software)
    All rights reserved.
    
    Redistribution and use in source and binary forms, with or without
    modification, are permitted provided that the following conditions are met:
    
    1. Redistributions of source code must retain the above copyright notice, this
       list of conditions and the following disclaimer.
    
    2. Redistributions in binary form must reproduce the above copyright notice,
       this list of conditions and the following disclaimer in the documentation
       and/or other materials provided with the distribution.
    
    3. All advertising materials mentioning features or use of this software must
       display the following acknowledgement:
         This product includes software developed by P36 Software.
    
    4. Neither the name of the copyright holder nor the names of its
       contributors may be used to endorse or promote products derived from
       this software without specific prior written permission.
    
    THIS SOFTWARE IS PROVIDED BY COPYRIGHT HOLDER "AS IS" AND ANY EXPRESS OR
    IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF
    MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO
    EVENT SHALL COPYRIGHT HOLDER BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
    SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
    PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS;
    OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,
    WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR
    OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF
    ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
#endregion

using DoomModLoader2.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DoomModLoader2.Forms
{
    /// <summary>
    /// Form used to create/update presets
    /// </summary>
    public partial class SavePresetForm : Form
    {
        private PathName IWAD { get; }
        private PathName config { get; }
        private string presetPath { get; }
        private KeyValuePair<int, string> renderer { get; }
        private string commandLine { get; }
        private PathName sourcePort { get; }
        private List<PathName> pwads { get; }
        private List<string> saveWithPresetBackup { get; }
        private bool isUpdate { get; } = true;

        public List<string> saveWithPreset;
        public string presetName;
        public bool play;

        /// <summary>
        /// Initialize the save preset form.
        /// </summary>
        /// <param name="presetPath"></param>
        /// <param name="config"></param>
        /// <param name="IWAD"></param>
        /// <param name="sourcePort"></param>
        /// <param name="renderer"></param>
        /// <param name="saveWithPreset"></param>
        /// <param name="commandLine"></param>
        /// <param name="pwads"></param>
        /// <param name="presetName"></param>
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

        /// <summary>
        /// Save the preset, replacing the old one. (Like a "Save" button)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSavePreset_Click(object sender, EventArgs e)
        {
            Save(true);
        }

        /// <summary>
        /// Save the preset, keeping the old one. (Like a "Save As..." button)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Save the preset. If update = true it will replace the old file.
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
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
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a preset name.", $"DML v{SharedVar.LOCAL_VERSION}", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
