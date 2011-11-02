namespace Mandelbrot
{
    partial class ColorRenderer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorRenderer));
            this.buttonOK = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.buttonDefaults = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxConvergence = new System.Windows.Forms.TextBox();
            this.comboBoxColorMap = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelColor = new System.Windows.Forms.Panel();
            this.panelMixer = new System.Windows.Forms.Panel();
            this.buttonAddColor = new System.Windows.Forms.Button();
            this.buttonAddMap = new System.Windows.Forms.Button();
            this.buttonGradient = new System.Windows.Forms.Button();
            this.buttonSaveMap = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(416, 166);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(48, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "Ok";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // colorDialog
            // 
            this.colorDialog.AnyColor = true;
            this.colorDialog.FullOpen = true;
            // 
            // buttonDefaults
            // 
            this.buttonDefaults.Location = new System.Drawing.Point(55, 127);
            this.buttonDefaults.Name = "buttonDefaults";
            this.buttonDefaults.Size = new System.Drawing.Size(59, 23);
            this.buttonDefaults.TabIndex = 12;
            this.buttonDefaults.Text = "Defaults";
            this.buttonDefaults.UseVisualStyleBackColor = true;
            this.buttonDefaults.Click += new System.EventHandler(this.buttonDefaults_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 69);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "Convergence e^k :";
            // 
            // textBoxConvergence
            // 
            this.textBoxConvergence.Location = new System.Drawing.Point(13, 93);
            this.textBoxConvergence.Name = "textBoxConvergence";
            this.textBoxConvergence.Size = new System.Drawing.Size(167, 20);
            this.textBoxConvergence.TabIndex = 17;
            // 
            // comboBoxColorMap
            // 
            this.comboBoxColorMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxColorMap.FormattingEnabled = true;
            this.comboBoxColorMap.Location = new System.Drawing.Point(13, 37);
            this.comboBoxColorMap.Name = "comboBoxColorMap";
            this.comboBoxColorMap.Size = new System.Drawing.Size(169, 21);
            this.comboBoxColorMap.TabIndex = 19;
            this.comboBoxColorMap.SelectedIndexChanged += new System.EventHandler(this.comboBoxColorMap_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Choose A Map: ";
            // 
            // panelColor
            // 
            this.panelColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelColor.BackColor = System.Drawing.Color.White;
            this.panelColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelColor.Location = new System.Drawing.Point(199, 13);
            this.panelColor.Name = "panelColor";
            this.panelColor.Size = new System.Drawing.Size(514, 74);
            this.panelColor.TabIndex = 21;
            // 
            // panelMixer
            // 
            this.panelMixer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMixer.BackColor = System.Drawing.Color.White;
            this.panelMixer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMixer.Location = new System.Drawing.Point(198, 93);
            this.panelMixer.Name = "panelMixer";
            this.panelMixer.Size = new System.Drawing.Size(514, 34);
            this.panelMixer.TabIndex = 22;
            // 
            // buttonAddColor
            // 
            this.buttonAddColor.Location = new System.Drawing.Point(416, 132);
            this.buttonAddColor.Name = "buttonAddColor";
            this.buttonAddColor.Size = new System.Drawing.Size(33, 23);
            this.buttonAddColor.TabIndex = 23;
            this.buttonAddColor.Text = "++";
            this.buttonAddColor.UseVisualStyleBackColor = true;
            this.buttonAddColor.Click += new System.EventHandler(this.buttonAddColor_Click);
            // 
            // buttonAddMap
            // 
            this.buttonAddMap.Location = new System.Drawing.Point(290, 133);
            this.buttonAddMap.Name = "buttonAddMap";
            this.buttonAddMap.Size = new System.Drawing.Size(112, 23);
            this.buttonAddMap.TabIndex = 24;
            this.buttonAddMap.Text = "Add To Maps";
            this.buttonAddMap.UseVisualStyleBackColor = true;
            this.buttonAddMap.Click += new System.EventHandler(this.buttonAddMap_Click);
            // 
            // buttonGradient
            // 
            this.buttonGradient.Location = new System.Drawing.Point(203, 133);
            this.buttonGradient.Name = "buttonGradient";
            this.buttonGradient.Size = new System.Drawing.Size(75, 23);
            this.buttonGradient.TabIndex = 25;
            this.buttonGradient.Text = "Gradient";
            this.buttonGradient.UseVisualStyleBackColor = true;
            this.buttonGradient.Click += new System.EventHandler(this.buttonGradient_Click);
            // 
            // buttonSaveMap
            // 
            this.buttonSaveMap.Location = new System.Drawing.Point(463, 133);
            this.buttonSaveMap.Name = "buttonSaveMap";
            this.buttonSaveMap.Size = new System.Drawing.Size(167, 23);
            this.buttonSaveMap.TabIndex = 26;
            this.buttonSaveMap.Text = "Export Current ColorMap";
            this.buttonSaveMap.UseVisualStyleBackColor = true;
            this.buttonSaveMap.Click += new System.EventHandler(this.buttonSaveMap_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "ColorMap";
            this.saveFileDialog.Filter = "ColorMap files (*.ColorMap)|*.ColorMap";
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(637, 134);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 27;
            this.buttonLoad.Text = "Load...";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "ColorMap files (*.ColorMap)|*.ColorMap";
            // 
            // ColorRenderer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(724, 195);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonSaveMap);
            this.Controls.Add(this.buttonGradient);
            this.Controls.Add(this.buttonAddMap);
            this.Controls.Add(this.buttonAddColor);
            this.Controls.Add(this.panelMixer);
            this.Controls.Add(this.panelColor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxColorMap);
            this.Controls.Add(this.textBoxConvergence);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.buttonDefaults);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ColorRenderer";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Color Renderer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button buttonDefaults;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxConvergence;
        private System.Windows.Forms.ComboBox comboBoxColorMap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelColor;
        private System.Windows.Forms.Panel panelMixer;
        private System.Windows.Forms.Button buttonAddColor;
        private System.Windows.Forms.Button buttonAddMap;
        private System.Windows.Forms.Button buttonGradient;
        private System.Windows.Forms.Button buttonSaveMap;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}