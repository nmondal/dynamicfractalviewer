namespace Mandelbrot
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemColors = new System.Windows.Forms.ToolStripMenuItem();
            this.generateAnimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoZoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualZoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewStopDrawing = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.qualityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fixAspectRatioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.zoomeOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomeInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxPower = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripComboBoxPhase = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripComboBoxFractalType = new System.Windows.Forms.ToolStripComboBox();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.lblProgressCaption = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBarDrawing = new System.Windows.Forms.ToolStripProgressBar();
            this.lblCoords = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblZoomFactor = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.toolStripTextBoxPower,
            this.toolStripComboBoxPhase,
            this.toolStripComboBoxFractalType});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(791, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.toolStripSeparator3,
            this.toolStripMenuItemColors,
            this.generateAnimToolStripMenuItem,
            this.toolStripSeparator4,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 23);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(150, 6);
            // 
            // toolStripMenuItemColors
            // 
            this.toolStripMenuItemColors.Name = "toolStripMenuItemColors";
            this.toolStripMenuItemColors.Size = new System.Drawing.Size(153, 22);
            this.toolStripMenuItemColors.Text = "C&olors";
            this.toolStripMenuItemColors.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripMenuItemColors.Click += new System.EventHandler(this.toolStripMenuItemColors_Click);
            // 
            // generateAnimToolStripMenuItem
            // 
            this.generateAnimToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoZoomToolStripMenuItem,
            this.manualZoomToolStripMenuItem});
            this.generateAnimToolStripMenuItem.Name = "generateAnimToolStripMenuItem";
            this.generateAnimToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.generateAnimToolStripMenuItem.Text = "Generate Anim";
            // 
            // autoZoomToolStripMenuItem
            // 
            this.autoZoomToolStripMenuItem.Name = "autoZoomToolStripMenuItem";
            this.autoZoomToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.autoZoomToolStripMenuItem.Text = "Auto Zoom";
            this.autoZoomToolStripMenuItem.Click += new System.EventHandler(this.autoZoomToolStripMenuItem_Click);
            // 
            // manualZoomToolStripMenuItem
            // 
            this.manualZoomToolStripMenuItem.Name = "manualZoomToolStripMenuItem";
            this.manualZoomToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.manualZoomToolStripMenuItem.Text = "Manual Zoom";
            this.manualZoomToolStripMenuItem.Click += new System.EventHandler(this.manualZoomToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(150, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.mnuViewStopDrawing,
            this.toolStripSeparator1,
            this.qualityToolStripMenuItem,
            this.fixAspectRatioToolStripMenuItem,
            this.toolStripSeparator2,
            this.zoomeOutToolStripMenuItem,
            this.zoomeInToolStripMenuItem,
            this.toolStripSeparator5,
            this.backToolStripMenuItem,
            this.forwardToolStripMenuItem,
            this.resetToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 23);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.refreshToolStripMenuItem.Text = "&Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // mnuViewStopDrawing
            // 
            this.mnuViewStopDrawing.Enabled = false;
            this.mnuViewStopDrawing.Name = "mnuViewStopDrawing";
            this.mnuViewStopDrawing.ShortcutKeyDisplayString = "Esc";
            this.mnuViewStopDrawing.Size = new System.Drawing.Size(179, 22);
            this.mnuViewStopDrawing.Text = "Stop";
            this.mnuViewStopDrawing.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(176, 6);
            // 
            // qualityToolStripMenuItem
            // 
            this.qualityToolStripMenuItem.Name = "qualityToolStripMenuItem";
            this.qualityToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.qualityToolStripMenuItem.Text = "Image &Quality...";
            this.qualityToolStripMenuItem.Click += new System.EventHandler(this.qualityToolStripMenuItem_Click);
            // 
            // fixAspectRatioToolStripMenuItem
            // 
            this.fixAspectRatioToolStripMenuItem.Name = "fixAspectRatioToolStripMenuItem";
            this.fixAspectRatioToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.fixAspectRatioToolStripMenuItem.Text = "&Lock Aspect Ratio";
            this.fixAspectRatioToolStripMenuItem.Click += new System.EventHandler(this.fixAspectRatioToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(176, 6);
            // 
            // zoomeOutToolStripMenuItem
            // 
            this.zoomeOutToolStripMenuItem.Name = "zoomeOutToolStripMenuItem";
            this.zoomeOutToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.zoomeOutToolStripMenuItem.Text = "Zoome Out";
            this.zoomeOutToolStripMenuItem.Click += new System.EventHandler(this.zoomeOutToolStripMenuItem_Click);
            // 
            // zoomeInToolStripMenuItem
            // 
            this.zoomeInToolStripMenuItem.Name = "zoomeInToolStripMenuItem";
            this.zoomeInToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.zoomeInToolStripMenuItem.Text = "Zoome In";
            this.zoomeInToolStripMenuItem.Click += new System.EventHandler(this.zoomeInToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(176, 6);
            // 
            // backToolStripMenuItem
            // 
            this.backToolStripMenuItem.Name = "backToolStripMenuItem";
            this.backToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Left)));
            this.backToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.backToolStripMenuItem.Text = "Back";
            this.backToolStripMenuItem.Click += new System.EventHandler(this.backToolStripMenuItem_Click);
            // 
            // forwardToolStripMenuItem
            // 
            this.forwardToolStripMenuItem.Name = "forwardToolStripMenuItem";
            this.forwardToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right)));
            this.forwardToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.forwardToolStripMenuItem.Text = "Forward";
            this.forwardToolStripMenuItem.Click += new System.EventHandler(this.forwardToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.resetToolStripMenuItem.Text = "R&eset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 23);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.aboutToolStripMenuItem.Text = "&About Mandelbrot Set Viewer";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripTextBoxPower
            // 
            this.toolStripTextBoxPower.Name = "toolStripTextBoxPower";
            this.toolStripTextBoxPower.Size = new System.Drawing.Size(116, 23);
            // 
            // toolStripComboBoxPhase
            // 
            this.toolStripComboBoxPhase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxPhase.Items.AddRange(new object[] {
            "0.00",
            "0.17",
            "0.25",
            "0.33",
            "0.50",
            "0.67",
            "0.75",
            "0.87",
            "1.00",
            "1.17",
            "1.25",
            "1.33",
            "1.50",
            "1.67",
            "1.75",
            "1.87",
            "2.00"});
            this.toolStripComboBoxPhase.Name = "toolStripComboBoxPhase";
            this.toolStripComboBoxPhase.Size = new System.Drawing.Size(140, 23);
            this.toolStripComboBoxPhase.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxPhase_SelectedIndexChanged);
            // 
            // toolStripComboBoxFractalType
            // 
            this.toolStripComboBoxFractalType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxFractalType.Name = "toolStripComboBoxFractalType";
            this.toolStripComboBoxFractalType.Size = new System.Drawing.Size(186, 23);
            this.toolStripComboBoxFractalType.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxFractalType_SelectedIndexChanged);
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblProgressCaption,
            this.progressBarDrawing,
            this.lblCoords,
            this.lblZoomFactor});
            this.statusStripMain.Location = new System.Drawing.Point(0, 467);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStripMain.Size = new System.Drawing.Size(791, 22);
            this.statusStripMain.TabIndex = 1;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // lblProgressCaption
            // 
            this.lblProgressCaption.BackColor = System.Drawing.SystemColors.Control;
            this.lblProgressCaption.Name = "lblProgressCaption";
            this.lblProgressCaption.Size = new System.Drawing.Size(51, 17);
            this.lblProgressCaption.Text = "Drawing";
            this.lblProgressCaption.Visible = false;
            // 
            // progressBarDrawing
            // 
            this.progressBarDrawing.Name = "progressBarDrawing";
            this.progressBarDrawing.Size = new System.Drawing.Size(117, 16);
            this.progressBarDrawing.Visible = false;
            // 
            // lblCoords
            // 
            this.lblCoords.BackColor = System.Drawing.SystemColors.Control;
            this.lblCoords.Name = "lblCoords";
            this.lblCoords.Size = new System.Drawing.Size(0, 17);
            // 
            // lblZoomFactor
            // 
            this.lblZoomFactor.BackColor = System.Drawing.SystemColors.Control;
            this.lblZoomFactor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblZoomFactor.Name = "lblZoomFactor";
            this.lblZoomFactor.Size = new System.Drawing.Size(0, 17);
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 5000;
            this.toolTip.InitialDelay = 100;
            this.toolTip.ReshowDelay = 100;
            this.toolTip.ShowAlways = true;
            this.toolTip.ToolTipTitle = "About Params";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(791, 489);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Fractal Set Designer And Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qualityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuViewStopDrawing;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel lblCoords;
        private System.Windows.Forms.ToolStripProgressBar progressBarDrawing;
        private System.Windows.Forms.ToolStripStatusLabel lblProgressCaption;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fixAspectRatioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripStatusLabel lblZoomFactor;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxPower;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxFractalType;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxPhase;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemColors;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem zoomeOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomeInToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem generateAnimToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoZoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualZoomToolStripMenuItem;
    }
}

