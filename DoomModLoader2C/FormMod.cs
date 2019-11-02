using DoomModLoader2.Entity;
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


        private string files;
        private PathName IWAD;

        private string presetPath;
        public FormMod(string _presetPath, PathName _IWAD)
        {
            InitializeComponent();
            presetPath = _presetPath;
            IWAD = _IWAD;
            this.Text += " - DML v" + SharedVar.LOCAL_VERSION;
            StringBuilder txtCheckBox = new StringBuilder();
            txtCheckBox.AppendFormat(chkSaveIWAD.Text,IWAD.name);
            chkSaveIWAD.Text = txtCheckBox.ToString();
        }



        private void FormMod_Load(object sender, EventArgs e)
        {
            
            pwads = pwads.OrderBy(P => P.loadOrder).ToList();
            lstPwad.DataSource = pwads;
            txtPresetName.Text = presetName;
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
            files = "";
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
                        if (chkSaveIWAD.Checked)
                        {
                            values.Add("-1", IWAD.name);
                        }
                        foreach (PathName p in lstPwad.Items)
                        {
                            values.Add(C.ToString(), p.name);
                            C++;
                        }

                        storage.SaveValues(values, true);
                        txtPresetName.Text = name;
                        presetName = name;
                        if (SharedVar.SHOW_SUCCESS_MESSAGE)
                            MessageBox.Show("Preset '" + name + "' has been saved.", "DML", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong while tryng to save your mod preset..." + Environment.NewLine +
                                "ERROR: \"" + ex.Message + "\"" + Environment.NewLine +
                                "Please try again", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
