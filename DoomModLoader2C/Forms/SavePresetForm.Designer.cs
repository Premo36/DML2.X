namespace DoomModLoader2.Forms
{
    partial class SavePresetForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkCommand = new System.Windows.Forms.CheckBox();
            this.chkConfiguration = new System.Windows.Forms.CheckBox();
            this.chkRenderer = new System.Windows.Forms.CheckBox();
            this.chkPORT = new System.Windows.Forms.CheckBox();
            this.chkSaveIWAD = new System.Windows.Forms.CheckBox();
            this.cmdSavePreset = new System.Windows.Forms.Button();
            this.txtPresetName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdSaveNew = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdSavePlay = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkCommand);
            this.groupBox2.Controls.Add(this.chkConfiguration);
            this.groupBox2.Controls.Add(this.chkRenderer);
            this.groupBox2.Controls.Add(this.chkPORT);
            this.groupBox2.Controls.Add(this.chkSaveIWAD);
            this.groupBox2.Location = new System.Drawing.Point(12, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(513, 138);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Save also:";
            // 
            // chkCommand
            // 
            this.chkCommand.AutoSize = true;
            this.chkCommand.Location = new System.Drawing.Point(6, 111);
            this.chkCommand.Name = "chkCommand";
            this.chkCommand.Size = new System.Drawing.Size(133, 17);
            this.chkCommand.TabIndex = 5;
            this.chkCommand.Text = "COMMAND LINE: \'{0}\'";
            this.chkCommand.UseVisualStyleBackColor = true;
            // 
            // chkConfiguration
            // 
            this.chkConfiguration.AutoSize = true;
            this.chkConfiguration.Location = new System.Drawing.Point(6, 88);
            this.chkConfiguration.Name = "chkConfiguration";
            this.chkConfiguration.Size = new System.Drawing.Size(139, 17);
            this.chkConfiguration.TabIndex = 4;
            this.chkConfiguration.Text = "CONFIGURATION: \'{0}\'";
            this.chkConfiguration.UseVisualStyleBackColor = true;
            // 
            // chkRenderer
            // 
            this.chkRenderer.AutoSize = true;
            this.chkRenderer.Location = new System.Drawing.Point(6, 65);
            this.chkRenderer.Name = "chkRenderer";
            this.chkRenderer.Size = new System.Drawing.Size(130, 17);
            this.chkRenderer.TabIndex = 3;
            this.chkRenderer.Text = "RENDERER: \'{0}/{1}\'";
            this.chkRenderer.UseVisualStyleBackColor = true;
            // 
            // chkPORT
            // 
            this.chkPORT.AutoSize = true;
            this.chkPORT.Location = new System.Drawing.Point(6, 42);
            this.chkPORT.Name = "chkPORT";
            this.chkPORT.Size = new System.Drawing.Size(125, 17);
            this.chkPORT.TabIndex = 2;
            this.chkPORT.Text = "SOURCEPORT: \'{0}\'";
            this.chkPORT.UseVisualStyleBackColor = true;
            // 
            // chkSaveIWAD
            // 
            this.chkSaveIWAD.AutoSize = true;
            this.chkSaveIWAD.Location = new System.Drawing.Point(6, 19);
            this.chkSaveIWAD.Name = "chkSaveIWAD";
            this.chkSaveIWAD.Size = new System.Drawing.Size(79, 17);
            this.chkSaveIWAD.TabIndex = 1;
            this.chkSaveIWAD.Text = "IWAD: \'{0}\'";
            this.chkSaveIWAD.UseVisualStyleBackColor = true;
            // 
            // cmdSavePreset
            // 
            this.cmdSavePreset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSavePreset.Location = new System.Drawing.Point(185, 229);
            this.cmdSavePreset.Name = "cmdSavePreset";
            this.cmdSavePreset.Size = new System.Drawing.Size(167, 43);
            this.cmdSavePreset.TabIndex = 6;
            this.cmdSavePreset.Text = "UPDATE";
            this.cmdSavePreset.UseVisualStyleBackColor = true;
            this.cmdSavePreset.Click += new System.EventHandler(this.cmdSavePreset_Click);
            // 
            // txtPresetName
            // 
            this.txtPresetName.Location = new System.Drawing.Point(53, 12);
            this.txtPresetName.Name = "txtPresetName";
            this.txtPresetName.Size = new System.Drawing.Size(472, 20);
            this.txtPresetName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Name:";
            // 
            // cmdSaveNew
            // 
            this.cmdSaveNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSaveNew.Location = new System.Drawing.Point(12, 229);
            this.cmdSaveNew.Name = "cmdSaveNew";
            this.cmdSaveNew.Size = new System.Drawing.Size(167, 43);
            this.cmdSaveNew.TabIndex = 7;
            this.cmdSaveNew.Text = "SAVE AS NEW";
            this.cmdSaveNew.UseVisualStyleBackColor = true;
            this.cmdSaveNew.Click += new System.EventHandler(this.cmdSaveNew_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.Location = new System.Drawing.Point(358, 229);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(167, 43);
            this.cmdClose.TabIndex = 8;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSavePlay
            // 
            this.cmdSavePlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSavePlay.Location = new System.Drawing.Point(12, 182);
            this.cmdSavePlay.Name = "cmdSavePlay";
            this.cmdSavePlay.Size = new System.Drawing.Size(513, 43);
            this.cmdSavePlay.TabIndex = 9;
            this.cmdSavePlay.Text = "UPDATE AND PLAY";
            this.cmdSavePlay.UseVisualStyleBackColor = true;
            this.cmdSavePlay.Click += new System.EventHandler(this.cmdSavePlay_Click);
            // 
            // SavePresetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 284);
            this.ControlBox = false;
            this.Controls.Add(this.cmdSavePlay);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSaveNew);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPresetName);
            this.Controls.Add(this.cmdSavePreset);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SavePresetForm";
            this.Text = "Save Preset";
            this.Load += new System.EventHandler(this.SavePresetForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkCommand;
        private System.Windows.Forms.CheckBox chkConfiguration;
        private System.Windows.Forms.CheckBox chkRenderer;
        private System.Windows.Forms.CheckBox chkPORT;
        private System.Windows.Forms.CheckBox chkSaveIWAD;
        private System.Windows.Forms.Button cmdSavePreset;
        private System.Windows.Forms.TextBox txtPresetName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdSaveNew;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdSavePlay;
    }
}