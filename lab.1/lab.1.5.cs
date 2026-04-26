// Підключення директиви
using System;

namespace lab._1._5
{
    internal class Program
    {
        static void Main(string[] args) // Головний метод програми
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Встановлення кодування для виводу в консоль

            double x, fx; // Оголошення змінних для зберігання значення x та результату функції f(x)
            string input; // Оголошення змінної для зберігання введеного користувачем рядка

            Console.WriteLine("Задана функція виду:\n\nЯкщо x > 0 -> f(x) = x^3 - 2x\nЯкщо x <= 0 -> f(x) = cos(x) + 5");
            Console.WriteLine();

            Console.Write("Введіть значення x: ");
            input = Console.ReadLine(); // Зчитування введеного користувачем рядка
            x = Convert.ToDouble(input); // Конвертація введеного рядка в тип double
            Console.WriteLine();

            if (x > 0) // Умовний оператор if, перевірка чи x більше нуля
            {
                fx = Math.Pow(x, 3) - 2 * x; 
                Console.WriteLine("f({0:F3}) -> ({0:F3})^3 - 2 * {0:F3} = {1:F3}", x, fx);

            }
            else // Інакше
            {
                fx = Math.Cos(x) + 5;
                Console.WriteLine("f({0:F3}) -> cos({0:F3}) + 5 = {1:F3}", x, fx);
            }
        }
    }
}
