using System;
using System.IO;
using System.Linq;
namespace GTS
{
    public class Matrix
{
    private readonly double[,] values;

    public double this[int x, int y] {
        get { return values[x,y]; }
    }
    public Matrix(){}
    public Matrix(double[,] values) {
        this.values = values;
    }
    //=====================================Lay so hang
    public static int dimension(Matrix x){
        double[,] m0 = x.values;
        return m0.GetLength(0);
    }
    //=====================================lay so cot
    public static int dimension1(Matrix x){
        double[,] m0 = x.values;
        return m0.GetLength(1);
    }
    //=====================================chong chat toan tu cong
    public static Matrix operator +(Matrix x, Matrix y) {
        double[,] m0 = x.values;
        double[,] m1 = y.values;
        int dimension=m0.GetLength(0);
        int dimension1=m0.GetLength(1);
        double[,] newMatrix= new double [dimension,dimension1];
        for(int i=0;i<dimension;i++){
            for(int j=0;j<dimension1;j++){
                newMatrix[i,j]=m0[i,j]+m1[i,j];
            }
        }
        return new Matrix(newMatrix);
    }
    // =====================================chong chat toan tu nhan
    public static Matrix operator *(Matrix x,Matrix y){
        double[,] m0 = x.values;
        double[,] m1 = y.values;
        int dimension=m0.GetLength(0);
        int dimension1=m1.GetLength(1);
        double[,] c = new double [dimension,dimension1];
        for(int i=0;i<dimension;i++){
                    for(int j=0;j<dimension1;j++){
                        int k=0;
                        while (k<dimension){
                            c[i,j] += m0[i,k]*m1[k,j]; 
                           if( k==dimension-1){break;}
                            k++;
                        }  
                    }
                }
                return new Matrix(c);
    }
    public static Matrix operator -(Matrix x, Matrix y) {
        double[,] m0 = x.values;
        double[,] m1 = y.values;
        int dimension=m0.GetLength(0);
        int dimension1=m0.GetLength(1);
        double[,] newMatrix= new double [dimension,dimension1];
        for(int i=0;i<dimension;i++){
            for(int j=0;j<dimension1;j++){
                newMatrix[i,j]=m0[i,j]-m1[i,j];
            }
        }
        return new Matrix(newMatrix);
    }
    // So sanh hai ma tran
    public static bool operator == (Matrix X, Matrix Y){
        double[,] x= X.values;
        double[,] y = Y.values;
        for(int i=0;i<x.GetLength(0);i++){
            for(int j=0;j<y.GetLength(0);j++){
                if(x[i,j]!=y[i,j])
                    return false;
            }
        }
        return false;
    }
    public static bool operator != (Matrix X, Matrix Y){
        double[,] x= X.values;
        double[,] y = Y.values;
        for(int i=0;i<x.GetLength(0);i++){
            for(int j=0;j<y.GetLength(0);j++){
                if(x[i,j]!=Y[i,j])
                    return true;
            }
        }
        return false;
    }
    
