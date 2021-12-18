namespace DoomModLoader2
{
    partial class FileManager
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
            this.lstPath = new System.Windows.Forms.ListBox();
            this.cmdAddFolder = new System.Windows.Forms.Button();
            this.cmdAddSingleFile = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdRemove = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstPath
            // 
            this.lstPath.AllowDrop = true;
            this.lstPath.FormattingEnabled = true;
            this.lstPath.HorizontalScrollbar = true;
            this.lstPath.Location = new System.Drawing.Point(12, 39);
            this.lstPath.Name = "lstPath";
            this.lstPath.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstPath.Size = new System.Drawing.Size(629, 316);
            this.lstPath.TabIndex = 0;
            this.lstPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstPath_DragDrop);
            this.lstPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.lstPath_DragEnter);
            // 
            // cmdAddFolder
            // 
            this.cmdAddFolder.Location = new System.Drawing.Point(156, 361);
            this.cmdAddFolder.Name = "cmdAddFolder";
            this.cmdAddFolder.Size = new System.Drawing.Size(138, 24);
            this.cmdAddFolder.TabIndex = 21;
            this.cmdAddFolder.Text = "ADD FOLDER...";
            this.cmdAddFolder.UseVisualStyleBackColor = true;
            this.cmdAddFolder.Click += new System.EventHandler(this.cmdAddFolder_Click);
            // 
            // cmdAddSingleFile
            // 
            this.cmdAddSingleFile.Location = new System.Drawing.Point(12, 362);
            this.cmdAddSingleFile.Name = "cmdAddSingleFile";
            this.cmdAddSingleFile.Size = new System.Drawing.Size(138, 23);
            this.cmdAddSingleFile.TabIndex = 20;
            this.cmdAddSingleFile.Text = "ADD FILE...";
            this.cmdAddSingleFile.UseVisualStyleBackColor = true;
            this.cmdAddSingleFile.Click += new System.EventHandler(this.cmdAddSingleFile_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(503, 359);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(138, 24);
            this.cmdClose.TabIndex = 23;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdRemove
            // 
            this.cmdRemove.Location = new System.Drawing.Point(300, 362);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(138, 23);
            this.cmdRemove.TabIndex = 22;
            this.cmdRemove.Text = "REMOVE...";
            this.cmdRemove.UseVisualStyleBackColor = true;
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(379, 26);
            this.label1.TabIndex = 24;
            this.label1.Text = "Add you mod files. You can also drag \'n drop your file/s or folder/s.\r\nSupported " +
    "files; \".wad\", \".pk3\", \".zip\", \".pak\", \".pk7\", \".grp\", \".rff\" and \".deh\" ";
            // 
            // FileManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 397);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdRemove);
            this.Controls.Add(this.cmdAddFolder);
            this.Controls.Add(this.cmdAddSingleFile);
            this.Controls.Add(this.lstPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FileManager";
            this.Text = "File Manager";
            this.Load += new System.EventHandler(this.FileManager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstPath;
        private System.Windows.Forms.Button cmdAddFolder;
        private System.Windows.Forms.Button cmdAddSingleFile;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdRemove;
        private System.Windows.Forms.Label label1;
    }
}