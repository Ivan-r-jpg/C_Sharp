using System; // Підключення простору імен System
using System.IO; // Підключення простору імен System.IO для роботи з файловими потоками

namespace lab._12._2
{

    internal class Program // Основний клас програми
    {
        void OutputMatrix(double[,] arr, int rows, int cols, StreamWriter file) // Метод, що виводить матрицю на екран та записує її у файл
        {
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    Console.Write("{0,4}\t", arr[i, j]);
                    file.Write("{0,4}\t", arr[i, j]);
                }
                Console.WriteLine("");
                file.WriteLine("");
            }
        }
        void ReadMatrix(double[,] matrix, int rows, int cols, StreamReader file) // Метод, що зчитує матрицю з файлу
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    string s = file.ReadLine();
                    matrix[i, j] = Convert.ToDouble(s);
                }
            }
        }
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
        static void Main(string[] args) // Головний метод програми
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Встановлення кодування консолі UTF-8

            StreamReader sr = new StreamReader("C:\\Users\\ivan-\\Desktop\\Visual_Studio\\lab.12.2\\lab.12.2\\MatrixInput.txt"); // Створення об'єкту файлового потоку для читання даних
            StreamWriter sw = new StreamWriter("C:\\Users\\ivan-\\Desktop\\Visual_Studio\\lab.12.2\\lab.12.2\\Result.txt", true); // Створення об'єкту файлового потоку для запису даних

            Program ob = new Program(); // Створення посилання на клас Program

            // Введення рядків та стовпців матриці
            int n = ob.IntegerInput(2, 1000, "Введіть кількість рядків матриці: "); 
            int m = ob.IntegerInput(2, 1000, "Введіть кількість стовпців матриці: ");

            // Оголошення двовимірних масивів
            double[,] arr1 = new double[n, m];
            double[,] arr2 = new double[m, n];
            double[,] result = new double[n, n];

            // Читання матриць з файлу
            ob.ReadMatrix(arr1, n, m, sr);
            ob.ReadMatrix(arr2, m, n, sr);
            Console.WriteLine("\n[УВАГА] - Матриця arr1:\n");
            sw.WriteLine("\n[УВАГА] - Матриця arr1:\n");
            ob.OutputMatrix(arr1, n, m, sw);
            Console.WriteLine("\n[УВАГА] - Матриця arr2:\n");
            sw.WriteLine("\n[УВАГА] - Матриця arr2:\n");
            ob.OutputMatrix(arr2, m, n, sw);

            // Множення матриць та занесення результату в result
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < m; k++)
                    {
                        sum += arr1[i, k] * arr2[k, j];
                    }
                    result[i, j] = sum;
                }
            }
            Console.WriteLine("\n[УВАГА] - Матриця result:\n");
            sw.WriteLine("\n[УВАГА] - Результат множення обох матриць:\n");
            ob.OutputMatrix(result, n, n, sw);
            sw.WriteLine("\n------------------------------------------------\n");

            // Закриття файлів
            sr.Close();
            sw.Close();
        }
    }
}
