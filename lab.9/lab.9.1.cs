using System; // Використання простору імен System

namespace lab._9._1
{
    class Transport // Базовий клас
    {
        // Захищені поля, що доступні базовому класу та його нащадкам
        protected double netProfit; // Поле "Чистий дохід"
        protected double profit; // Поле "Дохід"
        protected double costs; // Поле "Витрати"
        protected string transportNumber; // Поле "Номер транспорту"
        protected string transportBrand; // Поле "Марка транспорту"
        
        public virtual void Input() // Віртуальна функція для вводу базової інформації про транспорт
        {
            Console.Write("Введіть марку транспортного засобу: ");
            transportBrand = Console.ReadLine();
            Console.Write("Введіть номер транспорту: ");
            transportNumber = Console.ReadLine();
            profit = Program.DoubleInput(0, 1000000, "Введіть прибуток за поїздку (у грн.): ");
            costs = Program.DoubleInput(0, profit, "Введіть витрати за поїздку (у грн.): ");
        }

        protected virtual void CalculateNetProfit() // Віртуальна функція для обчислення чистого прибутку
        {
            netProfit = profit - costs;
        }
        public virtual void Output() // Віртуальна функція для виводу базової інформації про транспорт
        {
            CalculateNetProfit();
            Console.WriteLine("\n   Транспортний засіб '{0}' з номерами '{1}':\n", transportBrand, transportNumber);
            if (netProfit >= 0) // Якщо збитку немає, то виводиться наступне повідомлення
            {
                Console.WriteLine("   Чистий прибуток за перевезення: {0:F2} грн.", netProfit);
            }
            else // Якщо є збиток
            {
                Console.WriteLine("   [УВАГА] - Перевезення збиткове! Збиток склав: {0:F2} грн.", Math.Abs(netProfit));
            }
        }
    }

    class FreightTransport : Transport // Клас для представлення вантажного автомобіля
    {
        // Приватні поля, що доступні тільки в даному класі
        private double cargoWeight; // Поле "Вага товару"
        private double cargoAssessment; // Поле "Оцінка товару"
        private int cargoСondition; // Поле "Стан товару"
        private int driveHours; // Поле "Кількість годин водія"
        private double driverBonus; // Поле "Надбавка водію"
        private double fine; // Поле "Штраф"
        private int optimalCountOfHours; // Поле "Оптимальна кількість годин"

        public override void Input() // Перевизначення методу для вводу інформації
        {
            base.Input(); // Виклик методу з базового класу для вводу базової інформації
            cargoWeight = Program.DoubleInput(0, 1000000, "Введіть вагу вантажу, що перевозиться (кг.): ");
            cargoAssessment = Program.DoubleInput(0, 1000000, "Введіть оцінку товару, що перевозиться (грн.): ");
            driveHours = Program.IntegerInput(0, 500, "Введіть кількість годин, що тривало перевезення: ");
        }

        protected override void CalculateNetProfit() // Перевизначення методу для обчислення чистого прибутку
        {
            optimalCountOfHours = Program.rd.Next(5, 200); // Генерування випадкового значення оптимальної кількості годин
            cargoСondition = Program.rd.Next(40, 100); // Генерування випадкового значення стану товару від 40% до 100%
            if (cargoСondition > 72 && driveHours <= optimalCountOfHours) // Якщо товар у гарному стані і його доставлено вчасно
            {
                driverBonus = (Program.rd.NextDouble() / 2.0) * 100; // Нараховується бонус для водія
                fine = 0; // Значення штрафу встановлюється як 0
            }
            else if (cargoСondition < 72) // Якщо ж товар у поганому стані 
            {
                fine = Program.rd.NextDouble() * cargoAssessment * ((100 - cargoСondition) / 100.0); // Штраф напряму залежить від стану товару
                driverBonus = 0; // Значення бонуса для водія встановлюється як 0
            }
            else if (driveHours > optimalCountOfHours) // Якщо ж товар не доставлено вчасно
            {
                fine = ((Program.rd.NextDouble() * 2) * 100 * (driveHours - optimalCountOfHours)); 
                driverBonus = 0; // Значення бонуса для водія встановлюється як 0 
            }

            netProfit = profit - costs - fine + driverBonus;
        }
        public override void Output() // Перевизначення методу для виводу інформації
        {
            base.Output(); // Виклик методу базового класу для відображення базової інформації
            Console.WriteLine("   Вантажний автомобіль перевозив {0} кг товару дорогою, що зайняла {1} з допустимих {3} год." +
                "\n   Прибуток з перевезення: {4} грн.\n   Витрати під час перевезння: {5}\n   Оцінка товару, що перевозився: {6} грн." +
                "\n   На момент прибуття стан товару оцінювався як: [{2}%/100%]", cargoWeight, driveHours, cargoСondition, optimalCountOfHours, profit, costs, cargoAssessment);
            if (driverBonus != 0) // Якщо водій заробив штраф, то виводиться наступне повідомлення
            {
                Console.WriteLine("   Винагода, що отримав перевізник: {0:F2} грн.", driverBonus);
            }
            else if (fine != 0) // Якщо водій не заробив штраф, то виводиться наступне повідомлення
            {
                Console.WriteLine("   Штраф, що отримав перевізник: {0:F2} грн.", fine);
            }
        }
    }

    class PassengerTransport : Transport // Клас для представлення пасажирського автомобіля
    {
        // Приватні поля, що доступні тільки в даному класу
        private int availableSeats; // Поле "Доступні місця"
        private int numberOfPeople; // Поле "Кількість пасажирів"
        private double driversRate; // Поле "Ставка водія"
        private double distance; // Поле "Відстань"
        private bool passengerSatisfaction; // Поле "Вдоволеність пасажирів"

