// Підключення директиви
using System;

namespace lab._1._2
{
    internal class Program
    {
        static void Main(string[] args) // Головний метод програми
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Встановлення кодування для коректного виводу кирилиці в консоль

            double x, c, y, x_min, x_max, dx; // Оголошення змінних для зберігання значень x, c, y, xmin, xmax та dx типу double
            string str; // Оголошення змінної для збереження введеного рядка

            Console.WriteLine("Вираз: y = (c^2 * x^2 + 2)^(1/3) + (ln(x^2 + 1) / 2 * π)");
            Console.WriteLine();
            Console.Write("Введіть c: ");

            str = Console.ReadLine(); // Зчитування введеного рядка з консолі
            c = Convert.ToDouble(str); // Конвертація введеного рядка в тип double і збереження його в змінну c
            Console.WriteLine();

            Console.Write("Введіть x_min: ");
            str = Console.ReadLine(); // Зчитування введеного рядка з консолі
            x_min = Convert.ToDouble(str); // Конвертація введеного рядка в тип double і збереження його в змінну x_min
            Console.WriteLine();

            Console.Write("Введіть x_max: ");
            str = Console.ReadLine(); // Зчитування введеного рядка з консолі
            x_max = Convert.ToDouble(str); // Конвертація введеного рядка в тип double і збереження його в змінну x_max
            Console.WriteLine();

            Console.Write("Введіть крок dx: ");
            str = Console.ReadLine(); // Зчитування введеного рядка з консолі
            dx = Convert.ToDouble(str); // Конвертація введеного рядка в тип double і збереження його в змінну dx
            
            if (x_min < x_max && dx > 0) // Перевірка на коректність введених значень: xmin має бути меншим за xmax, а dx має бути більшим за нуль
            {
                Console.WriteLine();
                for (double i = x_min; i <= x_max; i += dx)
                {
                    x = i;
                    y = Math.Pow((Math.Pow(c, 2) * Math.Pow(x, 2) + 2), 1.0 / 3.0) + (Math.Log(Math.Pow(x, 2) + 1) / (2 * Math.PI)); // Обчислення значення y за заданою формулою
                    Console.WriteLine("x = {0:F3}, y = {1:F3}", x, y);
                }        
            }
            else // Інакше
            {
                Console.WriteLine();
                Console.WriteLine("[ПОМИЛКА] - x_min має бути меншим за x_max, при цьому dx має бути більшим за нуль!");
            }
        }
    }
}
