using System; // Використання простору імен System

namespace lab._10._2
{
    abstract class GameCharacter // Абстрактний клас "Ігровий персонаж"
    {
        // Поля, що загально описують базові поля для класів нащадків
        protected string name; // Поле "ім'я"
        protected int health; // Поле "здоров'я"
        public GameCharacter() { } // Порожній конструктор
        public GameCharacter(string name, int health) // Конструтор з параметрами
        {
            this.name = name;
            this.health = health;
        }
        
        // Оголошення абстрактних методів для всіх похідних класів
        public abstract void DisplayCharacterInfo(); // Метод для виведення інформації про персонажа

        public abstract int Attack(); // Метод для проведення атаки персонажем
         
        public abstract bool Damage(int attackDamage); // Метод для отримання шкоди персонажем

    }

    class Warrior : GameCharacter // Похідний клас "Боєць"
    {
        private string weapon; // Поле "зброя"
        private int weaponPower; // Поле "сила зброї"
        public Warrior() { } // Порожній конструтор
        public Warrior(string warriorName, int warriorHealth, string weapon, int weaponPower)
            : base(warriorName, warriorHealth) // Конструктор
        {
            this.weapon = weapon;
            this.weaponPower = weaponPower;
        }

        public override void DisplayCharacterInfo() // Перевизначений метод для виведення інформації про бійця на екран
        {
            Console.WriteLine("\nІгровий персонаж - Боєць '{0}':\n\nОдиниці здоров'я: {1}\nЗброя: {2}\nСила зброї: {3} од.", 
                name, health, weapon, weaponPower);
        }

        public override int Attack() // Перевизначений метод для проведення атаки бійцем
        {
            int pushDamage = Program.rd.Next(0, weaponPower + 1); // Генерування випадкового значення сили удару від 0 до weaponPower
            if (pushDamage == 0) // Якщо сила удару дорівнює 0
            {
                Console.WriteLine("[УВАГА] - Боєць '{0}' промахнувся!", name);
                return 0;
            }
            Console.WriteLine("[УВАГА] - Боєць '{0}' атакує зброєю '{1}' і наносить {2} од. шкоди!", name, weapon, pushDamage);
            return pushDamage;
        }
        public override bool Damage(int attackDamage) // Перевизначений метод для отримання шкоди бійцем
        {
            health -= attackDamage; // Віднімання від загального здоров'я бійця
            if (attackDamage == 0) // Якщо сила атаки противника була 0
            {
                Console.WriteLine("-> Боєць '{0}' у цьому раунді не отримує шкоди!", name);
                return false; // Повернення показника виживання
            }
            Console.WriteLine("-> Боєць '{0}' отримує {1} од. шкоди! Залишок здоров'я: {2}", name, attackDamage, Math.Max(0, health));
            if (health <= 0) // Якщо здоров'я бійця менше 0
            {
                return true; // Повернення ознаки програшу
            }
            return false; // Повернення показника виживання
        }
    }

    class Wizard : GameCharacter // Похідний клас "Чарівник"
    {
        private string spell; // Поле "заклинання"
        private int spellPower; // Поле "сила заклинання"

        public Wizard() { }
        public Wizard(string wizardName, int wizardHealth, string spell, int spellPower)
            : base(wizardName, wizardHealth) // Конструтор
        {
            this.spell = spell;
            this.spellPower = spellPower;
        }

        public override void DisplayCharacterInfo() // Перевизначений метод для виведення інформації про чарівника
        {
            Console.WriteLine("\nІгровий персонаж - Чарівник '{0}':\n\nОдиниці здоров'я: {1}\nЗаклинання: {2}\nСила заклинання: {3} од.",
                name, health, spell, spellPower);
        }

        public override int Attack() // Перевизначений метод для проведення атаки чарівником
        {
            int pushDamage = Program.rd.Next(0, spellPower + 1); // Генерування випадкового значення сили удару від 0 до spellPower
            if (pushDamage == 0) // Якщо сила удару дорівнює 0
            {
                Console.WriteLine("[УВАГА] - Чарівник '{0}' промахнувся!", name);
                return 0;
            }
            Console.WriteLine("[УВАГА] - Чарівник '{0}' атакує заклинанням '{1}' і наносить {2} од. шкоди!", name, spell, pushDamage);
            return pushDamage;
        }

        public override bool Damage(int attackDamage) // Перевизначений метод для отримання шкоди чарівником
        {
            health -= attackDamage; // Віднімання від загального здоров'я чарівника
            if (attackDamage == 0) // Якщо сила атаки противника була 0 
            {
                Console.WriteLine("-> Чарівник '{0}' у цьому раунді не отримує шкоди!", name);
                return false; // Повернення показника виживання
            }
            Console.WriteLine("-> Чарівник '{0}' отримує {1} од. шкоди! Залишок здоров'я: {2}", name, attackDamage, Math.Max(0, health));
            if (health <= 0) // Якщо здоров'я бійця менше 0
            {
                return true; // Повернення ознаки програшу
            }
            return false; // Повернення показника виживання
        }
    }
    internal class Program // Основний клас програми
    {
        public static Random rd = new Random(); // Створення посилання на об'єкт класу Random, що є доступним всюди
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
        
