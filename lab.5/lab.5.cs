using System; // Підлюкчення дириктиви для використання класу Console та інших базових функцій

namespace lab._5
{
    class Wine // Визначення класу Wine для представлення інформації про вино
    {
        // Поля класу для зберігання інформації про вино
        string brand;
        string place;
        double strong;
        double volume;
        string color;
        public void Input() // Метод для введення інформації про вино з консолі
        {
            Console.WriteLine("");
            Console.Write("Введіть марку вина: ");
            brand = Console.ReadLine();

            Console.Write("Введіть місце розливу: ");
            place = Console.ReadLine();

            while (true) // Оператор циклу while, нескінченний цикл, доки користувач не введе правильне значення для міцності вина
            {
                // Блок try-catch для обробки помилок формату вводу при конвертації рядка в число
                try
                {
                    Console.Write("Введіть міцність вина: ");
                    strong = Convert.ToDouble(Console.ReadLine());

                    if (strong <= 0) // Умовний оператор if, перевірка на те, чи є введене значення міцності додатнім числом
                    {
                        Console.Write("\n[УВАГА] - Міцність повинна бути додатнім числом!\nСпробуйте ввести ще раз...\n");
                        continue; // Пропуск поточної ітерації циклу
                    }
                    break; // Вихід з циклу, якщо введене значення міцності є правильним
                }
                catch (FormatException ex) // Блок catch для обробки виключення FormatException, яке виникає при неправильному форматі вводу
                {
                    Console.WriteLine("\n[ПОМИЛКА] - Помилка формату вводу: {0}\n", ex.Message);
                    continue; // Пропуск поточної ітерації циклу
                }
            }
            while (true) // Оператор циклу while, нескінченний цикл, доки користувач не введе правильне значення для ємності пляшки
            {
                // Блок try-catch для обробки помилок формату вводу при конвертації рядка в число
                try
                {
                    Console.Write("Введіть ємність пляшки: ");
                    volume = Convert.ToDouble(Console.ReadLine());

                    if (volume <= 0) // Умовний оператор if, перевірка на те, чи є введене значення ємності додатнім числом
                    {
                        Console.WriteLine("");
                        Console.Write("[УВАГА] - Ємність повинна бути додатнім числом!\nСпробуйте ввести ще раз...\n");
                        continue; // Пропуск поточної ітерації циклу
                    }
                    break; // Вихід з циклу, якщо введене значення ємності є правильним
                }
                catch (FormatException ex) // Блок catch для обробки виключення FormatException, яке виникає при неправильному форматі вводу
                {    
                    Console.WriteLine("\n[ПОМИЛКА] - Помилка формату вводу: {0}\n", ex.Message);
                    continue; // Пропуск поточної ітерації циклу
                }
            }
            Console.Write("Введіть колір: ");
            color = Console.ReadLine();
        }
        public void Output() // Метод для виведення інформації про вино на консоль
        {
            Console.WriteLine("Марка вина: {0}", brand);
            Console.WriteLine("Місце розливу: {0}", place);
            Console.WriteLine("Міцність вина: {0}%", strong);
            Console.WriteLine("Ємність пляшки: {0} л", volume);
            Console.WriteLine("Колір: {0}", color);
        }
        public void Analize(ref Wine[] array, ref string place_formal, ref string color_formal) // Метод для аналізу масиву вин за заданими критеріями місця розливу та кольору
        {
            bool found = false; // Оголошення та ініціалізація логічної змінної для відстеження, чи було знайдено відповідні вина

            Console.WriteLine("\nВина, які розливалися в {0}:\n", place_formal);
            for (int i = 0; i < array.Length; i++) // Оператор циклу for, перебір масиву вин
            { 
                if (array[i].place.ToLower() == place_formal.ToLower()) // Умовний оператор if, перевірка, чи відповідає місце розливу та колір вина заданим критеріям
                {
                    Console.WriteLine("\nВино №{0}:\n", i + 1);
                    array[i].Output(); // Виклик методу Output для виведення інформації про вино, яке відповідає заданим критеріям
                    found = true; // Встановлення логічної змінної found в true, якщо знайдено відповідне вино
                }
            }
            if (!found) // Умовний оператор if, перевірка, чи не було знайдено відповідних вин
            {
                Console.WriteLine("\n[УВАГА] - Вина, які відповідають заданим критеріям, не знайдено!\n");
            }
            found = false;
            Console.WriteLine("\nВина, які мають колір {0}:\n", color_formal);
            for (int i =0; i < array.Length; i++)
            {
                if(array[i].color.ToLower() == color_formal.ToLower())
                {
                    Console.WriteLine("\nВино №{0}:\n", i + 1);
                    array[i].Output(); // Виклик методу Output для виведення інформації про вино, яке відповідає заданим критеріям
                    found = true; // Встановлення логічної змінної found в true, якщо знайдено відповідне вино
                }
            }
            if (!found) // Умовний оператор if, перевірка, чи не було знайдено відповідних вин
            {
                Console.WriteLine("\n[УВАГА] - Вина, які відповідають заданим критеріям, не знайдено!\n");
            }
        }
        internal class Program
        {
            static void Main(string[] args) // Головний метод програми
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8; // Встановлення кодування виводу консолі на UTF-8 для підтримки українських символів

