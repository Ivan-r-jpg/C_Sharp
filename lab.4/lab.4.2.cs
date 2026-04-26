using System; // Підключення дириктеви

namespace lab._4._2
{
    internal class Program
    {
        static void Main(string[] args) // Головний метод програми
        { 
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Встановлення кодування виводу консолі на UTF-8 для підтримки українських символів
            Random rand = new Random(); // Створення посилання на об'єкт класу Random для генерації випадкових чисел
            int n;
            string s, ar = "Площа", pr = "Ціна";
            double min_price = 10000.0, max_price = 1000000.0;

            Console.Write("Введіть кількість будинків: ");
            s = Console.ReadLine(); // Зчитування кількості будинків з консолі
            n = Convert.ToInt32(s); // Конвертація введеного рядка в ціле число

            while (true) // Оператор циклу while, який буде виконуватися, поки не буде введено правильну кількість будинків
            {
                if (n <= 1) // Умовний оператор if, якщо кількість будинків менше або дорівнює 1
                {
                    Console.Write("Кількість будинків повинна бути більше 1. Введіть ще раз: ");
                    s = Console.ReadLine(); // Зчитування кількості будинків з консолі
                    n = Convert.ToInt32(s); // Конвертація введеного рядка в ціле число
                }
                else // Умовний оператор else, якщо кількість будинків більше 1
                {
                    break; // Вихід з циклу, якщо кількість будинків більше 1
                }
            }
            // Створення масивів для зберігання площі та ціни будинків
            int[] area = new int[n];
            double[] price = new double[n];
            for (int i = 0; i < n; i++) // Оператор циклу for, заповнення масивів випадковими значеннями з заданого діапазону
            {
                area[i] = rand.Next(2, 150); // Генерація випадкової площі будинка в діапазоні від 150 до 200 м^2
                price[i] = min_price + (max_price - min_price) * rand.NextDouble(); // Генерація випадкової ціни будинка в діапазоні від 10000 до 1000000 доларів
            }
            Console.WriteLine("\n|-------------|------------|");
            Console.WriteLine("| {0,8}    | {1,8}   |", ar, pr);
            Console.WriteLine("|-------------|------------|");
            for (int i = 0; i < n; i++) // Оператор циклу for, виведення відсортованих площі та ціни будинків на екран
            {
                if (price[i] < 100000.0)
                { 
                    Console.WriteLine("| {0,8}м^2 | {1,8:F2}$  |", area[i], price[i]);
                    Console.WriteLine("|-------------|------------|");
                }
                else
                {
                    Console.WriteLine("| {0,8}м^2 | {1,8:F2}$ |", area[i], price[i]);
                    Console.WriteLine("|-------------|------------|");
                }
            }
            Array.Sort(area, price); // Сортування масиву площі та відповідного йому масиву за ціною будинків

            Console.WriteLine("\nВідсортовані площа та ціна будинків:");
            Console.WriteLine("\n|-------------|------------|");
            Console.WriteLine("| {0,8}    | {1,8}   |", ar, pr);
            Console.WriteLine("|-------------|------------|");
            for (int i = 0; i < n; i++) // Оператор циклу for, виведення відсортованих площі та ціни будинків на екран
            {
                if (price[i] < 100000.0)
                {
                    Console.WriteLine("| {0,8}м^2 | {1,8:F2}$  |", area[i], price[i]);
                    Console.WriteLine("|-------------|------------|");
                }
                else
                {
                    Console.WriteLine("| {0,8}м^2 | {1,8:F2}$ |", area[i], price[i]);
                    Console.WriteLine("|-------------|------------|");
                }
            }
        }
    }
}
    

