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
            this.chk_SHOW_END_MESSAGE = new System.Windows.Forms.CheckBox();
            this.chk_SHOW_OVERWRITE_MESSAGE = new System.Windows.Forms.CheckBox();
            this.chk_SHOW_SUCCESS_MESSAGE = new System.Windows.Forms.CheckBox();
            this.chk_SHOW_DELETE_MESSAGE = new System.Windows.Forms.CheckBox();
            this.cmdSaveOptions = new System.Windows.Forms.Button();
            this.cmdQuitOptions = new System.Windows.Forms.Button();
            this.chk_USE_ADVANCED_SELECTION_MODE = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbModListViewMode = new System.Windows.Forms.ComboBox();
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
            this.cmdSaveOptions.Location = new System.Drawing.Point(12, 154);
            this.cmdSaveOptions.Name = "cmdSaveOptions";
            this.cmdSaveOptions.Size = new System.Drawing.Size(139, 26);
            this.cmdSaveOptions.TabIndex = 4;
            this.cmdSaveOptions.Text = "SAVE";
            this.cmdSaveOptions.UseVisualStyleBackColor = true;
            this.cmdSaveOptions.Click += new System.EventHandler(this.cmdSaveOptions_Click);
            // 
            // cmdQuitOptions
            // 
            this.cmdQuitOptions.Location = new System.Drawing.Point(157, 154);
            this.cmdQuitOptions.Name = "cmdQuitOptions";
            this.cmdQuitOptions.Size = new System.Drawing.Size(147, 26);
            this.cmdQuitOptions.TabIndex = 5;
            this.cmdQuitOptions.Text = "BACK";
            this.cmdQuitOptions.UseVisualStyleBackColor = true;
            this.cmdQuitOptions.Click += new System.EventHandler(this.cmdQuitOptions_Click);
            // 
            // chk_USE_ADVANCED_SELECTION_MODE
            // 
            this.chk_USE_ADVANCED_SELECTION_MODE.AutoSize = true;
            this.chk_USE_ADVANCED_SELECTION_MODE.Location = new System.Drawing.Point(12, 104);
            this.chk_USE_ADVANCED_SELECTION_MODE.Name = "chk_USE_ADVANCED_SELECTION_MODE";
            this.chk_USE_ADVANCED_SELECTION_MODE.Size = new System.Drawing.Size(244, 17);
            this.chk_USE_ADVANCED_SELECTION_MODE.TabIndex = 6;
            this.chk_USE_ADVANCED_SELECTION_MODE.Text = "Use \"ADVANCED\" selection mode for mod list";
            this.chk_USE_ADVANCED_SELECTION_MODE.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "mod list view mode:";
            // 
            // cmbModListViewMode
            // 
            this.cmbModListViewMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModListViewMode.FormattingEnabled = true;
            this.cmbModListViewMode.Items.AddRange(new object[] {
            "ONLY FILE NAME",
            "LAST FOLDER AND FILE NAME",
            "FULL PATH"});
            this.cmbModListViewMode.Location = new System.Drawing.Point(117, 127);
            this.cmbModListViewMode.Name = "cmbModListViewMode";
            this.cmbModListViewMode.Size = new System.Drawing.Size(187, 21);
            this.cmbModListViewMode.TabIndex = 8;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 192);
            this.ControlBox = false;
            this.Controls.Add(this.cmbModListViewMode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chk_USE_ADVANCED_SELECTION_MODE);
            this.Controls.Add(this.cmdQuitOptions);
            this.Controls.Add(this.cmdSaveOptions);
            this.Controls.Add(this.chk_SHOW_DELETE_MESSAGE);
            this.Controls.Add(this.chk_SHOW_SUCCESS_MESSAGE);
            this.Controls.Add(this.chk_SHOW_OVERWRITE_MESSAGE);
            this.Controls.Add(this.chk_SHOW_END_MESSAGE);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
        private System.Windows.Forms.CheckBox chk_USE_ADVANCED_SELECTION_MODE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbModListViewMode;
    }
}