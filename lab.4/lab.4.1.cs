using System; // Підключення директиви

namespace lab._4._1
{
    internal class Program
    {
        void output(double[] array, string s) // Метод для виведення масиву на екран
        {
            Console.Write("\n{0} працівників: [", s);
            for (int i = 0; i < array.Length; i++)
            {
                if (i == array.Length - 1) // Умовний оператор if, якщо це останній елемент масиву
                {
                    Console.Write(" {0,8:F3} ]", array[i]);
                }
                else // Інакше
                {
                    Console.Write(" {0,8:F3}; ", array[i]);
                }
            }
            Console.WriteLine();
        }
        static void Main(string[] args) // Головний метод програми
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Встановлення кодування для виведення українських символів

            Program ob = new Program(); // Створення писилання на об'єкт класу Program для виклику методу output
            Random rand = new Random(); // Створення посилання на об'єкт класу Random для генерації випадкових чисел

            // Змінні для зберігання кількості працівників, мінімального та максимального зросту та ваги
            int n; 
            int min_height = 120, max_height = 210;
            int min_weight = 40, max_weight = 150;
            string s; 

            Console.Write("Введіть кількість працівників: ");
            s = Console.ReadLine(); // Зчитування кількості працівників з консолі
            n = Convert.ToInt32(s); // Конвертація введеного рядка в ціле число

            while (true) // Оператор циклу while, перевірка введеної кількості працівників на коректність
            {
                if (n <= 1) // Умовний оператор if, якщо кількість працівників менше або дорівнює 1
                {
                    Console.Write("Кількість працівників повинна бути більше 1. Введіть ще раз: ");
                    s = Console.ReadLine(); // Зчитування кількості працівників з консолі
                    n = Convert.ToInt32(s); // Конвертація введеного рядка в ціле число
                }
                else // Умовний оператор else, якщо кількість працівників більше 1
                {
                    break; // Вихід з циклу, якщо кількість працівників більше 1
                }
            } 
            // Створення масивів для зберігання зросту та ваги працівників
            double[] height = new double[n];
            double[] weight = new double[n];
            
            for (int i = 0; i < height.Length; i++) // Оператор циклу for, заповнення масивів випадковими значеннями з заданого діапазону
            {
                height[i] = min_height + (max_height - min_height) * rand.NextDouble(); // Генерація випадкового зросту працівника в діапазоні від min_height до max_height
                weight[i] = min_weight + (max_weight - min_weight) * rand.NextDouble(); // Генерація випадкової ваги працівника в діапазоні від min_weight до max_weight
            }
            ob.output(height, "Зріст"); // Виклик методу output для виведення зросту працівників на екран
            ob.output(weight, " Вага"); // Виклик методу output для виведення ваги працівників на екран
            Array.Sort(height, weight); // Сортування масиву зросту та відповідного йому масиву ваги за зростом працівників

            Console.WriteLine("\nВідсортовані зріст та вага працівників:");
            for (int i = 0; i < n; i++) // Оператор циклу for, виведення відсортованих зросту та ваги працівників на екран
            {
               Console.WriteLine();
               Console.WriteLine("| {0,8:F3} | {1,8:F3} |", height[i], weight[i]);
            }
        }
    }
}
