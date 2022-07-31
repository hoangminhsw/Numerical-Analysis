using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MATRIX
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            double[,] A;
            string fileLocation = @"MatrixInput.txt";
            double[,] matrixb; 
            InOutProcessing.MatrixInput(out A, out matrixb, fileLocation);
            double[,] B = matrixb;
            if (Algorithms.DominantMatrix(A) == -1)
            {
                Console.WriteLine("Ma trận A không chéo trội");
                return;
            }
            Console.Write("Nhập eps: ");
            double eps1 = Convert.ToDouble(Console.ReadLine());
            double[,] D = Algorithms.SetBtoD(A, B);
            if (Algorithms.DominantMatrix(A) == 0)
            {
                Console.WriteLine("A là ma trận chéo trội hàng");
                Algorithms.SeidelLoop(A, D, eps1);
            }
            if (Algorithms.DominantMatrix(A) == 1)
            {
                Console.WriteLine("A là ma trận chéo trội cột");
                Algorithms.SeidelLoop(A, D, eps1);
            }
            Console.ReadKey();
        }
    }
}
