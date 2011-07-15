////////////////////////////////////////////////////////////////////
// ViewManager.cs
// Copyright © 2006, 2008 Carl Johansen
// 
// Class for controlling the viewing area selection in the 
// Mandelbrot Set Viewer application.
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

namespace Mandelbrot
{
    internal class ViewManager
    {
        private ViewHistory viewHistory;

        private ZoomView currentSelectedView;
        private ZoomView currentDisplayView;

        private double aWidth;
        private double bWidth;

        private double unitsPerPixelX;
        public double UnitsPerPixelX
        {
            get { return unitsPerPixelX; }
        }

        private double unitsPerPixelY;
        public double UnitsPerPixelY
        {
            get { return unitsPerPixelY; }
        }

        public ViewManager()
        {
            viewHistory = new ViewHistory();
            currentSelectedView = new ZoomView();
            currentDisplayView = new ZoomView();
        }

        public double ZoomFactor
        {
            get { return 3.0 / aWidth; }
        }

        public bool AtViewHistoryStart()
        {
            return viewHistory.AtStart();
        }

        public bool AtViewHistoryEnd()
        {
            return viewHistory.AtEnd();
        }

        public bool PointIsInCurrentDisplayView(double a, double b)
        {
            return currentDisplayView.PointIsInZoomView(a, b);
        }

        public double XtoA(int x)
        {
            return x * UnitsPerPixelX + currentDisplayView.MinA;
        }

        public double YtoB(int y, int clientAreaHeight)
        {
            return (clientAreaHeight - y) * UnitsPerPixelY + currentDisplayView.MinB;
        }

        public void PixelToZ(int x, int y, int clientAreaHeight, out double a, out double b)
        {
            //Return the complex number c = a + bi represented by the pixel (x,y).
            //Pixels are numbered from top to bottom of screen, while units are numbered from bottom
            // to top, so we need the window height in order to flip the y coordinate.
            a = XtoA(x);
            b = YtoB(y, clientAreaHeight);
        }

        public void Reset()
        {
            viewHistory.Clear();
            ChangeViewport(-3.0, 3.0, -3.0, 3.0, true);
        }

        public void ChangeViewport(ZoomView newView, bool addToHistory)
        {
            ChangeViewport(newView.MinA, newView.MaxA, newView.MinB, newView.MaxB, addToHistory);
        }

        public void ChangeViewport(double newMinA, double newMaxA, double newMinB, double newMaxB, bool addToHistory)
        {
            //Apply a new view and add it to the history.
            currentSelectedView.MinA = newMinA;
            currentSelectedView.MaxA = newMaxA;
            currentSelectedView.MinB = newMinB;
            currentSelectedView.MaxB = newMaxB;
            aWidth = currentSelectedView.MaxA - currentSelectedView.MinA;
            bWidth = currentSelectedView.MaxB - currentSelectedView.MinB;
            if (addToHistory)
                viewHistory.AddNewView(currentSelectedView);
        }

        public void SetClientAreaDimensions(int bitmapWidth, int bitmapHeight, bool lockAspectRatio)
        {
            //Set the "display view".  This is different from the "selected view" if the user has the
            // Lock Aspect Ratio option set.
            currentDisplayView.MinA = currentSelectedView.MinA;
            currentDisplayView.MaxA = currentSelectedView.MaxA;
            currentDisplayView.MinB = currentSelectedView.MinB;
            currentDisplayView.MaxB = currentSelectedView.MaxB;
            if (lockAspectRatio)
                SetAspectRatioForWindow(bitmapWidth, bitmapHeight);
            //Re-calculate the units per pixel in each dimension.
            unitsPerPixelX = aWidth / bitmapWidth;
            unitsPerPixelY = bWidth / bitmapHeight;
        }

        private void SetAspectRatioForWindow(int bitmapWidth, int bitmapHeight)
        {   //Adjust the "display view" so that: (a) it is centred on the centre of the current
            // "selected view"; (b) it has the same extent as the "selected view" in at least 
            // one dimension (ie same width or height); and (c) it has the same number of units 
            // per pixel in both dimensions.
            double midA, midB, unitsPerPixelXinSelection, unitsPerPixelYinSelection;

            unitsPerPixelXinSelection = (currentSelectedView.MaxA - currentSelectedView.MinA) / bitmapWidth;
            unitsPerPixelYinSelection = (currentSelectedView.MaxB - currentSelectedView.MinB) / bitmapHeight;
            midA = (currentSelectedView.MaxA + currentSelectedView.MinA) / 2;
            midB = (currentSelectedView.MaxB + currentSelectedView.MinB) / 2;

            if (unitsPerPixelXinSelection < unitsPerPixelYinSelection)
            {
                //Selected view is too tall and narrow; widen the display view to 
                // increase the number of units per x pixel.
                currentDisplayView.MinA = midA - (unitsPerPixelYinSelection * bitmapWidth) / 2;
                currentDisplayView.MaxA = midA + (unitsPerPixelYinSelection * bitmapWidth) / 2;
            }
            else
            {
                //Selected view is too short and wide; stretch the display view to 
                // increase the number of units per y pixel.
                currentDisplayView.MinB = midB - (unitsPerPixelXinSelection * bitmapHeight) / 2;
                currentDisplayView.MaxB = midB + (unitsPerPixelXinSelection * bitmapHeight) / 2;
            }

            //Recalculate the number of units to be displayed in each dimension.
            aWidth = currentDisplayView.MaxA - currentDisplayView.MinA;
            bWidth = currentDisplayView.MaxB - currentDisplayView.MinB;
        }

        public void ViewHistoryGo(int offset)
        {
            ZoomView newView = viewHistory.Go(offset);
            ChangeViewport(newView, false);
        }
    }
}
