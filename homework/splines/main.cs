using System;
using static System.Console;
using static System.Math;

class main{
	static void Main(string[] args){
			foreach(string arg in args){
			if(arg == "-linspline"){
				(vector xs, vector ys) = gendat(50, -PI, PI);
				for(int i = 0; i < xs.size; i++){
					WriteLine($"{xs[i]}	{ys[i]}");
				}
				WriteLine("");
				WriteLine("");
				(vector zinpt, vector d) = gendat(50, -PI, PI);
				linspline spline = new linspline(xs, ys, zinpt); 
				for(int i = 0; i < xs.size; i++){
					WriteLine($"{xs[i]} {spline.z[i]}");
        		}
        		WriteLine("");
        		WriteLine("");
        		for(int i = 0; i < zinpt.size; i++){
        			WriteLine($"{zinpt[i]} {spline.linInteg(xs, ys, zinpt[i])}");
        		}


        	}
			if(arg == "qspline"){

			}
			if(arg == "cspline"){

			}
        }
	}

	public static (vector, vector) gendat(int size, double start=0.0, double end=10.0){
		double dx = (end - start)/size;
		vector xdat = new vector(size);
		vector ydat = new vector(size);
		for(int i = 0; i < size; i++){
			double xi = start + dx*i;
			xdat[i] = xi;
			ydat[i] = Cos(2*xi);
		}
		return (xdat, ydat);
	}
}
