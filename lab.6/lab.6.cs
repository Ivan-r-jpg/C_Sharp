using System; // Підключення простору імен System

namespace lab._6
{
    internal class Program // Основний клас програми
    {
        Random rand = new Random(); // Створення посилання на об'єкт для генерації випадкових чисел
        void PrintMenu() // Метод для виведення меню на екран
        {
            Console.WriteLine("\n[МЕНЮ]:\n");
            Console.WriteLine("1) Об'єднання двох рядків;");
            Console.WriteLine("2) Вставка одного рядка в інший після вказаного індексу;");
            Console.WriteLine("3) Заміна частини одного рядка на частину іншого рядка;");
            Console.WriteLine("4) Видалення частини рядка починаючи з вказаного індексу;");
            Console.WriteLine("5) Порівняння двох рядків;");
            Console.WriteLine("6) Порівняння частин двох рядків починаючи з вказаних індексів довжиною n символів;");
            Console.WriteLine("7) Пошук першого входження одного рядка в інший;");
            Console.WriteLine("8) Ввести нові рядки;");
            Console.WriteLine("9) Вийти з програми.");
        }

        int ChooseStr(string firstString, string secondString) // Метод для вибору рядка для взаємодії
        {
            while (true)
            {
                Console.Write("\nОберіть рядок для взаємодії:\n");
                Console.WriteLine("\nПерший рядок - {0}", firstString);
                Console.WriteLine("Другий рядок - {0}", secondString);
                Console.Write("\n[УВАГА] - Введіть ваш вибір у форматі 'Перший'/'Другий'/'1' або 'First'/'Second'/'2': ");
                string str = Console.ReadLine();
                switch (str.ToLower()) // Обробка вибору користувача з урахуванням різних варіантів вводу
                {
                    case "перший":
                    case "first":
                    case "1":
                        return 1;

                    case "другий":
                    case "second":
                    case "2":
                        return 2;

                    default:
                        Console.WriteLine("\n[УВАГА] - Невірний вибір рядка!");
                        break;
                }
            }
        }

        string StrInsert(string str1, string str2) // Метод для вставки одного рядка в інший після вказаного індексу
        {
            int index;
            while (true)
            {
                Console.Write("\n[УВАГА] - Напишіть індекс після якого потрібно вставити рядок '{1}' в рядок '{0}': ", str1, str2);
                string str = Console.ReadLine();
                try
                {
                    index = Convert.ToInt32(str);
                    while (index < 0 || index > str1.Length)
                    {
                        Console.WriteLine("\n[УВАГА] - Індекс виходить за межі рядка!");
                        Console.Write("\n[УВАГА] - Напишіть індекс після якого потрібно вставити рядок '{1}' в рядок '{0}': ", str1, str2);
                        str = Console.ReadLine();
                        index = Convert.ToInt32(str);
                    }
                }
                catch (FormatException ex) // Обробка помилки формату вводу
                {
                    Console.WriteLine("\n[ПОМИЛКА] - Помилка формату вводу: {0}", ex.Message);
                    continue; // Пропуск поточної ітерації циклу
                }
                break;
            }
            return str1.Insert(index, str2); 
        }

        string StrReplace(string str1, string str2, out string copyStr1, out string copyStr2) // Метод для заміни частини одного рядка на частину іншого рядка
        {
            int randomIndexStr1 = rand.Next(1, str1.Length);
            int randomIndexStr2 = rand.Next(0, str2.Length);
            copyStr1 = "";
            for (int i = 0; i < randomIndexStr1; i++)
            {
                copyStr1 += str1[i];
            }
            copyStr2 = "";
            for (int i = 0; i < randomIndexStr2; i++)
            {

                copyStr2 += str2[i];
            }
            return str1.Replace(copyStr1, copyStr2);
        }

        string StrRemove(string str, out int randomIndexStr, out int randomCountStr) // Метод для видалення частини рядка починаючи з вказаного індексу
        {

            randomIndexStr = rand.Next(0, str.Length);
            randomCountStr = rand.Next(1, str.Length - randomIndexStr + 1);

            return str.Remove(randomIndexStr, randomCountStr);
        }

