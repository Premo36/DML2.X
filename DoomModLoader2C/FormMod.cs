using DoomModLoader2.Entity;
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
        public string parameters;
        public List<PathName> pwads;
        public PathName sourcePort;

        public FormMod()
        {
            InitializeComponent();
        }



        private void FormMod_Load(object sender, EventArgs e)
        {
            lstPwad.DataSource = pwads;
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
                if (Path.GetExtension(p.path).ToUpper().Equals(".DEH")) {
                    parameters += "-deh \"" + p.path + "\" ";
                }
                else
                {
                    parameters += "-file \"" + p.path + "\" ";
                }
            }
            Process.Start(sourcePort.path, parameters);

        }
    }
}
