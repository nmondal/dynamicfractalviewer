namespace Mandelbrot
{
    partial class CustomExpression
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomExpression));
            this.textBoxExpr = new System.Windows.Forms.TextBox();
            this.buttonCompile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxExpr
            // 
            this.textBoxExpr.Location = new System.Drawing.Point(14, 34);
            this.textBoxExpr.Multiline = true;
            this.textBoxExpr.Name = "textBoxExpr";
            this.textBoxExpr.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxExpr.Size = new System.Drawing.Size(522, 200);
            this.textBoxExpr.TabIndex = 0;
            this.textBoxExpr.WordWrap = false;
            this.textBoxExpr.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // buttonCompile
            // 
            this.buttonCompile.Location = new System.Drawing.Point(218, 248);
            this.buttonCompile.Name = "buttonCompile";
            this.buttonCompile.Size = new System.Drawing.Size(87, 25);
            this.buttonCompile.TabIndex = 1;
            this.buttonCompile.Text = "Compile";
            this.buttonCompile.UseVisualStyleBackColor = true;
            this.buttonCompile.Click += new System.EventHandler(this.buttonCompile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Write your Transform f : z <- f(z) here :--";
            // 
            // CustomExpression
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 285);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCompile);
            this.Controls.Add(this.textBoxExpr);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomExpression";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CustomExpression";
            this.Shown += new System.EventHandler(this.CustomExpression_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxExpr;
        private System.Windows.Forms.Button buttonCompile;
        private System.Windows.Forms.Label label1;
    }
}