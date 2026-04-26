// Підключення директиви
using System;

namespace lab._1._4
{
    internal class Program
    {
        static void Main(string[] args) // Головний метод програми
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Встановлення кодування для коректного виводу кирилиці в консоль

            double r, h, V, S; // Оголошення змінних для радіуса, висоти, об'єму та площі бічної поверхні циліндра
            string input; // Змінна для зберігання введених даних у вигляді рядка
            Console.WriteLine("\t\tОбчислення об'єму та площі бічної поверхні циліндра");
            Console.WriteLine();

            Console.WriteLine("Формула для обчислення об'єму циліндра: V = π * r^2 * h");
            Console.WriteLine("Формула для обчислення площі бічної поверхні циліндра: S = 2 * π * r * h");
            Console.WriteLine();

            Console.Write("Введіть радіус основи циліндра (r): ");
            input = Console.ReadLine(); // Зчитування введеного користувачем рядка з консолі
            r = Convert.ToDouble(input); // Конвертація введеного рядка у тип double для подальших обчислень
            Console.WriteLine();

            Console.Write("Введіть висоту циліндра (h): ");
            input = Console.ReadLine(); // Зчитування введеного користувачем рядка з консолі
            h = Convert.ToDouble(input); // Конвертація введеного рядка у тип double для подальших обчислень
            Console.WriteLine();
            if (r > 0 && h > 0)
            {
                V = Math.PI * Math.Pow(r, 2) * h; // Обчислення об'єму циліндра 
                S = 2 * Math.PI * r * h; // Обчислення площі бічної поверхні циліндра
                Console.WriteLine("\t\tРЕЗУЛЬТАТ");
                Console.WriteLine();
                Console.WriteLine("Об'єм циліндра (V): {0:F2} од. куб.", V);
                Console.WriteLine("Площа бічної поверхні (S): {0:F3} од. кв.", S);
            }
            else
            {
                Console.WriteLine("[ПОМИЛКА] - Радіус та висота повинні бути додатними числами!");
            }
        }
    }
}
