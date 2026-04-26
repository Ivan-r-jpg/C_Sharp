using System; // Підключення простору імен System для використання базових класів та методів

namespace lab._2._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Встановлення кодування для виводу в консолів символів кирилиці
            double z, x; // Оголошення змінних типу double для зберігання результату (z) та вхідного значення (x)
            string variant, s; // Оголошення змінних типу string для зберігання вибору формули (variant) та введеного значення x у вигляді рядка (s)
            Console.WriteLine("Дана формула: z = f(x)\nВведіть потрібний варіант формули:\n" +
                "A, a - z = tg(x)^(1/2)\nB, b - z = 1 / tg(x)\nC, c - z = ln(tg(x))");
            Console.Write("Введіть варіант формули: ");
            variant = Console.ReadLine(); // Зчитування варіанту формули від користувача
            Console.Write("Введіть значення x: ");
            s = Console.ReadLine(); // Зчитування значення x від користувача у вигляді рядка
            x = Convert.ToDouble(s); // Конвертація рядка в число з плаваючою точкою (double) для подальших обчислень

            switch (variant) // Використання оператора switch для вибору формули на основі введеного варіанту
            {
                case "A":
                case "a":
                    Console.WriteLine("Ви вибрали формулу: z = tg(x)^(1/2)");
                    if(Math.Tan(x) >= 0) // Перевірка ОДЗ
                    {
                        z = Math.Sqrt(Math.Tan(x));
                        Console.WriteLine("Результат: z = {0:F3} при x = {1}", z, x);
                    }
                    else
                    {
                        Console.WriteLine("[ПОМИЛКА] - tg(x) має бути невід'ємним числом для обчислення квадратного кореня!");
                    }      
                    break;
                case "B":
                case "b": 
                    Console.WriteLine("Ви вибрали формулу: z = 1 / tg(x)");
                    if (Math.Tan(x) != 0) // Перевірка ОДЗ
                    {
                        z = 1.0 / Math.Tan(x);
                        Console.WriteLine("Результат: z = {0:F3} при x = {1}", z, x);
                    }
                    else
                    {
                        Console.WriteLine("[ПОМИЛКА] - Знаменник дробу не може дорівнювати нулю!");
                    }
                    break;
                case "C":
                case "c":
                    Console.WriteLine("Ви вибрали формулу: z = ln(tg(x))");
                    if (Math.Tan(x) > 0) // Перевірка ОДЗ
                    {
                        z = Math.Log(Math.Tan(x));
                        Console.WriteLine("Результат: z = {0:F3} при x = {1}", z, x);
                    }
                    else
                    {
                        Console.WriteLine("[ПОМИЛКА] - tg(x) має бути більше нуля!");
                    }
                    break;
                default: // Якщо введений варіант не відповідає жодному з випадків, виводиться повідомлення про помилку
                    Console.WriteLine("[ПОМИЛКА] - Невірний варіант формули!");
                    break;
            }

        }
    }
}