    // hien thi ma tran ra man hinh
    public static void output(Matrix x){
            double [,]a = x.values;
            for(int i=0;i<a.GetLength(0);i++){
                for(int j=0;j<a.GetLength(1);j++){
                Console.Write(a[i,j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
    }
    public static Matrix newMatrix (int n){
        double [,] x = new double[n,n];
        for(int i =0;i<n;i++){
            for(int j =0; j<n;j++){
                x[i,j] = 0;
            }
        }
        return new Matrix(x);
    }
    // Tim ma tran U
    public static int FindU(Matrix A, ref Matrix U){
        int tmp=0;
        int n = Matrix.dimension(A);
        double [,] u = new double[n,n];
        u[0,0]=Math.Sqrt(A[0,0]);
        for(int k=1;k<n;k++){
            u[0,k]= A[0,k]/u[0,0];
        }
        for(int i = 1; i<n-1;i++){
            double kq=0;
            for(int j=0;j<=i-1;j++){
                kq = kq + u[j,i]*u[j,i];
            }
            u[i,i] = A[i,i] - kq;
            if(u[i,i]<0) {
                tmp=1;
                return tmp;
            }
            u[i,i] = Math.Sqrt(u[i,i]);
            for(int k=i+1;k<n;k++){
                double kq2=0;
                for(int j=0;j<=i-1;j++){
                    kq2= kq2+ u[j,i]*u[j,k];
                }
                u[i,k]= (A[i,k] - kq2)/u[i,i];
            }
        }
        double nn=0;
        for(int i=0;i<n-1;i++){
            nn = nn + u[i,n-1]*u[i,n-1];
        }
        u[n-1,n-1]=Math.Sqrt(A[n-1,n-1]- nn);
        U = new Matrix(u);
        return tmp;
    }
    //Tim ma tran ngghich dao cua U
    public static Matrix nghichdao (Matrix u){
        int n = Matrix.dimension(u);
        double [,] l = new double[n,n];
        for(int i =0;i<n;i++){
                l[i,i] = 1/u[i,i];
            }
        for(int i=0;i<n;i++){
            for(int j=0;j<i;j++){
            l[i,j]=0;
            }
        }
        for(int i=0;i<n;i++){
            for(int j=i+1;j<n;j++){
                double kq=0;
                for(int k=0;k<=j-1;k++){
                    kq=kq+l[i,k]*u[k,j];
                }
                l[i,j]= (-1)*kq/(u[j,j]);
            }
        }
        return new Matrix(l); 
    }
    // Tim ma tran chuyen vi
    public static Matrix chuyenvi(Matrix A){
                double [,] a = A.values;
                int n = a.GetLength(0);
                double[,] b = new double[n,n];
                for(int i =0; i<n; i++){
                    for(int j=0;j<n;j++){
                        b[j,i] = a[i,j];
                    }
                }
                return new Matrix(b);
    }
    public static double det(ref double[][] a, int n){
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
                    for(int k=0;k<n;k++){
                        a[j][k] = a[j][k] - m*a[i][k];   // lay dong thu j - dong thu i de khu 
                    }
                  }
                }
            }
            double det1 = 1;
            for (int i = 0; i < n; i++)
                det1 = det1 * a[i][i];
            return det1;
        }
}
        class program {

