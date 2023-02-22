namespace SageHopkins_PP_1_Game_Of_Life
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromSeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromCurrentSeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleNeighborCountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toogleHUDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.universeSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adjustColorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridColorButton = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundColorButton = new System.Windows.Forms.ToolStripMenuItem();
            this.cellColorButton = new System.Windows.Forms.ToolStripMenuItem();
            this.deadCellButton = new System.Windows.Forms.ToolStripMenuItem();
            this.hudFillButton = new System.Windows.Forms.ToolStripMenuItem();
            this.hudOutlineButton = new System.Windows.Forms.ToolStripMenuItem();
            this.boundaryToggleButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.startButton = new System.Windows.Forms.ToolStripButton();
            this.pauseButton = new System.Windows.Forms.ToolStripButton();
            this.stopButton = new System.Windows.Forms.ToolStripButton();
            this.nextButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelGenerations = new System.Windows.Forms.ToolStripStatusLabel();
            this.reloadSettingsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreSettingButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveSettingsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.graphicsPanel1 = new SageHopkins_PP_1_Game_Of_Life.GraphicsPanel();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.randomizeToolStripMenuItem,
            this.optionsToolStripMenuItem1,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(860, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openButton_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(267, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(267, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(267, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // randomizeToolStripMenuItem
            // 
            this.randomizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromSeedToolStripMenuItem,
            this.fromCurrentSeedToolStripMenuItem,
            this.fromTimeToolStripMenuItem});
            this.randomizeToolStripMenuItem.Name = "randomizeToolStripMenuItem";
            this.randomizeToolStripMenuItem.Size = new System.Drawing.Size(117, 29);
            this.randomizeToolStripMenuItem.Text = "Randomize";
            // 
            // fromSeedToolStripMenuItem
            // 
            this.fromSeedToolStripMenuItem.Name = "fromSeedToolStripMenuItem";
            this.fromSeedToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.fromSeedToolStripMenuItem.Text = "From Seed";
            this.fromSeedToolStripMenuItem.Click += new System.EventHandler(this.fromSeedButton_Click);
            // 
            // fromCurrentSeedToolStripMenuItem
            // 
            this.fromCurrentSeedToolStripMenuItem.Name = "fromCurrentSeedToolStripMenuItem";
            this.fromCurrentSeedToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.fromCurrentSeedToolStripMenuItem.Text = "From Current Seed";
            this.fromCurrentSeedToolStripMenuItem.Click += new System.EventHandler(this.fromCurrentSeedButton_Click);
            // 
            // fromTimeToolStripMenuItem
            // 
            this.fromTimeToolStripMenuItem.Name = "fromTimeToolStripMenuItem";
            this.fromTimeToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.fromTimeToolStripMenuItem.Text = "From Time";
            this.fromTimeToolStripMenuItem.Click += new System.EventHandler(this.fromTimeButton_Click);
            // 
            // optionsToolStripMenuItem1
            // 
            this.optionsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toggleGridToolStripMenuItem,
            this.toggleNeighborCountToolStripMenuItem,
            this.toogleHUDToolStripMenuItem});
            this.optionsToolStripMenuItem1.Name = "optionsToolStripMenuItem1";
            this.optionsToolStripMenuItem1.Size = new System.Drawing.Size(65, 29);
            this.optionsToolStripMenuItem1.Text = "View";
            // 
            // toggleGridToolStripMenuItem
            // 
            this.toggleGridToolStripMenuItem.Name = "toggleGridToolStripMenuItem";
            this.toggleGridToolStripMenuItem.Size = new System.Drawing.Size(300, 34);
            this.toggleGridToolStripMenuItem.Text = "Toggle Grid";
            this.toggleGridToolStripMenuItem.Click += new System.EventHandler(this.toggleGridButton_Click);
            // 
            // toggleNeighborCountToolStripMenuItem
            // 
            this.toggleNeighborCountToolStripMenuItem.Name = "toggleNeighborCountToolStripMenuItem";
            this.toggleNeighborCountToolStripMenuItem.Size = new System.Drawing.Size(300, 34);
            this.toggleNeighborCountToolStripMenuItem.Text = "Toggle Neighbor Count";
            this.toggleNeighborCountToolStripMenuItem.Click += new System.EventHandler(this.toggleNeighborCountButton_Click);
            // 
            // toogleHUDToolStripMenuItem
            // 
            this.toogleHUDToolStripMenuItem.Name = "toogleHUDToolStripMenuItem";
            this.toogleHUDToolStripMenuItem.Size = new System.Drawing.Size(300, 34);
            this.toogleHUDToolStripMenuItem.Text = "Toogle HUD";
            this.toogleHUDToolStripMenuItem.Click += new System.EventHandler(this.toggleHUDButton_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timingToolStripMenuItem,
            this.universeSizeToolStripMenuItem,
            this.adjustColorsToolStripMenuItem,
            this.boundaryToggleButton,
            this.toolStripSeparator3,
            this.saveSettingsButton,
            this.reloadSettingsButton,
            this.restoreSettingButton});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(92, 29);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // timingToolStripMenuItem
            // 
            this.timingToolStripMenuItem.Name = "timingToolStripMenuItem";
            this.timingToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.timingToolStripMenuItem.Text = "Timing";
            this.timingToolStripMenuItem.Click += new System.EventHandler(this.timingButton_Click);
            // 
            // universeSizeToolStripMenuItem
            // 
            this.universeSizeToolStripMenuItem.Name = "universeSizeToolStripMenuItem";
            this.universeSizeToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.universeSizeToolStripMenuItem.Text = "Universe Size";
            this.universeSizeToolStripMenuItem.Click += new System.EventHandler(this.universeSizeButton_click);
            // 
            // adjustColorsToolStripMenuItem
            // 
            this.adjustColorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gridColorButton,
            this.backgroundColorButton,
            this.cellColorButton,
            this.deadCellButton,
            this.hudFillButton,
            this.hudOutlineButton});
            this.adjustColorsToolStripMenuItem.Name = "adjustColorsToolStripMenuItem";
            this.adjustColorsToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.adjustColorsToolStripMenuItem.Text = "Adjust Colors";
            // 
            // gridColorButton
            // 
            this.gridColorButton.Name = "gridColorButton";
            this.gridColorButton.Size = new System.Drawing.Size(214, 34);
            this.gridColorButton.Text = "Grid";
            this.gridColorButton.Click += new System.EventHandler(this.gridColorButton_Click);
            // 
            // backgroundColorButton
            // 
            this.backgroundColorButton.Name = "backgroundColorButton";
            this.backgroundColorButton.Size = new System.Drawing.Size(214, 34);
            this.backgroundColorButton.Text = "Background";
            this.backgroundColorButton.Click += new System.EventHandler(this.backgroundColorButton_Click);
            // 
            // cellColorButton
            // 
            this.cellColorButton.Name = "cellColorButton";
            this.cellColorButton.Size = new System.Drawing.Size(214, 34);
            this.cellColorButton.Text = "Cell";
            this.cellColorButton.Click += new System.EventHandler(this.cellColorButton_Click);
            // 
            // deadCellButton
            // 
            this.deadCellButton.Name = "deadCellButton";
            this.deadCellButton.Size = new System.Drawing.Size(214, 34);
            this.deadCellButton.Text = "Dead Cell";
            this.deadCellButton.Click += new System.EventHandler(this.deadCellButton_Click);
            // 
            // hudFillButton
            // 
            this.hudFillButton.Name = "hudFillButton";
            this.hudFillButton.Size = new System.Drawing.Size(214, 34);
            this.hudFillButton.Text = "HUD Fill";
            this.hudFillButton.Click += new System.EventHandler(this.hudFillButton_Click);
            // 
            // hudOutlineButton
            // 
            this.hudOutlineButton.Name = "hudOutlineButton";
            this.hudOutlineButton.Size = new System.Drawing.Size(214, 34);
            this.hudOutlineButton.Text = "HUD Outline";
            this.hudOutlineButton.Click += new System.EventHandler(this.hudOutlineButton_Click);
            // 
            // boundaryToggleButton
            // 
            this.boundaryToggleButton.Name = "boundaryToggleButton";
            this.boundaryToggleButton.Size = new System.Drawing.Size(270, 34);
            this.boundaryToggleButton.Text = "Finite Boundary";
            this.boundaryToggleButton.Click += new System.EventHandler(this.boundaryToggleButton_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newButton,
            this.toolStripSeparator6,
            this.toolStripSeparator7,
            this.startButton,
            this.pauseButton,
            this.stopButton,
            this.nextButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 33);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.Size = new System.Drawing.Size(860, 33);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newButton
            // 
            this.newButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newButton.Image = ((System.Drawing.Image)(resources.GetObject("newButton.Image")));
            this.newButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(34, 28);
            this.newButton.Text = "New";
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 33);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 33);
            // 
            // startButton
            // 
            this.startButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.startButton.Image = ((System.Drawing.Image)(resources.GetObject("startButton.Image")));
            this.startButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(34, 28);
            this.startButton.Text = "Start";
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pauseButton.Image = ((System.Drawing.Image)(resources.GetObject("pauseButton.Image")));
            this.pauseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(34, 28);
            this.pauseButton.Text = "Pause";
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopButton.Image = ((System.Drawing.Image)(resources.GetObject("stopButton.Image")));
            this.stopButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(34, 28);
            this.stopButton.Text = "Stop";
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nextButton.Image = ((System.Drawing.Image)(resources.GetObject("nextButton.Image")));
            this.nextButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(34, 28);
            this.nextButton.Text = "Next";
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelGenerations});
            this.statusStrip1.Location = new System.Drawing.Point(0, 499);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(860, 32);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelGenerations
            // 
            this.toolStripStatusLabelGenerations.Name = "toolStripStatusLabelGenerations";
            this.toolStripStatusLabelGenerations.Size = new System.Drawing.Size(138, 25);
            this.toolStripStatusLabelGenerations.Text = "Generations = 0";
            // 
            // reloadSettingsButton
            // 
            this.reloadSettingsButton.Name = "reloadSettingsButton";
            this.reloadSettingsButton.Size = new System.Drawing.Size(270, 34);
            this.reloadSettingsButton.Text = "Reload Settings";
            this.reloadSettingsButton.Click += new System.EventHandler(this.reloadSettingsButton_Click);
            // 
            // restoreSettingButton
            // 
            this.restoreSettingButton.Name = "restoreSettingButton";
            this.restoreSettingButton.Size = new System.Drawing.Size(270, 34);
            this.restoreSettingButton.Text = "Reset Settings";
            this.restoreSettingButton.Click += new System.EventHandler(this.restoreSettingButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(267, 6);
            // 
            // saveSettingsButton
            // 
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Size = new System.Drawing.Size(270, 34);
            this.saveSettingsButton.Text = "Save Settings";
            this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
            // 
            // graphicsPanel1
            // 
            this.graphicsPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.graphicsPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphicsPanel1.Location = new System.Drawing.Point(0, 66);
            this.graphicsPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.graphicsPanel1.Name = "graphicsPanel1";
            this.graphicsPanel1.Size = new System.Drawing.Size(860, 433);
            this.graphicsPanel1.TabIndex = 3;
            this.graphicsPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.graphicsPanel1_Paint);
            this.graphicsPanel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.graphicsPanel1_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 531);
            this.Controls.Add(this.graphicsPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Game of Life";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private GraphicsPanel graphicsPanel1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton newButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelGenerations;
        private System.Windows.Forms.ToolStripButton startButton;
        private System.Windows.Forms.ToolStripButton pauseButton;
        private System.Windows.Forms.ToolStripButton stopButton;
        private System.Windows.Forms.ToolStripButton nextButton;
        private System.Windows.Forms.ToolStripMenuItem randomizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromSeedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromCurrentSeedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toggleGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleNeighborCountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toogleHUDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem universeSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adjustColorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gridColorButton;
        private System.Windows.Forms.ToolStripMenuItem backgroundColorButton;
        private System.Windows.Forms.ToolStripMenuItem cellColorButton;
        private System.Windows.Forms.ToolStripMenuItem deadCellButton;
        private System.Windows.Forms.ToolStripMenuItem hudFillButton;
        private System.Windows.Forms.ToolStripMenuItem hudOutlineButton;
        private System.Windows.Forms.ToolStripMenuItem boundaryToggleButton;
        private System.Windows.Forms.ToolStripMenuItem reloadSettingsButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem restoreSettingButton;
        private System.Windows.Forms.ToolStripMenuItem saveSettingsButton;
    }
}

