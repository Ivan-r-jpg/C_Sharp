using System; // Підключення простору імен System

namespace lab._7._2
{
    class Document // Опис базового класу
    {
        // Поля, що доступні всередині цього класу та його нащадкам
        protected string id; // Номер документу
        protected string creationDate; // Дата створення документу
        protected string issuer; // Ким виданий документ

        public virtual void Input() // Метод для вводу базової інформації про документ
        {
            Console.Write("Введіть номер документу: ");
            id = Console.ReadLine();
            Console.Write("Введіть дату створення у форматі 'день/місяць/рік': ");
            creationDate = Console.ReadLine();
            Console.Write("Введіть ким даний документ виданий: ");
            issuer = Console.ReadLine();
        }

        public virtual void Output() // Метод для виводу базової інформації про документ
        {
            Console.WriteLine("Документ #{0}:\nДата створення документу: {1}\n-- Виданий {2} --\n", id, creationDate, issuer);
        }


    }

    class Receipt : Document // Опис похідного класу (Квитанція)
    {
        private double amount; // Сума оплати
        private string purpose; // Призначення

        public override void Input() // Перевизначення базового методу Input
        {
            base.Input(); // Виклик методу з базового класу Document
            amount = Program.DoubleInput(0, 100000, "Введіть суму оплати (у грн.):");
            Console.Write("Введіть призначення платежу: ");
            purpose = Console.ReadLine();
        }
        public override void Output() // Перевизначення базового методу Output
        {
            Console.WriteLine("=== КВИТАНЦІЯ ===\n");
            base.Output(); // Виклик методу з базового класу Document
            Console.WriteLine("Загальна сума до сплати квитанції: {0}\nПризначення платежу: {1}\n", amount, purpose);
        }
    }

    class Waybill : Document // Опис похідного класу (Накладна)
    {
        private string productName; // Ім'я товару
        private int numberOfProduct; // Кількість товару
        private string receiver; // Отримувач
        public override void Input() // Перевизначення базового методу Input 
        {
            base.Input(); // Виклик методу з базового класу Document
            Console.Write("Введіть назву товару: ");
            productName = Console.ReadLine();
            numberOfProduct = Program.IntegerInput(0, 1000, "Введіть кількість товару:");
            Console.Write("Введіть отримувача: ");
            receiver = Console.ReadLine();
        }
        public override void Output() // Перевизначення базового методу Output 
        {
            Console.WriteLine("=== НАКЛАДНА ===\n");
            base.Output(); // Виклик методу з базового класу Document
            Console.WriteLine("Назва товару: {0}\nКількість шт. товару: {1}\nОтримувач: {2}\n", productName, numberOfProduct, receiver);
        }
    }

    class Check : Document // Опис класу (Чек)
    {
        private string storeName; // Назва магазину
        private int cashRegisterNumber; // Номер каси
        private string cashierName; // Ім'я касира

        public override void Input() // Перевизначення базового методу Input 
        {
            base.Input(); // Виклик методу з базового класу Document
            Console.Write("Введіть назву магазину: ");
            storeName = Console.ReadLine();
            cashRegisterNumber = Program.IntegerInput(0, 100, "Введіть номер каси:");
            Console.Write("Введіть повне ім'я касира у форматі 'Прізвище | ім'я | по батькові': ");
            cashierName = Console.ReadLine();
        }

        public override void Output() // Перевизначення базового методу Output
        {
            Console.WriteLine("=== Чек ===\n");
            base.Output(); // Виклик методу з базового класу Document
            Console.WriteLine("Магазин '{0}':\n   Каса №{1}\n   Касир: {2}\n", storeName, cashRegisterNumber, cashierName);
        }
    }

    internal class Program // Основний клас Program
    {
        public static int IntegerInput(int min, int max, string text) // Метод для валідації вводу цілого числа
        {
            int number;
            Console.Write("{0} ", text);
            while (true) // Цикл, що триває поки користувач не введе число у правильному форматі 
            {
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                    while (number < min || number > max) // Цикл, що триває поки користувач не введе число, що належить заданому діапазону
                    {
                        Console.Write("\n[УВАГА] - Дане число виходить за межі допустимого діапазону!\n\n{0} ", text);
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
        public static double DoubleInput(int min, int max, string text) // Метод для валідації вводу числа з плаваючою комою
        {
            double number;
            Console.Write("{0} ", text);
            while (true) // Цикл, що триває поки користувач не введе число у правильному форматі 
            {
                try
                {
                    number = Convert.ToDouble(Console.ReadLine());
                    while (number < min || number > max) // Цикл, що триває поки користувач не введе число, що належить заданому діапазону
                    {
                        Console.Write("\n[УВАГА] - Дане число виходить за межі допустимого діапазону!\n\n{0} ", text);
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
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Налаштування кодування для виводу українських символів на екран консолі
            Console.InputEncoding = System.Text.Encoding.UTF8; // Налаштування кодування для вводу українських символів з клавіатури


            int num = IntegerInput(1, 100, "Введіть кількість документів, які хочете створити:");

           
            Document[] docs = new Document[num]; // Створення масиву об'єктів класу Document


            for (int i = 0; i < num; i++) // Цикл, що проходиться по всім об'єктам
            {
                Console.WriteLine("\n--- Документ {0} з {1} ---\n", i+1, num);
                int choice = IntegerInput(1, 3, "Оберіть тип (1 - Квитанція, 2 - Накладна, 3 - Чек):");

                switch (choice) // Вибір похідного класу
                {
                    case 1:
                        docs[i] = new Receipt();
                        break;
                    case 2:
                        docs[i] = new Waybill();
                        break;
                    case 3:
                        docs[i] = new Check();
                        break;
                }

                docs[i].Input(); // Виклик методу для вводу
            }

            Console.Clear(); // Очищення консолі для гарного виводу

            Console.WriteLine("=== ДРУК УСІХ ДОКУМЕНТІВ ===\n");

            foreach (Document doc in docs) // Цикл по всім об'єктам
            {
                doc.Output(); // Виклик методу для виведення інформації про об'єкт
                Console.WriteLine("===============================\n");
            }

            Console.WriteLine("Завершення роботи програми...");
        }
    }
}
