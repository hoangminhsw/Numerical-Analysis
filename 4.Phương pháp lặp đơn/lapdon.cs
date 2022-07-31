
using System;
using System.Linq;
namespace daycung{
    class program{
         static int check(double a, double b,double x0){
             if(x0<a || x0 >b){
                return 0;
            } 
             else if(a>b){
                return 0;
            } if(max(a,b)>=1){
                return 0;
            }
            return 1;
        }
            static double g(double x) {// nhap ham g(x)
                {
                   return (21*Math.Pow(x,5)-12*Math.Pow(x,4)+3*Math.Pow(x,2)-15+x);
                }
            }

            static double gdx(double x){
                double delta = 1.0e-1;
                double dy=g(x+delta)-g(x-delta);
                return dy/(2*delta);
            }
            static double max(double a,double b){
                double eps = 0.0001;
                double q = Math.Abs(gdx(a));
                while(a<b){
                    if(Math.Abs(gdx(a+eps))>q){
                        q = Math.Abs(gdx(a+eps));
                    }
                    a= a + eps;
                }
                return q;

            }


            static void Main(string[] args){
                    double a,b,x0;
           
               Console.WriteLine("Nhap khoang cach li nghiem a,b");
                     a= double.Parse(Console.ReadLine());
                     b= double.Parse(Console.ReadLine()); 
                     Console.WriteLine("Nhap x0");
                     x0= double.Parse(Console.ReadLine()); 
                    if(check(a,b,x0)==0){
                Console.WriteLine("Khoang cach li khong co nghiem hoac khong hop ,khong thua man dieu kien co");}
            double q= max(a,b);    
            Console.WriteLine("Nhap sai so");
            double eps = double.Parse(Console.ReadLine());
            double count=0,x1=g(x0);
            if(x0==g(x0)){
                Console.WriteLine("x0");
                return;
            }
            while(Math.Abs(x0-x1)>(1-q)*eps/q){
                Console.WriteLine("x" + count + "="+x0);
                count++;
                x1=x0;
                x0=g(x0);
            } 
            Console.WriteLine("Dung sau "+count+" lan lap");
            Console.WriteLine("Nghiem gan dung x = "+x0);
            return ;
            }
            
        }
    }
