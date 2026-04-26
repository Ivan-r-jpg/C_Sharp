using System; // Підключення простору імен System для використання базових класів та методів

namespace lab._2._1 
{
    internal class Program
    {
        static void Main(string[] args) // Головний метод, точка входу в програму
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Встановлення кодування для виводу в консолів символів кирилиці
            double z, x; // Оголошення змінних типу double для зберігання результату (z) та вхідного значення (x)
            string variant, s; // Оголошення змінних типу string для зберігання вибору формули (variant) та введеного значення x у вигляді рядка (s)
            Console.WriteLine("Дана формула: z = f(x)\nВведіть потрібний варіант формули:\n" +
                "1, first, First, FIRST - z = sin(x)^2\n2, second, Second, SECOND - z = log(x)^2\n3, third, Third, THIRD - z = 1 / cos(x^3)");
            Console.Write("Введіть варіант формули: ");
            variant = Console.ReadLine(); // Зчитування варіанту формули від користувача
            Console.Write("Введіть значення x: ");
            s = Console.ReadLine(); // Зчитування значення x від користувача у вигляді рядка
            x = Convert.ToDouble(s); // Конвертація рядка в число з плаваючою точкою (double) для подальших обчислень

            switch (variant) // Використання оператора switch для вибору формули на основі введеного варіанту
            {
                case "1":
                case "first":
                case "First":
                case "FIRST":
                    Console.WriteLine("Ви вибрали формулу: z = sin(x)^2");
                    z = Math.Pow(Math.Sin(x), 2);
                    Console.WriteLine("Результат: z = {0:F3} при x = {1}", z, x);
                    break; 
                case "2":
                case "second":
                case "Second":
                case "SECOND":
                    Console.WriteLine("Ви вибрали формулу: z = log(x)^2");
                    if (x > 0) // Перевірка ОДЗ
                    {
                        z = Math.Pow(Math.Log(x, 2), 2);
                        Console.WriteLine("Результат: z = {0:F3} при x = {1}", z, x);
                    }
                    else
                    {
                        Console.WriteLine("[ПОМИЛКА] - x має бути додатнім числом для обчислення логарифма!");
                    }
                    break;
                case "3":
                case "third":
                case "Third":
                case "THIRD":
                    Console.WriteLine("Ви вибрали формулу: z = 1 / cos(x^3)");
                    if (Math.Cos(Math.Pow(x, 3)) != 0) // Перевірка ОДЗ
                    {
                        z = 1.0 / Math.Cos(Math.Pow(x, 3));
                        Console.WriteLine("Результат: z = {0:F3} при x = {1}", z, x);
                    }
                    else
                    {
                        Console.WriteLine("[ПОМИЛКА] - cos(x^3) не повинно бути нулем для обчислення!");
                    }
                    break;
                default: // Якщо введений варіант не відповідає жодному з випадків, виводиться повідомлення про помилку
                    Console.WriteLine("[ПОМИЛКА] - Невірний варіант формули!");
                    break;
            }
        }
    }
}
