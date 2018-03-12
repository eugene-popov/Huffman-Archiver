namespace FrontEnd
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.welcomePanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.welcomeLabel2 = new System.Windows.Forms.Label();
            this.welcomeLabel1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.archiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testTheFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shortcutsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutHuffmanArchiverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ArchiveViewerPanel = new System.Windows.Forms.Panel();
            this.ArchiveVIEWER = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compressedSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uncompressedSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compressionRatio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ButtonsPanel = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ExitButton = new System.Windows.Forms.Button();
            this.CloseArchiveButton = new System.Windows.Forms.Button();
            this.ExtractArchiveButton = new System.Windows.Forms.Button();
            this.CreateArchiveButton = new System.Windows.Forms.Button();
            this.TestArchiveButton = new System.Windows.Forms.Button();
            this.OpenArchiveButton = new System.Windows.Forms.Button();
            this.RemoveFileButton = new System.Windows.Forms.Button();
            this.TestFileButton = new System.Windows.Forms.Button();
            this.ExtractFileButton = new System.Windows.Forms.Button();
            this.addFileButton = new System.Windows.Forms.Button();
            this.newArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.theArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.theFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testTheFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.testTheArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeTheFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.welcomePanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.ArchiveViewerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ArchiveVIEWER)).BeginInit();
            this.ButtonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // welcomePanel
            // 
            this.welcomePanel.Controls.Add(this.label5);
            this.welcomePanel.Controls.Add(this.label4);
            this.welcomePanel.Controls.Add(this.label3);
            this.welcomePanel.Controls.Add(this.label2);
            this.welcomePanel.Controls.Add(this.label1);
            this.welcomePanel.Controls.Add(this.welcomeLabel2);
            this.welcomePanel.Controls.Add(this.welcomeLabel1);
            this.welcomePanel.Controls.Add(this.pictureBox1);
            this.welcomePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.welcomePanel.Location = new System.Drawing.Point(0, 0);
            this.welcomePanel.Name = "welcomePanel";
            this.welcomePanel.Size = new System.Drawing.Size(665, 396);
            this.welcomePanel.TabIndex = 0;
            this.welcomePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.welcomePanel_Paint);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(30, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(589, 39);
            this.label5.TabIndex = 7;
            this.label5.Text = "Choose a further action to continue";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(329, 322);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(194, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "File ➜ Exit (Alt+F4)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(293, 281);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(211, 31);
            this.label3.TabIndex = 5;
            this.label3.Text = "Exit the program";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(329, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "File ➜ Open... (Ctrl+O)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(329, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "File ➜ New (Ctrl+N)";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // welcomeLabel2
            // 
            this.welcomeLabel2.AutoSize = true;
            this.welcomeLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.welcomeLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.welcomeLabel2.Location = new System.Drawing.Point(293, 129);
            this.welcomeLabel2.Name = "welcomeLabel2";
            this.welcomeLabel2.Size = new System.Drawing.Size(270, 31);
            this.welcomeLabel2.TabIndex = 2;
            this.welcomeLabel2.Text = "Create a new archive";
            this.welcomeLabel2.Click += new System.EventHandler(this.welcomeLabel2_Click);
            // 
            // welcomeLabel1
            // 
            this.welcomeLabel1.AutoSize = true;
            this.welcomeLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.welcomeLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.welcomeLabel1.Location = new System.Drawing.Point(293, 207);
            this.welcomeLabel1.Name = "welcomeLabel1";
            this.welcomeLabel1.Size = new System.Drawing.Size(311, 31);
            this.welcomeLabel1.TabIndex = 1;
            this.welcomeLabel1.Text = "Open an existing archive";
            this.welcomeLabel1.Click += new System.EventHandler(this.welcomeLabel1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.archiveToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(665, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.TabStop = true;
            this.menuStrip1.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newArchiveToolStripMenuItem,
            this.openArchiveToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // archiveToolStripMenuItem
            // 
            this.archiveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFileToolStripMenuItem,
            this.extrToolStripMenuItem,
            this.testTheFileToolStripMenuItem,
            this.removeTheFileToolStripMenuItem});
            this.archiveToolStripMenuItem.Name = "archiveToolStripMenuItem";
            this.archiveToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.archiveToolStripMenuItem.Text = "Archive";
            this.archiveToolStripMenuItem.Click += new System.EventHandler(this.archiveToolStripMenuItem_Click);
            // 
            // extrToolStripMenuItem
            // 
            this.extrToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.theArchiveToolStripMenuItem,
            this.theFileToolStripMenuItem});
            this.extrToolStripMenuItem.Name = "extrToolStripMenuItem";
            this.extrToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.extrToolStripMenuItem.Text = "Extract";
            this.extrToolStripMenuItem.Click += new System.EventHandler(this.extrToolStripMenuItem_Click);
            // 
            // testTheFileToolStripMenuItem
            // 
            this.testTheFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testTheFileToolStripMenuItem1,
            this.testTheArchiveToolStripMenuItem});
            this.testTheFileToolStripMenuItem.Name = "testTheFileToolStripMenuItem";
            this.testTheFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.testTheFileToolStripMenuItem.Text = "Test";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shortcutsToolStripMenuItem,
            this.aboutHuffmanArchiverToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // shortcutsToolStripMenuItem
            // 
            this.shortcutsToolStripMenuItem.Name = "shortcutsToolStripMenuItem";
            this.shortcutsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.shortcutsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.shortcutsToolStripMenuItem.Text = "Shortcuts";
            this.shortcutsToolStripMenuItem.Click += new System.EventHandler(this.shortcutsToolStripMenuItem_Click);
            // 
            // aboutHuffmanArchiverToolStripMenuItem
            // 
            this.aboutHuffmanArchiverToolStripMenuItem.Name = "aboutHuffmanArchiverToolStripMenuItem";
            this.aboutHuffmanArchiverToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutHuffmanArchiverToolStripMenuItem.Text = "About";
            this.aboutHuffmanArchiverToolStripMenuItem.Click += new System.EventHandler(this.aboutHuffmanArchiverToolStripMenuItem_Click);
            // 
            // ArchiveViewerPanel
            // 
            this.ArchiveViewerPanel.Controls.Add(this.ArchiveVIEWER);
            this.ArchiveViewerPanel.Controls.Add(this.ButtonsPanel);
            this.ArchiveViewerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArchiveViewerPanel.Location = new System.Drawing.Point(0, 24);
            this.ArchiveViewerPanel.Name = "ArchiveViewerPanel";
            this.ArchiveViewerPanel.Size = new System.Drawing.Size(665, 372);
            this.ArchiveViewerPanel.TabIndex = 2;
            this.ArchiveViewerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ArchiveViewerPanel_Paint);
            // 
            // ArchiveVIEWER
            // 
            this.ArchiveVIEWER.AllowUserToAddRows = false;
            this.ArchiveVIEWER.AllowUserToDeleteRows = false;
            this.ArchiveVIEWER.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.ArchiveVIEWER.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ArchiveVIEWER.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.ArchiveVIEWER.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ArchiveVIEWER.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.compressedSize,
            this.uncompressedSize,
            this.compressionRatio});
            this.ArchiveVIEWER.Location = new System.Drawing.Point(3, 58);
            this.ArchiveVIEWER.MultiSelect = false;
            this.ArchiveVIEWER.Name = "ArchiveVIEWER";
            this.ArchiveVIEWER.ReadOnly = true;
            this.ArchiveVIEWER.RowHeadersVisible = false;
            this.ArchiveVIEWER.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ArchiveVIEWER.Size = new System.Drawing.Size(659, 311);
            this.ArchiveVIEWER.StandardTab = true;
            this.ArchiveVIEWER.TabIndex = 2;
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 165;
            // 
            // compressedSize
            // 
            this.compressedSize.HeaderText = "Compressed size";
            this.compressedSize.Name = "compressedSize";
            this.compressedSize.ReadOnly = true;
            this.compressedSize.Width = 164;
            // 
            // uncompressedSize
            // 
            this.uncompressedSize.HeaderText = "Uncompressed size";
            this.uncompressedSize.Name = "uncompressedSize";
            this.uncompressedSize.ReadOnly = true;
            this.uncompressedSize.Width = 165;
            // 
            // compressionRatio
            // 
            this.compressionRatio.HeaderText = "Compression ratio";
            this.compressionRatio.Name = "compressionRatio";
            this.compressionRatio.ReadOnly = true;
            this.compressionRatio.Width = 164;
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.BackColor = System.Drawing.SystemColors.Control;
            this.ButtonsPanel.Controls.Add(this.ExitButton);
            this.ButtonsPanel.Controls.Add(this.CloseArchiveButton);
            this.ButtonsPanel.Controls.Add(this.ExtractArchiveButton);
            this.ButtonsPanel.Controls.Add(this.CreateArchiveButton);
            this.ButtonsPanel.Controls.Add(this.TestArchiveButton);
            this.ButtonsPanel.Controls.Add(this.OpenArchiveButton);
            this.ButtonsPanel.Controls.Add(this.RemoveFileButton);
            this.ButtonsPanel.Controls.Add(this.TestFileButton);
            this.ButtonsPanel.Controls.Add(this.ExtractFileButton);
            this.ButtonsPanel.Controls.Add(this.addFileButton);
            this.ButtonsPanel.Location = new System.Drawing.Point(0, 0);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Size = new System.Drawing.Size(665, 52);
            this.ButtonsPanel.TabIndex = 1;
            this.ButtonsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ButtonsPanel_Paint);
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Transparent;
            this.ExitButton.BackgroundImage = global::FrontEnd.Properties.Resources.exit;
            this.ExitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ExitButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ExitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Location = new System.Drawing.Point(412, 3);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ExitButton.Size = new System.Drawing.Size(39, 47);
            this.ExitButton.TabIndex = 11;
            this.toolTip1.SetToolTip(this.ExitButton, "Exit the program");
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // CloseArchiveButton
            // 
            this.CloseArchiveButton.BackColor = System.Drawing.Color.Transparent;
            this.CloseArchiveButton.BackgroundImage = global::FrontEnd.Properties.Resources.CloseArchive;
            this.CloseArchiveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CloseArchiveButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.CloseArchiveButton.FlatAppearance.BorderSize = 0;
            this.CloseArchiveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.CloseArchiveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.CloseArchiveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseArchiveButton.Location = new System.Drawing.Point(189, 4);
            this.CloseArchiveButton.Name = "CloseArchiveButton";
            this.CloseArchiveButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CloseArchiveButton.Size = new System.Drawing.Size(37, 46);
            this.CloseArchiveButton.TabIndex = 6;
            this.toolTip1.SetToolTip(this.CloseArchiveButton, "Close the archive");
            this.CloseArchiveButton.UseVisualStyleBackColor = false;
            this.CloseArchiveButton.Click += new System.EventHandler(this.CloseArchiveButton_Click);
            // 
            // ExtractArchiveButton
            // 
            this.ExtractArchiveButton.BackColor = System.Drawing.Color.Transparent;
            this.ExtractArchiveButton.BackgroundImage = global::FrontEnd.Properties.Resources.ExtractArchive;
            this.ExtractArchiveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ExtractArchiveButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ExtractArchiveButton.FlatAppearance.BorderSize = 0;
            this.ExtractArchiveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ExtractArchiveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ExtractArchiveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExtractArchiveButton.Location = new System.Drawing.Point(101, 3);
            this.ExtractArchiveButton.Name = "ExtractArchiveButton";
            this.ExtractArchiveButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ExtractArchiveButton.Size = new System.Drawing.Size(39, 47);
            this.ExtractArchiveButton.TabIndex = 4;
            this.toolTip1.SetToolTip(this.ExtractArchiveButton, "Extract the archive");
            this.ExtractArchiveButton.UseVisualStyleBackColor = false;
            this.ExtractArchiveButton.Click += new System.EventHandler(this.ExtractArchiveButton_Click);
            // 
            // CreateArchiveButton
            // 
            this.CreateArchiveButton.BackColor = System.Drawing.Color.Transparent;
            this.CreateArchiveButton.BackgroundImage = global::FrontEnd.Properties.Resources.CreateArchive;
            this.CreateArchiveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CreateArchiveButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.CreateArchiveButton.FlatAppearance.BorderSize = 0;
            this.CreateArchiveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.CreateArchiveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.CreateArchiveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateArchiveButton.Location = new System.Drawing.Point(11, 3);
            this.CreateArchiveButton.Name = "CreateArchiveButton";
            this.CreateArchiveButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CreateArchiveButton.Size = new System.Drawing.Size(39, 47);
            this.CreateArchiveButton.TabIndex = 2;
            this.toolTip1.SetToolTip(this.CreateArchiveButton, "Create an archive");
            this.CreateArchiveButton.UseVisualStyleBackColor = false;
            this.CreateArchiveButton.Click += new System.EventHandler(this.CreateArchiveButton_Click);
            // 
            // TestArchiveButton
            // 
            this.TestArchiveButton.BackColor = System.Drawing.Color.Transparent;
            this.TestArchiveButton.BackgroundImage = global::FrontEnd.Properties.Resources.TestArchive;
            this.TestArchiveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TestArchiveButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.TestArchiveButton.FlatAppearance.BorderSize = 0;
            this.TestArchiveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.TestArchiveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.TestArchiveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TestArchiveButton.Location = new System.Drawing.Point(146, 4);
            this.TestArchiveButton.Name = "TestArchiveButton";
            this.TestArchiveButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TestArchiveButton.Size = new System.Drawing.Size(37, 46);
            this.TestArchiveButton.TabIndex = 5;
            this.toolTip1.SetToolTip(this.TestArchiveButton, "Test the archive");
            this.TestArchiveButton.UseVisualStyleBackColor = false;
            this.TestArchiveButton.Click += new System.EventHandler(this.TestArchiveButton_Click);
            // 
            // OpenArchiveButton
            // 
            this.OpenArchiveButton.BackColor = System.Drawing.Color.Transparent;
            this.OpenArchiveButton.BackgroundImage = global::FrontEnd.Properties.Resources.openArchive;
            this.OpenArchiveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.OpenArchiveButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.OpenArchiveButton.FlatAppearance.BorderSize = 0;
            this.OpenArchiveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.OpenArchiveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.OpenArchiveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenArchiveButton.Location = new System.Drawing.Point(56, 3);
            this.OpenArchiveButton.Name = "OpenArchiveButton";
            this.OpenArchiveButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.OpenArchiveButton.Size = new System.Drawing.Size(39, 47);
            this.OpenArchiveButton.TabIndex = 3;
            this.toolTip1.SetToolTip(this.OpenArchiveButton, "Open another archive");
            this.OpenArchiveButton.UseVisualStyleBackColor = false;
            this.OpenArchiveButton.Click += new System.EventHandler(this.OpenArchiveButton_Click);
            // 
            // RemoveFileButton
            // 
            this.RemoveFileButton.BackColor = System.Drawing.Color.Transparent;
            this.RemoveFileButton.BackgroundImage = global::FrontEnd.Properties.Resources.RemoveFile;
            this.RemoveFileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RemoveFileButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.RemoveFileButton.FlatAppearance.BorderSize = 0;
            this.RemoveFileButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.RemoveFileButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.RemoveFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveFileButton.Location = new System.Drawing.Point(367, 3);
            this.RemoveFileButton.Name = "RemoveFileButton";
            this.RemoveFileButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RemoveFileButton.Size = new System.Drawing.Size(39, 47);
            this.RemoveFileButton.TabIndex = 10;
            this.toolTip1.SetToolTip(this.RemoveFileButton, "Remove the file");
            this.RemoveFileButton.UseVisualStyleBackColor = false;
            this.RemoveFileButton.Click += new System.EventHandler(this.RemoveFileButton_Click);
            // 
            // TestFileButton
            // 
            this.TestFileButton.BackColor = System.Drawing.Color.Transparent;
            this.TestFileButton.BackgroundImage = global::FrontEnd.Properties.Resources.TestFile;
            this.TestFileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TestFileButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.TestFileButton.FlatAppearance.BorderSize = 0;
            this.TestFileButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.TestFileButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.TestFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TestFileButton.Location = new System.Drawing.Point(322, 3);
            this.TestFileButton.Name = "TestFileButton";
            this.TestFileButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TestFileButton.Size = new System.Drawing.Size(39, 47);
            this.TestFileButton.TabIndex = 9;
            this.toolTip1.SetToolTip(this.TestFileButton, "Test the file");
            this.TestFileButton.UseVisualStyleBackColor = false;
            this.TestFileButton.Click += new System.EventHandler(this.TestFileButton_Click);
            // 
            // ExtractFileButton
            // 
            this.ExtractFileButton.BackColor = System.Drawing.Color.Transparent;
            this.ExtractFileButton.BackgroundImage = global::FrontEnd.Properties.Resources.ExtractFile;
            this.ExtractFileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ExtractFileButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ExtractFileButton.FlatAppearance.BorderSize = 0;
            this.ExtractFileButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ExtractFileButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ExtractFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExtractFileButton.Location = new System.Drawing.Point(277, 3);
            this.ExtractFileButton.Name = "ExtractFileButton";
            this.ExtractFileButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ExtractFileButton.Size = new System.Drawing.Size(39, 47);
            this.ExtractFileButton.TabIndex = 8;
            this.toolTip1.SetToolTip(this.ExtractFileButton, "Extract the file");
            this.ExtractFileButton.UseVisualStyleBackColor = false;
            this.ExtractFileButton.Click += new System.EventHandler(this.ExtractFileButton_Click);
            // 
            // addFileButton
            // 
            this.addFileButton.BackColor = System.Drawing.Color.Transparent;
            this.addFileButton.BackgroundImage = global::FrontEnd.Properties.Resources.AddFile;
            this.addFileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.addFileButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.addFileButton.FlatAppearance.BorderSize = 0;
            this.addFileButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.addFileButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.addFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addFileButton.Location = new System.Drawing.Point(232, 3);
            this.addFileButton.Name = "addFileButton";
            this.addFileButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.addFileButton.Size = new System.Drawing.Size(39, 47);
            this.addFileButton.TabIndex = 7;
            this.toolTip1.SetToolTip(this.addFileButton, "Add a file ");
            this.addFileButton.UseVisualStyleBackColor = false;
            this.addFileButton.Click += new System.EventHandler(this.addFileButton_Click);
            // 
            // newArchiveToolStripMenuItem
            // 
            this.newArchiveToolStripMenuItem.Image = global::FrontEnd.Properties.Resources.CreateArchive;
            this.newArchiveToolStripMenuItem.Name = "newArchiveToolStripMenuItem";
            this.newArchiveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newArchiveToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.newArchiveToolStripMenuItem.Text = "New";
            this.newArchiveToolStripMenuItem.Click += new System.EventHandler(this.newArchiveToolStripMenuItem_Click);
            // 
            // openArchiveToolStripMenuItem
            // 
            this.openArchiveToolStripMenuItem.Image = global::FrontEnd.Properties.Resources.OpenAnotherArchive;
            this.openArchiveToolStripMenuItem.Name = "openArchiveToolStripMenuItem";
            this.openArchiveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openArchiveToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.openArchiveToolStripMenuItem.Text = "Open...";
            this.openArchiveToolStripMenuItem.Click += new System.EventHandler(this.openArchiveToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Image = global::FrontEnd.Properties.Resources.CloseArchive;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.C)));
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::FrontEnd.Properties.Resources.exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // addFileToolStripMenuItem
            // 
            this.addFileToolStripMenuItem.Image = global::FrontEnd.Properties.Resources.AddFile;
            this.addFileToolStripMenuItem.Name = "addFileToolStripMenuItem";
            this.addFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.addFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addFileToolStripMenuItem.Text = "Add a file";
            this.addFileToolStripMenuItem.Click += new System.EventHandler(this.addFileToolStripMenuItem_Click);
            // 
            // theArchiveToolStripMenuItem
            // 
            this.theArchiveToolStripMenuItem.Image = global::FrontEnd.Properties.Resources.ExtractFile;
            this.theArchiveToolStripMenuItem.Name = "theArchiveToolStripMenuItem";
            this.theArchiveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.theArchiveToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.theArchiveToolStripMenuItem.Text = "Extract the file";
            this.theArchiveToolStripMenuItem.Click += new System.EventHandler(this.theArchiveToolStripMenuItem_Click);
            // 
            // theFileToolStripMenuItem
            // 
            this.theFileToolStripMenuItem.Image = global::FrontEnd.Properties.Resources.ExtractArchive;
            this.theFileToolStripMenuItem.Name = "theFileToolStripMenuItem";
            this.theFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.E)));
            this.theFileToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.theFileToolStripMenuItem.Text = "Extract the archive";
            this.theFileToolStripMenuItem.Click += new System.EventHandler(this.theFileToolStripMenuItem_Click);
            // 
            // testTheFileToolStripMenuItem1
            // 
            this.testTheFileToolStripMenuItem1.Image = global::FrontEnd.Properties.Resources.TestFile;
            this.testTheFileToolStripMenuItem1.Name = "testTheFileToolStripMenuItem1";
            this.testTheFileToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.testTheFileToolStripMenuItem1.Size = new System.Drawing.Size(225, 22);
            this.testTheFileToolStripMenuItem1.Text = "Test the file";
            this.testTheFileToolStripMenuItem1.Click += new System.EventHandler(this.testTheFileToolStripMenuItem1_Click);
            // 
            // testTheArchiveToolStripMenuItem
            // 
            this.testTheArchiveToolStripMenuItem.Image = global::FrontEnd.Properties.Resources.TestArchive;
            this.testTheArchiveToolStripMenuItem.Name = "testTheArchiveToolStripMenuItem";
            this.testTheArchiveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.T)));
            this.testTheArchiveToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.testTheArchiveToolStripMenuItem.Text = "Test the archive";
            this.testTheArchiveToolStripMenuItem.Click += new System.EventHandler(this.testTheArchiveToolStripMenuItem_Click);
            // 
            // removeTheFileToolStripMenuItem
            // 
            this.removeTheFileToolStripMenuItem.Image = global::FrontEnd.Properties.Resources.RemoveFile;
            this.removeTheFileToolStripMenuItem.Name = "removeTheFileToolStripMenuItem";
            this.removeTheFileToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.removeTheFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.removeTheFileToolStripMenuItem.Text = "Remove the file";
            this.removeTheFileToolStripMenuItem.Click += new System.EventHandler(this.removeTheFileToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(56, 118);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(231, 245);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 396);
            this.Controls.Add(this.ArchiveViewerPanel);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.welcomePanel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Huffman Archiver";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.welcomePanel.ResumeLayout(false);
            this.welcomePanel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ArchiveViewerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ArchiveVIEWER)).EndInit();
            this.ButtonsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel welcomePanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label welcomeLabel1;
        private System.Windows.Forms.Label welcomeLabel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem newArchiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openArchiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shortcutsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutHuffmanArchiverToolStripMenuItem;
        private System.Windows.Forms.Panel ArchiveViewerPanel;
        private System.Windows.Forms.Panel ButtonsPanel;
        private System.Windows.Forms.Button addFileButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button ExtractFileButton;
        private System.Windows.Forms.Button TestFileButton;
        private System.Windows.Forms.Button RemoveFileButton;
        private System.Windows.Forms.Button OpenArchiveButton;
        private System.Windows.Forms.Button TestArchiveButton;
        private System.Windows.Forms.Button ExtractArchiveButton;
        private System.Windows.Forms.Button CreateArchiveButton;
        private System.Windows.Forms.Button CloseArchiveButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.ToolStripMenuItem archiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extrToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testTheFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem theArchiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem theFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeTheFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testTheFileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem testTheArchiveToolStripMenuItem;
        public System.Windows.Forms.DataGridView ArchiveVIEWER;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn compressedSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn uncompressedSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn compressionRatio;
    }
}

