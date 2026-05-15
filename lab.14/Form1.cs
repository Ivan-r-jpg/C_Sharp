// Підключення просторів імен для роботи з формами
using System; 
using System.Windows.Forms;

namespace lab._14
{
    public partial class Form1 : Form // Клас форми, який похідний від базового класу Form
    {
        private void clearTextBoxes() // Метод для очищення текстових полів
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox1.Focus(); // Встановлюється фокус на перше текстове поле після очищення
        }
        private void CheckFields() // Метод для перевірки заповнення текстових полів
        {
            bool isXminOk = !string.IsNullOrWhiteSpace(textBox1.Text);
            bool isXmaxOk = !string.IsNullOrWhiteSpace(textBox2.Text);
            bool isDxOk = !string.IsNullOrWhiteSpace(textBox3.Text);
            bool isBOk = !string.IsNullOrWhiteSpace(textBox4.Text);

            button1.Enabled = isXminOk && isXmaxOk && isDxOk && isBOk; // Кнопка "Обчислити" буде активною лише тоді, коли всі текстові поля заповнені
        }
        public Form1() // Конструктор форми, який викликається при її створенні
        {
            InitializeComponent();
            button1.Enabled = false; // Кнопка "Обчислити" буде неактивною при завантаженні форми, поки користувач не введе всі необхідні дані
        }

        private void button1_Click(object sender, EventArgs e) // Обробник події для кнопки "Обчислити"
        {
            listBox1.Items.Clear(); // Очищення списку результатів перед новим обчисленням
            double xMin, xMax, step, b;
            // Спроба конвертації текстових значень у числові, з обробкою можливих помилок форматування
            try
            {
                xMin = Convert.ToDouble(textBox1.Text);
                xMax = Convert.ToDouble(textBox2.Text);
                step = Convert.ToDouble(textBox3.Text);
                b = Convert.ToDouble(textBox4.Text);
              
            }
            catch (FormatException) // Перехоплення виключення
            {
                MessageBox.Show("Будь ласка, введіть коректні числові значення у всі поля!", "Помилка вводу", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error); // Виведення повідомлення про помилку 
                clearTextBoxes(); // Очищення текстових полів після помилки
                return; 
            }
            if ((xMin < xMax && step < 0) || step == 0 || (xMin > xMax && step > 0)) // Додаткова перевірка логіки введених значень для Xmin, Xmax та dx
            {
                MessageBox.Show("Будь ласка, введіть коректні значення для Xmin, Xmax та dx!", "Помилка вводу", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error); // Виведення повідомлення про помилку 
                clearTextBoxes(); // Очищення текстових полів після помилки
                return;
            }
            for (double x = xMin; x <= xMax; x += step) // Цикл для обчислення значення y для кожного x в заданому діапазоні з певним кроком
            {
                if (b - x > 0 && b - x != 1) // Перевірка ОДЗ
                {
                    double y = (Math.Sign(Math.Sin(b * x) + Math.Cos(x)) * Math.Pow(Math.Abs(Math.Sin(b * x) + 
                        Math.Cos(x)), 1.0 / 3.0)) + (Math.Tan(b*x) / Math.Log(b - x));
                    listBox1.Items.Add("y = " + y + " при x = " + x); // Додавання результату до списку
                }
                else // Якщо x не задовольняє ОДЗ, то виводиться відповідне повідомлення
                {
                    listBox1.Items.Add("[УВАГА] - Значення х = " + x + " не задовольняє ОДЗ");
                }
            }

        }
        // Обробники подій для всіх текстових полів, які викликають метод CheckFields() при зміні тексту, щоб перевірити, чи всі поля заповнені
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CheckFields();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            CheckFields();
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            CheckFields();
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            CheckFields();
        }

        private void button2_Click(object sender, EventArgs e) // Обробник події для кнопки "Примусово очистити поля"
        {
            listBox1.Items.Clear(); // Очищення списку результатів
        }
    }
}
