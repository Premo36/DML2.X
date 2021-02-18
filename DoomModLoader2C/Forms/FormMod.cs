// Copyright (c) 2016 - 2021, Matteo Premoli (P36 Software)
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
using DoomModLoader2.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace DoomModLoader2
{

    /// <summary>
    /// Form used to change mod load order
    /// </summary>
    public partial class FormMod : Form
    {
        public string presetName;
        public string parameters;
        public List<PathName> pwads;
        public PathName sourcePort;

        private PathName IWAD { get; }
        private PathName config { get; }
        private string presetPath { get; }
        private KeyValuePair<int, string> renderer;
        private List<string> saveWithPreset;
        private string commandLine { get; }
        public FormMod(string presetPath, PathName IWAD, KeyValuePair<int, string> renderer, PathName config, List<string> saveWithPreset, string commandLine, string parameters)
        {
            InitializeComponent();
            this.presetPath = presetPath;
            this.config = config;
            this.IWAD = IWAD;
            this.renderer = renderer;
            this.saveWithPreset = saveWithPreset;
            this.commandLine = commandLine.Trim();
            this.parameters = parameters;
            this.Text += " - DML v" + SharedVar.LOCAL_VERSION;

        }



        private void FormMod_Load(object sender, EventArgs e)
        {
            pwads = pwads.OrderBy(P => P.loadOrder).ToList();
            lstPwad.DataSource = pwads;

            UpdatePresetNameLabel(presetName);

        }



        private void cmdUp_Click(object sender, EventArgs e)
        {
            MoveModUp();
        }

        private void cmdDown_Click(object sender, EventArgs e)
        {
            MoveModDown();
        }

        /// <summary>
        /// Launch the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdPlay_Click(object sender, EventArgs e)
        {
            string files = string.Empty;
            foreach (PathName p in lstPwad.Items)
            {
                if (Path.GetExtension(p.path).ToUpper().Equals(".DEH"))
                {
                    files += "-deh \"" + p.path + "\" ";
                }
                else
                {
                    files += "-file \"" + p.path + "\" ";
                }
            }

            files = parameters + " " + files;
            Process.Start(sourcePort.path, files);

        }

        /// <summary>
        /// Open the "SavePresetForm" dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSavePreset_Click(object sender, EventArgs e)
        {
            SavePresetForm savePresetForm = new SavePresetForm(presetPath, config, IWAD, sourcePort, renderer, saveWithPreset, commandLine, lstPwad.Items.Cast<PathName>().ToList(), presetName);
            savePresetForm.ShowDialog();
            presetName = savePresetForm.presetName;
            saveWithPreset = savePresetForm.saveWithPreset;
            UpdatePresetNameLabel(presetName);
            if (savePresetForm.play)
            {
                cmdPlay_Click(null, null);
            }
        }

        /// <summary>
        /// Update the "lblPresetName" label text with the name of the preset.<br></br>
        /// If the currents mods are not already saved in one, an hint about how to save it will be shown instead.
        /// </summary>
        /// <param name="presetName"></param>
        private void UpdatePresetNameLabel(string presetName)
        {
            if (presetName != null && presetName.Trim() != string.Empty)
            {
                lblPresetName.Text = presetName;
            }
            else
            {
                lblPresetName.Text = "(You can save the current mod list in a preset by clicking on \"SAVE PRESET\")";
            }
        }

        private void cmdRemove_Click(object sender, EventArgs e)
        {
            Remove();
        }

    

        private void lstPwad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                MoveModUp();
            }

            if (e.KeyCode == Keys.Down)
            {
                MoveModDown();
            }

            if (e.KeyCode == Keys.Delete)
            {

                Remove();
            }

            e.Handled = true;
        }

        private void MoveModUp()
        {
            int i = lstPwad.SelectedIndex;
            if (i > 0)
            {

                List<PathName> lst = lstPwad.Items.Cast<PathName>().ToList();

                var y = lst[i];
                lst[i] = lst[i - 1];
                lst[i - 1] = y;

                lstPwad.DataSource = lst;
                lstPwad.DisplayMember = "name";

                lstPwad.SelectedItem = y;

                pwads = lst;
            }
            else
            {
                SystemSounds.Beep.Play();
            }
        }

        private void MoveModDown()
        {

            int i = lstPwad.SelectedIndex;
            if (i < lstPwad.Items.Count - 1)
            {

                List<PathName> lst = lstPwad.Items.Cast<PathName>().ToList();

                var y = lst[i];
                lst[i] = lst[i + 1];
                lst[i + 1] = y;

                lstPwad.DataSource = lst;
                lstPwad.DisplayMember = "name";

                lstPwad.SelectedItem = y;

                pwads = lst;
            }
            else
            {
                SystemSounds.Beep.Play();
            }
        }

        private void Remove()
        {
            pwads.RemoveAll(P => P.path == ((PathName)lstPwad.SelectedItem).path);

            lstPwad.SelectedItem = null;
            lstPwad.DataSource = null;


            lstPwad.DataSource = pwads;
            lstPwad.DisplayMember = "name";

            if(lstPwad.SelectedIndex < 0)
            {
                lstPwad.SelectedIndex = lstPwad.Items.Count - 1;
            }

        }



    }
}