        static void Main(string[] args) // Головний метод програми
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Встановлення кодування для виводу в консоль
            Console.InputEncoding = System.Text.Encoding.UTF8; // Встановлення кодування для вводу в консоль

            bool endOfProgram = false; // Змінна-флаг для контролю завершення програми

            Console.Write("[УВАГА] - Введіть перший рядок: ");
            string firstString = Console.ReadLine();
            Console.Write("\n[УВАГА] - Введіть другий рядок: ");
            string secondString = Console.ReadLine(); 

            int numberOfString;

            Program ob = new Program(); // Створення посилання на об'єкт класу Program для виклику методів

            while (!endOfProgram) // Головний цикл програми, який продовжується до тих пір, поки користувач не захоче вийти з програми
            {
                ob.PrintMenu();
                Console.Write("\n[УВАГА] - Введіть ваш вибір: ");
                string userChoice = Console.ReadLine();
            
                switch (userChoice.ToLower()) // Обробка вибору користувача
                {
                    case "1":
                    case "1)":
                    case "перший":
                    case "first":
                        Console.WriteLine("\n[РЕЗУЛЬТАТ] - Об'єднання двох рядків: {0}", String.Concat(firstString, secondString));
                        break;

                    case "2":
                    case "2)":
                    case "другий":
                    case "second":
                        numberOfString = ob.ChooseStr(firstString, secondString);

                        string result;

                        if (numberOfString == 1) // Вставка другого рядка в перший рядок
                        {
                            result = ob.StrInsert(firstString, secondString);
                            Console.WriteLine("\n[РЕЗУЛЬТАТ] - Вставка рядка '{0}' в рядок '{1}': {2}", secondString, firstString, result);
                        }
                        else // Вставка першого рядка в другий рядок
                        {
                            result = ob.StrInsert(secondString, firstString);
                            Console.WriteLine("\n[РЕЗУЛЬТАТ] - Вставка рядка '{0}' в рядок '{1}': {2}", firstString, secondString, result);
                        } 
                        break;

                    case "3":
                    case "3)":
                    case "третій":
                    case "third":
                        numberOfString = ob.ChooseStr(firstString, secondString);
                        string copyStr1; 
                        string copyStr2;
                        if (numberOfString == 1) // Заміна частини першого рядка на частину другого рядка
                        {
                            result = ob.StrReplace(firstString, secondString, out copyStr1, out copyStr2);
                            Console.WriteLine("\n[РЕЗУЛЬТАТ] - Заміна частини першого рядка ('{0}') на частину другого рядка ('{1}'): {2}", 
                                copyStr1, copyStr2, result);
                        }
                        else // Заміна частини другого рядка на частину першого рядка
                        {
                            result = ob.StrReplace(secondString, firstString, out copyStr2, out copyStr1);
                            Console.WriteLine("\n[РЕЗУЛЬТАТ] - Заміна частини другого рядка ('{0}') на частину першого рядка ('{1}'): {2}",
                                copyStr1, copyStr2, result);
                        }
                        break;

                    case "4":
                    case "4)":
                    case "четвертий":
                    case "fourth":
                        numberOfString = ob.ChooseStr(firstString, secondString);

                        int randomIndexStr = 0;
                        int randomCountStr = 0;

                        if (numberOfString == 1) // Видалення частини першого рядка починаючи з випадкового індексу
                        {
                            result = ob.StrRemove(firstString, out randomIndexStr, out randomCountStr);
                            Console.WriteLine("\n[РЕЗУЛЬТАТ] - Видалення {0} символів починаючи з {1} індексу в рядку '{2}': {3}",
                                randomCountStr, randomIndexStr, firstString, result);
                        }
                        else // Видалення частини другого рядка починаючи з випадкового індексу
                        {
                            result = ob.StrRemove(secondString, out randomIndexStr, out randomCountStr);
                            Console.WriteLine("\n[РЕЗУЛЬТАТ] - Видалення {0} символів починаючи з {1} індексу в рядку '{2}': {3}",
                                randomCountStr, randomIndexStr, secondString, result);
                        }
                        break;

                    case "5":
                    case "5)":
                    case "п'ятий":
                    case "fifth":
                        Console.WriteLine("\n[РЕЗУЛЬТАТ] - Порівняння рядка '{0}' з рядком '{1}': {2}", firstString, secondString,
                            firstString.CompareTo(secondString));
                        break;

                    case "6":
                    case "6)":
                    case "шостий":
                    case "sixth":
                        int lengthForCompare;

                        while (true) // Введення довжини порівняння з перевіркою на коректність
                        {
                            Console.Write("\n[УВАГА] - Введіть довжину порівняння: ");
                            try
                            {
                                lengthForCompare = Convert.ToInt32(Console.ReadLine());

                                while ((lengthForCompare > firstString.Length || lengthForCompare > secondString.Length) || lengthForCompare < 0)
                                {
                                    Console.WriteLine("\n[УВАГА] - Довжина порівняння виходить за межі рядків.");
                                    Console.Write("\n[УВАГА] - Введіть довжину порівняння: ");
                                    lengthForCompare = Convert.ToInt32(Console.ReadLine());
                                }
                            }
                            catch (FormatException ex) // Обробка помилки формату вводу
                            {
                                Console.WriteLine("\n[ПОМИЛКА] - Помилка формату вводу: {0}", ex.Message);
                                continue; // Пропуск поточної ітерації циклу
                            }
                            break;
                        }
                        
                        int positionA = ob.rand.Next(0, firstString.Length - lengthForCompare + 1); // Генерація випадкового індексу для першого рядка
                        int positionB = ob.rand.Next(0, secondString.Length - lengthForCompare + 1); // Генерація випадкового індексу для другого рядка

                        Console.WriteLine("\n[РЕЗУЛЬТАТ] - Порівняння частини рядка '{0}' починаючи з {1} індексу з частиною рядка " +
                            "'{2}' починаючи з {3} індексу довжиною {4} символів: {5}",
                            firstString, positionA, secondString, positionB, lengthForCompare,
                            String.Compare(firstString, positionA, secondString, positionB, lengthForCompare));
                        break;

                    case "7":
                    case "7)":
                    case "сьомий":
                    case "seventh":
                        Console.Write("\n[УВАГА] - Введіть рядок для пошуку: ");
                        string str = Console.ReadLine();
                        numberOfString = ob.ChooseStr(firstString, secondString);

                        if (numberOfString == 1) // Пошук першого входження рядка в перший рядок
                        {
                            if(firstString.IndexOf(str) == -1)
                            {
                                Console.WriteLine("\n[УВАГА] - Рядок '{0}' не знайдено в рядку '{1}'!", str, firstString);
                                break;
                            }
                            Console.WriteLine("\n[РЕЗУЛЬТАТ] - Індекс першого входження рядка '{0}' в рядок '{1}': {2}", str, firstString,
                                firstString.IndexOf(str));
                        }
                        else // Пошук першого входження рядка в другий рядок
                        {
                            if (secondString.IndexOf(str) == -1)
                            {
                                Console.WriteLine("\n[УВАГА] - Рядок '{0}' не знайдено в рядку '{1}'!", str, secondString);
                                break;
                            }
                            Console.WriteLine("\n[РЕЗУЛЬТАТ] - Індекс першого входження рядка '{0}' в рядок '{1}': {2}", str, secondString,
                                secondString.IndexOf(str));
                        }
                        break;

                    case "8":
                    case "8)":
                    case "восьмий":
                    case "eighth":
                        Console.Write("\n[УВАГА] - Введіть перший рядок: ");
                        firstString = Console.ReadLine();
                        Console.Write("\n[УВАГА] - Введіть другий рядок: ");
                        secondString = Console.ReadLine();
                        break;

                    case "9":
                    case "9)":
                    case "дев'ятий":
                    case "ninth":
                        endOfProgram = true; // Встановлення флага для завершення програми
                        Console.WriteLine("\n[УВАГА] - Вихід з програми...");
                        break;
                    default: // Обробка невірного вибору користувача
                        Console.WriteLine("\n[УВАГА] - Невірний вибір!\n(Спробуйте ввести ще раз)");
                        break;
                }
            } 
        }
    }
}
