﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace DoomModLoader2
{
    public partial class WelcomeForm : Form
    {
        public bool agreeTOS = false;
        public WelcomeForm()
        {
            InitializeComponent();
        }


        private void WelcomeForm_Load(object sender, EventArgs e)
        {
            this.Text += "v" + SharedVar.LOCAL_VERSION;
        }

        private void textBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void btnAgree_Click(object sender, EventArgs e)
        {
            agreeTOS = true;
            this.Close();
        }
    }
}

