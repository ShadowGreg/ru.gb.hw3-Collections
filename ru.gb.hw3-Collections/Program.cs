using System;
using System.Collections.Generic;

class Program
{
    static int HasExit(int startI, int startJ, int[,] labyrinth)
    {
        int exitCount = 0;
        int rows = labyrinth.GetLength(0);
        int cols = labyrinth.GetLength(1);

        // Создаем очередь для хранения позиций, которые нужно исследовать
        Queue<(int, int)> queue = new Queue<(int, int)>();

        // Добавляем начальную позицию в очередь
        queue.Enqueue((startI, startJ));

        while (queue.Count > 0)
        {
            // Извлекаем следующую позицию для исследования
            var (i, j) = queue.Dequeue();

            // Проверяем, является ли текущая позиция допустимым выходом
            if (IsExit(i, j, rows, cols, labyrinth))
                exitCount++;

            // Отмечаем текущую позицию как посещенную
            labyrinth[i, j] = -1;

            // Проверяем соседние ячейки и добавляем в очередь непосещенные
            if (i > 0 && labyrinth[i - 1, j] == 0)
            {
                queue.Enqueue((i - 1, j)); // Вверх
                labyrinth[i - 1, j] = -1; // Отмечаем как посещенную
            }
            if (i < rows - 1 && labyrinth[i + 1, j] == 0)
            {
                queue.Enqueue((i + 1, j)); // Вниз
                labyrinth[i + 1, j] = -1; // Отмечаем как посещенную
            }
            if (j > 0 && labyrinth[i, j - 1] == 0)
            {
                queue.Enqueue((i, j - 1)); // Влево
                labyrinth[i, j - 1] = -1; // Отмечаем как посещенную
            }
            if (j < cols - 1 && labyrinth[i, j + 1] == 0)
            {
                queue.Enqueue((i, j + 1)); // Вправо
                labyrinth[i, j + 1] = -1; // Отмечаем как посещенную
            }
        }

        return exitCount;
    }

    static bool IsExit(int i, int j, int rows, int cols, int[,] labyrinth)
    {
        // Проверяем, находится ли позиция на границе лабиринта
        return i == 0 || i == rows - 1 || j == 0 || j == cols - 1;
    }

    static void Main(string[] args)
    {
        int[,] labyrinth1 = new int[,]
        {
            {1, 1, 1, 1, 1, 1, 1 },
            {1, 0, 0, 0, 0, 0, 1 },
            {1, 0, 1, 1, 1, 0, 1 },
            {0, 0, 0, 0, 1, 0, 0 },
            {1, 1, 0, 0, 1, 1, 1 },
            {1, 1, 1, 0, 1, 1, 1 },
            {1, 1, 1, 0, 1, 1, 1 }
        };

        int startI = 1; // Начальный индекс строки
        int startJ = 1; // Начальный индекс столбца

        int exitCount = HasExit(startI, startJ, labyrinth1);
        Console.WriteLine("Количество выходов: " + exitCount + " ожидаемое количество 3.");
        
        int[,] labyrinth2 = new int[,]
        {
            {1, 1, 1, 1, 1, 1, 1 },
            {1, 0, 0, 0, 0, 0, 1 },
            {1, 0, 1, 1, 1, 0, 1 },
            {0, 0, 0, 0, 1, 0, 0 },
            {1, 1, 0, 0, 1, 0, 1 },
            {1, 1, 1, 0, 1, 0, 1 },
            {1, 1, 1, 0, 1, 0, 1 }
        };
        
        exitCount = HasExit(startI, startJ, labyrinth2);
        Console.WriteLine("Количество выходов: " + exitCount + " ожидаемое количество 4.");
        
        int[,] labyrinth3 = new int[,]
        {
            {1, 1, 1, 1, 1, 1, 1 },
            {1, 0, 0, 0, 0, 0, 1 },
            {1, 0, 1, 1, 1, 0, 1 },
            {0, 0, 0, 0, 1, 0, 1 },
            {1, 1, 0, 0, 1, 1, 1 },
            {1, 1, 1, 0, 1, 1, 1 },
            {1, 1, 1, 0, 1, 1, 1 }
        };
        
        exitCount = HasExit(startI, startJ, labyrinth3);
        Console.WriteLine("Количество выходов: " + exitCount + " ожидаемое количество 2.");
    }
}