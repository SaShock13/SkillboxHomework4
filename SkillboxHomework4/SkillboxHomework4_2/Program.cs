using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillboxHomework4_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество строк: ");
            int lines = int.Parse(Console.ReadLine());
            Console.Write("Введите количество столбцов: ");
            int columns = int.Parse(Console.ReadLine());
            int[,] matrix1 = new int[lines, columns];
            int[,] matrix2 = new int[lines, columns];
            int[,] matrixSum = new int[lines, columns];
            Random r = new Random();
            int sum = 0;
            Console.WriteLine("Матрица 1: ");
            for (int i = 0; i < lines; i++)
            {

                for (int j = 0; j < columns; j++)
                {
                    matrix1[i, j] = r.Next(-100, 100);
                    matrixSum[i, j] = matrix1[i, j];
                    Console.Write($"{matrix1[i, j],5}");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Матрица 2: ");
            for (int i = 0; i < lines; i++)
            {

                for (int j = 0; j < columns; j++)
                {
                    matrix2[i, j] = r.Next(-100, 100);
                    matrixSum[i, j] += matrix2[i, j];
                    Console.Write($"{matrix2[i, j],5}");
                }
                Console.WriteLine();
            }
            Console.ReadKey();

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Cумма матриц : ");
            for (int i = 0; i < lines; i++)
            {

                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{matrixSum[i, j],5}");
                }
                Console.WriteLine();
            }
        }
    }
}
