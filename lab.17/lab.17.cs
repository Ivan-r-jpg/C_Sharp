using System; // Підключення простору імен System

namespace lab._17
{
    internal class Program // Основний клас програми
    {

        delegate double Func(double x); // Делегат для функцій, що приймають один аргумент типу double і повертають double
        int IntegerInput(double min, double max, string text) // Метод для валідації вводу цілого числа
        {
            text = text.Trim();
            int number;
            Console.Write("{0} ", text);
            while (true) // Цикл, що триває поки користувач не введе число у правильному форматі 
            {
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                    while (number < min || number > max) // Цикл, що триває поки користувач не введе число, що належить заданому діапазону
                    {
                        if (number < min)
                        {
                            Console.Write("\n[УВАГА] - Ви ввели занадто мале число для цього параметра!\n\n{0} ", text);
                        }
                        else if (number > max)
                        {
                            Console.Write("\n[УВАГА] - Ви ввели занадто велике число для цього параметра!\n\n{0} ", text);
                        }
                        number = Convert.ToInt32(Console.ReadLine());
                    }
                }
                catch (FormatException) // Перехоплення помилки вводу
                {
                    Console.Write("\n[ПОМИЛКА] - Спробуйте ввести ще раз: ");
                    continue;
                }
                return number; // Повернення цілого числа
            }
        }
        double DoubleInput() // Метод для валідації вводу дробового числа 
        {
            double number;
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
        void CalculateParameters(double[] array, Func F1, Func F2, Func F3,out double AD, out double BE, out double CF) // Метод, що обчислює всі параметри для формули
        {
            double s = 0, p = 1, sumF1 = 0, sumF2 = 0, sumF3 = 0; 

            for (int i = 0; i < array.Length; i++) // Цикл, що проходить по всіх елементах масиву і обчислює необхідні суми s та добутки p для формули
            {
                s += array[i];
                p *= array[i];
                sumF1 += array[i] * F1(array[i]);
                sumF2 += array[i] * F2(array[i]);
                sumF3 += array[i] * F3(array[i]);
            }
            // Обчислення параметрів для формули
            AD = (p + s) * sumF1;
            BE = p * sumF2;
            CF = sumF3;
        }

        void ArrayInput(double[] array, string name) // Метод для вводу елементів масиву
        {
            Console.WriteLine("[УВАГА] - Введіть елементи масиву {0}:\n", name);
            for (int i = 0; i < array.Length; i++) 
            {
                Console.Write("{0}[{1}]: ", name, i);
                array[i] = DoubleInput();
            }
        }
        void ArrayOutput(double[] array, string name) // Метод для виводу елементів масиву
        {
            Console.Write("[УВАГА] - Масив {0}: [ ", name);
            for (int i = 0; i < array.Length; i++)
            {
                if (i != array.Length - 1)
                { 
                    Console.Write("{0}, ", array[i]); 
                
                }
                else
                {
                    Console.Write("{0} ]", array[i]);
                }
            }
            Console.WriteLine();
        }
        static void Main(string[] args) // Головний метод програми
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Встановлення кодування для коректного виводу символів

            Program ob = new Program(); // Створення посилання на об'єкт класу Program для виклику його методів

            int n, m;

            // Введення розмірів масивів з валідацією вводу
            n = ob.IntegerInput(1, int.MaxValue, "Введіть кількість елементів масиву z:");
            double[] z = new double[n];
            m = ob.IntegerInput(1, int.MaxValue, "Введіть кількість елементів масиву beta:");
            double[] beta = new double[m];
            Console.WriteLine("");

            // Введення та вивід елементів масивів 
            ob.ArrayInput(z, "z");
            Console.WriteLine("");
            ob.ArrayOutput(z, "z");
            Console.WriteLine("");
            ob.ArrayInput(beta, "beta");
            Console.WriteLine("");
            ob.ArrayOutput(beta, "beta");

            double A = 0, D = 0, B = 0, E = 0, C = 0, F = 0;

            // Обчислення параметрів для формули з використанням відповідних функцій
            ob.CalculateParameters(z, Math.Exp, Math.Cos, Math.Sin, out A, out B, out C);
            ob.CalculateParameters(beta, Math.Sin, Math.Tan, Math.Abs, out D, out E, out F);

            // Обчислення чисельника та знаменника формули
            double numerator = A + (B * Math.Cos(D)) + Math.Sin(C);
            double denominator = D + E + Math.Cos(F);

            if (denominator != 0) // Якщо знаменник не дорівнює нулю
            { 
                double result = numerator / denominator;
                Console.WriteLine("\n[УВАГА] - Результат обчислення: {0:F3}", result);
            }
            else // Якщо знаменник дорівнює нулю, виводиться повідомлення про помилку
            {
                Console.WriteLine("\n[ПОМИЛКА] - Дільник дорівнює нулю, обчислення неможливе!");
            }
            Console.WriteLine("\n[УВАГА] - Натисніть будь - яку клавішу для завершення програми...");
            Console.ReadKey(true); // Очікування натискання будь-якої клавіші для завершення програми
        }
    }
}
