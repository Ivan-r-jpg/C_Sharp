using System; // Використання простору імен System

namespace lab._9._2
{
    class Student // Базвоий клас, що описує студента
    {
        protected string group; // Поле "група"
        protected string name; // Поле "ім'я"
        protected int course; // Поле "курс навчання"
        protected int numberOfDisciplines; // Поле "кількість вивчаємих дисциплін"
        protected bool scholarshipOpportunity; // Поле "можливість отримати стипендію"
        protected string faculty; // Поле "факультет"

        public virtual void Input() // Базовий метод для вводу даних про студента
        {
            Console.Write("Введіть ім'я студента: ");
            name = Console.ReadLine();
            Console.Write("Введіть назву факультету, на якому навчається студент: ");
            faculty = Console.ReadLine();
            Console.Write("Введіть групу студента: ");
            group = Console.ReadLine();
            course = Program.IntegerInput(1, 7, "Введіть на якому курсі навчається студент:");
            numberOfDisciplines = Program.IntegerInput(1, 12, "Введіть кількість дисциплін, що вивчає студент: ");
        }

        protected virtual void ScholarshipAward() // Базовий метод для отримання стипендії
        {
            if (scholarshipOpportunity) // Якщо студент має можливість отриувати стипендію
            {
                Console.WriteLine("\n[УВАГА] - Треба більше інформації про студента для нарахування стипендії!");
            }
            else // Якщо ж не має такої можливості
            {
                Console.WriteLine("\n[УВАГА] - Студенту '{0}' стипендія не передбачена!", name);
            }
        }

        public virtual void Output() // Базовий метод для відображення даних про студента
        {
            ScholarshipAward();
            Console.WriteLine("\nІм'я студента: {0}\nФакультет: {1}\nГрупа: {2}\nКурс навчання: {3}" +
                "\nКількість дисциплін, що вивчає студент: {4}", name, faculty, group, course, numberOfDisciplines);
        }
    }

    class StateFundedStudent : Student // Похідний клас, що описує бюджетника
    {
        private double averageScore; // Поле "середній бал"
        private int ratingsPlace; // Поле "місце в рейтингу"
        private double scholarship; // Поле "стипендія"
        private bool becomePayer = false; // Поле "стати платником"

        public override void Input() // Перевизначений метод для вводу інформації про студента
        {
            base.Input(); // Виклик методу Input з базового класу
            averageScore = Program.DoubleInput(5, 100, "Введіть середній бал студента: ");
            ratingsPlace = Program.IntegerInput(1, 60, "Вкажіть, яке місце займає студент в рейтингу: ");
        }

        protected override void ScholarshipAward() // Перевизначений метод для отримання стипендії
        {
            if (averageScore >= 90 && ratingsPlace < 3) // Якщо середній бал вище за 80 і рейтингове місце менше 20-го
            {
                scholarshipOpportunity = true; // Встановлюється, що студент має стипендію
                scholarship = 2999.99; // Нарахування стипендії у розмірі 2000
            }
            else if (averageScore >= 80 && ratingsPlace <= 20) // Якщо ж середній бал вище 90 і рейтингове місце менше 3-го
            {
                scholarshipOpportunity = true; // Встановлюється що студент має стипендію
                scholarship = 2000; // Нарахування підвищеної стипендії
            }
            else if (averageScore < 80 && averageScore >= 60) // Якщо ж середній бал студента більше за 60, але менший ща 80
            {
                scholarshipOpportunity = false; // Студент не зможе отримувати стипендію
            }
            else if (averageScore < 60) // Якщо ж середній бал менший за 60
            {
                becomePayer = true; // Студент стає платником
            }
        }

        public override void Output() // Перевизначений метод для виводу інформації про студента на екран
        {
            base.Output(); // Виклик методу Output з базового класу
            Console.WriteLine("Студент '{0}', що навчається на бюджеті по всім предметам має середній бал: {1}" +
                "\nСтудент займає {2} місце в рейтинговому списку на стипендію!", name, averageScore, ratingsPlace);
            if (becomePayer)
            {
                Console.WriteLine("[УВАГА] - Студент не склав екзамени успішно і наступного семестру переходить на навчання за контрактом!");
            }
            else if (scholarshipOpportunity)
            {
                Console.WriteLine("Студент '{0}' наступні півроку отримуватиме стипендію у розмірі {1} грн!", name, scholarship);
            }
            else
            {
                Console.WriteLine("[УВАГА] - Даний студент навчатиметься на бюджеті, але стипендію на протязі наступного півріччя не отримає!");
            }
        }
    }

