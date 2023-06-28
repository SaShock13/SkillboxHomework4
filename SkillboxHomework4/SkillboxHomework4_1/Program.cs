using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillboxHomework4_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Число строк : ");
            int lines = int.Parse(Console.ReadLine());
            Console.Write("Число столбцов: ");
            int columns = int.Parse(Console.ReadLine());
            int[,] matrix = new int[lines, columns];
            Random randomizer = new Random();
            int sum = 0;
            Console.WriteLine("Матрица: ");
            for (int i = 0; i < lines; i++)
            {

                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = randomizer.Next(10001);
                    sum += matrix[i, j];
                    Console.Write($"{matrix[i, j],8}");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Сумма элементов матрицы : {sum}");
        }
    }
}
