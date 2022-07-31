using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace MATRIX
{
    public class Algorithms
    {
        // Giải hệ phương trình
        // Lặp Jacobi
        // Gói cộng, trừ, nhân, chuyển vị ma trận
        public static double[,] Add2Matrix(double[,] matrix1, double[,] matrix2)
        {
            int lNumRow = matrix1.GetLength(0);
            int lNumCol = matrix1.GetLength(1);
            int rNumRow = matrix2.GetLength(0);
            int rNumCol = matrix2.GetLength(1);
            double[,] matrixO = new double[lNumRow, lNumCol];
            if (lNumRow != rNumRow)
            {
                Console.WriteLine("Không thể cộng 2 mai trận");
                return matrixO;
            }
            if (lNumCol != rNumCol)
            {
                Console.WriteLine("Không thể cộng 2 mai trận");
                return matrixO;
            }
            double[,] add = new double[lNumRow, lNumCol];
            for (int i = 0; i < lNumRow; i++)
            {
                for (int j = 0; j < lNumCol; j++)
                {
                    add[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }
            return add;
        }

        public static double[,] Min2Matrix(double[,] matrix1, double[,] matrix2)
        {
            int lNumRow = matrix1.GetLength(0);
            int lNumCol = matrix1.GetLength(1);
            int rNumRow = matrix2.GetLength(0);
            int rNumCol = matrix2.GetLength(1);
            double[,] matrixO = new double[lNumRow, lNumCol];
            if (lNumRow != rNumRow)
            {
                Console.WriteLine("Không thể trừ 2 mai trận");
                return matrixO;
            }
            if (lNumCol != rNumCol)
            {
                Console.WriteLine("Không thể trừ 2 mai trận");
                return matrixO;
            }
            double[,] min = new double[lNumRow, lNumCol];
            for (int i = 0; i < lNumRow; i++)
            {
                for (int j = 0; j < lNumCol; j++)
                {
                    min[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }
            return min;
        }

        public static double[,] Mul2Matrix(double[,] matrix1, double[,] matrix2)
        {
            int lNumRow = matrix1.GetLength(0);
            int lNumCol = matrix1.GetLength(1);
            int rNumRow = matrix2.GetLength(0);
            int rNumCol = matrix2.GetLength(1);
            double[,] matrixO = new double[lNumRow, lNumCol];
            double[,] mul = new double[lNumRow, rNumCol];
            if (lNumCol != rNumRow)
            {
                Console.WriteLine("Không thể nhân 2 mai trận");
                return matrixO;
            }
            for (int i = 0; i < lNumRow; i++)
            {
                for (int j = 0; j < rNumCol; j++)
                {
                    for (int k = 0; k < lNumCol; k++)
                        mul[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
            return mul;
        }

        public static double[,] TranspositionMatrix(double[,] matrix)
        {
            double[,] transpositionMatrix = new double[matrix.GetLength(1), matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    transpositionMatrix[i, j] = matrix[j, i];
                }
            }
            return transpositionMatrix;
        }

        public static double[,] Mul1Matrix_1Number(double[,] matrix, double n)
        {
            double[,] MulMatrix = new double[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    MulMatrix[i, j] = n * matrix[i, j];
                }
            }
            return MulMatrix;
        }

        // Gói kiểm tra tính chéo trội của ma trận
        public static double DominantMatrix(double[,] matrix)
        {
            int n = matrix.GetLength(1);
            int i, j;
            for (i = 0; i < n; i++)
            {
                double sumRow = 0;
                for (j = 0; j < n; j++)
                {
                    sumRow += Math.Abs(matrix[i, j]);
                }
                if (2 * Math.Abs(matrix[i, i]) < sumRow)
                {
                    break;
                }
            }
            if (i == n)
                return 0;
            for (i = 0; i < n; i++)
            {
                double sumCol = 0;
                for (j = 0; j < n; j++)
                {
                    sumCol += Math.Abs(matrix[j, i]);
                }
                if (2*Math.Abs(matrix[i, i]) < sumCol)
                {
                    break;
                }
            }
            if (i == n)
                return 1;
            return -1;
        }

        // Gói tính và trả về giá trị chuẩn vô cùng
        public static double NormInfMatrix(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            double[] sumRow = new double[n];
            double norm_inf = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    sumRow[i] += Math.Abs(matrix[i, j]);
                }
                if (sumRow[i] > norm_inf)
                {
                    norm_inf = sumRow[i];
                }
            }
            return norm_inf;
        }

        // Gói tính và trả về giá trị chuẩn 1
        public static double Norm1Matrix(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            double[] sumCol = new double[n];
            double norm_1 = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                        sumCol[i] += Math.Abs(matrix[j, i]);
                }
                if (sumCol[i] > norm_1)
                {
                    norm_1 = sumCol[i];
                }
            }
            return norm_1;
        }

        public static double NormMatrix(double[,] matrix)
        {
            double[,] matrixA;
            double[,] matrixB;
            string fileLocation = @"MatrixInput.txt";
            InOutProcessing.MatrixInput(out matrixA, out matrixB, fileLocation);
            if (DominantMatrix(matrixA) == 0)
            {
                return NormInfMatrix(matrix);
            }
            if (DominantMatrix(matrixA) == 1)
            {
                return Norm1Matrix(matrix);
            }
            if (DominantMatrix(matrixA) == -1)
            {
                return 0;
            }
            return 0;
        }

        // Gói xác định B, B1, d
        public static double[,] DefinitionB(double[,] A)
        {
            int n = A.GetLength(0);
            double[,] B = new double[n, n];
            
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (i == j)
                        {
                            B[i, j] = 0;
                        }
                        else
                        {
                            B[i, j] = -A[i, j] / A[i, i];
                        }
                    }
                }
            return B;
        }

        public static double[,] DefinitionB1(double[,] A)
        {
            int n = A.GetLength(0);
            double[,] B1 = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        B1[i, j] = 0;
                    }
                    else
                    {
                        B1[j, i] = -A[j, i] / A[i, i];
                    }
                }
            }
            return B1;
        }

        public static double[,] Definitiond(double[,] A, double[,] b)
        {
            int n = A.GetLength(0);
            double[,] d = new double[n, 1];
            for (int i = 0; i < n; i++)
            {
                d[i, 0] = b[i, 0] / A[i, i];
            }
            return d;
        }

        // Gói lặp đơn
        public static double[,] SingleLoop(double[,] B, double[,] d, double eps)
        {
            int n = B.GetLength(0);
            double[,] X = new double[n, 1];
            X = d;
            double[,] Xk = new double[n, 1];
            Xk = Algorithms.Add2Matrix(Algorithms.Mul2Matrix(B,X), d);
            int count = 0;
            while (Algorithms.NormMatrix(Algorithms.Min2Matrix(X, Xk)) > eps)
            {
                Console.WriteLine("Lần lặp thứ {0}: ", count);
                Console.WriteLine("X{0} =", count);
                InOutProcessing.PrintMatix(Xk);
                X = Xk;
                Xk = Algorithms.Add2Matrix(Algorithms.Mul2Matrix(B, X), d);
                count++;
            }
            Console.WriteLine("Số lần lặp là: {0}", count);
            Console.WriteLine("Nghiệm của hệ phương trình là:");
            Console.WriteLine("X =");
            return Xk;
        }


        // Gauss - Seidel
        //Gói biến đổi từ AX + B = 0 về dạng X = CX + D hoặc từ AX + B = 0 về dạng Y = CY + D
        public static double[,] SetAtoC(double[,] A)
        {
            int n = A.GetLength(0);
            double[,] C = new double[n, n];
            if (Algorithms.DominantMatrix(A) == 0)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (i != j)
                        {
                            C[i, j] = -A[i, j] / A[i, i];
                        }
                        else
                        {
                            C[i, j] = 0;
                        }
                    }
                }
            }
            if (Algorithms.DominantMatrix(A) == 1)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (i != j)
                        {
                            C[i, j] = -A[j, i] / A[i, i];
                        }
                        else
                        {
                            C[i, j] = 0;
                        }
                    }
                }
            }
            return C;
        }

        public static double[,] SetBtoD(double[,] A, double[,] B)
        {
            int n = A.GetLength(1);
            double[,] D = new double[n, 1];
            for (int i = 0; i < n; i++)
            {
                D[i, 0] = B[i, 0] / A[i, i];
            }
            return D;
        }

        //Thiết lập công thức sai số, hệ số co
        public static double GetqCoeff(double[,] A, double[,] C)
        {
            int n = C.GetLength(1);
            double[] a = new double[n];
            double[] b = new double[n];
            double sum = 0;
            double q = 0;
            if(Algorithms.DominantMatrix(A) == 0)
            {
                for (int i = 0; i < n; i++)
                {
                    sum = 0;
                    for (int j = i; j < n; j++)
                    {
                        sum += Math.Abs(C[i, j]);
                    }
                    a[i] = sum;
                    sum = 0;
                    for (int k = 0; k < i - 1; k++)
                    {
                        sum += Math.Abs(C[i, k]);
                    }
                    b[i] = 1 - sum;
                    if (a[i] / b[i] > q)
                    {
                        q = a[i] / b[i];
                    }
                }
            }
            if (Algorithms.DominantMatrix(A) == 1)
            {
                for (int i = 0; i < n; i++)
                {
                    sum = 0;
                    for (int j = 1; j < i; j++) 
                    {
                        sum += Math.Abs(C[j, i]);
                    }
                    a[i] = sum;
                    sum = 0;
                    for (int k = i + 1; k < n; k++) 
                    {
                        sum += Math.Abs(C[k, i]);
                    }
                    b[i] = 1 - sum;
                    if (a[i] / b[i] > q)
                    {
                        q = a[i] / b[i];
                    }
                }
            }
            return q;
        }

        public static double GetSCoeff(double[,] A, double[,] C)
        {
            int n = A.GetLength(0);
            double S = 0;
            double sum = 0;
            if (Algorithms.DominantMatrix(A) == 0)
            {
                S = 0;
            }
            if (Algorithms.DominantMatrix(A) == 1)
            {
                for (int i = 0; i < n; i++)
                {
                    sum = 0;
                    for (int j = i + 1; j < n; j++) 
                    {
                        sum += Math.Abs(C[j, i]);
                    }
                    if (sum > S) 
                    {
                        S = sum;
                    }
                }
            }
            return S;
        }

        // Gói lặp Gauss Seidel
        public static double[,] SeidelLoop(double[,] A, double[,] D, double eps)
        {
            int n = A.GetLength(0);
            double[,] X = new double[n, 1];
            double[,] Xk = new double[n, 1];
            double[,] Col = new double[n, n];
            double[,] C_ = Algorithms.SetAtoC(A);
            double[,] C = Algorithms.DefinitionB(A);
            for (int i = 0; i < n; i++)
            {
                Col[i, i] = 1 / A[i, i];
            }
            int count = 0;
            double S = Algorithms.GetSCoeff(A, C_);
            double q = Algorithms.GetqCoeff(A, C_);
            Console.WriteLine("q = {0}", q);
            double[,] C1 = new double[n, n];
            double[,] C2 = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    C1[i, j] = C[i, j];
                }
                for (int k = i; k < n; k++)
                {
                    C2[i, k] = C[i, k];
                }
            }
            do
            {
                Console.WriteLine("Lần lặp thứ {0}:", count);
                Console.WriteLine("X{0} =", count);
                InOutProcessing.PrintMatix(X);
                count++;
                for (int i = 0; i < n; i++)
                {
                    Xk[i, 0] = X[i, 0];
                }
                X = Algorithms.Add2Matrix(Algorithms.Add2Matrix(Algorithms.Mul2Matrix(C1, X), Algorithms.Mul2Matrix(C2, Xk)), D);
            }
            while (q * Algorithms.NormMatrix(Algorithms.Min2Matrix(X, Xk)) > (eps * (1 - q) * (1 - S)));
            Console.WriteLine("Số lần lặp là: {0}", count);
            Console.WriteLine("Nghiệm của hệ phương trình là:");
            Console.WriteLine("X =");
            InOutProcessing.PrintMatix(X);
            return X;
        }





    }
}
