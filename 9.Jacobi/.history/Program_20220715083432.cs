using System;
using System.IO;
using System.Linq;
namespace a
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
    }// =====================================chong chat toan tu nhan
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

    public static Matrix In(int n){
        double[,] a = new double [n,n];
        for(int i=0;i<n;i++){
            a[i,i]=1;
        }
        return new Matrix(a);
    } 

    public static void output(Matrix x){
            double [,]a = x.values;
            for(int i=0;i<a.GetLength(0);i++){
                 Console.WriteLine();
                for(int j=0;j<a.GetLength(1);j++){
                Console.Write(a[i,j] + " ");
                }
            }
             Console.WriteLine();
        }
        public static double chuanB1(Matrix A){
            double[,] a = A.values;
            int m = a.GetLength(0);
            double max=0,tong=0,temp;
            for(int i=0;i<m;i++){
                for(int j=0;j<m;j++){
                   if(i!=j) tong=tong+a[i,j];
                }
                tong = tong/Math.Abs(1/A[i,i]);
                if(max<tong){
                    temp = tong;
                    tong = max;
                    max = temp;
                }
                tong =0;
            }
            return max;
        }
        public static double chuan_vocung(Matrix A){
            double[,] a = A.values;
            int m = a.GetLength(0);
            int n = a.GetLength(1);
            double max=0,tong=0,temp;
            for(int i=0;i<m;i++){
                for(int j=0;j<n;j++){
                    tong = tong + Math.Abs(a[j,i]);
                }
                if(max<tong){
                    temp = tong;
                    tong = max;
                    max = temp;
                }
                tong =0;
            }
            return max;
        }
        public static double chuan(Matrix A){
            double[,] a = A.values;
            int m = a.GetLength(0);
            int n = a.GetLength(1);
            double max=0,tong=0,temp;
            for(int i=0;i<m;i++){
                for(int j=0;j<n;j++){
                    tong = tong + Math.Abs(a[i,j]);
                }
                if(max<tong){
                    temp = tong;
                    tong = max;
                    max = temp;
                }
                tong =0;
            }
            return max;
        }
         public static Matrix T(Matrix A)
            {
                double[,] T= A.values;
                int dimension=T.GetLength(0);
                double[,] newMatrix= new double [dimension,dimension];
                for(int i=0;i<dimension;i++){
                    for(int j=0;j<dimension;j++){
                        if(i==j){
                            newMatrix[i,j]=1/T[i,j];
                        } else {
                            newMatrix[i,j]=0;
                        }
                    }
                }
                return new Matrix(newMatrix);
            }
            public static Matrix x0(int dimension){
                double[,] x0 = new double [dimension,1];
                for(int i=0;i<dimension;i++){
                    x0[i,0]=0;
                   
                }
                return new Matrix(x0);
            }
             public static double lambda(Matrix A){
                double[,] x= A.values;
                double max=0,min=0;
                for(int i=0;i<Matrix.dimension(A);i++){
                    if(max<Math.Abs(x[i,i])){
                        max=Math.Abs(x[i,i]);
                    }
                    if(min<Math.Abs(x[i,i])){
                        min=Math.Abs(x[i,i]);
                    }
                }
                return max/min;
            }
            public static bool check_cheo_troi_hang(Matrix A){
                double[,] x = A.values;
                for(int i=0;i<dimension(A);i++){
                    double sum=0;
                    for(int j=0;j<dimension1(A);j++){
                        if(i!=j)
                        sum += Math.Abs(x[i,j]);
                    }
                    if(Math.Abs(x[i,i])<sum){
                        return false;
                    }
                }
                return true;
            }
            public static bool check_cheo_troi_cot(Matrix A){
                double[,] x = A.values;
                for(int i=0;i<dimension(A);i++){
                    double sum=0;
                    for(int j=0;j<dimension1(A);j++){
                        if(i!=j)
                        sum += Math.Abs(x[j,i]);
                    }
                    if(Math.Abs(x[i,i])<sum){
                        Console.WriteLine(sum);
                        return false;
                    }
                }
                return true;
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
             double[][] a = File.ReadAllLines("matranA.txt").Select(l => l.Split(' ').Select(i => double.Parse(i)).ToArray()).ToArray();
             double[,]m=JaggedToMultidimensional(a);
             Matrix A=new Matrix(m);
             double[][] b = File.ReadAllLines("matranB.txt").Select(l => l.Split(' ').Select(i => double.Parse(i)).ToArray()).ToArray();
             double[,]Y=JaggedToMultidimensional(b);
             Matrix B=new Matrix(Y);
             Console.WriteLine("Nhap sai so");
             double eps = double.Parse(Console.ReadLine());
             if(Matrix.check_cheo_troi_cot(A)){
                    Console.WriteLine("Ma tran cheo troi cot");
                    Matrix x=Matrix.x0(Matrix.dimension(A));
                    Matrix x1=x;
                    Matrix I = Matrix.In(Matrix.dimension(A));
                    Matrix T = Matrix.T(A);
                    Matrix B1=I-T*A;
                    Console.WriteLine("He so co");
                    Console.WriteLine(Matrix.chuan_vocung(B1));
                    int k=0;
                    do{
                    
                        x1= x;
                        x=B1*x+T*B;
                        Matrix.output(x);
                        Console.WriteLine("Lan lap thu"+k);
                        k++;
                }while((Matrix.lambda(A)*Matrix.chuan(B1)/(1-Matrix.chuan(B1)))*Matrix.chuan(x1-x)>eps);
                    Matrix.output(x);
             }
             else if(Matrix.check_cheo_troi_hang(A)) {
                    Console.WriteLine("Ma tran cheo troi hang");
                    Matrix x=Matrix.x0(Matrix.dimension(A));
                    Matrix x1=x;
                    Matrix I = Matrix.In(Matrix.dimension(A));
                    Matrix T = Matrix.T(A);
                    Matrix B1=I-T*A;
                    Console.WriteLine("He so co");
                    Console.WriteLine(Matrix.chuan_vocung(B1));
                    int k=0;
                    do{
                        x1= x;
                        x=B1*x+T*B;
                        Matrix.output(x);
                        Console.WriteLine("Lan lap thu"+k);
                        k++;
                }while((Matrix.chuan(B1)/(1-Matrix.chuan(B1)))*Matrix.chuan(x1-x)>eps);
                    Matrix.output(x);
            }else {
                Console.WriteLine("Ma tran khong cheo troi");
            }

            }
        }
}
//while((Matrix.lambda(A)*Matrix.chuan_vocung(B1)/(1-Matrix.chuan_vocung(B1)))*Matrix.chuan_vocung(x1-x)>eps);