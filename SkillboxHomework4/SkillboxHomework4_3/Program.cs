using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SkillboxHomework4_3
{
    public class LifeSimulation
    {
        private int _heigth;
        private int _width;
        private bool[,] cells;
        public int movesCount;
        Random generator ;

        /// <summary>
        /// Создаем новую игру
        /// </summary>
        /// <param name="Heigth">Высота поля.</param>
        /// <param name="Width">Ширина поля.</param>

        public LifeSimulation(int Heigth, int Width)
        {
            _heigth = Heigth;
            _width = Width;
            cells = new bool[Heigth, Width];
            movesCount = 0;
            generator = new Random();
            GenerateField();
        }

        /// <summary>
        /// Перейти к следующему поколению и вывести результат на консоль.
        /// </summary>
        public void DrawAndGrow()
        {
            DrawGame();
            Grow();
        }

        /// <summary>
        /// Двигаем состояние на одно вперед, по установленным правилам
        /// </summary>

        private void Grow()
        {
            movesCount++;
            if (movesCount % 10 == 0) Pandemia(); //Каждый 10-й ход происходит пандемия
            else
            {
                for (int i = 0; i < _heigth; i++)
                {
                    for (int j = 0; j < _width; j++)
                    {
                        int numOfAliveNeighbors = GetNeighbors(i, j);

                        if (cells[i, j])
                        {
                            if (numOfAliveNeighbors < 1|| numOfAliveNeighbors > 4)
                            {
                                cells[i, j] = false;

                            }

                            if (numOfAliveNeighbors == 1) // если сосед только один, появляется ещё одна бактерия рядом(размножение)
                            {
                                if (j != 0 && cells[i, j - 1] == false)
                                {
                                    cells[i, j - 1] = true;
                                }
                                else
                                {
                                    cells[i, j + 1] = true;
                                }
                            }
                        }
                        else
                        {
                            int number = generator.Next(20);
                            cells[i, j] = ((number == 0) ? true : false); // если клетка пуста - 1/20, что тут появится бактерия при новом ходе.

                        }
                    }
                }
            }
            

        }

        /// <summary>
        /// Смотрим сколько живых соседий вокруг клетки.
        /// </summary>
        /// <param name="x">X-координата клетки.</param>
        /// <param name="y">Y-координата клетки.</param>
        /// <returns>Число живых клеток.</returns>

        private int GetNeighbors(int x, int y)
        {
            int NumOfAliveNeighbors = 0;

            for (int i = x - 1; i < x + 2; i++)
            {
                for (int j = y - 1; j < y + 2; j++)
                {
                    if (!((i < 0 || j < 0) || (i >= _heigth || j >= _width)))
                    {
                        if (cells[i, j] == true) NumOfAliveNeighbors++;
                    }
                }
            }
            return NumOfAliveNeighbors;
        }

        /// <summary>
        /// Нарисовать Игру в консоле
        /// </summary>

        private void DrawGame()
        {
            Console.CursorVisible = false;
            for (int i = 0; i < _heigth; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    Console.Write(cells[i, j] ? "x" : " ");
                    if (j == _width - 1) Console.WriteLine("\r");
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Ход {movesCount}");
            Console.SetCursorPosition(0, Console.WindowTop);

           
            Console.ReadKey();

        }

        /// <summary>
        /// Инициализируем случайными значениями
        /// </summary>

        private void GenerateField()
        {
            
            int number;
            for (int i = 0; i < _heigth; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    number = generator.Next(2);
                    cells[i, j] = ((number == 0) ? false : true);
                }
            }
        }


        /// <summary>
        /// С вероятностью 80% уничтожает целые строки бактерий
        /// </summary>
        private void Pandemia()
        {
            Random generator = new Random();
            int number;
            for (int i = 0; i < _heigth; i++)
            {
                number = generator.Next(5);
                if (number != 0)
                for (int j = 0; j < _width; j++)
                {
                        cells[i, j] = false;
                }
            }
        }
    }

    internal class Program
    {

        // Ограничения игры
        private const int Heigth = 10;
        private const int Width = 50;
        private const uint MaxRuns = 100;

        private static void Main(string[] args)
        {
            int runs = 0;
            LifeSimulation sim = new LifeSimulation(Heigth, Width);

            while (runs++ < MaxRuns)
            {
                sim.DrawAndGrow();
                

                // Дадим пользователю шанс увидеть, что происходит, немного ждем
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
