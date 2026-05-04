using System; // Використання простору імен System

namespace lab._10._1
{
    abstract class Plane // Абстрактний клас "Літак"
    {
        // Оголошення абстрактних методів для всіх похідних класів
        public abstract void Input(); // Метод для вводу інформації про літак
        public abstract void Output(); // Метод для виводу інформації про літак
    }

    class Destroyer : Plane // Похідний клас "Винищувач"
    {
        private string destroyerName; // Поле "назва винищувача"
        private string engineType; // Поле "тип двигуна"
        private string fuelType; // Поле "палива"
        private int numberOfEngines; // Поле "кількість двигунів"

        public override void Input() // Перевизначений метод для вводу інформації
        {
            Console.Write("Введіть найменування винищувача: ");
            destroyerName = Console.ReadLine();
            Console.Write("Введіть тип двигуна: ");
            engineType = Console.ReadLine();
            Console.Write("Введіть тип палива: ");
            fuelType = Console.ReadLine();
            numberOfEngines = Program.IntegerInput(1, 10, "Введіть кількість двигунів: ");
        }

        public override void Output() // Перевизначений метод для виведення інформації
        {
            Console.WriteLine("Винищувач під кодовим ім'ям '{0}':" +
                "\nТип двигуна: {1}\nСпоживає паливо: {2}\nМає на борту двигуни кількістю: {3} шт.", 
                destroyerName, engineType, fuelType, numberOfEngines);
        }
    }

    class PassengerLiner : Plane // Похідний клас "Пасажирський лайнер"
    {
        private int numberOfPeople; // Поле "кількість людей"
        private double ticketPrice; // Поле "ціна квитка"
        private string companyName; // Поле "назва компанії"
        private double distance; // Поле "відстань"
        private string destination; // Поле "призначення"

        public override void Input() // Перевизначений метод для вводу інформації
        {
            Console.Write("Введіть назву компанії, що відповідає за авіаперевезення: ");
            companyName = Console.ReadLine();
            ticketPrice = Program.DoubleInput(100, 100000, "Введіть ціну квитка за переліт ($): ");
            numberOfPeople = Program.IntegerInput(1, 500, "Введіть кількість людей на борту: ");
            Console.Write("Введіть місце призначення: ");
            destination = Console.ReadLine();
            distance = Program.DoubleInput(100, 10000000, "Введіть, на яку відстань відбувається переліт (км.): ");
        }

        public override void Output() // Перевизначений метод для виводу інформації
        {
            Console.WriteLine("Компанія '{0}' пропонує вигідну пропозицію!" +
                "\nВсього за {1}$ Ви матимете чудову можливість комфортної подорожжі до такого прекрасного місця як {2}!" +
                "\nРазом з Вами ще будуть подорожувати {3} людей\nНе гайте часу, адже на Вас чекають {4} км. незабутніх краєвидів!", 
                companyName, ticketPrice, destination, numberOfPeople, distance);
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
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Встановлення кодування консолі для коректоного виведення українських символів на екран
            Console.InputEncoding = System.Text.Encoding.UTF8; // Встановлення кодування консолі для коректного введення українських символів

            Plane pl; // Ініціалізація об'єкту абстрактного класу Plane
            Console.WriteLine("--- ЗАНЕСЕННЯ ІНФОРМАЦІЇ ПРО ВИНИЩУВАЧ ---\n");
            Destroyer dr = new Destroyer(); // Створення посилання на об'єкт класу Destroyer

            pl = dr; // pl присвоюється адреса dr

            pl.Input(); // Виклик методу для вводу інформації про винищувач
            Console.WriteLine("\n--- ВИВЕДЕННЯ ІНФОРМАЦІЇ ПРО ВИНИЩУВАЧ ---\n");
            pl.Output(); // Виклик методу дял виводу інформації про винищувач

            Console.WriteLine("\n--- ЗАНЕСЕННЯ ІНФОРМАЦІЇ ПРО ПАСАЖИРСЬКИЙ ЛАЙНЕР ---\n");
            PassengerLiner pr = new PassengerLiner(); // Створення посилання на об'єкт класу PassengerLiner

            pl = pr; // pl присвоюється адреса pr

            pl.Input(); // Виклик методу для вводу інформації про пасажирський лайнер
            Console.WriteLine("\n--- ВИВЕДЕННЯ ІНФОРМАЦІЇ ПРО ПАСАЖИРСЬКИЙ ЛАЙНЕР ---\n");
            pl.Output(); // Виклик методу дял виводу інформації про пасажирський лайнер

            Console.WriteLine("\n[УВАГА] - Натисість будь-яку клавішу для завершення програми...");
            Console.ReadKey(true); // Очікування натиснення будь-якої клавіші
            Console.WriteLine("\n[УВАГА] - Завершення програми...");
        }
    }
}
