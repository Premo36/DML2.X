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
    public partial class FormMod : Form
    {
        public string presetName;
        //TODO: Make all properties private and initialize them trough the constructor
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
            int i = lstPwad.SelectedIndex;
            if (i > 0)
            {

                List<PathName> lst = lstPwad.Items.Cast<PathName>().ToList();

                var y = lst[i];
                lst[i] = lst[i - 1];
                lst[i - 1] = y;

                lstPwad.DataSource = lst;

                lstPwad.SelectedItem = y;
            }
            else
            {
                SystemSounds.Beep.Play();
            }

        }

        private void cmdDown_Click(object sender, EventArgs e)
        {
            int i = lstPwad.SelectedIndex;
            if (i < lstPwad.Items.Count - 1)
            {

                List<PathName> lst = lstPwad.Items.Cast<PathName>().ToList();

                var y = lst[i];
                lst[i] = lst[i + 1];
                lst[i + 1] = y;

                lstPwad.DataSource = lst;

                lstPwad.SelectedItem = y;
            }
            else
            {
                SystemSounds.Beep.Play();
            }
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
    }
}
