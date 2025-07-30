namespace DoomModLoader2
{
    partial class FormMod
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmdUp = new System.Windows.Forms.Button();
            this.cmdDown = new System.Windows.Forms.Button();
            this.cmdPlay = new System.Windows.Forms.Button();
            this.lstPwad = new System.Windows.Forms.ListBox();
            this.PathNameSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmdSavePreset = new System.Windows.Forms.Button();
            this.lblPresetName = new System.Windows.Forms.Label();
            this.cmdRemove = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PathNameSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdUp
            // 
            this.cmdUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdUp.Location = new System.Drawing.Point(411, 42);
            this.cmdUp.Name = "cmdUp";
            this.cmdUp.Size = new System.Drawing.Size(176, 46);
            this.cmdUp.TabIndex = 1;
            this.cmdUp.Text = "UP";
            this.toolTip1.SetToolTip(this.cmdUp, "Hold \"CTRL\" while clicking to push the selected mod to the top of the list");
            this.cmdUp.UseVisualStyleBackColor = true;
            this.cmdUp.Click += new System.EventHandler(this.cmdUp_Click);
            // 
            // cmdDown
            // 
            this.cmdDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDown.Location = new System.Drawing.Point(411, 94);
            this.cmdDown.Name = "cmdDown";
            this.cmdDown.Size = new System.Drawing.Size(176, 46);
            this.cmdDown.TabIndex = 2;
            this.cmdDown.Text = "DOWN";
            this.toolTip1.SetToolTip(this.cmdDown, "Hold \"CTRL\" while clicking to push the selected mod to the bottom of the list");
            this.cmdDown.UseVisualStyleBackColor = true;
            this.cmdDown.Click += new System.EventHandler(this.cmdDown_Click);
            // 
            // cmdPlay
            // 
            this.cmdPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 33.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPlay.Location = new System.Drawing.Point(12, 304);
            this.cmdPlay.Name = "cmdPlay";
            this.cmdPlay.Size = new System.Drawing.Size(575, 61);
            this.cmdPlay.TabIndex = 0;
            this.cmdPlay.Text = "PLAY";
            this.cmdPlay.UseVisualStyleBackColor = true;
            this.cmdPlay.Click += new System.EventHandler(this.cmdPlay_Click);
            // 
            // lstPwad
            // 
            this.lstPwad.DataSource = this.PathNameSource;
            this.lstPwad.DisplayMember = "name";
            this.lstPwad.FormattingEnabled = true;
            this.lstPwad.Location = new System.Drawing.Point(12, 42);
            this.lstPwad.Name = "lstPwad";
            this.lstPwad.Size = new System.Drawing.Size(393, 251);
            this.lstPwad.TabIndex = 3;
            this.lstPwad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstPwad_KeyDown);
            // 
            // PathNameSource
            // 
            this.PathNameSource.DataSource = typeof(DoomModLoader2.Entity.PathName);
            // 
            // cmdSavePreset
            // 
            this.cmdSavePreset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSavePreset.Location = new System.Drawing.Point(411, 236);
            this.cmdSavePreset.Name = "cmdSavePreset";
            this.cmdSavePreset.Size = new System.Drawing.Size(176, 43);
            this.cmdSavePreset.TabIndex = 3;
            this.cmdSavePreset.Text = "SAVE PRESET...";
            this.cmdSavePreset.UseVisualStyleBackColor = true;
            this.cmdSavePreset.Click += new System.EventHandler(this.cmdSavePreset_Click);
            // 
            // lblPresetName
            // 
            this.lblPresetName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPresetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPresetName.Location = new System.Drawing.Point(0, 0);
            this.lblPresetName.Name = "lblPresetName";
            this.lblPresetName.Size = new System.Drawing.Size(599, 39);
            this.lblPresetName.TabIndex = 4;
            this.lblPresetName.Text = "PRESET NAME HERE";
            this.lblPresetName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdRemove
            // 
            this.cmdRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRemove.Location = new System.Drawing.Point(411, 156);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(176, 43);
            this.cmdRemove.TabIndex = 5;
            this.cmdRemove.Text = "REMOVE";
            this.cmdRemove.UseVisualStyleBackColor = true;
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // FormMod
            // 
            this.AcceptButton = this.cmdPlay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 377);
            this.Controls.Add(this.cmdRemove);
            this.Controls.Add(this.lblPresetName);
            this.Controls.Add(this.cmdSavePreset);
            this.Controls.Add(this.cmdPlay);
            this.Controls.Add(this.lstPwad);
            this.Controls.Add(this.cmdDown);
            this.Controls.Add(this.cmdUp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMod";
            this.Text = "Mod Loading Order";
            this.Load += new System.EventHandler(this.FormMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PathNameSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdUp;
        private System.Windows.Forms.Button cmdDown;
        private System.Windows.Forms.Button cmdPlay;
        private System.Windows.Forms.ListBox lstPwad;
        private System.Windows.Forms.BindingSource PathNameSource;
        private System.Windows.Forms.Button cmdSavePreset;
        private System.Windows.Forms.Label lblPresetName;
        private System.Windows.Forms.Button cmdRemove;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}