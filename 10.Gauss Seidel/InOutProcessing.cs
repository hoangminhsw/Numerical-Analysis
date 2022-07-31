using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MATRIX
{
    public class InOutProcessing
    {

        public static bool MatrixInput(out double[,] matrixA, out double[,] matrixB, string fileLocation = @"MatrixInput.txt")
        {
            int iMax = 0, jMax = 0;
            double[,] matrix0 = new double[iMax, jMax];
            Queue<string> s = new Queue<string>(); string _s;
            using StreamReader sr = File.OpenText(fileLocation);
            while ((_s = sr.ReadLine()) != null)
            {
                s.Enqueue(_s.Trim());
                iMax++;
            }
            if (iMax == 0)
            {
                matrixA = matrix0;
                matrixB = matrix0;
                return false;
            }
            Queue<string[]> s_matrix = new Queue<string[]>();
            foreach (string rowRaw in s)
            {
                s_matrix.Enqueue(rowRaw.Split(' '));
            }
            jMax = s_matrix.Peek().Length;
            matrixA = new double[iMax, jMax - 1];
            matrixB = new double[iMax, 1];
            int i = 0;
            int j = 0;
            foreach (string[] row in s_matrix)
            {
                j = 0;
                foreach (string elem in row)
                {
                    double temp;
                    if (!double.TryParse(elem, out temp))
                    {

                        matrixA = matrix0;
                        return false;
                    }
                    if (j < jMax - 1)
                    {
                        matrixA[i, j] = temp;
                    }
                    else
                    {
                        matrixB[i, 0] = temp;
                    }
                    j++;
                }
                i++;
            }
            return true;
        }        
        public static void PrintMatix(double[,] matrix)
        {
            int iMax = matrix.GetLength(0);
            int jMax = matrix.GetLength(1);
            for (int i = 0; i < iMax; i++)
            {
                for (int j = 0; j < jMax; j++)
                {
                    Console.Write("\t" + Math.Round(matrix[i, j], 10));
                }
                Console.WriteLine();
            }
            Console.WriteLine("===================================================================================");
            return;
        }
    }
}
