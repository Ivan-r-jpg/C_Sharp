using System; // Підключення простору імен System

namespace lab._7._1
{
    class Ship // Опис базового класу 
    {
        // Поля, що доступні всередині цього класу та його нащадкам
        protected string name;
        protected string function;
        protected double cavity;
        protected int powerOfEngine;
        protected string typeOfFuel;

        public virtual void Input() // Метод для введення даних про корабель взагалом
        {
            Console.Write("Введіть назву корабля: ");
            name = Console.ReadLine();
            Console.Write("Введіть призначення корабля '{0}': ", name);
            function = Console.ReadLine();
            cavity = DoubleInput(1, 100000, "Введіть водотоннажність корабля (в тоннах):");
            
            powerOfEngine = IntegerInput(1, 1000, "Введіть потужність двигуна (в к.с.):");
            Console.Write("Введіть тип палива, що приймає даний корабель: ");
            typeOfFuel = Console.ReadLine();
        }
        public virtual void Output() // Метод для виведення базової інформації про корабель
        {
            Console.WriteLine("\nНазва корабля: {0}\nПризначення корабля '{0}': {1}\nВодотоннажність корабля '{0}': {2}" +
                "\nПотужність двигуна корабля '{0}': {3}\nТип палива, що використовує корабель '{0}': {4}",
                name, function, cavity, powerOfEngine, typeOfFuel);
        }

        protected int IntegerInput(int min, int max, string text) // Метод для валідації вводу цілого числа
        {
            int number;
            Console.Write("{0} ", text);
            while (true) // Цикл, що триває поки ввід не буде правильний
            {
                try
                {
                    number = Convert.ToInt32(Console.ReadLine()); // Спроба конвертації рядка в ціле число
                    while (number < min || number > max) // Цикл, що триває поки число не потрапить в дозволений діапазон
                    {
                        Console.Write("\n[УВАГА] - Дане число виходить за межі допустимого діапазону!\n\n{0} ", text);
                        number = Convert.ToInt32(Console.ReadLine());
                    }
                }
                catch (FormatException) // Перехоплення помилки конвертації
                {
                    Console.Write("\n[ПОМИЛКА] - Спробуйте ввести ще раз: ");
                    continue;
                }
                return number; // Повернення цілого числа
            }
        }

        protected double DoubleInput(int min, int max, string text) // Метод для валідації вводу числа з плавуючою комою
        {
            double number;
            Console.Write("{0} ", text);
            while (true) // Цикл, що триває поки ввід не буде правильний
            {
                try
                {
                    number = Convert.ToDouble(Console.ReadLine()); // Спроба конвертації рядка в число з плавуючою комою
                    while (number < min || number > max) // Цикл, що триває поки число не потрапить в дозволений діапазон
                    {
                        Console.Write("\n[УВАГА] - Дане число виходить за межі допустимого діапазону!\n\n{0} ", text);
                        number = Convert.ToDouble(Console.ReadLine());
                    }
                }
                catch (FormatException) // Перехоплення помилки конвертації
                {
                    Console.Write("\n[ПОМИЛКА] - Спробуйте ввести ще раз: ");
                    continue;
                }
                return number; // Повернення числа
            }
        }
    }

    class Carrier : Ship // Опис похідного класу
    {
        private string aircraftTypes;
        private int numberOfAircraft;
        public override void Input() // Перевизначення методу базового класу
        {
            base.Input(); // Виклик методу з базового класу
            Console.Write("Введіть тип літаків, що переносить авіаносець '{0}': ", name);
            aircraftTypes = Console.ReadLine();
            numberOfAircraft = IntegerInput(0, 100, "Введіть кількість літаків, що переносить авіаносець:");
        }

        public override void Output() // Перевизначення методу базового класу
        {
            base.Output(); // Виклик методу з базового класу
            Console.WriteLine("\nАвіаносець '{0}' перевозить літаки типу '{1}' кількістю {2} шт. ", name, aircraftTypes, numberOfAircraft);
        }
    }

    class RocketCarrier : Ship // Опис похідного класу
    {
        private string typeOfRockets;
        private int numberOfRockets;
        public override void Input() // Перевизначення методу базового класу
        {
            base.Input(); // Виклик методу з базового класу
            Console.Write("Введіть тип ракет, що переносить ракетоносець '{0}': ", name);
            typeOfRockets = Console.ReadLine();
            numberOfRockets = IntegerInput(0, 1000, "Введіть кількість ракет, що переносить даний ракетоносець:");
        }

        public override void Output() // Перевизначення методу базового класу
        {
            base.Output(); // Виклик методу з базового класу
            Console.WriteLine("\nРакетоносець '{0}' перевозить ракети типу '{1}' кількістю {2} шт. ", name, typeOfRockets, numberOfRockets);
        }
    }


    internal class Program // Основний клас Program
    {
        static void Main(string[] args) // Головний метод програми
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Налаштування кодування виводу в консоль 
            Console.InputEncoding = System.Text.Encoding.UTF8; // Налаштування кодування для введення в консоль

            Carrier cr = new Carrier(); // Створення посилання на об'єкт класу Carrier
            RocketCarrier rtc = new RocketCarrier(); // Створення посилання на об'єкт класу RocketCarrier

            Console.WriteLine("\t\t=== ЗАНЕСЕННЯ ІНФОРМАЦІЇ ПРО АВІАНОСЕЦЬ ===\n");
            cr.Input(); // Виклик методу для Carrier
            Console.WriteLine("\n\t\t=== ІНФОРМАЦІЯ ПРО АВІАНОСЕЦЬ ===");
            cr.Output(); // Виклик методу для Carrier
            Console.WriteLine("\n\t\t=== ЗАНЕСЕННЯ ІНФОРМАЦІЇ ПРО РАКЕТОНОСЕЦЬ ===\n");
            rtc.Input(); // Виклик методу для RocketCarrier
            Console.WriteLine("\n\t\t=== ІНФОРМАЦІЯ ПРО РАКЕТОНОСЕЦЬ ===");
            rtc.Output(); // Виклик методу для RocketCarrier

            Console.WriteLine("\n[УВАГА] - Завершення роботи програми...");
        }
    }
}
