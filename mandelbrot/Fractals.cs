////////////////////////////////////////////////////////////////////
// Fractals
// Copyright c 2011  Nabarun Mondal
// 
// Fractal set calculation class
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
using System.Numerics;

namespace Mandelbrot
{
    class Fractals
    {
        


        public static string GetHelpText()
        {
            string ret = "" ;

            switch (CurrentTransformType)
            {
                case TransformType.ExponentiatonDivide :
                    ret = "-Uses the left text box as 'R' and right combo as 'theta' to raise z's power"; 
                    break;
                case TransformType.ExponentiatonInverseDivide:
                    ret = "-Uses the left text box as 'R' and right combo as 'theta' to raise z's power"; 
                    break;
                case TransformType.ExponentiatonMultiply:
                    ret = "-Uses the left text box as 'R' and right combo as 'theta' to raise z's power"; 
                    break;
                case TransformType.ImaginaryBrot :
                    ret = "-Uses the left text box as 'R' and right combo as 'theta' to raise z's power"; 
                    break;
                case TransformType.ImaginaryBrotN:
                    ret = "-Uses the left text box as 'R' and right combo as 'theta' to raise z's power";
                    break;
                case TransformType.Logarithmic:
                    ret = "-Uses the exponetial of the left text box as 'MAX_DIST'"; 
                    break;
                case TransformType.MultiBrot :
                    ret = "-Uses the left text box as 'n' to raise z's power"; 
                    break;
                case TransformType.NaturalExponentiation :
                    ret = "-Uses the exponetial of the left text box as 'MAX_DIST'"; 
                    break;
                case TransformType.Nova:
                    ret = "-Uses the left text box as 'R' and right combo as 'theta' to raise z's power"; 
                    break;
                case TransformType.Reciprocal :
                    ret = "-Uses the square of the exponetial of the left text box as 'MAX_DIST'"; 
                    break;
                case TransformType.ReverseExponentian :
                    ret = "-It is plain z^e"; 
                    break;
                case TransformType.ReverseTetration:
                    ret = "-Uses left text box as the 'MAX_DIST'";
                    break;
                case TransformType.Tetration :
                    ret = "-Uses left text box as the 'MAX_DIST'";
                    break;
                default:
                    ret = "-I donno" ;
                    break;
            }


            return ret;
        }


		public enum TransformType
		{
			MultiBrot,
			ImaginaryBrot,
            ImaginaryBrotN,
            Reciprocal,
			Nova,
            Logarithmic,
			ExponentiatonMultiply,
			ExponentiatonDivide,
			ExponentiatonInverseDivide,
			NaturalExponentiation,
			ReverseExponentian,
			Tetration,
			ReverseTetration,
			GeneralizedCollatz,
            CustomExpression
			
		}
		public static TransformType CurrentTransformType = TransformType.MultiBrot ;



        #region setting default params .... Holistic 
        public static string[] SetNovaParams()
		{
			if ( ConstK >= 3.0 ) 
			{
				ConstK = 2.0 ;
			}
			if ( ConstPhase == 0.00 )
			{
				ConstPhase = Math.PI * 0.17 ;
			}
			return new string[] { "2.0" , "0.17" };
		}
        public static string[] SetImaginaryBrotParams()
        {
            if (ConstK < 2.0)
            {
                ConstK = 2.0;
            }
            if (ConstPhase == 0.00)
            {
                ConstPhase = Math.PI * 0.17;
            }
            return new string[] { "2.0", "0.17" };
        }
        public static string[] SetMaxDistTypeBrotParams()
        {
            if (ConstK <= 2.0)
            {
                ConstK = 2.0;
            }
            return new string[] { "2.0", "" };
        }
        public static string[] SetExponentiationBrotParams()
        {
            if (ConstK < 2.0)
            {
                ConstK = 2.0;
            }
            if (ConstPhase == 0.00)
            {
                ConstPhase = Math.PI * 0.33;
            }
            return new string[] { "1.0", "0.33" };
        }


