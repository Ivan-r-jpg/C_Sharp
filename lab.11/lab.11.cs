using System; // Використання простору імен System

namespace lab._11
{
    class Fighter // Клас "Винищувач"
    {
        private string brand; // Поле "марка"
        private double maxSpeed; // Поле "максимальна швидкість"
        private int missilesCount; // Поле "кількість ракет"
        private double price; // Поле "ціна"

        public string GetBrand() // Метод, що дозволяє отримати значення марки
        {
            return brand;
        }

        public double GetMaxSpeed() // Метод, що дозволяє отримати значення максимальної швидкості
        { 
            return maxSpeed; 
        }
        public void Input() // Метод для вводу інформації про винищувач
        {
            Console.Write("Введіть марку винищувача: ");
            brand = Console.ReadLine();
            maxSpeed = Program.DoubleInput(500, 2500, "Введіть макcимальну швидкість винищувача (км/год): ");
            missilesCount = Program.IntegerInput(2, 16, "Введіть кількість ракет, що несе винищувач: ");
            price = Program.DoubleInput(10000, 10000000000, "Введіть ціну винищувача ($): ");
        }

        public void Output() // Метод для виведення інформації про винищувач
        {
            Console.WriteLine("\nВинищувач '{0}':\nМаксимальна швидкіть літака: {1} км/год\nКількість ракет, якими оснащений літак: {2}" +
                "\nЦіна даного літака: {3} $", brand, maxSpeed, missilesCount, price);
        }

        public static bool operator == (Fighter a, Fighter b) // Перевантаження унарного оператора ==
        {
            if (a.brand == b.brand && a.maxSpeed == b.maxSpeed && a.missilesCount == b.missilesCount && a.price == b.price)
            {
                return true;
            }
            return false;
        }

        public static bool operator != (Fighter a, Fighter b) // Перевантаження унарного оператора !=
        {
            if (a.brand != b.brand || a.maxSpeed != b.maxSpeed || a.missilesCount != b.missilesCount || a.price != b.price)
            {
                return true;
            }
            return false;
        }

        public static bool operator < (Fighter a, Fighter b) // Перевантаження унарного оператора <
        {
            if (a.maxSpeed < b.maxSpeed)
            {
                return true;
            }
            return false;
        }

        public static bool operator >(Fighter a, Fighter b) // Перевантаження унарного оператора >
        {
            if (a.maxSpeed > b.maxSpeed)
            {
                return true;
            }
            return false;
        }

        public static Fighter operator + (Fighter a, Fighter b) // Перевантаження бінарного оператора +
        {
            Fighter figh = new Fighter(); // Створення тимчасового об'єкту
            
            figh.brand = "Не визначено";
            figh.maxSpeed = Math.Max(a.maxSpeed, b.maxSpeed);
            figh.missilesCount = a.missilesCount + b.missilesCount;
            figh.price = a.price + b.price;

            return figh; // Повернення нового об'єкта
        }
    }

