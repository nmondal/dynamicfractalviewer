////////////////////////////////////////////////////////////////////
// MandelbrotSet.cs
// Copyright © 2006, 2008 Carl Johansen
// 
// Mandelbrot set calculation class
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
using System.Numerics ;

namespace Mandelbrot
{
    class MandelbrotSet
    {
		
		public static double[] Add(double[] left,double[] right)
		{
			double[] ret = new double[2];
			ret[0] = left[0] + right[0];
			ret[1] = left[1] + right[1];
			return ret;
		}
		
		public static double[] Multiply(double[] left,double[] right)
		{
			double[] ret = new double[2];
			ret[0] = left[0]*right[0] - left[1]*right[1];
			
			ret[1] = left[1]*right[0] + left[0]*right[1];
			
			return ret;
		}
		
		public static double[] RaisePower(double[] cIn, int power)
		{
			double[] cRet = new double[2];
			
			if ( power <= 0)
			{
				cRet[0] = 1.0000;
				cRet[1] = 0.0000;
			}
			else if ( power == 1 )
			{
				cRet[0] = cIn[0];
				cRet[1] = cIn[1];
				
			}
			else
			{
				cRet = cIn ;
				while ( --power > 1 )
				{
					double[] tmp = Multiply( cRet, cIn);
					cRet[0] = tmp[0];
					cRet[1] = tmp[1];
				}
			}
			return cRet;
		}
		
        /// <summary>
        /// Performs the Mandelbrot iteration for the complex number a + bi.
        /// </summary>
        /// <param name="a">The real part of the complex number being tested.</param>
        /// <param name="b">The imaginary part of the complex number being tested.</param>
        /// <param name="maxIterations">The maximum number of iterations to be performed.</param>
        /// <returns>If Z[n] > 2 then the function returns n (ie the number of iterations before the result
        /// was known to be unbounded.  If Z[n] &lt; 2 after maxIterations iterations, the function returns 0
        /// (and c is assumed to be in the Mandelbrot set).</returns>
        /// <remarks>Performs the Mandelbrot iteration Z[n+1] = Z[n]^2 + c for the complex number c = a + bi.</remarks>
        public static int IsInSet2(double a, double b, int maxIterations)
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
		
    }
}
