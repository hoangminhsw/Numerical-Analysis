// Nguyen Thanh Nam-20206252
using System;
using System.IO;
using System.Text;
using System.Linq;
namespace _20206252_Bai_2_1{
    class program{
//===============================================================Qua trinh nguoc=======================================
        static int tinh_nghiem(ref double[][] a,ref int n,ref double[] x){
            if(a[n-1][n-1]!=0){
                x[n-1]=a[n-1][n]/a[n-1][n-1];
                for(int i=n-2;i>=0;i--){
                    x[i]=a[i][n];
                    for(int j=n-1 ; j>i;j--){
                       x[i] = x[i] - x[j]*a[i][j];
                    }
                    x[i]=x[i]/a[i][i];
                }
            }
              return n; 

        }
        static int rank(ref double[][] a,ref int n,ref double[] x){
            if(a[n-1][n]!=0 && a[n-1][n-1]==0){
                return -1;
            } else if(n>=0 && a[n-1][n-1]==0){
                n--;
                rank(ref a,ref n,ref x);
            }
            return n;
        }

//==================================================================================dua ma tran ve dang bac thang======================================================================
        static void bacthang(ref double[][] a, int n){
            double m;
            int p = 0; 
            double[] temp;  
             for(int i=0;i<n;i++){
               
                while(a[p][i]==0 || p<i ){
                    if(p<n-1)
                   p++;
                   else break;
                  //kiem tra ap  Console.WriteLine(p); 
                }
                if(p!=i){ //doi dong i va p, day dong thu i len dau 
                    temp = a[p];
                    a[p] = a[i];
                    a[i] = temp;
                }
                for(int j=i+1;j<n;j++){  //xet tat ca cac dong sau dong thu i
                if(a[i][i]!=0)        
                    {m = (a[j][i]/a[i][i]) ;
                    for(int k=0;k<=n;k++){
                        a[j][k] = a[j][k] - m*a[i][k];   // lay dong thu j - dong thu i de khu 
                    }
                  }
                }
            }
        }
        static void output(double[][] a,int n,double[] x){
            for(int i=0;i<n;i++){
                 Console.WriteLine();
                for(int j=0;j<=a.Length;j++){
                Console.Write(a[i][j] + " ");
                }
            }
             Console.WriteLine();
            
           for(int i=0;i<n;i++){
              
               {Console.WriteLine("x"+i+"="+x[i]);}
           }
        }
        static void Main(string[] args){
            double[][] a = File.ReadAllLines("example.txt").Select(l => l.Split(' ').Select(i => double.Parse(i)).ToArray()).ToArray();
            int n = a.Length;
            double[] x = new double[100];
            double[] a1 = new double[100];
            bacthang(ref a,n);
            int check= rank(ref a,ref n,ref x);
            if(check==-1){
                 output(a,n,x);
                Console.WriteLine("Phuong trinh vo nghiem");
                return;
            } 
            if(n < a.Length){
                 output(a,n,x);
                Console.WriteLine("Phuong trinh co vo so nghiem");
                return;
            }else {
               tinh_nghiem(ref a,ref n,ref x);
            }
               output(a,n,x);
        }
   }
}