namespace DoomModLoader2
{
    partial class VersionForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLocalVersion = new System.Windows.Forms.Label();
            this.lblServerVersion = new System.Windows.Forms.Label();
            this.txtChangeLog = new System.Windows.Forms.TextBox();
            this.chkUpdate = new System.Windows.Forms.CheckBox();
            this.cmdOpenDownload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Local Version:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Latest Version";
            // 
            // lblLocalVersion
            // 
            this.lblLocalVersion.AutoSize = true;
            this.lblLocalVersion.Location = new System.Drawing.Point(105, 13);
            this.lblLocalVersion.Name = "lblLocalVersion";
            this.lblLocalVersion.Size = new System.Drawing.Size(0, 13);
            this.lblLocalVersion.TabIndex = 2;
            // 
            // lblServerVersion
            // 
            this.lblServerVersion.AutoSize = true;
            this.lblServerVersion.Location = new System.Drawing.Point(105, 35);
            this.lblServerVersion.Name = "lblServerVersion";
            this.lblServerVersion.Size = new System.Drawing.Size(0, 13);
            this.lblServerVersion.TabIndex = 3;
            // 
            // txtChangeLog
            // 
            this.txtChangeLog.Location = new System.Drawing.Point(16, 62);
            this.txtChangeLog.Multiline = true;
            this.txtChangeLog.Name = "txtChangeLog";
            this.txtChangeLog.ReadOnly = true;
            this.txtChangeLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChangeLog.Size = new System.Drawing.Size(389, 265);
            this.txtChangeLog.TabIndex = 4;
            // 
            // chkUpdate
            // 
            this.chkUpdate.AutoSize = true;
            this.chkUpdate.Location = new System.Drawing.Point(170, 9);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.Size = new System.Drawing.Size(235, 17);
            this.chkUpdate.TabIndex = 5;
            this.chkUpdate.Text = "Always check for update on application start";
            this.chkUpdate.UseVisualStyleBackColor = true;
            this.chkUpdate.CheckedChanged += new System.EventHandler(this.chkUpdate_CheckedChanged);
            // 
            // cmdOpenDownload
            // 
            this.cmdOpenDownload.Location = new System.Drawing.Point(170, 33);
            this.cmdOpenDownload.Name = "cmdOpenDownload";
            this.cmdOpenDownload.Size = new System.Drawing.Size(235, 23);
            this.cmdOpenDownload.TabIndex = 6;
            this.cmdOpenDownload.Text = "Open Download Page";
            this.cmdOpenDownload.UseVisualStyleBackColor = true;
            // 
            // VersionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 339);
            this.Controls.Add(this.cmdOpenDownload);
            this.Controls.Add(this.chkUpdate);
            this.Controls.Add(this.txtChangeLog);
            this.Controls.Add(this.lblServerVersion);
            this.Controls.Add(this.lblLocalVersion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VersionForm";
            this.Text = "DML 2.0 - Check for update";
            this.Load += new System.EventHandler(this.VersionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLocalVersion;
        private System.Windows.Forms.Label lblServerVersion;
        private System.Windows.Forms.TextBox txtChangeLog;
        private System.Windows.Forms.CheckBox chkUpdate;
        private System.Windows.Forms.Button cmdOpenDownload;
    }
}