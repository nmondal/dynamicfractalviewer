using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Numerics;
using CodeGen;

namespace Mandelbrot
{
    public partial class CustomExpression : Form
    {
        internal static bool IsCompiled = false ;
        internal static CodeGen.CodedomCalculator calculator = new CodedomCalculator();
        
        internal static string expr;

        internal bool TryRunning()
        {
            return calculator.CreateInstanceReady(expr);
        }
        internal static Complex EvaluateCustomExpression(Complex z, Complex c)
        {
            return calculator.ExecuteExpressionValue(z, c);
        }
        
        public CustomExpression()
        {
            InitializeComponent();
        }

        private void buttonCompile_Click(object sender, EventArgs e)
        {
            expr = this.textBoxExpr.Text ;

            IsCompiled = TryRunning();
            if (IsCompiled)
            {
                this.Close();
            }
            else 
            {
                MessageBox.Show("There was exception running with 1,1", "Parser");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (IsCompiled)
            {
                IsCompiled = false;
            }
        }

        private void CustomExpression_Shown(object sender, EventArgs e)
        {
            if (expr != null)
            {
                this.textBoxExpr.Text = expr;
                IsCompiled = true;
            }
        }
    }
     
}
