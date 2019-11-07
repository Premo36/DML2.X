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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMod));
            this.cmdUp = new System.Windows.Forms.Button();
            this.cmdDown = new System.Windows.Forms.Button();
            this.cmdPlay = new System.Windows.Forms.Button();
            this.lstPwad = new System.Windows.Forms.ListBox();
            this.PathNameSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmdSavePreset = new System.Windows.Forms.Button();
            this.txtPresetName = new System.Windows.Forms.TextBox();
            this.chkSaveIWAD = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkConfiguration = new System.Windows.Forms.CheckBox();
            this.chkRenderer = new System.Windows.Forms.CheckBox();
            this.chkPORT = new System.Windows.Forms.CheckBox();
            this.chkCommand = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.PathNameSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdUp
            // 
            this.cmdUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdUp.Location = new System.Drawing.Point(411, 24);
            this.cmdUp.Name = "cmdUp";
            this.cmdUp.Size = new System.Drawing.Size(176, 46);
            this.cmdUp.TabIndex = 0;
            this.cmdUp.Text = "UP";
            this.cmdUp.UseVisualStyleBackColor = true;
            this.cmdUp.Click += new System.EventHandler(this.cmdUp_Click);
            // 
            // cmdDown
            // 
            this.cmdDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDown.Location = new System.Drawing.Point(411, 76);
            this.cmdDown.Name = "cmdDown";
            this.cmdDown.Size = new System.Drawing.Size(176, 46);
            this.cmdDown.TabIndex = 1;
            this.cmdDown.Text = "DOWN";
            this.cmdDown.UseVisualStyleBackColor = true;
            this.cmdDown.Click += new System.EventHandler(this.cmdDown_Click);
            // 
            // cmdPlay
            // 
            this.cmdPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 33.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPlay.Location = new System.Drawing.Point(12, 448);
            this.cmdPlay.Name = "cmdPlay";
            this.cmdPlay.Size = new System.Drawing.Size(575, 61);
            this.cmdPlay.TabIndex = 2;
            this.cmdPlay.Text = "PLAY";
            this.cmdPlay.UseVisualStyleBackColor = true;
            this.cmdPlay.Click += new System.EventHandler(this.cmdPlay_Click);
            // 
            // lstPwad
            // 
            this.lstPwad.DataSource = this.PathNameSource;
            this.lstPwad.DisplayMember = "name";
            this.lstPwad.FormattingEnabled = true;
            this.lstPwad.Location = new System.Drawing.Point(12, 12);
            this.lstPwad.Name = "lstPwad";
            this.lstPwad.Size = new System.Drawing.Size(393, 212);
            this.lstPwad.TabIndex = 3;
            // 
            // PathNameSource
            // 
            this.PathNameSource.DataSource = typeof(DoomModLoader2.Entity.PathName);
            // 
            // cmdSavePreset
            // 
            this.cmdSavePreset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSavePreset.Location = new System.Drawing.Point(6, 19);
            this.cmdSavePreset.Name = "cmdSavePreset";
            this.cmdSavePreset.Size = new System.Drawing.Size(167, 43);
            this.cmdSavePreset.TabIndex = 4;
            this.cmdSavePreset.Text = "SAVE PRESET";
            this.cmdSavePreset.UseVisualStyleBackColor = true;
            this.cmdSavePreset.Click += new System.EventHandler(this.cmdSavePreset_Click);
            // 
            // txtPresetName
            // 
            this.txtPresetName.Location = new System.Drawing.Point(179, 32);
            this.txtPresetName.Name = "txtPresetName";
            this.txtPresetName.Size = new System.Drawing.Size(390, 20);
            this.txtPresetName.TabIndex = 5;
            // 
            // chkSaveIWAD
            // 
            this.chkSaveIWAD.AutoSize = true;
            this.chkSaveIWAD.Location = new System.Drawing.Point(6, 19);
            this.chkSaveIWAD.Name = "chkSaveIWAD";
            this.chkSaveIWAD.Size = new System.Drawing.Size(79, 17);
            this.chkSaveIWAD.TabIndex = 6;
            this.chkSaveIWAD.Text = "IWAD: \'{0}\'";
            this.chkSaveIWAD.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.cmdSavePreset);
            this.groupBox1.Controls.Add(this.txtPresetName);
            this.groupBox1.Location = new System.Drawing.Point(12, 230);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(575, 212);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Save preset";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkCommand);
            this.groupBox2.Controls.Add(this.chkConfiguration);
            this.groupBox2.Controls.Add(this.chkRenderer);
            this.groupBox2.Controls.Add(this.chkPORT);
            this.groupBox2.Controls.Add(this.chkSaveIWAD);
            this.groupBox2.Location = new System.Drawing.Point(6, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(563, 138);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Save also:";
            // 
            // chkConfiguration
            // 
            this.chkConfiguration.AutoSize = true;
            this.chkConfiguration.Location = new System.Drawing.Point(6, 88);
            this.chkConfiguration.Name = "chkConfiguration";
            this.chkConfiguration.Size = new System.Drawing.Size(139, 17);
            this.chkConfiguration.TabIndex = 9;
            this.chkConfiguration.Text = "CONFIGURATION: \'{0}\'";
            this.chkConfiguration.UseVisualStyleBackColor = true;
            // 
            // chkRenderer
            // 
            this.chkRenderer.AutoSize = true;
            this.chkRenderer.Location = new System.Drawing.Point(6, 65);
            this.chkRenderer.Name = "chkRenderer";
            this.chkRenderer.Size = new System.Drawing.Size(111, 17);
            this.chkRenderer.TabIndex = 8;
            this.chkRenderer.Text = "RENDERER: \'{0}\'";
            this.chkRenderer.UseVisualStyleBackColor = true;
            // 
            // chkPORT
            // 
            this.chkPORT.AutoSize = true;
            this.chkPORT.Location = new System.Drawing.Point(6, 42);
            this.chkPORT.Name = "chkPORT";
            this.chkPORT.Size = new System.Drawing.Size(125, 17);
            this.chkPORT.TabIndex = 7;
            this.chkPORT.Text = "SOURCEPORT: \'{0}\'";
            this.chkPORT.UseVisualStyleBackColor = true;
            // 
            // chkCommand
            // 
            this.chkCommand.AutoSize = true;
            this.chkCommand.Location = new System.Drawing.Point(6, 111);
            this.chkCommand.Name = "chkCommand";
            this.chkCommand.Size = new System.Drawing.Size(133, 17);
            this.chkCommand.TabIndex = 10;
            this.chkCommand.Text = "COMMAND LINE: \'{0}\'";
            this.chkCommand.UseVisualStyleBackColor = true;
            // 
            // FormMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 521);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lstPwad);
            this.Controls.Add(this.cmdPlay);
            this.Controls.Add(this.cmdDown);
            this.Controls.Add(this.cmdUp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMod";
            this.Text = "Mod Loading Order";
            this.Load += new System.EventHandler(this.FormMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PathNameSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdUp;
        private System.Windows.Forms.Button cmdDown;
        private System.Windows.Forms.Button cmdPlay;
        private System.Windows.Forms.ListBox lstPwad;
        private System.Windows.Forms.BindingSource PathNameSource;
        private System.Windows.Forms.Button cmdSavePreset;
        private System.Windows.Forms.TextBox txtPresetName;
        private System.Windows.Forms.CheckBox chkSaveIWAD;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkConfiguration;
        private System.Windows.Forms.CheckBox chkRenderer;
        private System.Windows.Forms.CheckBox chkPORT;
        private System.Windows.Forms.CheckBox chkCommand;
    }
}