        public static string[] SelectCurrentTransformType(string s)
        {
            CurrentTransformType = (TransformType)Enum.Parse(typeof(TransformType), s);
            
            switch (CurrentTransformType)
            {
                case TransformType.Nova:
					return SetNovaParams();
                case TransformType.ImaginaryBrot:
                    return SetImaginaryBrotParams();
                case TransformType.ImaginaryBrotN:
                    return SetImaginaryBrotParams();
                case TransformType.Reciprocal:
                    return SetMaxDistTypeBrotParams();
                case TransformType.Tetration:
                    return SetMaxDistTypeBrotParams();
                case TransformType.ReverseTetration :
                    return SetMaxDistTypeBrotParams();
                case TransformType.ExponentiatonMultiply:
                    return SetExponentiationBrotParams();
                case TransformType.ExponentiatonDivide:
                    return SetExponentiationBrotParams();
                case TransformType.ExponentiatonInverseDivide:
                    return SetExponentiationBrotParams();
                default:
                    break;
            }
            return new string[]{"",""};
        }

        #endregion 


        public static double ConstK = 2.00;
		public static double ConstPhase = Math.PI * 0.25;
		public static Complex expComplex = Complex.One ;
        public static Complex expImaginary = Complex.Zero;
		public static double ConstR = 4.0 ;
		public static double  MaxDistance_ConstK = 4.0 ;
		public static double  MaxDistance_On_EXP_ConstK = 4.0 ;
		public static double  MaxDistance_EXP_CONST = System.Math.Exp ( 10 ) ; 
		public static double  MaxDistance_MULTI = 4.0 ;
		public static double  MaxDistance_NOVA = System.Math.Exp(1);
        
        public static void SetParameters()
		{
			/* Used by Imaginary Brot */
			expComplex = Complex.FromPolarCoordinates( ConstK, ConstPhase);
            expImaginary = Complex.FromPolarCoordinates(1, ConstPhase);
			MaxDistance_NOVA = Math.Exp (  Math.Ceiling ( expComplex.Magnitude) + 1 ) ;
			MaxDistance_ConstK = Math.Ceiling (Fractals.ConstK ) ;
			
			if ( MaxDistance_ConstK < 2.0 )
			{
				MaxDistance_ConstK = 2.0 ;
			}
			MaxDistance_On_EXP_ConstK = Math.Exp( ColorRenderer.K );
            
			
			/* Used by Nova */
			ConstR = 1 / ( expComplex.Magnitude *  expComplex.Magnitude) ;
			
		}
		

        #region Transforms
        public static int TransformImaginaryBrot(Complex z, Complex c,int maxIterations )
		{
			double currDistSq = 0 ;
            int numIterations = 0;
			
			while (numIterations++ < maxIterations)
            {	
				
				currDistSq = z.Magnitude * z.Magnitude;
				
				if ( currDistSq >  MaxDistance_On_EXP_ConstK )
					return numIterations ;
				
				Complex z_val =  Complex.Pow (z  , expComplex );
                z = z_val + c ;// Complex.Pow(c, expComplex);
			}
			return maxIterations;
		}
        public static int TransformImaginaryBrotN(Complex z, Complex c, int maxIterations)
        {
            double currDistSq = 0;
            int numIterations = 0;

            while (numIterations++ < maxIterations)
            {

                currDistSq = z.Magnitude * z.Magnitude;

                if (currDistSq > MaxDistance_On_EXP_ConstK)
                    return numIterations;

                Complex z_val = Complex.Pow(z, expComplex);
                z = z_val +  Complex.Pow(c, expComplex);
            }
            return maxIterations;
        }
		public static int TransformNova(Complex z, Complex c,int maxIterations)
        {
            double currDistSq = 0 ;
            int numIterations = 0;
			
			while (numIterations++ < maxIterations)
            {

                currDistSq = z.Magnitude * z.Magnitude;
				
				if ( currDistSq > MaxDistance_NOVA  )
					return numIterations ;
				
				Complex z_N =  Complex.Pow(z,expComplex) - 1;
				Complex z_D =  expComplex * Complex.Pow(z,expComplex -1 );
				z  =  ConstR * z_N /z_D ;
				
				
			}
			return maxIterations;
        }