        //Phuong phap cholesky
        public static Matrix Cholesky(Matrix A){
            int n = Matrix.dimension(A);
            Matrix U = Matrix.newMatrix(n);
            int tmp = Matrix.FindU(A,ref U);
            if(tmp == 1){
                Matrix B1 = CholeskyPhuc(A);
                return B1;
            }
            Console.WriteLine("Ma tran U:"); Matrix.output(U);
            Matrix U1 = Matrix.nghichdao(U);
            Console.WriteLine("Ma tran nghich dao U1:"); Matrix.output(U1);
            Console.WriteLine("Kiem tra U*U1:"); Matrix.output(U*U1);
            Matrix U1T = Matrix.chuyenvi(U1); 
            Console.WriteLine("Ma tran chuyen vi U1T:"); Matrix.output(U1T);
            Matrix A1 = U1*U1T;  
            Console.WriteLine("Kiem tra A1*A:"); Matrix.output(A*A1);
            return A1;
        }
        public static Matrix CholeskyPhuc(Matrix A){
            Complex [,] aa = Complex.convertToCom(A);
            int n = Matrix.dimension(A);
            Complex [,] U = Complex.FindUphuc(A);
            Console.WriteLine("\nMa tran U:"); Complex.showCom(U);
            Console.WriteLine("Kiem tra UT*U:"); Complex.showCom(Complex.NhanMtPhuc(Complex.chuyenviPhuc(U),U));
            Complex [,] U1 = Complex.nghichdaoPhuc(U);
            Console.WriteLine("\nMa tran nghich dao U1:"); Complex.showCom(U1);
            Console.WriteLine("Kiem tra U*U1:"); Complex.showCom(Complex.NhanMtPhuc(U,U1));
            Complex [,] U1T = Complex.chuyenviPhuc(U1);
            Console.WriteLine("\nMa tran chuyen vi U1T:"); Complex.showCom(U1T);
            Complex [,] A1 = Complex.NhanMtPhuc(U1,U1T);  
            Console.WriteLine("\nKiem tra A1*A:"); Complex.showCom(Complex.NhanMtPhuc(aa,A1));
            double [,] a = Complex.convertToDb(A1);
            Matrix a1 = new Matrix(a);
            return a1;
        }
            public static T[,] JaggedToMultidimensional<T>(T[][] jaggedArray)
            {
                int rows = jaggedArray.Length;
                int cols = jaggedArray.Max(subArray => subArray.Length);
                T[,] array = new T[rows, cols];
                for(int i = 0; i < rows; i++)
                {
                    cols = jaggedArray[i].Length;
                    for(int j = 0; j < cols; j++)
                    {
                        array[i, j] = jaggedArray[i][j];
                    }
                }
                return array;
            }
            static void Main(string[] args ){
//=====================================Nhap: File--> jagged array ------>multidimensional array -------->matrix
             double[][] a = File.ReadAllLines("matrixA.txt").Select(l => l.Split(' ').Select(i => double.Parse(i)).ToArray()).ToArray();
             double[,]m=JaggedToMultidimensional(a);
             Matrix A = new Matrix(m);
             int n = Matrix.dimension(A);
             Console.WriteLine("Ma tran A:"); Matrix.output(A);
             Matrix AT = Matrix.chuyenvi(A);
//=========== Kiểm tra tinh kha nghịch ==============
             if(Matrix.det(ref a,n)!=0)
                Console.WriteLine("Ma tran A kha nghich.");
             else{
                Console.WriteLine("Ma tran A khong kha nghich.");
                return;
             }
//=========== Kiểm tra tinh doi xung ================
             Matrix B = A;
             int index = 0;
             if(A != AT){
                Console.WriteLine("Ma tran A khong doi xung.");
                B = AT*A;
                Console.WriteLine("--Matrix B = AT*A: "); Matrix.output(B);
                index =1;
             }
             else Console.WriteLine("Ma tran A doi xung.");
             Matrix B1 = Cholesky(B);
//=========== Tìm ma trận nghịch đảo ==================            
             Console.WriteLine("\nMa tran nghich dao cua A la:");
             if(index == 0)
                Matrix.output(B1);
             else 
                Matrix.output(B1*AT);
             return;
        }
}
class Complex
    {
        public double real{get; set;}
        public double img{get; set;}
        public Complex (){}
        public Complex (double real,double img){    
            this.real= real;
            this.img = img;
        }
        public static Complex operator + (Complex b, Complex c){
            Complex a  = new Complex();
                a.real = b.real + c.real;
                a.img = b.img +c.img;
            return a;
        }
        public static Complex operator + (Complex b, double c){
            Complex a  = new Complex{
                real = b.real + c,
                img = b.img 
            };
            return a;
        }
        public static Complex operator - (Complex b, Complex c){
            Complex a = new Complex{
                real = b.real - c.real,
                img = b.img - c.img
            };
            return a;
        }
        public static Complex operator *(Complex b, Complex c){
            Complex a = new Complex{
                real = b.real*c.real -b.img*c.img,
                img = b.real*c.img + b.img*c.real
            };
            return a;
        }
        public static Complex operator *(double c,Complex b){
            Complex a = new Complex{
                real = b.real*c,
                img = b.img*c
            };
            return a;
        }
        public static Complex operator /(Complex b, Complex c){
            Complex a = new Complex{
                real = (b.real*c.real + b.img*c.img)/(Math.Pow(c.real,2)+Math.Pow(c.img,2)),
                img = (b.img*c.real - b.real*c.img )/(Math.Pow(c.real,2)+Math.Pow(c.img,2))
            };
            return a;
        }
        public static Complex Can(Complex a){
            Complex b = new Complex();
            if(a.img == 0){
                if(a.real<0){
                    b.real= 0;
                    b.img= Math.Sqrt(-a.real);
                }
            else{
                b.real= Math.Sqrt(a.real);
                b.img= 0;
            }
                return b;
            }
            b.real = Math.Sqrt((4*a.real+Math.Sqrt(16*Math.Pow(a.real,2)+16*Math.Pow(a.img,2)))/8);
            b.img = a.img/(2*b.real);
            return b;
        }
        
