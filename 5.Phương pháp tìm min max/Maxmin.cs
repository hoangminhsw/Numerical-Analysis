
using System;
using System.Linq;
namespace minmax{
    class program{
       static  double step = 1.0e-6;
        static double eta = 1.0e-3;
        static double f(double x0 , double[] x , int n){
            double f=0;
            for(int i=0;i<=n;i++){
                f += x[i]*(Math.Pow(x0,n-i));
            }
            return f;
        }
//======================================================Tính f'(x)=============================================================================================================//
            static double fdx(double x0 , double[] x , int n){
                double delta = 1.0e-1;
            double dy=f(x0+delta,x,n)-f(x0-delta,x,n),dx=2*delta;
	        return dy/dx;
        }
//======================================================gradient=============================================================================================================//

        static double grad(double x0,double[] x,int n,double eps,double a,double b){
               while(Math.Abs(fdx(x0,x,n))>eps){
                   x0= x0 + Math.Sign(fdx(x0,x,n))*eta*fdx(x0,x,n);
 //                   Console.WriteLine(fdx(x0,x,n));
//                 Console.WriteLine(x0);
  //                  Console.WriteLine(f(x0,x,n));
               if(x0>b){
                       return b;
                   }
               }
            return x0;
           }
        
//======================================================Min Max==============================================================================================================//
     static int minmax(double[] x,int n,double eps,double a,double b,double[] index){
         double i=a;
         int count = 0;
        while(i<b){
            i=grad(i,x,n,eps,a,b);
            index[count]=f(i,x,n);
            i = i + step;
            count++;
        }
        return count;
     }
//===================================================================================================================================================================//
        static void Main(string[] args){
//======================================================Nhap bac va he so cua ham so============================================================//
            Console.WriteLine("Nhap bac cua ham so f(x)");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Nhap he so cho ham so f(x):");
            double[] x = new double [100];
            for (int i=0;i<=n;i++){
                 x[i]= double.Parse(Console.ReadLine());
            }
            double[] index = new double [1000];
            
//======================================================Nhap khoang cach li nghiem==============================================================//
            double a,b;
               Console.WriteLine("Nhap khoang a,b");
                     a= double.Parse(Console.ReadLine());
                     b= double.Parse(Console.ReadLine()); 

//======================================================Kiem tra f(a) va f(b),nhap sai so=======================================================//
            
            Console.WriteLine("Nhap sai so");
            double eps= double.Parse(Console.ReadLine());
//===============================================================Kiem tra min max================================================================================//
            int count = minmax(x,n,eps,a,b,index);
            index[++count]=f(a,x,n);
            index[++count]=f(b,x,n);
            double max;
            double min;
            max = index[0];
            min = index[0];
            for(int i=0;i<=count;i++){
                if(max < index[i]){
                    max = index[i];
                }
                if(min>index[i]){
                    min = index[i];
                }
            }
            Console.WriteLine("GTLN "+max);
            Console.WriteLine("GTNN "+min);
        }
    }
}