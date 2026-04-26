// Підключення директиви
using System;

namespace lab._1._1 
{
    internal class Program
    {
        static void Main(string[] args) // Головний метод програми
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Встановлення кодування для коректного виводу кирилиці в консоль

            double c, a, x, y; // Оголошення змінних для збереження значень c, a, x та y типу double
            string str; // Оголошення змінної для збереження введеного рядка

            Console.WriteLine("Вираз: y = ((c * x) - a)^(1/3) + (ln(x) / sin(π/3 + x))");
            Console.WriteLine();

            Console.Write("Введіть значення с = ");
            str = Console.ReadLine(); // Зчитування введеного рядка з консолі
            c = Convert.ToDouble(str); // Конвертація введеного рядка в тип double і збереження його в змінну c
            Console.WriteLine();

            Console.Write("Введіть значення a = ");
            str = Console.ReadLine(); // Зчитування введеного рядка з консолі
            a = Convert.ToDouble(str); // Конвертація введеного рядка в тип double і збереження його в змінну a
            Console.WriteLine();

            Console.Write("Введіть значення x = ");
            str = Console.ReadLine(); // Зчитування введеного рядка з консолі
            x = Convert.ToDouble(str); // Конвертація введеного рядка в тип double і збереження його в змінну x

            if (((c*x)-a)>0 && x>0 && Math.Sin((Math.PI/3)+x)!=0) // Перевірка ОДЗ
            {
                y = Math.Pow(((c * x) - a), 1.0 / 3.0) + (Math.Log(x) / (2 * Math.Sin((Math.PI / 3) + x))); // Обчислення значення y за заданою формулою
                Console.WriteLine();
                Console.WriteLine("Значення y = {0:F3}", y);
            }
            else // Якщо ОДЗ не виконується, виводиться повідомлення про помилку
            {
                Console.WriteLine();
                Console.WriteLine("[ПОМИЛКА] - Введіть інші значення!");
            }
        }
    }
}
