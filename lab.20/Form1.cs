using System; // Підключення простору імен System
using System.Windows.Forms; // Підключення простору імен для роботи з Windows Forms

namespace graf_Web_Browse
{
    public partial class Form1 : Form
    {
        public Form1() // Конструктор форми
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) // Завантаження форми
        {
            this.Text = "My Browser"; // Встановлення назви форми

            webBrowser1.ScriptErrorsSuppressed = true; // Вимкнення повідомлень про помилки скриптів

            // Заповнення ComboBox адресами сайтів
            comboBox1.Items.Clear();
            comboBox1.Items.Add("youtube.com");
            comboBox1.Items.Add("google.com");
            comboBox1.Items.Add("gmail.com");

            comboBox1.SelectedIndex = 1; // Вибір Google за замовчуванням
            textBox1.Text = "google.com";

            webBrowser1.Navigate("https://www.google.com"); // Відкриття початкової сторінки

            // Прив’язування додаткових обробників подій
            textBox1.KeyDown += textBox1_KeyDown;
            webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;
        }

        private string FixUrl(string text) // Метод для обробки введеної адреси або пошукового запиту
        {
            text = text.Trim();

            if (text == "")
                return "";

            if (!text.Contains(".")) // Якщо введено не адресу сайту, а звичайний запит
            {
                return "https://www.google.com/search?q=" + Uri.EscapeDataString(text);
            }

            if (!text.StartsWith("http://") && !text.StartsWith("https://")) // Якщо не вказано протокол
            {
                text = "https://" + text;
            }

            return text;
        }

        private void button1_Click(object sender, EventArgs e) // Обробник кнопки "Пошук"
        {
            string url = FixUrl(textBox1.Text); // Отримання правильної адреси

            if (url == "") // Перевірка на порожнє поле
            {
                MessageBox.Show(
                    "Введіть адресу сайту або пошуковий запит!",
                    "Увага",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                textBox1.Focus();
                return;
            }

            webBrowser1.Navigate(url); // Перехід за вказаною адресою
        }

        private void button2_Click(object sender, EventArgs e) // Обробник кнопки "Forward"
        {
            if (webBrowser1.CanGoForward) // Перевірка можливості переходу вперед
            {
                webBrowser1.GoForward();
            }
            else
            {
                MessageBox.Show(
                    "Немає сторінки для переходу вперед!",
                    "Увага",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void button3_Click(object sender, EventArgs e) // Обробник кнопки "Back"
        {
            if (webBrowser1.CanGoBack) // Перевірка можливості переходу назад
            {
                webBrowser1.GoBack();
            }
            else
            {
                MessageBox.Show(
                    "Немає сторінки для переходу назад!",
                    "Увага",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void button4_Click(object sender, EventArgs e) // Обробник кнопки "Home"
        {
            textBox1.Text = "google.com";
            webBrowser1.Navigate("https://www.google.com");
        }

        private void button5_Click(object sender, EventArgs e) // Обробник кнопки збереження сторінки
        {
            webBrowser1.ShowSaveAsDialog(); // Відкриття вікна збереження веб-сторінки
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) // Обробник зміни вибору в ComboBox
        {
            switch (comboBox1.SelectedIndex) // Вибір сайту залежно від індексу
            {
                case 0:
                    textBox1.Text = "youtube.com";
                    webBrowser1.Navigate("https://www.youtube.com");
                    break;

                case 1:
                    textBox1.Text = "google.com";
                    webBrowser1.Navigate("https://www.google.com");
                    break;

                case 2:
                    textBox1.Text = "gmail.com";
                    webBrowser1.Navigate("https://mail.google.com");
                    break;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e) // Обробник натискання клавіші Enter в TextBox
        {
            if (e.KeyCode == Keys.Enter) // Якщо натиснуто Enter
            {
                button1_Click(sender, e); // Виклик кнопки переходу
                e.SuppressKeyPress = true;
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) // Завершення завантаження сторінки
        {
            if (webBrowser1.Url != null)
            {
                textBox1.Text = webBrowser1.Url.ToString(); // Виведення поточної адреси в TextBox
            }
        }
    }
}