                int n, choice;
      
                while (true) // Оператор циклу while, нескінченний цикл, доки користувач не введе правильне значення для кількості винних напоїв
                {
                    Console.Write("Введіть кількість винних напоїв: ");
                    try
                    {
                        n = Convert.ToInt32(Console.ReadLine());

                        while (n <= 0) // Оператор циклу while, нескінченний цикл, доки користувач не введе правильне значення для кількості винних напоїв
                        {
                            Console.Write("\n[УВАГА] - Кількість винних напоїв менше нуля!\nВведіть ще раз...\n\n");
                            Console.Write("Введіть кількість винних напоїв: ");
                            n = Convert.ToInt32(Console.ReadLine());
                        }
                        break; // Вихід з циклу, якщо введене значення для кількості винних напоїв є правильним
                    }
                    catch (FormatException ex) // Блок catch для обробки виключення FormatException, яке виникає при неправильному форматі вводу
                    {
                        Console.WriteLine("\n[ПОМИЛКА] - Помилка формату вводу: {0}\n", ex.Message);
                        continue; // Пропуск поточної ітерації циклу
                    }
                }
                Wine[] arr = new Wine[n]; // Оголошення та ініціалізація масиву об'єктів типу Wine для зберігання інформації про введені вина
                for (int i = 0; i < n; i++) // Оператор циклу for, перебір для введення інформації про кожне вино
                {
                    Console.WriteLine("\nВведіть інформацію про вино №{0}:", i + 1);

                    arr[i] = new Wine(); // Створення нового об'єкта типу Wine
                    arr[i].Input(); // Виклик методу Input для введення інформації про вино, яке зберігається в arr[i]
                }
                while (true) // Оператор циклу while, нескінченний цикл для аналізу вин або виходу з програми
                {
                    try
                    {
                        Console.WriteLine("\nВведіть:\n\n1 - для аналізу вин\n0 - для виходу");

                        Console.Write("\nЗробіть ваш вибір: ");
                        choice = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("");
                    }
                    catch (FormatException ex)
                    { 
                        Console.WriteLine("\n[ПОМИЛКА] - Помилка формату вводу: {0}", ex.Message);
                        continue; // Пропуск поточної ітерації циклу
                    }
                    if (choice == 0) // Умовний оператор if, перевірка, чи вибір користувача для виходу з програми
                    {
                        Console.WriteLine("\n[УВАГА] - Вихід з програми...");
                        break; // Вихід з циклу, якщо вибір користувача для виходу з програми
                    }
                    else if (choice == 1) // Умовний оператор else if, перевірка, чи вибір користувача для аналізу вин
                    {
                        string place_formal, color_formal;
                        Console.Write("Введіть місце розливу для аналізу: ");
                        place_formal = Console.ReadLine();
                        Console.WriteLine("");
                        Console.Write("Введіть колір для аналізу: ");
                        color_formal = Console.ReadLine();
                        Console.WriteLine("");
                        arr[0].Analize(ref arr, ref place_formal, ref color_formal); // Виклик методу Analize для аналізу масиву вин за заданими критеріями місця розливу та кольору
                    }
                    else // Умовний оператор else, якщо вибір користувача не відповідає жодному з очікуваних варіантів
                    {
                        Console.WriteLine("\n[УВАГА] - Вказано неправильний вибір!\nСпробуйте ще раз...");
                        continue; // Пропуск поточної ітерації циклу
                    }
                }
            }
        }
    }
}
