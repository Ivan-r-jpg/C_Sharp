// Підключення директиви
using System;

namespace lab._1._6
{
    internal class Program
    {
        static void Main(string[] args) // Головний метод програми
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Встановлення кодування для виводу в консоль

            int count; // Змінна для зберігання кількості членів ряду типу int
            double power, sum = 0; // Змінна для зберігання степеня ряду та суми ряду типу double
            string input; // Змінна для зберігання введеного користувачем рядка типу string

            Console.WriteLine("\t\tОбчислення членів ряду Діріхле");
            Console.WriteLine();

            Console.Write("Введіть кількість членів ряду: ");
            input = Console.ReadLine(); // Зчитування введеного користувачем рядка
            count = Convert.ToInt32(input); // Конвертація введеного рядка в ціле число
            Console.WriteLine();

            Console.Write("Введіть степінь ряду: ");
            input = Console.ReadLine(); // Зчитування введеного користувачем рядка для степеня ряду
            power = Convert.ToDouble(input); // Конвертація введеного рядка в число з плаваючою точкою для степеня ряду
            Console.WriteLine();

            if (count >= 1) // Умовний оператор if, перевірка чи кількість членів ряду є більшою або рівною 1
            {
                for (int i = 1; i <= count; i++) // Оператор циклу for, прохід по всім членам ряду від 1 до count включно
                {

                    Console.WriteLine("Член ряду #{0} = {1:F3}", i, 1.0 / Math.Pow(i, power));
                    sum += 1.0 / Math.Pow(i, power);
                }
                Console.WriteLine("Сума ряду Діріхле до {0} члена = {1:F3}", count, sum);
            }
            else // Інакше
            {
                Console.WriteLine("[ПОМИЛКА] - Кількість членів ряду повинна бути більшою або рівною 1!");
            }
        }
    }
}
