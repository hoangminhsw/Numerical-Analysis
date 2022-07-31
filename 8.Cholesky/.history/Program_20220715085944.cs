using System;
using System.IO;
using System.Linq;
namespace GTS
{
    public class Matrix
{
    public readonly double[,] values;

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
    
    // Tim ma tran U
    public static Matrix FindU(Matrix A){
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
            if(A[i,i] - kq<0){
                Matrix_C.FindU(A);
            }
            u[i,i] = Math.Sqrt(A[i,i] - kq);
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
        return new Matrix(u);
    }
    //Tim ma tran nghich dao cua U
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
        public static Matrix gauss_nghichdao_duoi(Matrix a,Matrix b,int n){
            double[,] x = new double [n,1];
            if(a[0,0]!=0){
                x[0,0]=b[0,0]/a[0,0];
                for(int i=1;i<n;i++){
                    x[i,0]=b[i,0];
                    for(int j=0 ; j<i ; j++){
                       x[i,0] = x[i,0] - x[j,0]*a[i,j];
                    }
                    x[i,0]=x[i,0]/a[i,i];
                }
            }
              return new Matrix(x) ; 
        }
        public static Matrix gauss_nghichdao_tren(Matrix a,Matrix b,int n){
            double[,] x = new double [n,1];
            
            if(a[n-1,n-1]!=0){
                x[n-1,0]=b[n-1,0]/a[n-1,n-1];
                for(int i=n-2;i>=0;i--){
                    x[i,0]=b[i,0];
                    for(int j=n-1 ; j>i ; j--){
                       x[i,0] = x[i,0] - x[j,0]*a[i,j];
                    }
                    x[i,0]=x[i,0]/a[i,i];
                }
            }
              return new Matrix(x) ; 
        }
    
}
        class program {
           
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
//=========================================MA tran B===============
             double[][] b = File.ReadAllLines("matrixB.txt").Select(l => l.Split(' ').Select(i => double.Parse(i)).ToArray()).ToArray();
             double[,]m1=JaggedToMultidimensional(b);
             Matrix B = new Matrix(m1);
//=========== Kiểm tra tinh kha nghịch ==============
             if(Matrix.det(ref a,n)!=0)
                Console.WriteLine("Ma tran A kha nghich.");
             else{
                Console.WriteLine("Ma tran A khong kha nghich.");
                return;
             }
//=========== Kiểm tra tinh doi xung ================
             if(A != AT){
                Console.WriteLine("Ma tran A khong doi xung.");
                Matrix M = AT * A;
                Matrix d = AT*B;
                Matrix_C U = Matrix_C.FindU(M);
                    Console.WriteLine("==========M = AT*A:=========");
                    Matrix.output(M);
                    Console.WriteLine("==========Ma tran U va uT:=========");
                    Matrix_C UT = Matrix_C.chuyenvi(U)*U;
                    Matrix_C.output(UT);
                    Matrix_C.output(Matrix_C.chuyenvi(U));
                    Matrix_C y = Matrix_C.gauss_nghichdao_duoi(Matrix_C.chuyenvi(U),Matrix_C.convertToCom(d),n);
                    Console.WriteLine("==========Ma tran Y: UT*Y=D =========");
                    Matrix_C.output(y);
                    Matrix_C x = Matrix_C.gauss_nghichdao_tren(U,y,n);
                    Console.WriteLine("Ket qua la:");
                Matrix_C.output(x);

             }
             else {Console.WriteLine("Ma tran A doi xung.");
                Matrix_C U = Matrix_C.FindU(A);
                Console.WriteLine("==========Ma tran U va uT:=========");
                Matrix_C.output(U);
                Matrix_C UT = Matrix_C.chuyenvi(U);
                Matrix_C.output((UT));
                Console.WriteLine("==========Ma tran Y: UT*Y=D =========");
                Matrix_C y = Matrix_C.gauss_nghichdao_duoi(Matrix_C.chuyenvi(U),Matrix_C.convertToCom(B),n);
                Matrix_C.output(y);
                Matrix_C x = Matrix_C.gauss_nghichdao_tren(U,y,n);
                Console.WriteLine("Ket qua la:");
                Matrix_C.output(x);
             }   
            
        }
}
        public class Complex
    {
        public double real{get; set;}
        public double img{get; set;}
        public Complex (){}
        public Complex (double real,double img){    
            this.real= real;
            this.img = img;
        }
        public static Complex operator + (Complex b, Complex c){
            Complex a  = new Complex{
                real = b.real + c.real,
                img = b.img +c.img
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
        public static Complex operator /(Complex b, Complex c){
            Complex a = new Complex{
                real = (b.real*c.real + b.img*c.img)/(Math.Pow(c.real,2)+Math.Pow(c.img,2)),
                img = -(b.real*c.img - b.img*c.real)/(Math.Pow(c.real,2)+Math.Pow(c.img,2))
            };
            return a;
        }
        public static double[,] convertToDb(Matrix_C A){
            Complex[,] a = A.values;
            int n = a.GetLength(0);
            double [,] b = new double[n,n];
            for(int i=0;i<n;i++){
                for(int j=0;j<n;j++){
                    b[i,j]=a[i,j].real;
                }
            }
            return b;
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
            b.real =-1*(Math.Sqrt((4*a.real+Math.Sqrt(16*Math.Pow(a.real,2)+16*Math.Pow(a.img,2)))/8));
            b.img = -1*(a.img/(2*b.real));
            return b;
        }

        public override string ToString()
        {
            return this.real + " " + this.img + "i";
        }
    }
     public class Matrix_C
{
    public Complex[,] values;

    public Complex this[int x, int y] {
        get { return values[x,y]; }
    }
    public Matrix_C(){}
    public Matrix_C(Complex[,] values) {
        this.values = values;
    }
    //=====================================Lay so hang
    public static int dimension(Matrix_C x){
        Complex[,] m0 = x.values;
        return m0.GetLength(0);
    }
    //=====================================lay so cot
    public static int dimension1(Matrix_C x){
        Complex[,] m0 = x.values;
        return m0.GetLength(1);
    }
    //=====================================chong chat toan tu cong
    public static Matrix_C operator +(Matrix_C x, Matrix_C y) {
        Complex[,] m0 = x.values;
        Complex[,] m1 = y.values;
        int dimension=m0.GetLength(0);
        int dimension1=m0.GetLength(1);
        Complex[,] newMatrix= new Complex [dimension,dimension1];
        for(int i=0;i<dimension;i++){
            for(int j=0;j<dimension1;j++){
                newMatrix[i,j]=m0[i,j]+m1[i,j];
            }
        }
        return new Matrix_C(newMatrix);
    }
    // =====================================chong chat toan tu nhan
    public static Matrix_C operator *(Matrix_C x,Matrix_C y){
        Complex[,] m0 = x.values;
        Complex[,] m1 = y.values;
        int dimension=Matrix_C.dimension(x);
        int dimension1=Matrix_C.dimension(y);
        Complex[,] c = new Complex [dimension,dimension1]; 
        for(int i=0;i<dimension;i++){
                    for(int j=0;j<dimension1;j++){
                        int k=0;
                         c[i,j]=new Complex(0,0);
                        while (k<dimension){
                            c[i,j] += m0[i,k]*m1[k,j]; 
                           if( k==dimension-1){break;}
                            k++;
                        }  
                    }
                }
                return new Matrix_C(c);
    }
    public static Matrix_C operator -(Matrix_C x, Matrix_C y) {
        Complex[,] m0 = x.values;
        Complex[,] m1 = y.values;
        int dimension=m0.GetLength(0);
        int dimension1=m0.GetLength(1);
        Complex[,] newMatrix= new Complex [dimension,dimension1];
        for(int i=0;i<dimension;i++){
            for(int j=0;j<dimension1;j++){
                newMatrix[i,j]=m0[i,j]-m1[i,j];
            }
        }
        return new Matrix_C(newMatrix);
    }
    // So sanh hai ma tran
    public static bool operator == (Matrix_C X, Matrix_C Y){
        Complex[,] x= X.values;
        Complex[,] y = Y.values;
        for(int i=0;i<x.GetLength(0);i++){
            for(int j=0;j<y.GetLength(0);j++){
                if(x[i,j]!=y[i,j])
                    return false;
            }
        }
        return false;
    }
    public static Matrix_C convertToCom(Matrix x){
            double[,] A = x.values;
            int n = Matrix.dimension(x);
            int m = Matrix.dimension1(x);
            Complex [,] b = new Complex [n,m];
            for(int i=0;i<n;i++){
                for(int j=0;j<m;j++){
                    b[i,j] = new Complex(A[i,j],0);
                }
            }
            return new Matrix_C(b);
        }
    public static bool operator != (Matrix_C X, Matrix_C Y){
        Complex[,] x= X.values;
        Complex[,] y = Y.values;
        for(int i=0;i<x.GetLength(0);i++){
            for(int j=0;j<y.GetLength(0);j++){
                if(x[i,j]!=Y[i,j])
                    return true;
            }
        }
        return false;
    }
    
    // hien thi ma tran ra man hinh
    public static void output(Matrix_C x){
            Complex [,]a = x.values;
            for(int i=0;i<a.GetLength(0);i++){
                for(int j=0;j<a.GetLength(1);j++){
                Console.Write(a[i,j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
    }
    public static Matrix_C newMatrix (int n){
        Complex [,] x = new Complex[n,n];
        for(int i =0;i<n;i++){
            for(int j =0; j<n;j++){
                x[i,j].real = 0;
                x[i,j].img = 0;
            }
        }
        return new Matrix_C(x);
    }

    // Tim ma tran U
    public static Matrix_C FindU(Matrix A){
        int n = Matrix.dimension(A);
           // double [,] values = Matrix.getValues(A);
           Console.WriteLine("Check Uphuc");
           Matrix.output(A);
            Matrix_C a = Matrix_C.convertToCom(A);

            Complex[,] u = new Complex [n,n];
            u[0,0]=Complex.Can(new Complex(A[0,0],0));
            for(int k=1;k<n;k++){    // Tìm U[1,k]
                u[0,k] = a[0,k]/u[0,0];
            }
            for(int i=1;i<n;i++){
                for(int j=0;j<n;j++){
                    Complex Tong = new Complex(0,0);
                    if(i>j){
                            u[i,j]=new Complex(0,0);
                            continue;
                        }
                    for(int k=0;k<i;k++){
                        Tong += u[k,i]*u[k,j];
                    }
                    if(i==j){
                       
                            u[i,i]=Complex.Can((a[i,i]-Tong));
                        }
                    if(j>i){
                            
                            u[i,j]=(a[i,j]-Tong)/u[i,i];
                        }
                }
            }
            return new Matrix_C(u);
    }
    //Tim ma tran ngghich dao cua U
    public static Matrix_C nghichdao (Matrix_C u){
        int n = Matrix_C.dimension(u);
        Complex [,] l = new Complex[n,n];
        Complex O = new Complex (1,1);
        for(int i =0;i<n;i++){
                l[i,i] = O/u[i,i];
            }
        for(int i=0;i<n;i++){
            for(int j=0;j<i;j++){
                l[i,j] = new Complex(0,0);
            }
        }
        for(int i=0;i<n;i++){
            for(int j=i+1;j<n;j++){
                Complex kq=new Complex(0,0);
                for(int k=0;k<=j-1;k++){
                    kq=kq+l[i,k]*u[k,j];
                }
                l[i,j]= kq/(u[j,j]);
                l[i,j].real=(l[i,j].real)*(-1);
                l[i,j].img=(l[i,j].img)*(-1);

            }
        }
        return new Matrix_C(l); 
    }
    // Tim ma tran chuyen vi
    public static Matrix_C chuyenvi(Matrix_C A){
                Complex [,] a = A.values;
                int n = a.GetLength(0);
                Complex[,] b = new Complex[n,n];
                for(int i =0; i<n; i++){
                    for(int j=0;j<n;j++){
                        b[j,i] = a[i,j];
                    }
                }
                return new Matrix_C(b);
    }
     public static Matrix_C gauss_nghichdao_duoi(Matrix_C a,Matrix_C b,int n){
            Complex[,] x = new  Complex [n,1];
            if(a[0,0]!=new Complex(0,0)){
                x[0,0]=b[0,0]/a[0,0];
                for(int i=1;i<n;i++){
                    x[i,0]=b[i,0];
                    for(int j=0 ; j<i ; j++){
                       x[i,0] = x[i,0] - x[j,0]*a[i,j];
                    }
                    x[i,0]=x[i,0]/a[i,i];
                }
            }
              return new Matrix_C(x) ; 
        }
        public static Matrix_C gauss_nghichdao_tren(Matrix_C a,Matrix_C b,int n){
            Complex[,] x = new Complex [n,1];
            
            if(a[n-1,n-1]!= new Complex(0,0)){
                x[n-1,0]=b[n-1,0]/a[n-1,n-1];
                for(int i=n-2;i>=0;i--){
                    x[i,0]=b[i,0];
                    for(int j=n-1 ; j>i ; j--){
                       x[i,0] = x[i,0] - x[j,0]*a[i,j];
                    }
                    x[i,0]=x[i,0]/a[i,i];
                }
            }
              return new Matrix_C(x) ; 
        }
}
}