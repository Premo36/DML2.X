using DoomModLoader2.Entity;
using DoomModLoader2.Forms;
using P36_UTILITIES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
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


        //private string files { get; set; }
        private PathName IWAD;
        private PathName config;
        private string presetPath;
        private KeyValuePair<int, string> renderer;
        private List<string> saveWithPreset;
        private string commandLine;
        public FormMod(string presetPath, PathName IWAD, KeyValuePair<int, string> renderer, PathName config, List<string> saveWithPreset, string commandLine)
        {
            InitializeComponent();
            this.presetPath = presetPath;
            this.config = config;
            this.IWAD = IWAD;
            this.renderer = renderer;
            this.saveWithPreset = saveWithPreset;
            this.commandLine = commandLine.Trim();
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

        private void UpdatePresetNameLabel(string presetName)
        {
            if (presetName != null && presetName.Trim() != string.Empty)
            {
                lblPresetName.Text = $"LOADED PRESET: {presetName}";
            }
            else
            {
                lblPresetName.Text = "LOADED PRESET: NONE (You can save the current mod list in a preset by clicking on \"SAVE PRESET\"";
            }
        }
    }
}