    internal class Program // Основний клас програми
    {
        public static int IntegerInput(double min, double max, string text) // Метод для валідації вводу цілого числа
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
        public static double DoubleInput(double min, double max, string text) // Метод для валідації вводу числа з плаваючою комою
        {
            text = text.Trim();
            double number;
            Console.Write("{0} ", text);
            while (true) // Цикл, що триває поки користувач не введе число у правильному форматі 
            {
                try
                {
                    number = Convert.ToDouble(Console.ReadLine());
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
                        number = Convert.ToDouble(Console.ReadLine());
                    }
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
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Налаштування кодування консолі для коректного виведення українських символів на екран
            Console.InputEncoding = System.Text.Encoding.UTF8; // Налаштування кодування консолі для коректного вводу українських символів

            bool found = false;
            bool programRun = true;
            int planeNumber = Program.IntegerInput(2, 150, "Введіть кількість літаків-винищувачів: ");

            Fighter[] fighter = new Fighter[planeNumber]; // Оголошення масиву об'єктів класу Fighter

            Console.WriteLine("\n\t\t\t--- ЗАПОВНЕННЯ ІНФОРМАЦІЇ ПРО ВИНИЩУВАЧІ ---");
            for (int i = 0; i < fighter.Length; i++) // Цикл, в якому ініціалізується масив об'єктів
            {
                Console.WriteLine("\n--- ВИНИЩУВАЧ #{0} ---\n", i + 1);
                fighter[i] = new Fighter();
                fighter[i].Input();
            }
            Console.WriteLine("\n[УВАГА] - Всі дані про літаки успішно заповнено!\n");
            while (programRun) // Цикл, що триває поки користувач не захоче вийти з програми
            {
                found = false;
                Console.WriteLine("МЕНЮ ДІЇ (Оберіть які дії ви хочете провести з винищувачами):\n" +
                    "\n1 - Перевірити чи винищувачі рівні між собою;\n2 - Перевірити чи винищувачі різні;" +
                    "\n3 - Перевірити, який винищувач переважає у швидкості\n4 - Перевірити, який винищувач поступається у швидкості;" +
                    "\n5 - Провести операцію додавання між двома обраними винищувачами;\n6 - Вихід з програми.\n");
                int userChoice = Program.IntegerInput(1, 6, "Введіть ваш вибір: ");
                switch (userChoice) // Вибір дії 
                {
                    case 1:

                        Console.WriteLine("\n\t\t\t--- ПЕРЕВІРКА РІВНОСТІ ВИНИЩУВАЧІВ ---");
                        for (int i = 1; i < fighter.Length; i++)
                        {
                            if (fighter[i] == fighter[i - 1])
                            {
                                found = true;
                                Console.WriteLine("\nВинищувач #{0} ('{1}') == Винищувач #{2} ('{3}')", 
                                    i, fighter[i - 1].GetBrand(), i + 1, fighter[i].GetBrand());
                            }    
                        }
                        if (!found) // Якщо однакових об'єктів не знайдено
                        {
                            Console.WriteLine("\n[УВАГА] - Відповідних пар не знайдено!");
                        }
                        Console.WriteLine("\n[УВАГА] - Всі винищувачі ({0} шт.) проаналізовано!\n" +
                                "\nНатисність будь-яку клавішу для продовження...\n", fighter.Length);
                        Console.ReadKey(true); // Очікування натиснення клавіші
                        break;

                    case 2:

                        Console.WriteLine("\n\t\t\t--- ПЕРЕВІРКА НЕРІВНОСТІ ВИНИЩУВАЧІВ ---");
                        for (int i = 1; i < fighter.Length; i++)
                        {
                            if(fighter[i] != fighter[i - 1])
                            {
                                found = true;
                                Console.WriteLine("\nВинищувачі під номерами #{0} ({1}) та #{2} ({3}) - не рівні!", 
                                    i, fighter[i - 1].GetBrand(), i + 1, fighter[i].GetBrand());
                            }      
                        }
                        if (!found) // Якщо різних об'єктів не знайдено
                        {
                            Console.WriteLine("\n[УВАГА] - Відповідних пар не знайдено!");
                        }
                        Console.WriteLine("\n[УВАГА] - Всі винищувачі ({0} шт.) проаналізовано!\n" +
                                "\nНатисність будь-яку клавішу для продовження...\n", fighter.Length);
                        Console.ReadKey(true); // Очікування натиснення клавіші
                        break;

                    case 3:

                        Console.WriteLine("\n\t\t\t--- ПОРІВНЯННЯ ВИНИЩУВАЧІВ (>) ---");
                        for (int i = 1; i < fighter.Length; i++)
                        {
                            if (fighter[i] > fighter[i - 1])
                            {
                                found = true;
                                Console.WriteLine("\nВинищувач #{0} ({1} км/год) переважає у швидкості винищувача #{2} ({3} км/год)!", 
                                    i + 1, fighter[i].GetMaxSpeed(), i, fighter[i - 1].GetMaxSpeed());
                            }
                        }
                        if (!found) // Якщо всі об'єкти однакові
                        {
                            Console.WriteLine("\n[УВАГА] - Відповідних пар не знайдено!");
                        }
                        Console.WriteLine("\n[УВАГА] - Всі винищувачі ({0} шт.) проаналізовано!\n" +
                                "\nНатисність будь-яку клавішу для продовження...\n", fighter.Length);
                        Console.ReadKey(true); // Очікування натиснення клавіші
                        break;

                    case 4:

                        Console.WriteLine("\n\t\t\t--- ПОРІВНЯННЯ ВИНИЩУВАЧІВ (<) ---");
                        for (int i = 1; i < fighter.Length; i++)
                        {
                            if (fighter[i] < fighter[i - 1])
                            {
                                found = true;
                                Console.WriteLine("\nВинищувач #{0} ({1} км/год) поступається у швидкості винищувачу #{2} ({3} км/год)!", 
                                    i + 1, fighter[i].GetMaxSpeed(), i, fighter[i - 1].GetMaxSpeed());
                            }
                        }
                        if (!found) // Якщо всі об'єкти однакові
                        {
                            Console.WriteLine("\n[УВАГА] - Відповідних пар не знайдено!");
                        }
                        Console.WriteLine("\n[УВАГА] - Всі винищувачі ({0} шт.) проаналізовано!\n" +
                                "\nНатисність будь-яку клавішу для продовження...\n", fighter.Length);
                        Console.ReadKey(true); // Очікування натиснення клавіші
                        break;

                    case 5:

                        Console.WriteLine("\n\t\t\t--- ДОДАВАННЯ ВИНИЩУВАЧІВ ---\n");
                        int index1 = Program.IntegerInput(1, fighter.Length, "\nВведіть індекс лівого операнда (винищувача): ");
                        int index2 = Program.IntegerInput(1, fighter.Length, "Введіть індекс правого операнда (винищувача): ");
                        Console.WriteLine("\nВинищувач #{0} ('{1}') + Винищувач #{2} ('{3}') = ", 
                            index1, fighter[index1 - 1].GetBrand(), index2, fighter[index2 - 1].GetBrand());
                        Fighter sum = fighter[index1 - 1] + fighter[index2 - 1]; // Додавання двох винищувачів
                        sum.Output(); // Виведення нового винищувача на екран
                        Console.WriteLine("\nНатисність будь-яку клавішу для продовження...\n");
                        Console.ReadKey(true); // Очікування натиснення клавіші
                        break;

                    case 6:

                        programRun = false;
                        Console.WriteLine("\n[УВАГА] - Завершення роботи програми...");
                        break;
                }
  
            }
        }
    }
}