		public static int TransformMultiBrot(Complex z, Complex c ,int maxIterations)
		{
			double currDistSq = 0 ;
            int numIterations = 0;

			while (numIterations++ < maxIterations)
            {

                currDistSq = z.Magnitude * z.Magnitude ;
                if (currDistSq > MaxDistance_MULTI )
                    return numIterations;

                Complex z_val = Fractals.expImaginary * Complex.Pow(z, Fractals.ConstK);
				z = z_val + c ;
				
			}
			return maxIterations;
		}
        
        public static int TransformReciprocal(Complex z, Complex c, int maxIterations)
        {
            double currDistSq = 0;
            int numIterations = 0;
            
            while (numIterations++ < maxIterations)
            {
                currDistSq = z.Magnitude * z.Magnitude;
                if (currDistSq >  MaxDistance_On_EXP_ConstK * MaxDistance_On_EXP_ConstK )
                    return numIterations;

                Complex z_val = z * c / ( Complex.Pow ( z, Fractals.ConstK) + c);
                z = Complex.Reciprocal( z_val) ;

            }
            return maxIterations;
        }
        public static int TransformLogaritmic(Complex z, Complex c, int maxIterations)
        {
            double currDistSq = 0;
            int numIterations = 0;
            
            while (numIterations++ < maxIterations)
            {

                currDistSq = z.Magnitude * z.Magnitude;
                if (currDistSq > MaxDistance_On_EXP_ConstK )
                    return numIterations;

                Complex z_val = expComplex * Complex.Log(z) * Complex.Log(c);
                z = Complex.Exp (  z_val )  ;

            }
            return maxIterations;
        }
		public static int TransformExponentialMultiply(Complex z, Complex c,int maxIterations )
		{

            double currDistSq = 0 ;
            int numIterations = 0;
				
			while (numIterations++ < maxIterations)
            {

                currDistSq = z.Magnitude * z.Magnitude;
				
				if ( currDistSq > MaxDistance_MULTI )
					return numIterations ;
				
				Complex z_val = Complex.Pow( expComplex, z*c  );
				z = z_val   ;
				
			}
			return maxIterations;
		}
		public static int TransformExponentialDivide(Complex z, Complex c,int maxIterations )
		{

            double currDistSq = 0 ;
            int numIterations = 0;
				
			while (numIterations++ < maxIterations)
            {

                currDistSq = z.Magnitude * z.Magnitude;
				
				if ( currDistSq > MaxDistance_MULTI )
					return numIterations ;
				
				Complex z_val = Complex.Pow( expComplex , z/c  );
				z = z_val   ;
				
			}
			return maxIterations;
		}
		public static int TransformExponentialInverseDivide(Complex z, Complex c,int maxIterations )
		{
			
			double currDistSq = 0 ;
            int numIterations = 0;
				
			while (numIterations++ < maxIterations)
            {

                currDistSq = z.Magnitude * z.Magnitude;
				
				if ( currDistSq > MaxDistance_MULTI )
					return numIterations ;
				
				Complex z_val = Complex.Pow( expComplex , c/z  );
				z = z_val   ;
				
			}
			return maxIterations;
		}
		
