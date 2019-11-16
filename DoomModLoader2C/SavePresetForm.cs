using DoomModLoader2.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DoomModLoader2
{
    

    public partial class SavePresetForm : Form
    {
        public DTO_SavePreset saveDTO;
        
        public SavePresetForm()
        {
            InitializeComponent();
            saveDTO = new DTO_SavePreset();
        }

        private void SavePresetForm_Load(object sender, EventArgs e)
        {
          
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {

        }
    }
}
