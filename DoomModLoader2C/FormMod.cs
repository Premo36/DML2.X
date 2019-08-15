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
        
        private string presetPath;
        public FormMod(string _presetPath)
        {
            InitializeComponent();
            presetPath = _presetPath;
            this.Text += " - DML v" + SharedVar.LOCAL_VERSION;
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
            //parameters += "";
            foreach (PathName p in lstPwad.Items)
            {
                if (Path.GetExtension(p.path).ToUpper().Equals(".DEH"))
                {
                    parameters += "-deh \"" + p.path + "\" ";
                }
                else
                {
                    parameters += "-file \"" + p.path + "\" ";
                }
            }
            Process.Start(sourcePort.path, parameters);

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
                        answer = MessageBox.Show("A preset named '" + Path.GetFileNameWithoutExtension(path) + "' already exists." + Environment.NewLine +
                                                 "Do you want to overwrite it?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    }

                    if (answer == DialogResult.Yes)
                    {
                        FileStream f = File.Create(path);
                        f.Dispose();
                        Storage storage = new Storage(path);
                        Dictionary<string, string> values = new Dictionary<string, string>();
                        int C = 0;
                        foreach (PathName p in lstPwad.Items)
                        { 
                            values.Add(C.ToString(), p.path);
                            C++;
                        }

                        storage.SaveValues(values, true);
                        txtPresetName.Text = name;
                        presetName = name;
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
