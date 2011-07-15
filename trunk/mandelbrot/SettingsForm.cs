////////////////////////////////////////////////////////////////////
// SettingsForm.cs
// Copyright © 2006, 2008 Carl Johansen
// 
// Mandelbrot application settings form.
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published
// by the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more
// details (<http://www.gnu.org/licenses/>).
////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mandelbrot
{
    public partial class SettingsForm : Form
    {
        private bool userHitOK;

        public SettingsForm()
        {
            InitializeComponent();
            userHitOK = false;
        }

        public int MaxIterations
        {
            get { return Convert.ToInt32(txtMaxIterations.Text); }
            set { txtMaxIterations.Text = value.ToString(); }
        }

        private bool ValidateNewSettings()
        {
            bool result = true;
            try
            {
                int newMaxIterations = Convert.ToInt32(txtMaxIterations.Text);
                if (!(0 < newMaxIterations && newMaxIterations <= 99999))
                    throw new ArgumentException();
            }
            catch
            {
                result = false;
                MessageBox.Show("Enter an integer between 1 and 99999");
            }
            return result;
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (userHitOK)
            {
                userHitOK = false;
                if (!ValidateNewSettings())
                    e.Cancel = true;
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            userHitOK = true;
        }
    }
}