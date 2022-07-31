using System;
using System.Linq;
namespace chiadoi{
    class program{
        static int check(double a, double b,double[] x,int n){
                if(f(a,x,n)==0 || f(b,x,n)==0){
                return 1;
            } else if(a>b){
                return 0;
            } else if(f(a,x,n)*f(b,x,n)>0){
                return 0;
            }
            return 1;
        }
        static double f(double a , double[] x , int n){
            double f=0;
            for(int i=0;i<=n;i++){
                f += x[i]*(Math.Pow(a,n-i));
            }

         return f;
          
        }
        static void Main(string[] args){
           Console.WriteLine("Nhap bac cua ham so f(x)");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Nhap he so cho ham so f(x):");
            double[] x = new double [100];
            for (int i=0;i<=n;i++){
                 x[i]= double.Parse(Console.ReadLine());
            }
            Console.WriteLine("Nhap khoang cach li nghiem a,b");
            double a= double.Parse(Console.ReadLine());
            double b= double.Parse(Console.ReadLine());
            double c;     
            if(check(a,b,x,n)==0) {
                Console.WriteLine("Khoang cach li khong co nghiem hoac khong hop le ");
                return;
            } 
            if (f(a,x,n)==0){
                Console.WriteLine("Phuong trinh co nghiem:"+a);
                return;

            } if (f(b,x,n)==0){
                Console.WriteLine("Phuong trinh co nghiem:"+b);
                return;
            }
            Console.WriteLine("Nhap sai so");
            double eps= double.Parse(Console.ReadLine());
            int count=1;
            while(b-a>eps){
                 c= (a+b)/2;
                 Console.WriteLine("x{0}={1}",count,c);
                 count++;
                if(check(a,c,x,n)==1){
                    if (f(c,x,n)==0){
                        Console.WriteLine("Phuong trinh co nghiem la:"+c);
                         return;}
                    b=c;
                }else if(check(c,b,x,n)==1){
                    if (f(c,x,n)==0){
                        Console.WriteLine("Phuong trinh co nghiem la:"+c);
                         return;
                        }
                    a=c;
                }
            }
            Console.WriteLine("Phuong trinh co nghiem:"+(a+b)/2);
        }
    }
}