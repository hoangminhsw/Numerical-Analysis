
using System;
using System.Linq;
namespace daycung{
    class program{
//======================================================Kiem tra khoang cach li nghiem===========================================================================================//
        
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
                     if (f(a,x,n)==0){
                Console.WriteLine("Phuong trinh co nghiem:"+a);
                return;

            } if (f(b,x,n)==0){
                Console.WriteLine("Phuong trinh co nghiem:"+b);
                return;
            }
                    if(check(a,b,x,n)==0){
                Console.WriteLine("Khoang cach li khong co nghiem hoac khong hop le ");}

            }  while(check(a,b,x,n)==0);
//======================================================Kiem tra f(a) va f(b),nhap sai so=======================================================//
            
            Console.WriteLine("Nhap sai so");
            double eps= double.Parse(Console.ReadLine());
            double x0=0;
            double d=0;
//======================================================Tim diem fourier========================================================================//
            if(f(a,x,n)*fdx2(a,x,n)>0){
                 d=a;
                 x0=b;
            }else {
                 d=b;
                 x0=a;
            }
            double fd=f(d,x,n);
            double min,max;
//===============================================================================================================================================//
            min=Math.Min(Math.Abs(fdx(a,x,n)),Math.Abs(fdx(b,x,n)));
            max=Math.Max(Math.Abs(fdx(a,x,n)),Math.Abs(fdx(b,x,n)));
            double x1=0;
            int count=0;
            do {
                x1=x0;
                Console.WriteLine("x{0}={1}",count,x0);
                count++;
                x0 = x0 - (f(x0,x,n)*(x0-d))/(f(x0,x,n)-fd);
            } while(((max-min)*(Math.Abs(x1-x0))/min)>eps);
            Console.WriteLine("Phuong trinh co nghiem:"+x0);
             }
            
        }
    }
