using System; // Підключення простору імен System для використання базових класів та методів

namespace lab._2._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Встановлення кодування для виводу в консолів символів кирилиці
            double z, x, a; // Оголошення змінних типу double для зберігання результату (z) та вхідного значення (x), (a)
            string variant, s; // Оголошення змінних типу string для зберігання вибору формули (variant) та введеного значення x у вигляді рядка (s)
            Console.WriteLine("Дана формула: z = f(x)\nВведіть потрібний варіант формули:\n" +
                "1, alfa - z = (a + sin(x))^(1/2)\n2, beta - z = (sin(a * x))^(1/2)\n3, gamma - z = ln(a - x)");
            Console.Write("Введіть варіант формули: ");
            variant = Console.ReadLine(); // Зчитування варіанту формули від користувача
            Console.Write("Введіть значення x: ");
            s = Console.ReadLine(); // Зчитування значення x від користувача у вигляді рядка
            x = Convert.ToDouble(s); // Конвертація рядка в число з плаваючою точкою (double) для подальших обчислень
            Console.Write("Введіть значення a: ");
            s = Console.ReadLine(); // Зчитування значення a від користувача у вигляді рядка
            a = Convert.ToDouble(s);

            switch (variant) // Використання оператора switch для вибору формули на основі введеного варіанту
            {
                case "1":
                case "alfa":
                    Console.WriteLine("Ви вибрали формулу: z = (a + sin(x))^(1/2)");
                    if ((a + Math.Sin(x)) >= 0) // Перевірка ОДЗ
                    {
                        z = Math.Sqrt((a + Math.Sin(x)));
                        Console.WriteLine("Результат: z = {0:F3} при x = {1}, a = {2}", z, x, a);
                    }
                    else
                    {
                        Console.WriteLine("[ПОМИЛКА] - Вираз a + sin(x) має бути невід'ємним числом для обчислення квадратного кореня!");
                    }
                    break;
                case "2":
                case "beta":
                    Console.WriteLine("Ви вибрали формулу: z = (sin(a * x))^(1/2)");
                    if (Math.Sin(a * x) >= 0) // Перевірка ОДЗ
                    {
                        z = Math.Sqrt(Math.Sin(a * x));
                        Console.WriteLine("Результат: z = {0:F3} при x = {1}, a = {2}", z, x, a);
                    }
                    else
                    {
                        Console.WriteLine("[ПОМИЛКА] - Вираз sin(a * x) має бути невід'ємним числом для обчислення квадратного кореня!");
                    }
                    break;
                case "3":
                case "gamma":
                    Console.WriteLine("Ви вибрали формулу: z = ln(a - x)");
                    if (a - x > 0) // Перевірка ОДЗ
                    {
                        z = Math.Log(a - x);
                        Console.WriteLine("Результат: z = {0:F3} при x = {1}, a = {2}", z, x, a);
                    }
                    else
                    {
                        Console.WriteLine("[ПОМИЛКА] - Вираз a - x має бути більше нуля!");
                    }
                    break;
                default: // Якщо введений варіант не відповідає жодному з випадків, виводиться повідомлення про помилку
                    Console.WriteLine("[ПОМИЛКА] - Невірний варіант формули!");
                    break;
            }

        }
    }
}
