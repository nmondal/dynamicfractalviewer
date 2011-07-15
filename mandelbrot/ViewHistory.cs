////////////////////////////////////////////////////////////////////
// ViewHistory.cs
// Copyright © 2006, 2008 Carl Johansen
// 
// The ZoomView and ViewHistory classes for recording viewing area
// selections in the Mandelbrot Set Viewer application.
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

namespace Mandelbrot
{
    internal struct ZoomView
    {
        //A view is simply a rectangular range from MinA to MaxA on the horizontal axis and
        // MinB to MaxB on the vertical axis.
        public double MinA, MaxA, MinB, MaxB;

        public ZoomView(double minA, double maxA, double minB, double maxB)
        {
            MinA = minA;
            MaxA = maxA;
            MinB = minB;
            MaxB = maxB;
        }

        public bool PointIsInZoomView(double a, double b)
        {
            return ((MinA <= a && a <= MaxA) && (MinB <= b && b <= MaxB));
        }
    }

    internal class ViewHistory
    {
        //A ViewHistory is an ordered collection of views with a pointer to the current view.
        private ArrayList viewHistory;
        private int currViewIndex;

        public ViewHistory()
        {
            currViewIndex = -1;
            viewHistory = new ArrayList();
        }

        public void Clear()
        {
            currViewIndex = -1;
            viewHistory.Clear();
        }

        public bool IsEmpty()
        {
            return currViewIndex == -1; 
        }

        public bool AtStart()
        { 
            return currViewIndex == 0; 
        }

        public bool AtEnd() 
        { 
            return (currViewIndex == viewHistory.Count - 1);
        }

        public void AddNewView(ZoomView newView) 
        {
            //Add a new view to the history.
            //If adding in the middle of the history, throw away the old views that appear in the list 
            // after the new one (so user can't hit View | Forward).
            currViewIndex++;
            if(currViewIndex < viewHistory.Count)
                viewHistory.RemoveRange(currViewIndex, viewHistory.Count - currViewIndex);
            viewHistory.Add(newView);
        }

        public ZoomView Go(int direction) 
        {
            //Change the current view by moving <direction> places forward (direction > 0) or
            // backward (direction < 0) in the history.  Return the newly selected view.
            if(IsEmpty())
                throw new NullReferenceException("View history is empty!");

            int newViewIndex = currViewIndex + direction;
            if (0 <= newViewIndex && newViewIndex < viewHistory.Count)
            {
                currViewIndex = newViewIndex;
                ZoomView newView = (ZoomView)viewHistory[currViewIndex];
                return newView;
            }
            else
                throw new ArgumentException("View index out of range", "direction");
        }
    }
}