    class ContractStudent : Student // Похідний клас, що описує контратника
    {
        private double contractValue; // Поле "сума контракту"
        private double debt; // Поле "борг"
        private int daysLeft; // Поле "днів лишилося"

        public override void Input() // Перевизначений метод для вводу інформації про студента
        {
            base.Input(); // Виклик методу Input з базвого класу
            contractValue = Program.DoubleInput(4000, 200000, "Введіть суму навчання за контрактом (грн.): ");
            debt = Program.DoubleInput(0, contractValue, "Введіть суму боргу по навчанню: ");
            if (debt != 0) // Якщо є борг, то вводиться крайній термін для його погашення
            {
                daysLeft = Program.IntegerInput(0, 365, "Введіть кількість днів, що залишилася для оплати боргу (грн): ");
            }
        }

        public override void Output() // Перевизначення методу для виведення інформації про студента на екран
        {
            base.Output(); // Виклик методу Output з базвого класу
            Console.WriteLine("Студент платить за навчання {0} грн.", contractValue);
            if (debt != 0 && daysLeft == 0) // Якщо навяний протермінований борг
            {
                Console.WriteLine("[УВАГА] - Студент не зміг вчасно оплатити навчання!\nДоля студента залишається невідомою...");
            }
            else if (debt != 0 && daysLeft != 0) // Якщо борг є, але ще не крайній термін дял його виплати
            {
                Console.WriteLine("[НАГАДУВАННЯ] - Студент має сплатити борг за навчання у розмірі {0} грн.\n[Часу, що лишилося: {1} дн.]", debt, daysLeft);
            }
            else if (debt == 0) // Якщо борг закрито
            {
                Console.WriteLine("[ВІТАННЯ] - Студент вчасно оплатив навчання та може сміливо продовжуватися навчатися на улюбленому факультеті {0}!", faculty);
            }
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
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Налаштування кодування для коректного виводу українських символів в консоль
            Console.InputEncoding = System.Text.Encoding.UTF8; // Налаштування кодування для коректного вводу українських символів в консоль

            int i;

            int studentCount = Program.IntegerInput(1, 100, "Введіть кількість студентів: ");
            Student[] trp = new Student[studentCount]; // Оголошення масиву об'єктів класу Student
            for (i = 0; i < trp.Length; i++) // Цикл, що проходиться по всім елементам масиву
            {
                Console.WriteLine();
                int userChoice = Program.IntegerInput(1, 2, "[УВАГА] - Оберіть вид студента, про якого хочете заповнити інформацію:\n" +
                "1 - Бюджетник;\n2 - Платник.\n\nВведіть ваш вибір: ");
                switch (userChoice) // Вибір студента
                {
                    case 1:
                        Console.WriteLine("\n--- СТУДЕНТ #{0} ---\n", i + 1);
                        trp[i] = new StateFundedStudent(); // Створення нового посилання на об'єкт класу StateFundedStudent

                        trp[i].Input(); // Введення інформації про об'єкт
                        break;
                    case 2:
                        Console.WriteLine("\n--- СТУДЕНТ #{0} ---\n", i + 1);
                        trp[i] = new ContractStudent(); // Створення нового посилання на об'єкт класу ContractStudent
                        trp[i].Input(); // Введення інформації про об'єкт
                        break;
                }
            }
            Console.WriteLine("\n[УВАГА] - Інформацію про студентів успішно занесено!\n" +
                "\nНатисність клавішу Enter, щоб вивести результати про студентів...");
            Console.ReadLine(); // Очікування натискання клавіші Enter
            Console.Clear(); // Очищення консолі для гарного виводу кінцевих результатів
            Console.WriteLine("\n~~~ РЕЗУЛЬТАТИ ~~~");

            for (i = 0; i < trp.Length; i++) // Цикл, що проходиться по всім елементам масиву об'єктів
            {
                Console.WriteLine("\n--- СТУДЕНТ #{0} ---", i + 1);
                trp[i].Output(); // Виведення інформації на екран про кожен об'єкт окремо 
            }
            Console.WriteLine("\nНатисніть Enter для завершення програми...");
            Console.ReadLine(); // Очікування натискання клавіші Enter
            Console.WriteLine("[УВАГА] - Завершення програми...");
        }
    }
}