		public static int TransformNaturalExponential(Complex z, Complex c,int maxIterations )
		{
			
			double currDistSq = 0 ;
            int numIterations = 0;
			
				
			while (numIterations++ < maxIterations)
            {
                currDistSq = z.Magnitude * z.Magnitude;
				
				if ( currDistSq > MaxDistance_On_EXP_ConstK )
					return numIterations ;
				
				Complex z_val = Complex.Exp(z) / c ;
				z = z_val  ;
				
			}
			return maxIterations;
		}
		public static int TransformReverseExponential(Complex z, Complex c,int maxIterations )
		{
			
			double currDistSq = 0 ;
            int numIterations = 0;
				
			while (numIterations++ < maxIterations)
            {

                currDistSq = z.Magnitude * z.Magnitude;
				
				if ( currDistSq > MaxDistance_MULTI  )
					return numIterations ;
				
				
				Complex z_val = Complex.Pow(  z, Math.E );
				z = z_val +- c ;
				
			}
			return maxIterations;
		}
        public static int TransformTetration(Complex z, Complex c,int maxIterations)
        {
            double currDistSq = 0 ;
            int numIterations = 0;
			

			while (numIterations++ < maxIterations)
            {

                currDistSq = z.Magnitude * z.Magnitude;
				
				if ( currDistSq > MaxDistance_On_EXP_ConstK  )
					return numIterations ;
				
				Complex z_val = Complex.Pow( c, z );
				z = z_val ;
				
			}
			return maxIterations;
        }
		public static int TransformReverseTetration(Complex z, Complex c,int maxIterations)
        {
            double currDistSq = 0 ;
            int numIterations = 0;
            
				
			while (numIterations++ < maxIterations)
            {

                currDistSq = z.Magnitude * z.Magnitude;
				
				if ( currDistSq > MaxDistance_On_EXP_ConstK )
					return numIterations ;
				
				Complex z_val = Complex.Pow( z, c );
				z = z_val ;
				
			}
			return maxIterations;
        }
		public static int TransformGeneralCollatz(Complex z, Complex c,int maxIterations)
        {
            double currDistSq = 0 ;
            int numIterations = 0;
            
				
			while (numIterations++ < maxIterations)
            {

                currDistSq = z.Magnitude * z.Magnitude;
				
				if ( currDistSq > MaxDistance_ConstK )
					return numIterations ;
				
				
				double val = z.Magnitude + c.Magnitude ;
				if ( val > 0.5  )
				{
					z = 3*z + 1; 
				}
				z = z/2;
				
			}
			return maxIterations;
        }
        public static int TransformCustom(Complex z, Complex c, int maxIterations)
        {
            double currDistSq = 0;
            int numIterations = 0;


            while (numIterations++ < maxIterations)
            {

                currDistSq = z.Magnitude * z.Magnitude;

                if (currDistSq > MaxDistance_On_EXP_ConstK )
                    return numIterations;
                z = CustomExpression.EvaluateCustomExpression(z, c);
            }
            return maxIterations;
        }

        #endregion 
        public static int IsInSet(double a, double b, int maxIterations)
        {
            Complex c = new Complex(a, b);
            Complex z = c ; //Start point
            
            	
				switch ( CurrentTransformType )
				{
				
					case TransformType.GeneralizedCollatz:
						return TransformGeneralCollatz(z,c,maxIterations);
                    case TransformType.Reciprocal :
                        return TransformReciprocal(z, c, maxIterations);
                    case TransformType.Logarithmic:
                        return TransformLogaritmic(z, c, maxIterations);
					case TransformType.ExponentiatonMultiply:
						return TransformExponentialMultiply(z, c,maxIterations);
					
				    case TransformType.ExponentiatonDivide:
						return TransformExponentialDivide(z, c,maxIterations);
				
				    case TransformType.ExponentiatonInverseDivide:
						return TransformExponentialInverseDivide(z, c,maxIterations);
				
				
					case TransformType.NaturalExponentiation:
						return TransformNaturalExponential(z,c,maxIterations);
				
					case TransformType.ReverseExponentian:
						return TransformReverseExponential(z,c,maxIterations);
				
					case TransformType.MultiBrot:
						return TransformMultiBrot(z,c,maxIterations);
						//break;
					case TransformType.ImaginaryBrot:
						return TransformImaginaryBrot(z,c,maxIterations);
                    case TransformType.ImaginaryBrotN:
                        return TransformImaginaryBrotN(z, c, maxIterations);
						//break;
                    case TransformType.Tetration:
                        return TransformTetration(z, c,maxIterations);
                       // break;
					case TransformType.ReverseTetration:
						return TransformReverseTetration(z,c,maxIterations);
				
					case TransformType.Nova:
						return TransformNova(z,c,maxIterations);
				
                    case TransformType.CustomExpression :
                        return TransformCustom(z, c, maxIterations);
					default:
						break;
				}
            return maxIterations;
        }
    }
}