        static void Main(string[] args) // Головний метод програми
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Встановлення кодування консолі для коректоного виведення українських символів на екран
            Console.InputEncoding = System.Text.Encoding.UTF8; // Встановлення кодування консолі для коректного введення українських символів

            bool gameContinue = true; // Оголошення та ініціалізація флажка для ознаки заврешення програми

            Warrior warrior1 = new Warrior("Козак", 200, "Булава", 50); // Виклик конструтора для створення об'єкта класу Warrior
            Wizard wizard1 = new Wizard("Гендальф", 150, "Аварда Кедавра", 75); // Виклик конструтора для створення об'єкта класу Wizard
             
            // Якщо користувач не обрав персонажів, то за замовчуванням обираються наступні
            GameCharacter firstAttacker = warrior1; 
            GameCharacter secondAttacker = wizard1;

            while (gameContinue) // Основний цикл програми
            {
                Console.WriteLine("ГОЛОВНЕ МЕНЮ:\n\n1 - Обрати персонажа;\n2 - Переглянути характеритики доступних персонажів;" +
                    "\n3 - Почати бій (За замовчуванням обирається тип персонажу 'Боєць');\n4 - Вийти з програми.\n");
                int userChoice = Program.IntegerInput(1, 4, "Введіть Ваш вибір: ");

                switch (userChoice) // Обробка вибору користувача
                {
                    case 1:
                        Console.WriteLine("Оберіть персонажа:\n\n1 - Боєць;\n2 - Чарівник.\n");
                        int characterChoice = Program.IntegerInput(1, 2, "Введіть Ваш вибір: ");

                        switch(characterChoice)
                        {
                            case 1:
                                firstAttacker = warrior1;
                                secondAttacker = wizard1;
                                break;
                            case 2:
                                firstAttacker = wizard1;
                                secondAttacker = warrior1;
                                break;
                        }
                        Console.WriteLine("\n[УВАГА] - Персонажа успішно обрано!");
                        Console.WriteLine("\nНастисніть Enter, щоб провжити...");
                        Console.ReadLine(); // Очікування натискання клавіші Enter
                        Console.Clear(); // Очищення вмісту консолі
                        break;
                    case 2:
                        while (true)
                        {
                            warrior1.DisplayCharacterInfo();
                            Console.WriteLine();
                            wizard1.DisplayCharacterInfo();
                            Console.WriteLine("\nНатисніть Enter для виходу з даного пункту меню...");
                            Console.ReadLine(); // Очікування натискання клавіші Enter
                            Console.Clear(); // Очищення вмісту консолі
                            break;
                        }
                        break;
                    case 3:
                        Console.WriteLine("\n\t\t=== БІЙ ПОЧАВСЯ ===");
                        int iter = 0;
                        while (true)
                        {
                            iter++;
                            Console.WriteLine("\n\t\t--- РАУНД {0} ---", iter);
                            Console.WriteLine("\nНатисніть Enter, щоб зробити хід...");
                            Console.ReadLine(); // Очікування натискання клавіші Enter

                            int dmg1 = firstAttacker.Attack(); // Проведення атаки
                            bool isP2Dead = secondAttacker.Damage(dmg1); // Отримання шкоди

                            if (isP2Dead) // Якщо супротивника переможено 
                            { 
                                Console.WriteLine("\n[ПЕРЕМОГА] - Бій завершено! Ви перемогли!");
                                break; 
                            }

                            Console.WriteLine("\nНатисніть Enter, щоб супротивник зробив хід...");
                            Console.ReadLine(); // Очікування натискання клавіші Enter

                            int dmg2 = secondAttacker.Attack(); // Проведення атаки супротивником
                            bool isP1Dead = firstAttacker.Damage(dmg2); // Отримання шкоди від противника

                            if (isP1Dead) // Якщо гравець повністю знищений
                            {
                                Console.WriteLine("\n[ПОРАЗКА] - Бій завершено! Другий супротивник переміг!");
                                break; 
                            }
                        }

                        Console.WriteLine("\nНатисніть Enter для повернення в головне меню...");
                        Console.ReadLine(); // Очікування натискання клавіші Enter
                        Console.Clear(); // Очищення вмісту консолі
                        break;
                    case 4:
                        Console.WriteLine("\n[УВАГА] - Завершення програми...");
                        gameContinue = false;
                        break;
                }

            }
        }
    }
}