        public override void Input() // Перевизначення методу для вводу інформації
        {
            base.Input(); // Виклик методу з базового класу для вводу базової інформації
            availableSeats = Program.IntegerInput(0, 60, "Введіть кількість місць в автобусі: ");
            numberOfPeople = Program.IntegerInput(0, availableSeats, "Введіть кількість людей, що їдуть в путівку: ");
            driversRate = Program.DoubleInput(0, 100000, "Введіть ставку водія (грн.): ");
            distance = Program.DoubleInput(0, 10000000, "Введіть кілометраж поїздки (км. - в один бік): ");
        }

        protected override void CalculateNetProfit() // Перевизначення методу для обчислення чистого прибутку
        {
            double passengerMood = Program.rd.NextDouble(); // Генерування випадкового значення від 0 до 1
            if (passengerMood >= 0.7) // Якщо настрій пасажирів переважно позитивний
            {
                passengerSatisfaction = true; // Встановлення значення true
            }
            else // Якщо ж настрій переважно негативний
            {
                passengerSatisfaction = false; // Встановлення значення false
            }
            if (!passengerSatisfaction) // Якщо пасажири невдоволені, то обчислюється чистий прибуток разом із заробленим штрафом - 100 грн за кожну людину
            {
                netProfit = profit - costs - driversRate + (0.2 * 2 * distance) - (100 * numberOfPeople);
            }
            else // Якщо ж людям все сподобалося, то обчислюється чистий прибуток без нарахування штрафів
            {
                netProfit = profit - costs - driversRate + (0.2 * 2 * distance);
            }
        }

        public override void Output() // Перевизначення методу для виведення інформації
        {
            base.Output(); // Виклик методу з базового класу для виводу базової інформації
            Console.WriteLine("   Пасажирський автомобіль перевозив {0} людей дорогою довжиною в {1} км." +
                "\n   Прибуток з перевезення: {2} грн.\n   Витрати під час перевезння: {3}" +
                "\n   Загальна кількість міcць в автобусі: {4}", numberOfPeople, 2 * distance, profit, costs, availableSeats);
            if (passengerSatisfaction) // Якщо пасажири вдоволені поїздкою, то виводиться наступне повідомлення
            {
                Console.WriteLine("   Більшість пасажирів були задоволені поїзкою!");
            }
            else // Якщо не вдоволені
            {
                Console.WriteLine("   [УВАГА] - Більшість пасажирів були невдоволені поїздкою! (Штраф за кожну людину - 100 грн.)");
            }
            Console.WriteLine("   Ставка водія: {0}", driversRate);
        }
    }
    internal class Program // Основний клас програми
    {
        public static Random rd = new Random(); // Створення посилання на об'єкт класу Random
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
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Встановлення кодування для коректного виводу українських символів в консоль
            Console.InputEncoding = System.Text.Encoding.UTF8; // Встановлення кодування для коректного вводу українських символів в консоль

            uint iterFreight = 0;
            uint iterPassenger = 0;
            int i;

            int transportCount = Program.IntegerInput(1, 100, "Введіть кількість транспортних засобів: ");
            Transport[] trp = new Transport[transportCount]; // Оголошення масиву об'єктів класу Transport
            for (i = 0; i < trp.Length; i++) // Цикл, що проходиться по всім елементам масиву
            {
                Console.WriteLine();
                int userChoice = Program.IntegerInput(1, 2, "[УВАГА] - Оберіть вид транспорту, про якого хочете заповнити інформацію:\n" +
                "1 - Вантажний транспорт;\n2 - Пасажирський транспорт.\n\nВведіть ваш вибір: ");
                switch (userChoice) // Вибір транспорту
                {
                    case 1:
                        trp[i] = new FreightTransport(); // Створення нового посилання на об'єкт класу FreightTransport
                        iterFreight++;
                        Console.WriteLine("\n--- ВАНТАЖНИЙ ТРАНСПОРТ #{0} ---\n", iterFreight);
                        trp[i].Input(); // Введення інформації про об'єкт
                        break;
                    case 2:
                        trp[i] = new PassengerTransport(); // Створення нового посилання на об'єкт класу PassengerTransport
                        iterPassenger++;
                        Console.WriteLine("\n--- ПАСАЖИРСЬКИЙ ТРАНСПОРТ #{0} ---\n", iterPassenger);
                        trp[i].Input(); // Введення інформації про об'єкт
                        break;
                }
            }
            Console.WriteLine("\n[УВАГА] - Інформацію про транспортні засоби успішно занесено!\n" +
                "\nНатисність клавішу Enter, щоб вивести результати про наявні транспортні засоби...");
            Console.ReadLine(); // Очікування натискання клавіші Enter
            Console.Clear(); // Очищення консолі для гарного виводу кінцевих результатів
            Console.WriteLine("\n~~~ РЕЗУЛЬТАТИ ~~~");
              
            for (i = 0; i < trp.Length; i++) // Цикл, що проходиться по всім елементам масиву об'єктів
            {
                Console.WriteLine("\n--- ТРАНСПОРТНИЙ ЗАСІБ #{0} ---", i + 1); 
                trp[i].Output(); // Виведення інформації на екран про кожен об'єкт окремо 
            }
            Console.WriteLine("\nНатисніть Enter для завершення програми...");
            Console.ReadLine(); // Очікування натискання клавіші Enter
            Console.WriteLine("[УВАГА] - Завершення програми...");
        }
    }
}
