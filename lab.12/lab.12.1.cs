using System; // Підключення простору імен System
using System.IO; // Підключення простору імен System.IO для роботи з файловими потоками

namespace lab._12._1
{
    internal class Program // Основний клас програми
    {
        double DoubleInput(string text) // Метод для валідації вводу числа з плаваючою комою
        {
            text = text.Trim();
            double number;
            Console.Write("{0} ", text);
            while (true) // Цикл, що триває поки користувач не введе число у правильному форматі 
            {
                try
                {
                    number = Convert.ToDouble(Console.ReadLine());  
                }
                catch (FormatException) // Перехоплення помилки вводу
                {
                    Console.Write("\n[ПОМИЛКА] - Спробуйте ввести ще раз: ");
                    continue;
                }
                return number; // Повернення числа
            }
        }
        static void Main(string[] args) // Головний метод програми
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Встановлення кодування UTF-8
            double xMin, xMax, dx, k; // Оголошення змінних для збереження зчитуваних даних
            StreamReader sr = new StreamReader("C:\\Users\\ivan-\\Desktop\\Visual_Studio\\lab.12.1\\lab.12.1\\FileInput.txt"); // Створення об'єкту файлового потоку для читання даних
            StreamWriter sw = new StreamWriter("C:\\Users\\ivan-\\Desktop\\Visual_Studio\\lab.12.1\\lab.12.1\\FileOutput.txt", true); // Створення об'єкту файлового потоку для занесення даних
            Console.WriteLine("Дано функцію: z = ((1 / tg(k * x)^1/3)) + cos(k * x) / ln(sin(k * x))");
            Console.WriteLine();
            Program ob = new Program(); // Створення посилання на клас Program
            k = ob.DoubleInput("\nВведіть значення k:");
            
            string s; // Оголошення посередника

            // Читання з файлу FileInput.txt
            s = sr.ReadLine();
            xMin = Convert.ToDouble(s);
            s = sr.ReadLine();
            dx = Convert.ToDouble(s);
            s = sr.ReadLine();
            xMax = Convert.ToDouble(s);

            if (xMin > xMax && dx > 0) // Перевірка, чи зчитанні дані коректні
            {
                Console.WriteLine("\n[ПОМИЛКА] - Зчитане мінімальне значення з файлу більше за максимальне!");
                return;
            }
            else if (xMax > xMin && dx < 0) // Якщо ж ні, то програма виводить відповідне повідомлення і завершує роботу
            {
                Console.WriteLine("\n[ПОМИЛКА] - Задано від'ємний крок при тому, що мінімальне значення менше за максимальне!");
                return;
            }
            else // Вивід на екран повідомлення про успішне зчитування даних
            {
                Console.WriteLine("\n[УВАГА] - Дані з файлу успішно зчитано!");
            }


            sw.WriteLine("\nk = {0}\nMin: {1}\nMax: {2}\ndx = {3}", k, xMin, xMax, dx); // Запис інформації у файл FileOutput.txt
            for (double x = xMin; x <= xMax; x+=dx)
            {
                if (Math.Tan(k * x) != 0 && Math.Sin(k * x) > 0 && Math.Log(Math.Sin(k * x)) != 0) // Перевірка ОДЗ
                {
                    double z = Math.Sign(1.0 / Math.Tan(k * x)) * Math.Pow(Math.Abs(1.0 / Math.Tan(k * x)), 1.0 / 3.0) + ((Math.Cos(k * x)) / Math.Log(Math.Sin(k * x)));
                    Console.WriteLine("\n[УВАГА] - Результат функції: {0:F3}\nПри x = {1}", z, x);
                    sw.WriteLine("\n[УВАГА] - Результат функції: {0:F3}\nПри x = {1}", z, x);
                }
                else
                {
                    Console.WriteLine("\n[УВАГА] - Помилка в обчисленні при х = {0}!", x);
                    sw.WriteLine("\n[УВАГА] - Помилка в обчисленні при х = {0}!", x);
                }
            }

            sr.Close(); // Закриття файлу FileInput.txt
            sw.Close(); // Закриття файлу FileOutput.txt
        }
    }
}
