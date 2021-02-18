namespace DoomModLoader2
{
    partial class MainForm
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbFileFilter = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbOrder = new System.Windows.Forms.ComboBox();
            this.cmdOpenFileManager = new System.Windows.Forms.Button();
            this.cmbPreset = new System.Windows.Forms.ComboBox();
            this.PathBinding = new System.Windows.Forms.BindingSource(this.components);
            this.cmdRemovePreset = new System.Windows.Forms.Button();
            this.lstPWAD = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.chkCustomConfiguration = new System.Windows.Forms.CheckBox();
            this.cmdAddConfiguration = new System.Windows.Forms.Button();
            this.cmdRemoveConfiguration = new System.Windows.Forms.Button();
            this.cmbPortConfig = new System.Windows.Forms.ComboBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.txtCommandLine = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cmdAddSourcePort = new System.Windows.Forms.Button();
            this.cmdAddIWAD = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdRemoveSourcePort = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdRemoveIWAD = new System.Windows.Forms.Button();
            this.cmbIWAD = new System.Windows.Forms.ComboBox();
            this.cmbSourcePort = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cmbSkill = new System.Windows.Forms.ComboBox();
            this.txtMap = new System.Windows.Forms.TextBox();
            this.chkNoMonster = new System.Windows.Forms.CheckBox();
            this.chkRespawn = new System.Windows.Forms.CheckBox();
            this.chkFast = new System.Windows.Forms.CheckBox();
            this.lblSkill = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmb_vidrender = new System.Windows.Forms.ComboBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtScreenHeight = new System.Windows.Forms.TextBox();
            this.chkFullscreen = new System.Windows.Forms.CheckBox();
            this.txtScreenWidth = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radAudioNoMusic = new System.Windows.Forms.RadioButton();
            this.radAudioNoSFX = new System.Windows.Forms.RadioButton();
            this.radAudioNoSounds = new System.Windows.Forms.RadioButton();
            this.radAudioAllSounds = new System.Windows.Forms.RadioButton();
            this.cmdPlay = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openFILEFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openIWADFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPWADFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPORTFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPORTCONFIGFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadResourcesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PathBinding)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cmbFileFilter);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmbOrder);
            this.groupBox1.Controls.Add(this.cmdOpenFileManager);
            this.groupBox1.Controls.Add(this.cmbPreset);
            this.groupBox1.Controls.Add(this.cmdRemovePreset);
            this.groupBox1.Controls.Add(this.lstPWAD);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(314, 509);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MODS (-file / -deh)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Search:";
            // 
            // cmbFileFilter
            // 
            this.cmbFileFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFileFilter.FormattingEnabled = true;
            this.cmbFileFilter.Items.AddRange(new object[] {
            " "});
            this.cmbFileFilter.Location = new System.Drawing.Point(255, 54);
            this.cmbFileFilter.Name = "cmbFileFilter";
            this.cmbFileFilter.Size = new System.Drawing.Size(52, 21);
            this.cmbFileFilter.TabIndex = 3;
            this.cmbFileFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFileFilter_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(59, 54);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(190, 20);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Order by:";
            // 
            // cmbOrder
            // 
            this.cmbOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrder.FormattingEnabled = true;
            this.cmbOrder.Items.AddRange(new object[] {
            "NAME (ASCENDING)",
            "NAME (DESCENDING)",
            "EXTENSION (ASCENDING)",
            "EXTENSION (DESCENDING)",
            "FOLDER (ASCENDING)",
            "FOLDER (DESCENDING)",
            "PATH (ASCENDING)",
            "PATH (DESCENDING)"});
            this.cmbOrder.Location = new System.Drawing.Point(60, 83);
            this.cmbOrder.Name = "cmbOrder";
            this.cmbOrder.Size = new System.Drawing.Size(248, 21);
            this.cmbOrder.TabIndex = 4;
            this.cmbOrder.SelectedIndexChanged += new System.EventHandler(this.cmbOrder_SelectedIndexChanged);
            // 
            // cmdOpenFileManager
            // 
            this.cmdOpenFileManager.Location = new System.Drawing.Point(6, 19);
            this.cmdOpenFileManager.Name = "cmdOpenFileManager";
            this.cmdOpenFileManager.Size = new System.Drawing.Size(301, 23);
            this.cmdOpenFileManager.TabIndex = 1;
            this.cmdOpenFileManager.Text = "Open file manager...";
            this.cmdOpenFileManager.UseVisualStyleBackColor = true;
            this.cmdOpenFileManager.Click += new System.EventHandler(this.cmdOpenFileManager_Click);
            // 
            // cmbPreset
            // 
            this.cmbPreset.DataSource = this.PathBinding;
            this.cmbPreset.DisplayMember = "name";
            this.cmbPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPreset.FormattingEnabled = true;
            this.cmbPreset.Location = new System.Drawing.Point(6, 458);
            this.cmbPreset.Name = "cmbPreset";
            this.cmbPreset.Size = new System.Drawing.Size(302, 21);
            this.cmbPreset.TabIndex = 6;
            this.cmbPreset.SelectedIndexChanged += new System.EventHandler(this.cmbPreset_SelectedIndexChanged);
            // 
            // PathBinding
            // 
            this.PathBinding.DataSource = typeof(DoomModLoader2.Entity.PathName);
            // 
            // cmdRemovePreset
            // 
            this.cmdRemovePreset.Location = new System.Drawing.Point(6, 482);
            this.cmdRemovePreset.Name = "cmdRemovePreset";
            this.cmdRemovePreset.Size = new System.Drawing.Size(302, 21);
            this.cmdRemovePreset.TabIndex = 7;
            this.cmdRemovePreset.Text = "DELETE SELECTED PRESET...";
            this.cmdRemovePreset.UseVisualStyleBackColor = true;
            this.cmdRemovePreset.Click += new System.EventHandler(this.cmdRemovePreset_Click);
            // 
            // lstPWAD
            // 
            this.lstPWAD.DataSource = this.PathBinding;
            this.lstPWAD.DisplayMember = "name";
            this.lstPWAD.FormattingEnabled = true;
            this.lstPWAD.HorizontalScrollbar = true;
            this.lstPWAD.Location = new System.Drawing.Point(6, 110);
            this.lstPWAD.Name = "lstPWAD";
            this.lstPWAD.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstPWAD.Size = new System.Drawing.Size(302, 342);
            this.lstPWAD.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox9);
            this.groupBox2.Controls.Add(this.groupBox8);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(332, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(563, 509);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Launch Options";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.chkCustomConfiguration);
            this.groupBox9.Controls.Add(this.cmdAddConfiguration);
            this.groupBox9.Controls.Add(this.cmdRemoveConfiguration);
            this.groupBox9.Controls.Add(this.cmbPortConfig);
            this.groupBox9.Location = new System.Drawing.Point(7, 358);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(549, 81);
            this.groupBox9.TabIndex = 15;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Alternative sourceport .ini/.cfg";
            // 
            // chkCustomConfiguration
            // 
            this.chkCustomConfiguration.AutoSize = true;
            this.chkCustomConfiguration.Location = new System.Drawing.Point(6, 23);
            this.chkCustomConfiguration.Name = "chkCustomConfiguration";
            this.chkCustomConfiguration.Size = new System.Drawing.Size(253, 17);
            this.chkCustomConfiguration.TabIndex = 27;
            this.chkCustomConfiguration.Text = "Use alternative engine configuration file (-config)";
            this.chkCustomConfiguration.UseVisualStyleBackColor = true;
            this.chkCustomConfiguration.CheckedChanged += new System.EventHandler(this.chkCustomConfiguration_CheckedChanged);
            // 
            // cmdAddConfiguration
            // 
            this.cmdAddConfiguration.Location = new System.Drawing.Point(385, 19);
            this.cmdAddConfiguration.Name = "cmdAddConfiguration";
            this.cmdAddConfiguration.Size = new System.Drawing.Size(76, 23);
            this.cmdAddConfiguration.TabIndex = 28;
            this.cmdAddConfiguration.Text = "ADD...";
            this.cmdAddConfiguration.UseVisualStyleBackColor = true;
            this.cmdAddConfiguration.Click += new System.EventHandler(this.cmdAddConfiguration_Click);
            // 
            // cmdRemoveConfiguration
            // 
            this.cmdRemoveConfiguration.Location = new System.Drawing.Point(467, 18);
            this.cmdRemoveConfiguration.Name = "cmdRemoveConfiguration";
            this.cmdRemoveConfiguration.Size = new System.Drawing.Size(76, 24);
            this.cmdRemoveConfiguration.TabIndex = 29;
            this.cmdRemoveConfiguration.Text = "REMOVE...";
            this.cmdRemoveConfiguration.UseVisualStyleBackColor = true;
            this.cmdRemoveConfiguration.Click += new System.EventHandler(this.cmdRemoveConfiguration_Click);
            // 
            // cmbPortConfig
            // 
            this.cmbPortConfig.DataSource = this.PathBinding;
            this.cmbPortConfig.DisplayMember = "name";
            this.cmbPortConfig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPortConfig.FormattingEnabled = true;
            this.cmbPortConfig.Location = new System.Drawing.Point(6, 48);
            this.cmbPortConfig.Name = "cmbPortConfig";
            this.cmbPortConfig.Size = new System.Drawing.Size(537, 21);
            this.cmbPortConfig.TabIndex = 30;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.txtCommandLine);
            this.groupBox8.Location = new System.Drawing.Point(6, 453);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(550, 50);
            this.groupBox8.TabIndex = 3;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Custom command line parameters";
            // 
            // txtCommandLine
            // 
            this.txtCommandLine.Location = new System.Drawing.Point(6, 19);
            this.txtCommandLine.Name = "txtCommandLine";
            this.txtCommandLine.Size = new System.Drawing.Size(538, 20);
            this.txtCommandLine.TabIndex = 31;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cmdAddSourcePort);
            this.groupBox6.Controls.Add(this.cmdAddIWAD);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.cmdRemoveSourcePort);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.cmdRemoveIWAD);
            this.groupBox6.Controls.Add(this.cmbIWAD);
            this.groupBox6.Controls.Add(this.cmbSourcePort);
            this.groupBox6.Location = new System.Drawing.Point(7, 283);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(549, 72);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Game";
            // 
            // cmdAddSourcePort
            // 
            this.cmdAddSourcePort.Location = new System.Drawing.Point(74, 15);
            this.cmdAddSourcePort.Name = "cmdAddSourcePort";
            this.cmdAddSourcePort.Size = new System.Drawing.Size(76, 24);
            this.cmdAddSourcePort.TabIndex = 21;
            this.cmdAddSourcePort.Text = "ADD...";
            this.cmdAddSourcePort.UseVisualStyleBackColor = true;
            this.cmdAddSourcePort.Click += new System.EventHandler(this.cmdAddSourcePort_Click);
            // 
            // cmdAddIWAD
            // 
            this.cmdAddIWAD.Location = new System.Drawing.Point(388, 15);
            this.cmdAddIWAD.Name = "cmdAddIWAD";
            this.cmdAddIWAD.Size = new System.Drawing.Size(76, 23);
            this.cmdAddIWAD.TabIndex = 24;
            this.cmdAddIWAD.Text = "ADD...";
            this.cmdAddIWAD.UseVisualStyleBackColor = true;
            this.cmdAddIWAD.Click += new System.EventHandler(this.cmdAddIWAD_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Source Port:";
            // 
            // cmdRemoveSourcePort
            // 
            this.cmdRemoveSourcePort.Location = new System.Drawing.Point(156, 15);
            this.cmdRemoveSourcePort.Name = "cmdRemoveSourcePort";
            this.cmdRemoveSourcePort.Size = new System.Drawing.Size(76, 24);
            this.cmdRemoveSourcePort.TabIndex = 22;
            this.cmdRemoveSourcePort.Text = "REMOVE...";
            this.cmdRemoveSourcePort.UseVisualStyleBackColor = true;
            this.cmdRemoveSourcePort.Click += new System.EventHandler(this.cmdRemoveSourcePort_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(238, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Original Game (-IWAD):";
            // 
            // cmdRemoveIWAD
            // 
            this.cmdRemoveIWAD.Location = new System.Drawing.Point(470, 14);
            this.cmdRemoveIWAD.Name = "cmdRemoveIWAD";
            this.cmdRemoveIWAD.Size = new System.Drawing.Size(76, 24);
            this.cmdRemoveIWAD.TabIndex = 25;
            this.cmdRemoveIWAD.Text = "REMOVE...";
            this.cmdRemoveIWAD.UseVisualStyleBackColor = true;
            this.cmdRemoveIWAD.Click += new System.EventHandler(this.cmdRemoveIWAD_Click);
            // 
            // cmbIWAD
            // 
            this.cmbIWAD.DataSource = this.PathBinding;
            this.cmbIWAD.DisplayMember = "name";
            this.cmbIWAD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIWAD.FormattingEnabled = true;
            this.cmbIWAD.Location = new System.Drawing.Point(238, 41);
            this.cmbIWAD.Name = "cmbIWAD";
            this.cmbIWAD.Size = new System.Drawing.Size(305, 21);
            this.cmbIWAD.TabIndex = 26;
            // 
            // cmbSourcePort
            // 
            this.cmbSourcePort.DataSource = this.PathBinding;
            this.cmbSourcePort.DisplayMember = "name";
            this.cmbSourcePort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSourcePort.FormattingEnabled = true;
            this.cmbSourcePort.Location = new System.Drawing.Point(6, 41);
            this.cmbSourcePort.Name = "cmbSourcePort";
            this.cmbSourcePort.Size = new System.Drawing.Size(226, 21);
            this.cmbSourcePort.TabIndex = 23;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cmbSkill);
            this.groupBox5.Controls.Add(this.txtMap);
            this.groupBox5.Controls.Add(this.chkNoMonster);
            this.groupBox5.Controls.Add(this.chkRespawn);
            this.groupBox5.Controls.Add(this.chkFast);
            this.groupBox5.Controls.Add(this.lblSkill);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Location = new System.Drawing.Point(236, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(320, 129);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Gameplay";
            // 
            // cmbSkill
            // 
            this.cmbSkill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSkill.FormattingEnabled = true;
            this.cmbSkill.Items.AddRange(new object[] {
            "I\'m too young to die",
            "Hey, not too rough",
            "Hurt me plenty",
            "Ultra-Violence",
            "Nightmare!"});
            this.cmbSkill.Location = new System.Drawing.Point(128, 42);
            this.cmbSkill.Name = "cmbSkill";
            this.cmbSkill.Size = new System.Drawing.Size(186, 21);
            this.cmbSkill.TabIndex = 13;
            // 
            // txtMap
            // 
            this.txtMap.Location = new System.Drawing.Point(128, 18);
            this.txtMap.Name = "txtMap";
            this.txtMap.Size = new System.Drawing.Size(186, 20);
            this.txtMap.TabIndex = 12;
            this.txtMap.TextChanged += new System.EventHandler(this.txtMap_TextChanged);
            // 
            // chkNoMonster
            // 
            this.chkNoMonster.AutoSize = true;
            this.chkNoMonster.Location = new System.Drawing.Point(6, 66);
            this.chkNoMonster.Name = "chkNoMonster";
            this.chkNoMonster.Size = new System.Drawing.Size(173, 17);
            this.chkNoMonster.TabIndex = 14;
            this.chkNoMonster.Text = "Remove Monster (-nomonsters)";
            this.chkNoMonster.UseVisualStyleBackColor = true;
            this.chkNoMonster.CheckedChanged += new System.EventHandler(this.chkNoMonster_CheckedChanged);
            // 
            // chkRespawn
            // 
            this.chkRespawn.AutoSize = true;
            this.chkRespawn.Location = new System.Drawing.Point(6, 106);
            this.chkRespawn.Name = "chkRespawn";
            this.chkRespawn.Size = new System.Drawing.Size(164, 17);
            this.chkRespawn.TabIndex = 16;
            this.chkRespawn.Text = "Monster Respawn (-respawn)";
            this.chkRespawn.UseVisualStyleBackColor = true;
            // 
            // chkFast
            // 
            this.chkFast.AutoSize = true;
            this.chkFast.Location = new System.Drawing.Point(6, 86);
            this.chkFast.Name = "chkFast";
            this.chkFast.Size = new System.Drawing.Size(116, 17);
            this.chkFast.TabIndex = 15;
            this.chkFast.Text = "Fast Monster (-fast)";
            this.chkFast.UseVisualStyleBackColor = true;
            // 
            // lblSkill
            // 
            this.lblSkill.AutoSize = true;
            this.lblSkill.Location = new System.Drawing.Point(3, 42);
            this.lblSkill.Name = "lblSkill";
            this.lblSkill.Size = new System.Drawing.Size(80, 13);
            this.lblSkill.TabIndex = 1;
            this.lblSkill.Text = "Skill level (-skill)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start from level (+map)";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmb_vidrender);
            this.groupBox4.Controls.Add(this.groupBox7);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(7, 154);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(552, 123);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Video";
            // 
            // cmb_vidrender
            // 
            this.cmb_vidrender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_vidrender.FormattingEnabled = true;
            this.cmb_vidrender.Items.AddRange(new object[] {
            "DOOM SOFTWARE RENDERER",
            "TRUE COLOR SOFTWARE RENDERER",
            "SOFTPOLY RENDERER",
            "TRUE COLOR SOFTPOLY",
            "HARDWARE ACCELERATED",
            "[DON\'T OVERRIDE]"});
            this.cmb_vidrender.Location = new System.Drawing.Point(5, 97);
            this.cmb_vidrender.Name = "cmb_vidrender";
            this.cmb_vidrender.Size = new System.Drawing.Size(538, 21);
            this.cmb_vidrender.TabIndex = 20;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtScreenHeight);
            this.groupBox7.Controls.Add(this.chkFullscreen);
            this.groupBox7.Controls.Add(this.txtScreenWidth);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Location = new System.Drawing.Point(6, 16);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(537, 62);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Resolution";
            // 
            // txtScreenHeight
            // 
            this.txtScreenHeight.Location = new System.Drawing.Point(223, 32);
            this.txtScreenHeight.Name = "txtScreenHeight";
            this.txtScreenHeight.Size = new System.Drawing.Size(199, 20);
            this.txtScreenHeight.TabIndex = 18;
            // 
            // chkFullscreen
            // 
            this.chkFullscreen.AutoSize = true;
            this.chkFullscreen.Checked = true;
            this.chkFullscreen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFullscreen.Location = new System.Drawing.Point(440, 32);
            this.chkFullscreen.Name = "chkFullscreen";
            this.chkFullscreen.Size = new System.Drawing.Size(77, 17);
            this.chkFullscreen.TabIndex = 19;
            this.chkFullscreen.Text = "+fullscreen";
            this.chkFullscreen.UseVisualStyleBackColor = true;
            // 
            // txtScreenWidth
            // 
            this.txtScreenWidth.Location = new System.Drawing.Point(6, 33);
            this.txtScreenWidth.Name = "txtScreenWidth";
            this.txtScreenWidth.Size = new System.Drawing.Size(199, 20);
            this.txtScreenWidth.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(220, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "-height";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "-width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "+vid_rendermode";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radAudioNoMusic);
            this.groupBox3.Controls.Add(this.radAudioNoSFX);
            this.groupBox3.Controls.Add(this.radAudioNoSounds);
            this.groupBox3.Controls.Add(this.radAudioAllSounds);
            this.groupBox3.Location = new System.Drawing.Point(6, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(224, 129);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Audio";
            // 
            // radAudioNoMusic
            // 
            this.radAudioNoMusic.AutoSize = true;
            this.radAudioNoMusic.Location = new System.Drawing.Point(6, 88);
            this.radAudioNoMusic.Name = "radAudioNoMusic";
            this.radAudioNoMusic.Size = new System.Drawing.Size(142, 17);
            this.radAudioNoMusic.TabIndex = 11;
            this.radAudioNoMusic.Text = "Disable Music (-nomusic)";
            this.radAudioNoMusic.UseVisualStyleBackColor = true;
            // 
            // radAudioNoSFX
            // 
            this.radAudioNoSFX.AutoSize = true;
            this.radAudioNoSFX.Location = new System.Drawing.Point(6, 65);
            this.radAudioNoSFX.Name = "radAudioNoSFX";
            this.radAudioNoSFX.Size = new System.Drawing.Size(120, 17);
            this.radAudioNoSFX.TabIndex = 10;
            this.radAudioNoSFX.Text = "Disable SFX (-nosfx)";
            this.radAudioNoSFX.UseVisualStyleBackColor = true;
            // 
            // radAudioNoSounds
            // 
            this.radAudioNoSounds.AutoSize = true;
            this.radAudioNoSounds.Location = new System.Drawing.Point(6, 42);
            this.radAudioNoSounds.Name = "radAudioNoSounds";
            this.radAudioNoSounds.Size = new System.Drawing.Size(163, 17);
            this.radAudioNoSounds.TabIndex = 9;
            this.radAudioNoSounds.Text = "Disable all sounds (-nosound)";
            this.radAudioNoSounds.UseVisualStyleBackColor = true;
            // 
            // radAudioAllSounds
            // 
            this.radAudioAllSounds.AutoSize = true;
            this.radAudioAllSounds.Checked = true;
            this.radAudioAllSounds.Location = new System.Drawing.Point(6, 19);
            this.radAudioAllSounds.Name = "radAudioAllSounds";
            this.radAudioAllSounds.Size = new System.Drawing.Size(108, 17);
            this.radAudioAllSounds.TabIndex = 8;
            this.radAudioAllSounds.TabStop = true;
            this.radAudioAllSounds.Text = "Enable all sounds";
            this.radAudioAllSounds.UseVisualStyleBackColor = true;
            // 
            // cmdPlay
            // 
            this.cmdPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPlay.Location = new System.Drawing.Point(10, 542);
            this.cmdPlay.Name = "cmdPlay";
            this.cmdPlay.Size = new System.Drawing.Size(885, 82);
            this.cmdPlay.TabIndex = 0;
            this.cmdPlay.Text = "PLAY";
            this.cmdPlay.UseVisualStyleBackColor = true;
            this.cmdPlay.Click += new System.EventHandler(this.cmdPlay_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFILEFolderToolStripMenuItem,
            this.checkForUpdateToolStripMenuItem,
            this.preferencesToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.reloadResourcesToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(907, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openFILEFolderToolStripMenuItem
            // 
            this.openFILEFolderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openIWADFolderToolStripMenuItem,
            this.openPWADFolderToolStripMenuItem,
            this.openPORTFolderToolStripMenuItem,
            this.openPORTCONFIGFolderToolStripMenuItem});
            this.openFILEFolderToolStripMenuItem.Name = "openFILEFolderToolStripMenuItem";
            this.openFILEFolderToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.openFILEFolderToolStripMenuItem.Text = "Open folder...";
            // 
            // openIWADFolderToolStripMenuItem
            // 
            this.openIWADFolderToolStripMenuItem.Name = "openIWADFolderToolStripMenuItem";
            this.openIWADFolderToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.openIWADFolderToolStripMenuItem.Text = "Open \"IWAD\" folder";
            this.openIWADFolderToolStripMenuItem.Click += new System.EventHandler(this.openIWADFolderToolStripMenuItem_Click);
            // 
            // openPWADFolderToolStripMenuItem
            // 
            this.openPWADFolderToolStripMenuItem.Name = "openPWADFolderToolStripMenuItem";
            this.openPWADFolderToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.openPWADFolderToolStripMenuItem.Text = "Open \"PWAD\" folder";
            this.openPWADFolderToolStripMenuItem.Click += new System.EventHandler(this.openPWADFolderToolStripMenuItem_Click);
            // 
            // openPORTFolderToolStripMenuItem
            // 
            this.openPORTFolderToolStripMenuItem.Name = "openPORTFolderToolStripMenuItem";
            this.openPORTFolderToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.openPORTFolderToolStripMenuItem.Text = "Open \"PORT\" folder";
            this.openPORTFolderToolStripMenuItem.Click += new System.EventHandler(this.openPORTFolderToolStripMenuItem_Click);
            // 
            // openPORTCONFIGFolderToolStripMenuItem
            // 
            this.openPORTCONFIGFolderToolStripMenuItem.Name = "openPORTCONFIGFolderToolStripMenuItem";
            this.openPORTCONFIGFolderToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.openPORTCONFIGFolderToolStripMenuItem.Text = "Open \"PORT_CONFIG\" folder";
            this.openPORTCONFIGFolderToolStripMenuItem.Click += new System.EventHandler(this.openPORTCONFIGFolderToolStripMenuItem_Click);
            // 
            // checkForUpdateToolStripMenuItem
            // 
            this.checkForUpdateToolStripMenuItem.Name = "checkForUpdateToolStripMenuItem";
            this.checkForUpdateToolStripMenuItem.Size = new System.Drawing.Size(119, 20);
            this.checkForUpdateToolStripMenuItem.Text = "Check for update...";
            this.checkForUpdateToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdateToolStripMenuItem_Click);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.preferencesToolStripMenuItem.Text = "Preferences...";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // reloadResourcesToolStripMenuItem1
            // 
            this.reloadResourcesToolStripMenuItem1.Name = "reloadResourcesToolStripMenuItem1";
            this.reloadResourcesToolStripMenuItem1.Size = new System.Drawing.Size(108, 20);
            this.reloadResourcesToolStripMenuItem1.Text = "Reload resources";
            this.reloadResourcesToolStripMenuItem1.Click += new System.EventHandler(this.reloadResourcesToolStripMenuItem1_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.cmdPlay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 629);
            this.Controls.Add(this.cmdPlay);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Doom Mod Loader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PathBinding)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cmbIWAD;
        private System.Windows.Forms.ComboBox cmbSourcePort;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtScreenWidth;
        private System.Windows.Forms.RadioButton radAudioNoMusic;
        private System.Windows.Forms.RadioButton radAudioNoSFX;
        private System.Windows.Forms.RadioButton radAudioNoSounds;
        private System.Windows.Forms.RadioButton radAudioAllSounds;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txtScreenHeight;
        private System.Windows.Forms.CheckBox chkFullscreen;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox txtCommandLine;
        private System.Windows.Forms.Button cmdPlay;
        private System.Windows.Forms.ListBox lstPWAD;
        private System.Windows.Forms.CheckBox chkNoMonster;
        private System.Windows.Forms.CheckBox chkRespawn;
        private System.Windows.Forms.CheckBox chkFast;
        private System.Windows.Forms.Label lblSkill;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdRemoveIWAD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cmdRemoveSourcePort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbPreset;
        private System.Windows.Forms.Button cmdRemovePreset;
        private System.Windows.Forms.Button cmdAddSourcePort;
        private System.Windows.Forms.Button cmdAddIWAD;
        private System.Windows.Forms.ComboBox cmbSkill;
        private System.Windows.Forms.TextBox txtMap;
        private System.Windows.Forms.BindingSource PathBinding;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_vidrender;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdateToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.CheckBox chkCustomConfiguration;
        private System.Windows.Forms.Button cmdAddConfiguration;
        private System.Windows.Forms.Button cmdRemoveConfiguration;
        private System.Windows.Forms.ComboBox cmbPortConfig;
        private System.Windows.Forms.Button cmdOpenFileManager;
        private System.Windows.Forms.ToolStripMenuItem reloadResourcesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbFileFilter;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbOrder;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripMenuItem openFILEFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openIWADFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPWADFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPORTFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPORTCONFIGFolderToolStripMenuItem;
    }
}

