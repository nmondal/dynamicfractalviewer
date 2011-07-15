namespace ColorMapFromImage
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
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.listBoxColors = new System.Windows.Forms.ListBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panelColor = new System.Windows.Forms.Panel();
            this.textBoxNum = new System.Windows.Forms.TextBox();
            this.buttonCluster = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.pictureBoxColorGradient = new System.Windows.Forms.PictureBox();
            this.buttonExport = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.textBoxDist = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxSort = new System.Windows.Forms.GroupBox();
            this.radioButtonI = new System.Windows.Forms.RadioButton();
            this.radioButtonB = new System.Windows.Forms.RadioButton();
            this.radioButtonG = new System.Windows.Forms.RadioButton();
            this.radioButtonR = new System.Windows.Forms.RadioButton();
            this.pictureBoxResultGradient = new System.Windows.Forms.PictureBox();
            this.buttonGradient = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColorGradient)).BeginInit();
            this.groupBoxSort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResultGradient)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxImage.BackColor = System.Drawing.Color.White;
            this.pictureBoxImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxImage.Location = new System.Drawing.Point(6, 4);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(375, 240);
            this.pictureBoxImage.TabIndex = 0;
            this.pictureBoxImage.TabStop = false;
            this.pictureBoxImage.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            // 
            // listBoxColors
            // 
            this.listBoxColors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxColors.FormattingEnabled = true;
            this.listBoxColors.Location = new System.Drawing.Point(430, 13);
            this.listBoxColors.Name = "listBoxColors";
            this.listBoxColors.Size = new System.Drawing.Size(145, 238);
            this.listBoxColors.TabIndex = 1;
            this.listBoxColors.SelectedIndexChanged += new System.EventHandler(this.listBoxColors_SelectedIndexChanged);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "All files (*.*)|*.*";
            // 
            // panelColor
            // 
            this.panelColor.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.panelColor.BackColor = System.Drawing.Color.White;
            this.panelColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelColor.Location = new System.Drawing.Point(391, 155);
            this.panelColor.Name = "panelColor";
            this.panelColor.Size = new System.Drawing.Size(31, 29);
            this.panelColor.TabIndex = 2;
            // 
            // textBoxNum
            // 
            this.textBoxNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNum.Location = new System.Drawing.Point(499, 335);
            this.textBoxNum.Name = "textBoxNum";
            this.textBoxNum.ReadOnly = true;
            this.textBoxNum.Size = new System.Drawing.Size(64, 20);
            this.textBoxNum.TabIndex = 3;
            // 
            // buttonCluster
            // 
            this.buttonCluster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCluster.Location = new System.Drawing.Point(393, 372);
            this.buttonCluster.Name = "buttonCluster";
            this.buttonCluster.Size = new System.Drawing.Size(75, 23);
            this.buttonCluster.TabIndex = 4;
            this.buttonCluster.Text = "Cluster";
            this.buttonCluster.UseVisualStyleBackColor = true;
            this.buttonCluster.Click += new System.EventHandler(this.buttonCluster_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonUp.Location = new System.Drawing.Point(393, 95);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(26, 36);
            this.buttonUp.TabIndex = 6;
            this.buttonUp.Text = "/\\";
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonDown.Location = new System.Drawing.Point(393, 208);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(26, 36);
            this.buttonDown.TabIndex = 7;
            this.buttonDown.Text = "\\/";
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // pictureBoxColorGradient
            // 
            this.pictureBoxColorGradient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxColorGradient.BackColor = System.Drawing.Color.White;
            this.pictureBoxColorGradient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxColorGradient.Location = new System.Drawing.Point(11, 261);
            this.pictureBoxColorGradient.Name = "pictureBoxColorGradient";
            this.pictureBoxColorGradient.Size = new System.Drawing.Size(563, 27);
            this.pictureBoxColorGradient.TabIndex = 8;
            this.pictureBoxColorGradient.TabStop = false;
            // 
            // buttonExport
            // 
            this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExport.Location = new System.Drawing.Point(499, 370);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(75, 23);
            this.buttonExport.TabIndex = 9;
            this.buttonExport.Text = "Export";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "All files (*.*)|*.*";
            // 
            // textBoxDist
            // 
            this.textBoxDist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDist.Location = new System.Drawing.Point(292, 375);
            this.textBoxDist.Name = "textBoxDist";
            this.textBoxDist.Size = new System.Drawing.Size(89, 20);
            this.textBoxDist.TabIndex = 10;
            this.textBoxDist.Text = "0.2";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(295, 349);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Distance : ";
            // 
            // groupBoxSort
            // 
            this.groupBoxSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxSort.Controls.Add(this.radioButtonI);
            this.groupBoxSort.Controls.Add(this.radioButtonB);
            this.groupBoxSort.Controls.Add(this.radioButtonG);
            this.groupBoxSort.Controls.Add(this.radioButtonR);
            this.groupBoxSort.Location = new System.Drawing.Point(8, 334);
            this.groupBoxSort.Name = "groupBoxSort";
            this.groupBoxSort.Size = new System.Drawing.Size(280, 64);
            this.groupBoxSort.TabIndex = 12;
            this.groupBoxSort.TabStop = false;
            this.groupBoxSort.Text = "Sort By ";
            // 
            // radioButtonI
            // 
            this.radioButtonI.AutoSize = true;
            this.radioButtonI.Checked = true;
            this.radioButtonI.Location = new System.Drawing.Point(178, 20);
            this.radioButtonI.Name = "radioButtonI";
            this.radioButtonI.Size = new System.Drawing.Size(64, 17);
            this.radioButtonI.TabIndex = 3;
            this.radioButtonI.TabStop = true;
            this.radioButtonI.Text = "Intensity";
            this.radioButtonI.UseVisualStyleBackColor = true;
            this.radioButtonI.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonB
            // 
            this.radioButtonB.AutoSize = true;
            this.radioButtonB.Location = new System.Drawing.Point(122, 20);
            this.radioButtonB.Name = "radioButtonB";
            this.radioButtonB.Size = new System.Drawing.Size(32, 17);
            this.radioButtonB.TabIndex = 2;
            this.radioButtonB.Text = "B";
            this.radioButtonB.UseVisualStyleBackColor = true;
            this.radioButtonB.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonG
            // 
            this.radioButtonG.AutoSize = true;
            this.radioButtonG.Location = new System.Drawing.Point(73, 20);
            this.radioButtonG.Name = "radioButtonG";
            this.radioButtonG.Size = new System.Drawing.Size(33, 17);
            this.radioButtonG.TabIndex = 1;
            this.radioButtonG.Text = "G";
            this.radioButtonG.UseVisualStyleBackColor = true;
            this.radioButtonG.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonR
            // 
            this.radioButtonR.AutoSize = true;
            this.radioButtonR.Location = new System.Drawing.Point(16, 19);
            this.radioButtonR.Name = "radioButtonR";
            this.radioButtonR.Size = new System.Drawing.Size(33, 17);
            this.radioButtonR.TabIndex = 0;
            this.radioButtonR.Text = "R";
            this.radioButtonR.UseVisualStyleBackColor = true;
            this.radioButtonR.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // pictureBoxResultGradient
            // 
            this.pictureBoxResultGradient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxResultGradient.BackColor = System.Drawing.Color.White;
            this.pictureBoxResultGradient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxResultGradient.Location = new System.Drawing.Point(11, 299);
            this.pictureBoxResultGradient.Name = "pictureBoxResultGradient";
            this.pictureBoxResultGradient.Size = new System.Drawing.Size(563, 27);
            this.pictureBoxResultGradient.TabIndex = 13;
            this.pictureBoxResultGradient.TabStop = false;
            // 
            // buttonGradient
            // 
            this.buttonGradient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGradient.Location = new System.Drawing.Point(378, 334);
            this.buttonGradient.Name = "buttonGradient";
            this.buttonGradient.Size = new System.Drawing.Size(106, 23);
            this.buttonGradient.TabIndex = 14;
            this.buttonGradient.Text = "Create Gradient";
            this.buttonGradient.UseVisualStyleBackColor = true;
            this.buttonGradient.Click += new System.EventHandler(this.buttonGradient_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 404);
            this.Controls.Add(this.buttonGradient);
            this.Controls.Add(this.pictureBoxResultGradient);
            this.Controls.Add(this.groupBoxSort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDist);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.pictureBoxColorGradient);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.buttonCluster);
            this.Controls.Add(this.textBoxNum);
            this.Controls.Add(this.panelColor);
            this.Controls.Add(this.listBoxColors);
            this.Controls.Add(this.pictureBoxImage);
            this.Name = "MainForm";
            this.Text = "Color Map From Image";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColorGradient)).EndInit();
            this.groupBoxSort.ResumeLayout(false);
            this.groupBoxSort.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResultGradient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.ListBox listBoxColors;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Panel panelColor;
        private System.Windows.Forms.TextBox textBoxNum;
        private System.Windows.Forms.Button buttonCluster;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.PictureBox pictureBoxColorGradient;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TextBox textBoxDist;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxSort;
        private System.Windows.Forms.RadioButton radioButtonB;
        private System.Windows.Forms.RadioButton radioButtonG;
        private System.Windows.Forms.RadioButton radioButtonR;
        private System.Windows.Forms.RadioButton radioButtonI;
        private System.Windows.Forms.PictureBox pictureBoxResultGradient;
        private System.Windows.Forms.Button buttonGradient;
    }
}

