////////////////////////////////////////////////////////////////////
// MainForm.cs
// Copyright © 2006, 2008 Carl Johansen
// 
// UI for Mandelbrot set viewer
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
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Mandelbrot
{
    public partial class MainForm : Form
    {
        Bitmap bmpMandSet = null;
        private bool drawingCancelled = false;
        private ViewManager viewManager;

        private int maxIterations;

        private bool isRubberBanding;
        private bool isDrawing;
        private bool isClosing;
        private int bitmapYoffset;

        private Point ptLast;
        private Point ptOriginal;
        private Rectangle rectLast;

        public MainForm()
        {
            InitializeComponent();
            //Add all type of fractals...
			string[] Names = Enum.GetNames( typeof ( Fractals.TransformType ) );
			foreach ( string s in  Names ) 
			{
				this.toolStripComboBoxFractalType.Items.Add(s);
			}
			this.toolStripTextBoxPower.Text = Fractals.ConstK.ToString();
            this.toolStripComboBoxFractalType.SelectedIndex = 0;
            this.toolStripComboBoxPhase.SelectedIndex = 0 ;
            

        }

        private bool LockAspectRatio
        {
            get { return fixAspectRatioToolStripMenuItem.Checked; }
            set { fixAspectRatioToolStripMenuItem.Checked = value; }
        }

        private int ClientAreaWidth
        {
            get { return this.ClientRectangle.Width; }
        }

        private int ClientAreaHeight
        {
            get { return (this.ClientRectangle.Height - bitmapYoffset - statusStripMain.Height); }
        }

        private int BitmapHeight
        {
            get {   if(bmpMandSet == null)
                        return 0;
                    else
                        return bmpMandSet.Height;
                }
        }

        int _hasFullUIPermission = -1;
        private bool HasFullUIPermission
        {
            get
            {
                if (_hasFullUIPermission == -1)
                {
                    // We haven't cached this setting yet, so determine it now...
                    try
                    {
                        // Try to demand a UIPermission of AllWindows and see if a SecurityException is thrown.
                        System.Security.Permissions.UIPermission x = new System.Security.Permissions.UIPermission(System.Security.Permissions.UIPermissionWindow.AllWindows);
                        x.Demand();
                        _hasFullUIPermission = 1; // If we got to this point then we have AllWindows permission.
                    }
                    catch (System.Security.SecurityException)
                    {   // Looks like we don't have AllWindows permission.
                        _hasFullUIPermission = 0;
                    }
                }
                return (_hasFullUIPermission == 1);
            }
        }

        private void ResetView()
        {
            switch (Fractals.CurrentTransformType)
            {
                case Fractals.TransformType.MultiBrot :
                    maxIterations = 500;
                    break;
                default:
					maxIterations = 400;
                    break;
            }
           
            viewManager.Reset();
            ShowHideMenus();
        }

        private void MousePtToZ(int x, int y, out double a, out double b)
        {
            viewManager.PixelToZ(x, y - bitmapYoffset, BitmapHeight, out a, out b);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            isRubberBanding = false;
            isDrawing = false;
            isClosing = false;
            LockAspectRatio = true;
            bitmapYoffset = menuStrip1.Height;

            viewManager = new ViewManager();

            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);

            if (!HasFullUIPermission)
                saveToolStripMenuItem.Enabled = false;

            ResetView();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            DrawBitmapToScreen(e.Graphics);
        }

        private void DrawBitmapToScreen(Graphics formGraphics)
        {
            //Redraw the bitmap
            formGraphics.DrawImage(bmpMandSet, new Point(0, bitmapYoffset));

            //If the window has been enlarged without a Refresh (so that the bitmap does not take up the whole
            // window), clear the excess areas in case the user is doing a partial-trust rubber band.
            if (bmpMandSet.Width < ClientAreaWidth || bmpMandSet.Height < ClientAreaHeight)
            {
                SolidBrush blankBrush = new SolidBrush(this.BackColor);
                if (bmpMandSet.Width < ClientAreaWidth)
                    formGraphics.FillRectangle(blankBrush, bmpMandSet.Width, bitmapYoffset, ClientAreaWidth - bmpMandSet.Width, ClientAreaHeight);
                if (bmpMandSet.Height < ClientAreaHeight)
                    formGraphics.FillRectangle(blankBrush, 0, bitmapYoffset + bmpMandSet.Height, ClientAreaWidth, ClientAreaHeight - bmpMandSet.Height);
                blankBrush.Dispose();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            isDrawing = false;
            isClosing = true;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            DrawSet();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (!isDrawing)
            {
                // Make a note that we "have the mouse".
                isRubberBanding = true;
                // Store the "starting point" for this rubber-band rectangle.
                ptOriginal.X = e.X;
                ptOriginal.Y = e.Y;
                // Special value lets us know that no previous
                // rectangle needs to be erased.
                ptLast.X = -1;
                ptLast.Y = -1;
            }
        }

        private void ZoomeOut()
        {
            double zoomMinA =0, zoomMaxA=0, zoomMinB=0, zoomMaxB=0;

            MousePtToZ(this.ClientRectangle.Left, this.ClientRectangle.Top , out zoomMinA, out zoomMaxB);
            MousePtToZ(this.ClientRectangle.Right, this.ClientRectangle.Bottom , out zoomMaxA, out zoomMinB);
                 
            viewManager.ChangeViewport(zoomMinA -1.0 , zoomMaxA +1.0 , zoomMinB -1.0 , zoomMaxB + 1.0 , true);
            ShowHideMenus();
            DrawSet();
        }
        private void ZoomeIn()
        {
            double zoomMinA = 0, zoomMaxA = 0, zoomMinB = 0, zoomMaxB = 0;

            MousePtToZ(this.ClientRectangle.Left, this.ClientRectangle.Top, out zoomMinA, out zoomMaxB);
            MousePtToZ(this.ClientRectangle.Right, this.ClientRectangle.Bottom, out zoomMaxA, out zoomMinB);
            
            //Find the center point...
            double deltaA = (zoomMaxA - zoomMinA) / 5;
            double deltaB = (zoomMaxB - zoomMinB) / 5;

            //Zoom in about the 40% of the center...how?


            viewManager.ChangeViewport(zoomMinA + deltaA , zoomMaxA - deltaA , zoomMinB + deltaB , zoomMaxB - deltaB , true);
            ShowHideMenus();
            DrawSet();
        }
        private void AutoAnimateWithSaveImage()
        {
            //Default images count = 15;
            int count = 15;
            drawingCancelled = false;
            string baseDir = Environment.GetEnvironmentVariable("TMP") + @"\" + "Fractals";
            if (!System.IO.Directory.Exists(baseDir ))
            {
                
                System.IO.Directory.CreateDirectory(baseDir);
            }
            string prefix = DateTime.Now.Ticks.ToString();
            int i = 0;
            while (i++ < count && !drawingCancelled )
            {
                bmpMandSet.Save(String.Format(@"{1}\{2}_{0:000}.png", i, baseDir, prefix));
                ZoomeIn();
                while (this.isDrawing)
                {
                    System.Threading.Thread.Sleep(3000);
                }
            }
            bmpMandSet.Save(String.Format(@"{1}\{2}_{0:000}.png", i, baseDir, prefix));
            MessageBox.Show("Done!","Fractals");
        }
        private void AutoSaveImage()
        {
            //Default images count = 15;
            string baseDir = Environment.GetEnvironmentVariable("TMP") + @"\" + "Fractals";
            if (!System.IO.Directory.Exists(baseDir))
            {
                System.IO.Directory.CreateDirectory(baseDir);
            }
            bmpMandSet.Save(String.Format(@"{0}\{1}.png", baseDir, DateTime.Now.Ticks.ToString()));

        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.isDrawing)
                return;
            // Set internal flag to know we no longer "have the mouse".
            isRubberBanding = false;
            // If we have drawn previously, draw again in that spot
            // to remove the lines.
            if (ptLast.X != -1)
            {
                Point ptCurrent = new Point(e.X, e.Y);
                MyDrawReversibleRectangle(ptOriginal, ptLast);

                if (ptOriginal != ptLast)
                {
                    double originalA, originalB, lastA, lastB;
                    double zoomMinA, zoomMaxA, zoomMinB, zoomMaxB;

                    MousePtToZ(ptOriginal.X, ptOriginal.Y, out originalA, out originalB);
                    MousePtToZ(ptLast.X, ptLast.Y, out lastA, out lastB);
                    zoomMinA = Math.Min(originalA, lastA);
                    zoomMaxA = Math.Max(originalA, lastA);
                    zoomMinB = Math.Min(originalB, lastB);
                    zoomMaxB = Math.Max(originalB, lastB);
                    if(PointInRectangle(ptLast, this.ClientRectangle))
                    {
                        viewManager.ChangeViewport(zoomMinA, zoomMaxA, zoomMinB, zoomMaxB, true);
                        ShowHideMenus();
                        DrawSet();
                    }
                }
            }
            // Set flags to know that there is no "previous" line to reverse.
            ptLast.X = -1;
            ptLast.Y = -1;
            ptOriginal.X = -1;
            ptOriginal.Y = -1;
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            Point ptCurrent = new Point(e.X, e.Y);

            // If we "have the mouse", then we draw our lines.
            if (isRubberBanding)
            {
                // If we have drawn previously, draw again in
                // that spot to remove the lines.
                if (ptLast.X != -1)
                {
                    MyDrawReversibleRectangle(ptOriginal, ptLast);
                    ptLast.X = -1;
                }
                if (PointInRectangle(ptCurrent, this.ClientRectangle))
                {
                    // Update last point.
                    ptLast = ptCurrent;
                    // Draw new lines.
                    MyDrawReversibleRectangle(ptOriginal, ptCurrent);
                }
            }

            //Show in the status bar the (a,b) value represented by the mouse cursor's position.
            double a, b;
            MousePtToZ(e.X, e.Y, out a, out b);
            SetCoordsLabel(a, b);
        }

        private bool PointInRectangle(Point p, Rectangle r)
        {
            return ((r.Left <= p.X && p.X <= r.Right) && (r.Top <= p.Y && p.Y <= r.Bottom));
        }

        private void DrawSet()
        {
			//Set the params before draw...
			Fractals.SetParameters();
			//Done....
			
            if (ClientAreaHeight < 1 || ClientAreaWidth < 1)
                return;

            isDrawing = true;
            mnuViewStopDrawing.Enabled = true;
            refreshToolStripMenuItem.Enabled = false;
            qualityToolStripMenuItem.Enabled = false;
            viewManager.SetClientAreaDimensions(ClientAreaWidth, ClientAreaHeight, LockAspectRatio);
            lblZoomFactor.Text = String.Format(" Zoom: x {0:0}", viewManager.ZoomFactor);

            if (bmpMandSet != null)
                bmpMandSet.Dispose();

            bmpMandSet = new Bitmap(ClientAreaWidth, ClientAreaHeight);
            this.Cursor = Cursors.WaitCursor;
            progressBarDrawing.Visible = true;
            lblProgressCaption.Visible = true;
            progressBarDrawing.Minimum = 0;
            progressBarDrawing.Maximum = ClientAreaHeight;
            CreateMandelbrotImage(ClientAreaWidth, ClientAreaHeight, maxIterations, progressBarDrawing);

            if (!isClosing)
            {
                this.Refresh();
                isDrawing = false;
                progressBarDrawing.Visible = false;
                lblProgressCaption.Visible = false;
                mnuViewStopDrawing.Enabled = false;
                refreshToolStripMenuItem.Enabled = true;
                qualityToolStripMenuItem.Enabled = true;
                this.Cursor = Cursors.Default;
            }
            if (this.manualZoomToolStripMenuItem.Checked)
            {
                this.AutoSaveImage();
            }
        }

         //static double maxScale = 0.9999 ;
         //static double minScale = 0.8900 ;


		private void SetIterationColor(int numIterations, int x, int y)
		{
			double scale =  ((double)(maxIterations - numIterations) / (double)maxIterations);
            bmpMandSet.SetPixel(x, y, ColorRenderer.GetColor(scale));
		}
		
        private void CreateMandelbrotImage(int imageWidth, int imageHeight, int maxIterations, ToolStripProgressBar progressBar)
        {
            int x, y, numIterations;
            double a, b;
            //int greyScale;
            //Color pixelColor;

            //Create a new bitmap and fill it with the window's background colour (white) to ensure that it
            // has no transparency even if the user cancels the rendering.
            bmpMandSet = new Bitmap(imageWidth, imageHeight);
            Graphics rbGraphics = Graphics.FromImage(bmpMandSet);
            rbGraphics.Clear(this.BackColor);
            rbGraphics.Dispose();

            for (y = 0, b = viewManager.YtoB(0, imageHeight); y < imageHeight && isDrawing; y++, b -= viewManager.UnitsPerPixelY)
            {
                for (x = 0, a = viewManager.XtoA(0); x < imageWidth && isDrawing; x++, a+= viewManager.UnitsPerPixelX)
                {
                    
                    
                    //Count the number of iterations before the Mandelbrot function becomes unbounded
                    
					numIterations = Fractals.IsInSet(a, b, maxIterations);
                     //Colour the pixel grey, as a percentage of maxIterations (larger number of iterations = darker grey)
                     SetIterationColor(numIterations, x,y);
                    
                }
                if ((y % 10 == 0) && isDrawing)
                {
                    //We've calculated another 10 rows; show the latest bitmap and update the progress bar.
                    this.Refresh();
                    progressBar.Value = y;
                }
                //DoEvents() allows the user to cancel the drawing part-way through.
                Application.DoEvents();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "png";
            saveDialog.FileName = string.Format("[{0}]_[{1}]_[{2}]_Fractal", Fractals.CurrentTransformType.ToString(), Fractals.ConstK.ToString(), Fractals.ConstPhase.ToString());
            saveDialog.Filter = "Portable Network Graphics (*.png)|*.png | Tiff Images (*.tiff)|*.tiff";

            if (saveDialog.ShowDialog() == DialogResult.OK)
                try
                {
					if ( saveDialog.FilterIndex == 0 )
					{
						bmpMandSet.Save(saveDialog.FileName );
					}
					else
					{
						bmpMandSet.Save ( saveDialog.FileName , System.Drawing.Imaging.ImageFormat.Tiff );
					}
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while saving: " + ex.Message);
                }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Set the isDrawing flag to tell DrawSet() to quit.
            isDrawing = false;
            mnuViewStopDrawing.Enabled = false;
            refreshToolStripMenuItem.Enabled = true;
            qualityToolStripMenuItem.Enabled = true;
            drawingCancelled = true;
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetView();
            DrawSet();
        }

        private void qualityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Show the Settings dialog box.
            SettingsForm settingsForm = new SettingsForm();

            settingsForm.MaxIterations = maxIterations;
            settingsForm.ShowDialog(this);
            if (settingsForm.DialogResult == DialogResult.OK)
            {
                //User hit OK; apply the changes.  (User won't see effect until they hit Refresh).
                maxIterations = settingsForm.MaxIterations;
            }
            settingsForm.Dispose();
        }

        private void fixAspectRatioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LockAspectRatio = !LockAspectRatio;
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Re-calculate the Mandelbrot image.
            Fractals.ConstK = Double.Parse(this.toolStripTextBoxPower.Text);
            DrawSet();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewHistoryGo(-1);
        }

        private void forwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewHistoryGo(+1);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Mandelbrot set viewer" + " " + Application.ProductVersion.ToString() + 
				"\n© 2006 Carl Johansen\n\nwww.carljohansen.co.uk/mandelbrot"
				 + "\n© 2011 Nabarun Mondal\n\n www.nmandalh.wordpress.com" 
                 +"\n" + Fractals.GetHelpText()  ,
                "About this application",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetCoordsLabel(double a, double b)
        {
            lblCoords.Text = String.Format("( {0} , {1} )", a, b);
        }

        private void ViewHistoryGo(int offset)
        {
            //Show the next (offset = 1) or previous (offset = -1) view in the history.
            viewManager.ViewHistoryGo(offset);
            ShowHideMenus();
            DrawSet();
        }

        private void ShowHideMenus()
        {
            backToolStripMenuItem.Enabled = (!viewManager.AtViewHistoryStart());
            forwardToolStripMenuItem.Enabled = (!viewManager.AtViewHistoryEnd());
        }
        
        private void MyDrawReversibleRectangle(Point p1, Point p2)
        {
            //Draw (or remove) a rubber band rectangle (during a zoom selection click-and-drag).
            //Call the routine with the same (p1,p2) as on the previous call to remove the current
            // rectangle before drawing another one.
            Rectangle rubberBandRect = new Rectangle();

            if (this.HasFullUIPermission)
            {
                // For the Full Trust technique we need to convert the points to screen coordinates.
                p1 = PointToScreen(p1);
                p2 = PointToScreen(p2);
            }

            // Normalize the rectangle.
            if (p1.X < p2.X)
            {
                rubberBandRect.X = p1.X;
                rubberBandRect.Width = p2.X - p1.X;
            }
            else
            {
                rubberBandRect.X = p2.X;
                rubberBandRect.Width = p1.X - p2.X;
            }
            if (p1.Y < p2.Y)
            {
                rubberBandRect.Y = p1.Y;
                rubberBandRect.Height = p2.Y - p1.Y;
            }
            else
            {
                rubberBandRect.Y = p2.Y;
                rubberBandRect.Height = p1.Y - p2.Y;
            }

            if (this.HasFullUIPermission)
                FullTrustDrawReversibleRectangle(rubberBandRect); // Use our fast rubber-band drawing technique.
            else
                PartialTrustDrawReversibleRectangle(rubberBandRect); // Use the slow technique.
        }

        private void PartialTrustDrawReversibleRectangle(Rectangle rubberBandRect)
        {
            //We can't use ControlPaint.DrawReversibleFrame due to insufficient UI permissions, so we use this
            // krusty alternative.  On each call we record the rectangle we have drawn.  If the same rectangle
            // is passed on the next call, redraw the Mandelbrot bitmap to erase the rectangle.
            Graphics formGraphics = this.CreateGraphics();
            if (rectLast == rubberBandRect)
                //Redraw the bitmap, which erases the previous rectangle (mouse has moved and new rectangle
                // should be drawn on the next call).
                DrawBitmapToScreen(formGraphics);
            else
            {
                //Draw a rectangle over the bitmap to indicate the current rubber band selection.
                SolidBrush rectBrush = new SolidBrush(Color.DarkRed);
                Pen rectPen = new Pen(rectBrush);
                formGraphics.DrawRectangle(rectPen, rubberBandRect);
                rectPen.Dispose();
                rectBrush.Dispose();
                rectLast = rubberBandRect;
            }
            formGraphics.Dispose();
        }

        private void FullTrustDrawReversibleRectangle(Rectangle rubberBandRect)
        {
            // Draw the reversible frame (a second call with the same rectangle will erase the rectangle).
            ControlPaint.DrawReversibleFrame(rubberBandRect, Color.DarkRed, FrameStyle.Dashed);
        }

        private void toolStripComboBoxFractalType_SelectedIndexChanged(object sender, EventArgs e)
        {
           	
           
            
            Fractals.ConstK = Double.Parse ( this.toolStripTextBoxPower.Text );
			string[] ret = Fractals.SelectCurrentTransformType(this.toolStripComboBoxFractalType.SelectedItem.ToString() );
            if ( ret[0] != string.Empty) 
            {
                this.toolStripTextBoxPower.Text = ret[0];
            }
			if ( ret[1] != string.Empty) 
            {
                this.toolStripComboBoxPhase.Text  = ret[1];
            }
            this.toolTip.SetToolTip(this, Fractals.GetHelpText());

            if (Fractals.CurrentTransformType == Fractals.TransformType.CustomExpression)
            {
                CustomExpression exprForm = new CustomExpression();
                exprForm.ShowDialog();

                if (!CustomExpression.IsCompiled)
                {
                    toolStripComboBoxFractalType.SelectedIndex = 0;
                }
            }
        }

        private void toolStripComboBoxPhase_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fractals.ConstPhase = Double.Parse(this.toolStripComboBoxPhase.SelectedItem.ToString()) * Math.PI;
        }

        private void toolStripMenuItemColors_Click(object sender, EventArgs e)
        {
            //Show the Colors Selector Form
            ColorRenderer cr = new ColorRenderer();
            cr.ShowDialog();
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            
            
            if (e.KeyCode == Keys.Escape)
            {
                //User hit Esc; simulate a click of View | Stop.
                stopToolStripMenuItem_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Left && e.Modifiers == Keys.Control )
            {
                //User hit Left; simulate a click of View | Back.
                ViewHistoryGo(-1);
            }
            else if (e.KeyCode == Keys.F7 )
            {
                ZoomeOut();
            }
            else if (e.KeyCode == Keys.F9)
            {
                ZoomeIn();
            }
            else if (e.KeyCode == Keys.F5)
            {
                refreshToolStripMenuItem_Click(sender, e);
            }
            else if (e.KeyCode == Keys.C)
            {
                toolStripMenuItemColors_Click(sender, e);
            }
            else if (e.KeyCode == Keys.P)
            {
                Clipboard.SetData(System.Windows.Forms.DataFormats.Text, lblCoords.Text);
            }
        }

        private void zoomeOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZoomeOut();
        }

        private void zoomeInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZoomeIn();
        }

        private void autoZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.manualZoomToolStripMenuItem.Checked = false;
            this.autoZoomToolStripMenuItem.Checked = true;
            AutoAnimateWithSaveImage();
        }

        private void manualZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.manualZoomToolStripMenuItem.Checked = !this.manualZoomToolStripMenuItem.Checked ;
            this.autoZoomToolStripMenuItem.Checked = false;
        }
    }
}