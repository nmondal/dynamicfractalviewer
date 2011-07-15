using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ColorMapFromImage
{

    public partial class MainForm : Form
    {
        Bitmap bmpImage;
        Dictionary<string, Color> colorsFound;
        List<Color> resultListColorGradient;

        KMeans.ColorComponent sortColor;

        private void RadioButtonState()
        {
            if (this.radioButtonI.Checked)
                sortColor = KMeans.ColorComponent.I;
            if (this.radioButtonR.Checked)
                sortColor = KMeans.ColorComponent.R;
            if (this.radioButtonG.Checked)
                sortColor = KMeans.ColorComponent.G;
            if (this.radioButtonB.Checked)
                sortColor = KMeans.ColorComponent.B;
        }

        private void populateColors()
        {
            colorsFound = new Dictionary<string, Color>();
            for (int x = 0; x < bmpImage.Size.Width; x++)
            {
                for (int y = 0; y < bmpImage.Size.Height; y++)
                {
                    Color c = bmpImage.GetPixel(x, y);
                    //uint u = (uint)c.ToArgb();
                    string name = string.Format("{0} {1} {2}",c.R, c.G, c.B );
                    if (!colorsFound.ContainsKey(name))
                    {
                        colorsFound.Add(name, c);
                    }
                }
            }
            this.listBoxColors.Items.Clear();
            this.listBoxColors.Items.AddRange(colorsFound.Keys.ToArray());
            this.textBoxNum.Text = colorsFound.Keys.Count.ToString();
        }

        public MainForm()
        {
            InitializeComponent();
            RadioButtonState();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                bmpImage = new Bitmap( Bitmap.FromFile( openFileDialog.FileName), pictureBoxImage.ClientSize );
                this.pictureBoxImage.Image = bmpImage;
                populateColors();
            }
        }

        private void listBoxColors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBoxColors.SelectedItem != null)
            {
                this.panelColor.BackColor = this.colorsFound[this.listBoxColors.SelectedItem.ToString()];
                PaintGradientPanel(this.listBoxColors.SelectedIndex);        
            }
        }
        private void DoSort()
        {
            this.Cursor = Cursors.WaitCursor;
            List<Color> colorList = this.colorsFound.Values.ToList();
            colorList = KMeans.KMeansWorker.SortColorComponentWise(colorList, this.sortColor);
            this.colorsFound.Clear();
            string name = "";
            foreach (Color c in colorList)
            {
                name = string.Format("{0} {1} {2}", c.R, c.G, c.B);
                this.colorsFound.Add(name, c);
            }
            if (this.listBoxColors.SelectedItem == null)
            {
                this.listBoxColors.SelectedIndex = 0;
            }
            name = this.listBoxColors.SelectedItem.ToString();
            this.listBoxColors.Items.Clear();
            this.listBoxColors.Items.AddRange(colorsFound.Keys.ToArray());
            this.listBoxColors.Refresh();
            this.textBoxNum.Text = colorsFound.Keys.Count.ToString();
            PaintGradientPanel( this.listBoxColors.Items.IndexOf(name) );
            resultListColorGradient = null;
            this.Cursor = Cursors.Default;
        }
        private void DoClustering(double distance)
        {
            
            this.Cursor = Cursors.WaitCursor;
            List<Color> colorList = this.colorsFound.Values.ToList();
               
            //Now do the loop and all...
            List<Color> centroids = KMeans.KMeansWorker.DoClustering(colorList, distance );
            
            centroids = KMeans.KMeansWorker.SortColorComponentWise( centroids,this.sortColor);
            
            //Now I am done...
            //Clear the dictionery and repopulate the stuff..
            this.colorsFound.Clear();
            foreach (Color c in centroids)
            {
                string name = string.Format("{0} {1} {2}", c.R, c.G, c.B);
                this.colorsFound.Add(name, c);                   
            }
            
            this.listBoxColors.Items.Clear();
            this.listBoxColors.Items.AddRange(colorsFound.Keys.ToArray());
            this.listBoxColors.Refresh();
            this.textBoxNum.Text = colorsFound.Keys.Count.ToString();
            PaintGradientPanel(-1);
            this.Cursor = Cursors.Default ;
        }
        private void buttonCluster_Click(object sender, EventArgs e)
        {
            double dist = 0.3 ;
            if (Double.TryParse(this.textBoxDist.Text, out dist))
            {
                if (dist > 1.0)
                {
                    dist = 1 / dist;
                }
                DoClustering(dist);
            }
        }

        private void PaintGradientPanel(int highlight_inx)
        {

            Bitmap _bmp = new Bitmap(this.pictureBoxColorGradient.ClientSize.Width, this.pictureBoxColorGradient.ClientSize.Height);
            int inx = 0;
            bool highlightStart = true;
            bool highlightEnd = true;
            int step = this.pictureBoxColorGradient.ClientSize.Width / listBoxColors.Items.Count ;

            if (step <= 0)
                return;


            for (int x = 0; x < this.pictureBoxColorGradient.ClientSize.Width; x++)
            {
                for (int y = 0; y < this.pictureBoxColorGradient.ClientSize.Height; y++)
                {
                    if (listBoxColors.Items.Count > inx )
                    {
                        _bmp.SetPixel(x, y, colorsFound[listBoxColors.Items[inx].ToString()]);
                        if (inx == highlight_inx && highlightStart)
                        {
                            _bmp.SetPixel(x, y, Color.White);
                            
                        }
                        if (inx == highlight_inx +  1 && highlightEnd)
                        {
                            _bmp.SetPixel(x, y, Color.White);
                            
                        }
                    }

                }
                if (inx == highlight_inx && highlightStart)
                {
                    highlightStart = false ;
                }
                if (inx == highlight_inx + 1 && highlightEnd)
                {
                    highlightEnd = false ;

                }
                if ((x + 1) % step == 0)
                {
                    inx++;
                    
                }
            }
            this.pictureBoxColorGradient.Image = _bmp;
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            
            //Move the selected item into new position...
            int curPos = this.listBoxColors.SelectedIndex;
            if (curPos == 0)
                return;
            string item = this.listBoxColors.SelectedItem.ToString();
            this.listBoxColors.Items.RemoveAt(curPos);
            this.listBoxColors.Items.Insert(curPos - 1, item);
            this.listBoxColors.SelectedItem = item;
            PaintGradientPanel(curPos-1);
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            int curPos = this.listBoxColors.SelectedIndex;
            if (curPos == this.listBoxColors.Items.Count -1)
                return;
            string item = this.listBoxColors.SelectedItem.ToString();
            this.listBoxColors.Items.RemoveAt(curPos);
            this.listBoxColors.Items.Insert(curPos + 1, item);
            this.listBoxColors.SelectedItem = item;
            PaintGradientPanel(curPos+1);
        }

        private void Export(string fileName)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fileName);
            if (resultListColorGradient == null)
            {
                int count = 0;
                for (int i = 0; i < this.listBoxColors.Items.Count; i++)
                {
                    sw.WriteLine(this.listBoxColors.Items[i].ToString());
                    count++;
                }
                string val = "0";
                if (sortColor == KMeans.ColorComponent.I)
                {
                    val = "255";
                }
                while (count < 256)
                {
                    sw.WriteLine("{0} {0} {0}", val);
                    count++;
                }
            }
            else 
            {
                int count = 0;
                for (int i = 0; i < this.resultListColorGradient.Count; i++)
                {
                    Color c = this.resultListColorGradient[i];
                    sw.WriteLine("{0} {1} {2}", c.R, c.G, c.B );
                    count++;
                }
                string val = "0";
                if (this.sortColor == KMeans.ColorComponent.I)
                {
                    val = "256" ;
                }
                while (count < 256)
                {
                    sw.WriteLine("{0} {0} {0}", val );
                    count++;
                }
            }
            sw.Flush();
            sw.Close();
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Export(saveFileDialog.FileName);
            }
        }
         
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtonState();
            DoSort();

        }
        private int availableColors = 0;
        private double GetColorDistance(Color c1, Color c2)
        {
            return Math.Sqrt((c1.R - c2.R) * (c1.R - c2.R) + (c1.G - c2.G) * (c1.G - c2.G) + (c1.B - c2.B) * (c1.B - c2.B));
        }
        private List<Color> GetEquiDistColor(Color c1, Color c2, int max_Count)
        {
            //C2 - C1

            List<Color> list = new List<Color>();

            if (max_Count > 0)
            {
                double redDiff = (c2.R - c1.R) / max_Count;
                double greenDiff = (c2.G - c1.G) / max_Count;
                double blueDiff = (c2.B - c1.B) / max_Count;


                for (int i = 0; i < max_Count; i++)
                {
                    int r = c1.R + (int)((i + 1) * redDiff);
                    int g = c1.G + (int)((i + 1) * greenDiff);
                    int b = c1.B + (int)((i + 1) * blueDiff);

                    if (r < 0) r = 0;
                    if (r > 255) r = 255;
                    if (g < 0) g = 0;
                    if (g > 255) g = 255;
                    if (b < 0) b = 0;
                    if (b > 255) b = 255;


                    Color c = Color.FromArgb(255, r, g, b);
                    list.Add(c);
                }
            }
            return list;
        }
        private void CalculateGradient()
        {
            double[] distArray = new double[this.listBoxColors.Items.Count-1];
            int[] colorGenArray = new int[this.listBoxColors.Items.Count - 1];

            
            availableColors = 0;
            resultListColorGradient = new List<Color>();
            for (int i = 0; i < this.listBoxColors.Items.Count; i++)
            {
                Color c = this.colorsFound[this.listBoxColors.Items[i].ToString()];
                resultListColorGradient.Add(c);
            }
            availableColors = 256 - resultListColorGradient.Count;
                
            

            //Now check the difference...
            double totalDist = 0.0;

            for (int i = 1; i < resultListColorGradient.Count; i++)
            {
                distArray[i - 1] = GetColorDistance(resultListColorGradient[i - 1], resultListColorGradient[i]);
                totalDist += distArray[i - 1];
            }
            int totalColors = 0;
            
            for (int i = 1; i < resultListColorGradient.Count; i++)
            {
                colorGenArray[i - 1] = (int) ( availableColors * (distArray[i - 1] / totalDist));
                totalColors += colorGenArray[i - 1]; 
            }
            
            List<Color> tmpList = new List<Color>();
            for (int i = 1; i < resultListColorGradient.Count; i++)
            {
                List<Color> tmp = GetEquiDistColor(resultListColorGradient[i - 1], resultListColorGradient[i], colorGenArray[i-1]);
                tmpList.Add(resultListColorGradient[i - 1]);
                for (int j = 0; j < tmp.Count; j++)
                {
                    tmpList.Add(tmp[j]);
                }

            }
            tmpList.Add(resultListColorGradient[resultListColorGradient.Count - 1]);

            resultListColorGradient = tmpList;
            
            if (availableColors > totalColors)
            {
                //Add the last color some more time to give it going...
                int diff = availableColors - totalColors;
                Color lastColor = resultListColorGradient[resultListColorGradient.Count - 1];
                do
                {
                    --diff;
                    resultListColorGradient.Add(lastColor);
                } while (diff > 0);
                
            }
            
            int step = this.pictureBoxResultGradient.ClientSize.Width / resultListColorGradient.Count ;

            Bitmap _bmp = new Bitmap( this.pictureBoxResultGradient.ClientSize.Width, this.pictureBoxResultGradient.ClientSize.Height);
            int inx = 0;
            for (int x = 0; x < this.pictureBoxResultGradient.ClientSize.Width; x++)
            {
                for (int y = 0; y < this.pictureBoxResultGradient.ClientSize.Height; y++)
                {
                    if (resultListColorGradient.Count > inx)
                    {
                        _bmp.SetPixel(x, y, resultListColorGradient[inx]);
                    }
                    else
                    {
                        _bmp.SetPixel(x, y, Color.White);
                    }
                }
                if ((x + 1) % step == 0)
                {
                    inx++;
                }
            }
            pictureBoxResultGradient.Image = _bmp;

        }
        private void buttonGradient_Click(object sender, EventArgs e)
        {
            if (this.listBoxColors.Items.Count > 64 )
            {
                //Can not be done...but
                return;
            }
            CalculateGradient();
        }

    }
}
