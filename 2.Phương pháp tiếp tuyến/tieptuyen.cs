
using System;
using System.Linq;
namespace daycung{
    class program{
//======================================================Kiem tra khoang cach li nghiem======================================================================//
        static int check(double a, double b,double[] x,int n){
             if(fdx(a,x,n)*fdx(b,x,n)<0){
                return 0;
            } 
            return 1;
        }
//======================================================Tính f(x)==============================================================================================================//
        static double f(double a , double[] x , int n){
            double f=0;
            for(int i=0;i<=n;i++){
                f += x[i]*(Math.Pow(a,n-i));
            }
            return f;
        } 
//======================================================Tính f'(x)=============================================================================================================//
             static double fdx(double a , double[] x , int n){
                double delta = 1.0e-1;
            double dy=f(a+delta,x,n)-f(a-delta,x,n),dx=2*delta;
	        return dy/dx;
        }
//======================================================Tính f''(x)============================================================================================================//
         static double fdx2(double a , double[] x , int n){
             double delta = 1.0e-1;
            double dy=fdx(a+delta,x,n)-fdx(a-delta,x,n),dx=2*delta;
	        return dy/dx;
        }
        static void Main(string[] args){
//======================================================Nhap bac va he so cua ham so============================================================//
            Console.WriteLine("Nhap bac cua ham so f(x)");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Nhap he so cho ham so f(x):");
            double[] x = new double [100];
            for (int i=0;i<=n;i++){
                 x[i]= double.Parse(Console.ReadLine());
            }

//======================================================Nhap khoang cach li nghiem==============================================================//
            double a,b;
           do {
               Console.WriteLine("Nhap khoang cach li nghiem a,b");
                     a= double.Parse(Console.ReadLine());
                     b= double.Parse(Console.ReadLine()); 
                    if(check(a,b,x,n)==0){
                Console.WriteLine("Khoang cach li khong co nghiem hoac khong hop le ");}

            }  while(check(a,b,x,n)==0);
//======================================================Kiem tra f(a) va f(b),nhap sai so=======================================================//
            if (f(a,x,n)==0){
                Console.WriteLine("Phuong trinh co nghiem:"+a);
                return;

            } if (f(b,x,n)==0){
                Console.WriteLine("Phuong trinh co nghiem:"+b);
                return;
            }
            Console.WriteLine("Nhap sai so");
            double eps= double.Parse(Console.ReadLine());
            double x0=0;
//======================================================Tim diem fourier========================================================================//
            if(f(a,x,n)*fdx2(a,x,n)>0){
                 x0=a;
            }else {
                 x0=b;
            }
            double min,max2;
//===============================================================================================================================================//
            min=Math.Min(Math.Abs(fdx(a,x,n)),Math.Abs(fdx(b,x,n)));
            max2=Math.Max(Math.Abs(fdx2(a,x,n)),Math.Abs(fdx2(b,x,n)));
            double x1=0;
            int count=0;
            do {
                x1=x0;
                x0 = x0 - (f(x0,x,n)/fdx(x0,x,n));
                 Console.WriteLine("x{0}={1}",count,x0);
                count++;
            } while((max2*Math.Abs(x0-x1)*Math.Abs(x0-x1)/(2*min))>eps);
            Console.WriteLine("Phuong trinh co nghiem:"+x0);
             }
            
        }
    }

