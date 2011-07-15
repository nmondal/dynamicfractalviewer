////////////////////////////////////////////////////////////////////
// Program.cs
// Copyright © 2006, 2008 Carl Johansen
// 
// Mandelbrot program entry point.
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
using System.Windows.Forms;
using System.Numerics ;

namespace Mandelbrot
{
    static class Program
    {
		
		
		public static int Transform1(ref double a, ref double b, int maxIterations)
        {
            double currDistSq, aSq = 0.0, bSq = 0.0;
            double originalA = a, originalB = b;
            int numIterations = 0;

            while (numIterations++ < maxIterations)
            {
                aSq = a * a;
                bSq = b * b;
                currDistSq = aSq + bSq;
                if (currDistSq > 4)
                    return numIterations;
                b = 2 * a * b + originalB;
                a = (aSq - bSq) + originalA;
            }
            return maxIterations;
        }
		public static int Transform2(double a, double b, int maxIterations)
        {
            double currDistSq ;
            int numIterations = 0;
			
			Complex z = new Complex ( a, b);
            while (numIterations++ < maxIterations)
            {
                
                currDistSq = z.Magnitude * z.Magnitude ;
                
				if (currDistSq > 4)
                    return numIterations;
                
				Complex resZ =  Complex.Multiply(z,z)  ;
				
				resZ = Complex.Add(resZ, z) ;
				z = resZ ;
            }
            return maxIterations;
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           Application.EnableVisualStyles();
           Application.SetCompatibleTextRenderingDefault(false);
           Application.Run(new MainForm());
			
			
		}
    }
}