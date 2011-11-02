using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Mandelbrot
{
    
    public partial class ColorRenderer : Form
    {
        internal static double K = 2.0;
        internal static bool UseColor = false;
        internal static Dictionary<string, ColorMap> colorMaps;
        internal static ColorMap currentColorMap;
        internal static string GRAY_SCALE = "GrayScale";
        internal List<Color> currentColors;
        
        static ColorRenderer()
        {
            //Load all the ColorMaps..
            colorMaps = ColorMap.GenerateColorMaps();
            DefaultColors();
            
        }

        private static void DefaultColors()
        {
           K = 2.0;
           currentColorMap = colorMaps[GRAY_SCALE];
        }

        public static Color GetColor(double x)
        {
            int inx = (int)(currentColorMap.colors.Length * x);
            //System.Diagnostics.Debug.Assert(inx != 255,"255");
            return currentColorMap.colors[inx];
            
        }

        public ColorRenderer()
        {
            InitializeComponent();
            PaintUI();
            currentColors = new List<Color>();
        }

        private void ColorThePanel()
        {
            int step = this.panelColor.ClientSize.Width / currentColorMap.colors.Length ;
            int inx = 0;
            Bitmap _bmp = new Bitmap(this.panelColor.ClientSize.Width, this.panelColor.ClientSize.Height);
            for (int x = 0; x < this.panelColor.ClientSize.Width ; x++)
            {
                for (int y = 0; y < this.panelColor.ClientSize.Height; y++)
                {
                    if (currentColorMap.colors.Length > inx)
                    {
                        _bmp.SetPixel(x, y, currentColorMap.colors[inx]);
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
            this.panelColor.BackgroundImage = _bmp;
        }

        private void PaintUI()
        {
            this.textBoxConvergence.Text = K.ToString();
            this.comboBoxColorMap.Items.Clear();
            this.comboBoxColorMap.Items.AddRange( colorMaps.Keys.ToList().ToArray());
            this.comboBoxColorMap.SelectedItem = currentColorMap.Name;
           
        }

        

        private void buttonDefaults_Click(object sender, EventArgs e)
        {
            DefaultColors();
            PaintUI();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            
            if (!Double.TryParse(this.textBoxConvergence.Text, out K))
            {
                //Invalid P - resetting to default:-
                K = 2.0;
            }
            
        }

        private void comboBoxColorMap_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentColorMap = colorMaps[this.comboBoxColorMap.SelectedItem.ToString()];
            ColorThePanel();
        }


        private void PaintCustomPanel()
        {
            int step = this.panelMixer.ClientSize.Width / this.currentColors.Count;

            Bitmap _bmp = new Bitmap(this.panelMixer.ClientSize.Width, this.panelMixer.ClientSize.Height);
            int inx = 0;
            for (int x = 0; x < this.panelMixer.ClientSize.Width; x++)
            {
                for (int y = 0; y < this.panelMixer.ClientSize.Height; y++)
                {
                    if (currentColors.Count > inx)
                    {
                        _bmp.SetPixel(x, y, currentColors[inx]);
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
            panelMixer.BackgroundImage = _bmp;
        }

        private void buttonAddColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                currentColors.Add(colorDialog.Color);
                PaintCustomPanel();
            }
        }
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

            double[] distArray = new double[this.currentColors.Count - 1];
            int[] colorGenArray = new int[this.currentColors.Count - 1];


            int availableColors = 0;

            List<Color> resultListColorGradient = this.currentColors;
            
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
                colorGenArray[i - 1] = (int)(availableColors * (distArray[i - 1] / totalDist));
                totalColors += colorGenArray[i - 1];
            }

            List<Color> tmpList = new List<Color>();
            for (int i = 1; i < resultListColorGradient.Count; i++)
            {
                List<Color> tmp = GetEquiDistColor(resultListColorGradient[i - 1], resultListColorGradient[i], colorGenArray[i - 1]);
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
            this.currentColors = resultListColorGradient;
            PaintCustomPanel();
        }

        private void buttonGradient_Click(object sender, EventArgs e)
        {
            if (this.currentColors.Count > 2)
            {
                CalculateGradient();
            }
        }

        private void buttonAddMap_Click(object sender, EventArgs e)
        {
            if (this.currentColors.Count == 256)
            {
                ColorMap map = ColorMap.CreateFromList(this.currentColors, DateTime.Now.ToLongTimeString() );
                colorMaps.Add(map.Name, map);
                currentColorMap = map;
                PaintUI();

            }
        }

        private void buttonSaveMap_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Export(saveFileDialog.FileName);
            }
        }
        private void Export(string fileName)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fileName);
            for (int i = 0; i< currentColorMap.colors.Length; i++)
            {
                sw.WriteLine("{0} {1} {2}", currentColorMap.colors[i].R, currentColorMap.colors[i].G, currentColorMap.colors[i].B); 
            }
            sw.Flush();
            sw.Close();
            MessageBox.Show("ColorMap Saved!", "ColorMap");
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                ColorMap map = ColorMap.CreateFromFile(openFileDialog.FileName);
                if (colorMaps.ContainsKey(map.Name))
                {
                    MessageBox.Show("Dude, that ColorMap seems to be loaded already!", "");
                }
                else 
                {
                    colorMaps.Add(map.Name, map);
                    currentColorMap = map;
                    PaintUI();
                }
            }
        }
       
    }

    public class ColorMap
    {
        public Color[] colors;
        public string Name;
        public ColorMap()
        {
        }
        public static ColorMap CreateGrayMap()
        {
            ColorMap map = new ColorMap();
            map.colors = new Color[256];
            for (int i = 0; i < 256; i++)
            {
                map.colors[i] = Color.FromArgb(i, i, i);
            }
            map.Name = ColorRenderer.GRAY_SCALE ;
            return map;
        }
        public static ColorMap CreateFromFile(string fileName)
        {
            FileInfo finfo = new FileInfo(fileName);
            StreamReader sr = new StreamReader(fileName);
            string data = sr.ReadToEnd();

            sr.Close();
            ColorMap map = new ColorMap();
            map.colors = new Color[256];
            String[] lines = data.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            if (lines.Length < 256)
                return null;
            for (int i = 0; i < 256; i++)
            {
                string[] comps = lines[i].Split(' ');
                map.colors[i] = Color.FromArgb(Int32.Parse(comps[0]), Int32.Parse(comps[1]), Int32.Parse(comps[2]));
            }
            string Name = finfo.Name.Substring( 0, finfo.Name.IndexOf(finfo.Extension));
            map.Name = Name;
            return map;
        }
        public static Dictionary<string, ColorMap> GenerateColorMaps()
        {
            Dictionary<string, ColorMap> maps = new Dictionary<string, ColorMap>();
            ColorMap gray = CreateGrayMap();
            maps.Add(gray.Name, gray);
            //Now load others...
            string mapDirectory =  Environment.CurrentDirectory +  System.IO.Path.DirectorySeparatorChar +  @"ColorMaps" ;
            string[] files = System.IO.Directory.GetFiles(mapDirectory, "*.ColorMap", SearchOption.TopDirectoryOnly);
            foreach (string file in files)
            {
                ColorMap map = ColorMap.CreateFromFile(file);
                if (map != null)
                {
                    maps.Add(map.Name, map);
                }
            }
            return maps;
        }
        public static ColorMap CreateFromList(List<Color> list, string name)
        {
            ColorMap map = new ColorMap();
            map.Name = name;
            map.colors = list.ToArray();
            return map;
        }

    }

}
