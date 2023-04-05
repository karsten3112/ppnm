using System;
using static System.Console;
using static System.Math;

class main{
	static void Main(string[] args){
		foreach(string arg in args){
			if(arg == "-Test"){
				Func<double, double> f1 = delegate(double z){
					return Sqrt(z);
				};
				Func<double, double> f2 = delegate(double z){
					return 1.0/Sqrt(z);
				};
				Func<double, double> f3 = delegate(double z){
					return 4*Sqrt(1-z*z);
				};
				Func<double, double> f4 = delegate(double z){
					return Log(z)/Sqrt(z);
				};

				double res1 = integrator.integrate(f1, 0,1.0);
				double res2 = integrator.integrate(f2, 0,1.0);
				double res3 = integrator.integrate(f3, 0,1.0);
				double res4 = integrator.integrate(f4, 0,1.0);
				double[] results = {res1, res2, res3, res4};
				double[] actual = {2.0/3.0,  2.0, PI, -4.0};
				WriteLine("Calculating the integrals with abs. precission; 1e-3 and rel. prec.; 1e-3");
				WriteLine("-------------------------------------------------------------------");
				for(int i = 0; i < results.Length;i++){
					WriteLine($"Integral nr. {i+1} should be {actual[i]} - Calculating via our integration method");
					WriteLine($"I = {results[i]}");
					WriteLine("Checking with approx method");
					WriteLine($"{approx(results[i], actual[i], 1e-3, 1e-3)}");
					WriteLine("-------------------------------------------------------------------");
				}
			}
			if(arg == "-erf"){
				Func<double, double> f1 = delegate(double z){
					return Exp(-z*z);
				};

				Func<double, double> erf = delegate(double z){
					return erf1(z, f1);
				};
				double start = -3.0, end = 3.0; int npoints = 300; double dx = (end - start)/npoints;
				for(int i = 0; i < npoints; i++){
					double xdat = start + i*dx;
					double ydat = erf(xdat);
					WriteLine($"{xdat}	{ydat}");
				}
				WriteLine("");
				WriteLine("");
				for(int i = 0; i < npoints; i++){
					double xdat = start + i*dx;
					double ydat = erf2(xdat);
					WriteLine($"{xdat}  {ydat}");
				}
			}
		}
	}

	public static double erf1(double z, Func<double, double> f1){
		if(z < 0.0){
			return -erf1(-z, f1);
		}
		if(z <= 1.0 && z >= 0.0){
			double result = 2.0*integrator.integrate(f1, 0, z,1e-9,1e-9)/Sqrt(PI);
			return result;
		} else {
			Func<double, double> f2 = delegate(double t){
				return Exp(-Pow((z+(1-t)/t),2))/(t*t);
			};
			double result = 1.0 - 2.0*integrator.integrate(f2, 0, 1.0,1e-9,1e-9)/Sqrt(PI);
			return result;
		}
	}

	static double erf2(double x){
		if(x<0) return -erf2(-x);
		double[] a={0.254829592,-0.284496736,1.421413741,-1.453152027,1.061405429};
		double t=1/(1+0.3275911*x);
		double sum=t*(a[0]+t*(a[1]+t*(a[2]+t*(a[3]+t*a[4]))));/* the right thing */
		return 1-sum*Exp(-x*x);
	}

	public static bool approx(double a, double b, double tau=1e-9, double epsilon=1e-9){
		WriteLine("Comparing......");
        if(Abs(a-b) < tau || Abs(a-b)/(Abs(a) + Abs(b)) < epsilon){
        	return true;
        } else {
            return false;
        }
    }


}
