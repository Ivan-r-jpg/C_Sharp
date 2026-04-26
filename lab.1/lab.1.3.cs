// Підключення директиви
using System;

namespace lab._1._3
{
    internal class Program
    {
        static void Main(string[] args) // Головний метод програми
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Встановлення кодування для коректного виводу кирилиці в консоль

            double k, a, x, y, x_min, x_max, dx; // Оголошення змінних для зберігання значень k, a, x, y, xmin, xmax та dx типу double
            string str; // Оголошення змінної для збереження введеного рядка

            Console.WriteLine("Вираз: y = (cos(a * x))^(1/3) + (k * cos(a * x)) / ln(a * x)");
            Console.WriteLine();

            Console.Write("Введіть значення k: ");
            str = Console.ReadLine(); // Зчитування введеного рядка з консолі
            k = Convert.ToDouble(str); // Конвертація рядка str у тип double та збереження результату в змінну k
            Console.WriteLine();

            Console.Write("Введіть значення a: ");
            str = Console.ReadLine(); // Зчитування введеного рядка з консолі
            a = Convert.ToDouble(str); // Конвертація рядка str у тип double та збереження результату в змінну a
            Console.WriteLine();

            Console.Write("Введіть значення x_min: ");
            str = Console.ReadLine(); // Зчитування введеного рядка з консолі
            x_min = Convert.ToDouble(str); // Конвертація рядка str у тип double та збереження результату в змінну xmin
            Console.WriteLine();

            Console.Write("Введіть значення x_max: ");
            str = Console.ReadLine(); // Зчитування введеного рядка з консолі
            x_max = Convert.ToDouble(str); // Конвертація рядка str у тип double та збереження результату в змінну xmax
            Console.WriteLine();

            Console.Write("Введіть крок dx: ");
            str = Console.ReadLine(); // Зчитування введеного рядка з консолі
            dx = Convert.ToDouble(str); // Конвертація рядка str у тип double та збереження результату в змінну dx
            
            if (x_min < x_max && dx > 0) // Перевірка умови, що xmin має бути меншим за xmax, а dx має бути більшим за нуль
            {
                Console.WriteLine();

                for (double i = x_min; i <= x_max; i += dx) // Цикл, який ітерується від xmin до xmax з кроком dx, зберігаючи поточне значення в змінну i
                {

                    x = i;

                    if (Math.Cos(a * x) >= 0 && a * x > 0 && Math.Log(a * x) != 0) // Перевірка ОДЗ
                    {
                        y = (Math.Pow(Math.Cos(a * x), 1.0 / 3.0)) + ((k * Math.Cos(a * x)) / (Math.Log(a * x))); // Обчислення значення y за заданою формулою
                        Console.WriteLine("x = {0:F3}, y = {1:F3}", x, y);
                    }
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
