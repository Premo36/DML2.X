namespace DoomModLoader2
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
            this.button1 = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
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
            this.groupBox2.Location = new System.Drawing.Point(15, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(510, 138);
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
            this.chkCommand.TabIndex = 10;
            this.chkCommand.Text = "COMMAND LINE: \'{0}\'";
            this.chkCommand.UseVisualStyleBackColor = true;
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
            // cmdSavePreset
            // 
            this.cmdSavePreset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSavePreset.Location = new System.Drawing.Point(12, 182);
            this.cmdSavePreset.Name = "cmdSavePreset";
            this.cmdSavePreset.Size = new System.Drawing.Size(167, 43);
            this.cmdSavePreset.TabIndex = 4;
            this.cmdSavePreset.Text = "SAVE";
            this.cmdSavePreset.UseVisualStyleBackColor = true;
            // 
            // txtPresetName
            // 
            this.txtPresetName.Location = new System.Drawing.Point(56, 12);
            this.txtPresetName.Name = "txtPresetName";
            this.txtPresetName.Size = new System.Drawing.Size(469, 20);
            this.txtPresetName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Name:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(185, 182);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 43);
            this.button1.TabIndex = 9;
            this.button1.Text = "SAVE AS NEW";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cmdClose
            // 
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.Location = new System.Drawing.Point(358, 182);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(167, 43);
            this.cmdClose.TabIndex = 10;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // SavePresetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 238);
            this.ControlBox = false;
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdSavePreset);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtPresetName);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cmdClose;
    }
}