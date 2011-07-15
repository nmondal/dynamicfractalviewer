using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;
using System.Drawing;
using System.Diagnostics;
using System.Windows;
using System.Threading.Tasks;

namespace KMeans
{

    public enum ColorComponent
    {
        R,
        G,
        B,
        I
    }
    public class NormalizedColor
    {
        public Color InnerColor;
        public double Intensity
        {
            get 
            {
                return (double)InnerColor.R + (double)InnerColor.G + (double)InnerColor.B;
            }
        }
        public double R
        {
            get 
            {
                if (Intensity > 0)
                {
                    return ((double)InnerColor.R / Intensity);
                }
                return 0;
            }
        }
        public double G
        {
            get
            {
                if (Intensity > 0)
                {
                    return ((double)InnerColor.G / Intensity);
                }
                return 0;
            }
        }
        public double B
        {
            get
            {
                if (Intensity > 0)
                {
                    return ((double)InnerColor.B / Intensity);
                }
                return 0;
            }
        }

        public NormalizedColor(Color c)
        {
            InnerColor = Color.FromArgb ( 255, c);
        }
        public NormalizedColor(double r, double g, double b)
        {
            double total = r + g + b;
            if (total > 0)
            {
                r = r / total;
                g = g / total;
                b = b / total;

                int _r = (int)(256 * r) ;
                if (_r > 255)
                    _r = 255;
                int _g = (int)(255 * g) ;
                if (_g > 255)
                    _g = 255;
                int _b = (int)(256 * b) ;
                if (_b > 255)
                    _b = 255;
                InnerColor = Color.FromArgb(255 ,_r, _g, _b);
            }
            else 
            {
                InnerColor = Color.FromArgb( 0 , 0 , 0);
            }
        }
    }

    public  sealed class KMeansWorker
    {

        private static bool AreSameList(List<Color> list1, List<Color> list2)
        {
            foreach (Color c in list1)
            {
                if (list2.Contains(c))
                    return false;
            }
            return true;
        }
        public static List<Color> DoClustering(List<Color> dataPoints, double dist)
        {
            
            if (dist > 1)
            {
                dist = dist / (256 );
            }
            Dictionary<NormalizedColor, List<NormalizedColor>> centroids = new Dictionary<NormalizedColor, List<NormalizedColor>>();
            NormalizedColor cur = new NormalizedColor ( dataPoints[0] );
            if (!centroids.ContainsKey(cur))
            {
                centroids.Add(cur, new List<NormalizedColor>());
                centroids[cur].Add(cur);
            }
            dataPoints.RemoveAt(0);

            while (dataPoints.Count > 0)
            {
                cur = new NormalizedColor( dataPoints[0]);
                bool curIsACentroid = true;

                List<NormalizedColor> olderCentroids = centroids.Keys.ToList();
                for (int i = 0; i < olderCentroids.Count; i++)
                {
                    NormalizedColor _centroid = olderCentroids[i];
                    List<NormalizedColor> _list = centroids[olderCentroids[i]];
                    if (IsInCentroid(_list, cur, dist * dist, ref _centroid))
                    {
                        curIsACentroid = false;
                        centroids.Remove(olderCentroids[i]);
                        olderCentroids[i] = _centroid;
                        _list.Add(cur);
                        if (centroids.ContainsKey(olderCentroids[i]))
                        {
                            centroids[olderCentroids[i]].Concat(_list);
                        }
                        else 
                        {
                            centroids[olderCentroids[i]] = _list;
                        }
                        break;
                    }
                }
                if (curIsACentroid)
                {
                    centroids.Add(cur, new List<NormalizedColor>());
                    centroids[cur].Add(cur);
                }
                dataPoints.RemoveAt(0);
            }
            List<NormalizedColor> newDataPoints = centroids.Keys.ToList();
            List<Color> __list = new List<Color>();
            foreach (NormalizedColor nc in newDataPoints)
            {
                if (!__list.Contains(nc.InnerColor))
                {
                    __list.Add(nc.InnerColor);
                }
                
            }
            return __list;
        }
        private static bool IsInCentroid(List<NormalizedColor> centroidMembers, NormalizedColor newColor, double max_dist_sq, ref NormalizedColor centroid)
        {
            double r = newColor.R ;
            double g = newColor.G ;
            double b = newColor.B ;

            foreach (NormalizedColor c in centroidMembers)
            {
                double dist_sq = Math.Pow(c.R - newColor.R, 2) +
                    Math.Pow(c.G - newColor.G, 2) + Math.Pow(c.B - newColor.B, 2);

                r += c.R;
                g += c.G;
                b += c.B;

                if (max_dist_sq < dist_sq)
                    return false;
            }
            r =   ( r/(centroidMembers.Count + 1));
            g =   (g / (centroidMembers.Count + 1));
            b =   (b / (centroidMembers.Count + 1));
            centroid = new NormalizedColor ( r, g, b );
            return true;
        }
        
        public static List<Color> SortColorComponentWise(List<Color> list, ColorComponent sortComponent)
        {

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (sortComponent == ColorComponent.R)
                    {
                        if (list[i].R < list[j].R)
                        {
                            Color tmp = list[i];
                            list[i] = list[j];
                            list[j] = tmp;
                        }
                    }
                    else if (sortComponent == ColorComponent.G)
                    {
                        if (list[i].G < list[j].G)
                        {
                            Color tmp = list[i];
                            list[i] = list[j];
                            list[j] = tmp;
                        }
                    }
                    else if (sortComponent == ColorComponent.B)
                    {
                        if (list[i].B < list[j].B)
                        {
                            Color tmp = list[i];
                            list[i] = list[j];
                            list[j] = tmp;
                        }
                    }
                    else
                    {
                        int intens_i = list[i].R + list[i].G + list[i].B;
                        int intens_j = list[j].R + list[j].G + list[j].B;
                        if (intens_i > intens_j)
                        {
                            Color tmp = list[i];
                            list[i] = list[j];
                            list[j] = tmp;
                        }

                    }
                }
            }
            return list;
        }
     }
}
