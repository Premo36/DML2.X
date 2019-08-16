namespace DoomModLoader2
{
    partial class Options
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.chk_SHOW_END_MESSAGE = new System.Windows.Forms.CheckBox();
            this.chk_SHOW_OVERWRITE_MESSAGE = new System.Windows.Forms.CheckBox();
            this.chk_SHOW_SUCCESS_MESSAGE = new System.Windows.Forms.CheckBox();
            this.chk_SHOW_DELETE_MESSAGE = new System.Windows.Forms.CheckBox();
            this.cmdSaveOptions = new System.Windows.Forms.Button();
            this.cmdQuitOptions = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chk_SHOW_END_MESSAGE
            // 
            this.chk_SHOW_END_MESSAGE.AutoSize = true;
            this.chk_SHOW_END_MESSAGE.Location = new System.Drawing.Point(12, 12);
            this.chk_SHOW_END_MESSAGE.Name = "chk_SHOW_END_MESSAGE";
            this.chk_SHOW_END_MESSAGE.Size = new System.Drawing.Size(279, 17);
            this.chk_SHOW_END_MESSAGE.TabIndex = 0;
            this.chk_SHOW_END_MESSAGE.Text = "Show Doom-like quitting confirmation message on exit";
            this.chk_SHOW_END_MESSAGE.UseVisualStyleBackColor = true;

            // 
            // chk_SHOW_OVERWRITE_MESSAGE
            // 
            this.chk_SHOW_OVERWRITE_MESSAGE.AutoSize = true;
            this.chk_SHOW_OVERWRITE_MESSAGE.Location = new System.Drawing.Point(12, 35);
            this.chk_SHOW_OVERWRITE_MESSAGE.Name = "chk_SHOW_OVERWRITE_MESSAGE";
            this.chk_SHOW_OVERWRITE_MESSAGE.Size = new System.Drawing.Size(227, 17);
            this.chk_SHOW_OVERWRITE_MESSAGE.TabIndex = 1;
            this.chk_SHOW_OVERWRITE_MESSAGE.Text = "Show OVERWRITE warning message box";
            this.chk_SHOW_OVERWRITE_MESSAGE.UseVisualStyleBackColor = true;
    
            // 
            // chk_SHOW_SUCCESS_MESSAGE
            // 
            this.chk_SHOW_SUCCESS_MESSAGE.AutoSize = true;
            this.chk_SHOW_SUCCESS_MESSAGE.Location = new System.Drawing.Point(12, 58);
            this.chk_SHOW_SUCCESS_MESSAGE.Name = "chk_SHOW_SUCCESS_MESSAGE";
            this.chk_SHOW_SUCCESS_MESSAGE.Size = new System.Drawing.Size(171, 17);
            this.chk_SHOW_SUCCESS_MESSAGE.TabIndex = 2;
            this.chk_SHOW_SUCCESS_MESSAGE.Text = "Show SUCCESS message box";
            this.chk_SHOW_SUCCESS_MESSAGE.UseVisualStyleBackColor = true;
     
            // 
            // chk_SHOW_DELETE_MESSAGE
            // 
            this.chk_SHOW_DELETE_MESSAGE.AutoSize = true;
            this.chk_SHOW_DELETE_MESSAGE.Location = new System.Drawing.Point(12, 81);
            this.chk_SHOW_DELETE_MESSAGE.Name = "chk_SHOW_DELETE_MESSAGE";
            this.chk_SHOW_DELETE_MESSAGE.Size = new System.Drawing.Size(257, 17);
            this.chk_SHOW_DELETE_MESSAGE.TabIndex = 3;
            this.chk_SHOW_DELETE_MESSAGE.Text = "Show DELETE/REMOVE warning message box.";
            this.chk_SHOW_DELETE_MESSAGE.UseVisualStyleBackColor = true;

            // 
            // cmdSaveOptions
            // 
            this.cmdSaveOptions.Location = new System.Drawing.Point(12, 104);
            this.cmdSaveOptions.Name = "cmdSaveOptions";
            this.cmdSaveOptions.Size = new System.Drawing.Size(120, 26);
            this.cmdSaveOptions.TabIndex = 4;
            this.cmdSaveOptions.Text = "SAVE";
            this.cmdSaveOptions.UseVisualStyleBackColor = true;
            this.cmdSaveOptions.Click += new System.EventHandler(this.cmdSaveOptions_Click);
            // 
            // cmdQuitOptions
            // 
            this.cmdQuitOptions.Location = new System.Drawing.Point(158, 104);
            this.cmdQuitOptions.Name = "cmdQuitOptions";
            this.cmdQuitOptions.Size = new System.Drawing.Size(120, 26);
            this.cmdQuitOptions.TabIndex = 5;
            this.cmdQuitOptions.Text = "BACK";
            this.cmdQuitOptions.UseVisualStyleBackColor = true;
            this.cmdQuitOptions.Click += new System.EventHandler(this.cmdQuitOptions_Click);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 134);
            this.ControlBox = false;
            this.Controls.Add(this.cmdQuitOptions);
            this.Controls.Add(this.cmdSaveOptions);
            this.Controls.Add(this.chk_SHOW_DELETE_MESSAGE);
            this.Controls.Add(this.chk_SHOW_SUCCESS_MESSAGE);
            this.Controls.Add(this.chk_SHOW_OVERWRITE_MESSAGE);
            this.Controls.Add(this.chk_SHOW_END_MESSAGE);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Options";
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chk_SHOW_END_MESSAGE;
        private System.Windows.Forms.CheckBox chk_SHOW_OVERWRITE_MESSAGE;
        private System.Windows.Forms.CheckBox chk_SHOW_SUCCESS_MESSAGE;
        private System.Windows.Forms.CheckBox chk_SHOW_DELETE_MESSAGE;
        private System.Windows.Forms.Button cmdSaveOptions;
        private System.Windows.Forms.Button cmdQuitOptions;
    }
}