        public static double[,] convertToDb(Complex [,] a){
            int n = a.GetLength(0);
            double [,] b = new double[n,n];
            for(int i=0;i<n;i++){
                for(int j=0;j<n;j++){
                    b[i,j]=a[i,j].real;
                }
            }
            return b;
        }

        public static Complex [,] convertToCom(Matrix A){
            int n = Matrix.dimension(A);
            Complex [,] b = new Complex [n,n];
            for(int i=0;i<n;i++){
                for(int j=0;j<n;j++){
                    b[i,j] = new Complex(A[i,j],0);
                }
            }
            return b;
        }
        
        public static void showCom(Complex [,] a){
            int n = a.GetLength(0);
            for(int i=0;i<n;i++){
                for(int j=0;j<n;j++){
                    Console.Write("   {0}",a[i,j]);
                }
                Console.WriteLine();
            }
        }
        public static Complex[,] newCom (int n){
        Complex [,] x = new Complex[n,n];
        for(int i =0;i<n;i++){
            for(int j =0; j<n;j++){
                x[i,j] = new Complex(0,0);
            }
        }
        return x;
    }

        public override string ToString()
        {
            return this.real + " " + this.img + "i";
        }

        public static Complex [,] FindUphuc(Matrix A){
            int n = Matrix.dimension(A);
            Complex [,] a = Complex.convertToCom(A);
            Complex [,] u = Complex.newCom(n);
            u[0,0]=Complex.Can(a[0,0]);// Tìm u[1,1]

            for(int k=1;k<n;k++){    // Tìm U[1,k]
                u[0,k]= a[0,k]/u[0,0];
            }
            
            for(int i = 1; i<n-1;i++){ // Tìm u[i,i] và u[i,k]
                Complex kq = new Complex();
                for(int j=0;j<=i-1;j++){
                    kq = kq + u[j,i]*u[j,i];
                }
                u[i,i] = Complex.Can(a[i,i] - kq);
                for(int k=i+1;k<n;k++){
                    Complex kq2 = new Complex();
                    for(int j=0;j<=i-1;j++){
                        kq2= kq2+ u[j,i]*u[j,k];
                    }
                    u[i,k]= (a[i,k] - kq2)/u[i,i];
                }
            }
            Complex nn= new Complex();
            for(int i=0;i<n-1;i++){
                nn = nn + u[i,n-1]*u[i,n-1];
            }
            u[n-1,n-1]= Complex.Can(a[n-1,n-1]- nn);    // Tìm u[n,n]
            return u;
        }
        // tim ma tran u1
        public static Complex [,] nghichdaoPhuc(Complex [,] u){
            int n = u.GetLength(0);
            Complex [,] l = new Complex [n,n];
            Complex mot = new Complex(1,0);
            for(int i =0;i<n;i++){
                l[i,i] = mot/u[i,i];
            }
            for(int i=0;i<n;i++){
                for(int j=0;j<i;j++){
                    l[i,j] = new Complex(0,0);
                }
            }
            for(int i=0;i<n;i++){
                for(int j=i+1;j<n;j++){
                    Complex kq = new Complex();
                    for(int k=0;k<=j-1;k++){
                        kq=kq+l[i,k]*u[k,j];
                    }
                    l[i,j]= (-1)*kq/(u[j,j]);
                }
            }
            return l;
        }
        public static Complex [,] chuyenviPhuc(Complex [,] l){
        // Tim ma tran chuyen vi cua U1
                int n = l.GetLength(0);
                Complex [,] lt = new Complex [n,n];
                for(int i =0; i<n; i++){
                    for(int j=0;j<n;j++){
                        lt[j,i] = l[i,j];
                    }
                }
                return lt;
        }
        public static Complex [,] NhanMtPhuc(Complex [,] l,Complex [,] lt){
        // Nhân 2 ma tran so phuc
            int n = l.GetLength(0);
            Complex [,] a1 = Complex.newCom(n);
            for(int i=0;i<n;i++){
                for(int j=0;j<n;j++){
                    int k=0;
                    while (k<n){
                        a1[i,j] = a1[i,j] + l[i,k]*lt[k,j]; 
                        if( k==n-1){break;}
                        k++;
                    }  
                }
            }
            return a1;
        }
    }
}