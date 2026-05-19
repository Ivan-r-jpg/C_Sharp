using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab._16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private Bitmap bmp_for_draw; // Змінна для зберігання зображення, на якому буде відбуватися малювання
        private Point start_point; // Змінна для зберігання початкової точки при малюванні
        private bool dozvil; // Змінна для визначення, чи дозволено малювання (натиснута ліва кнопка миші)
        private Pen pen1 = new Pen(Color.Yellow, 5); // Створення пензля, який буде використовуватися для малювання
        private string full_name_of_image; // Змінна для зберігання повного шляху до відкритого зображення

        private void Form1_Load(object sender, EventArgs e) // Подія завантаження форми
        {
            this.Text = "Редагування картинки";
            button1.Text = "Огляд";
            button2.Text = "Зберегти";
            button3.Text = "Очистити";
        }

        private void button1_Click(object sender, EventArgs e) // Обробник події кліку на кнопку "Огляд"
        {
            OpenFileDialog open_dialog = new OpenFileDialog(); // Створення діалогового вікна для вибору файлу

            if (open_dialog.ShowDialog() == DialogResult.OK) // Якщо користувач вибрав файл і підтвердив вибір
            {
                // Спроба відкрити вибраний файл і відобразити його в PictureBox
                try
                {
                    full_name_of_image = open_dialog.FileName;
                    bmp_for_draw = new Bitmap(open_dialog.FileName);
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    pictureBox1.Image = bmp_for_draw;
                    pictureBox1.Invalidate();
                }
                catch
                {
                    DialogResult result = MessageBox.Show("It's impossible to open selected file");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) // Обробник події кліку на кнопку "Зберегти"
        {
            if (pictureBox1.Image != null) // Перевірка, чи є зображення в PictureBox перед збереженням
            {
                string format = full_name_of_image.Substring(full_name_of_image.Length - 5, 5); // Збереження формату файлу
                SaveFileDialog savedialog = new SaveFileDialog(); // Створення діалогового вікна для збереження файлу
                savedialog.Title = "Зберегти як ..."; // Встановлення заголовка діалогового вікна
                savedialog.OverwritePrompt = true; // Встановлення параметра, який запитує підтвердження перед перезаписом файлу
                savedialog.ShowHelp = true; // Встановлення параметра, який показує кнопку допомоги

                if (savedialog.ShowDialog() == DialogResult.OK) // Якщо користувач вибрав місце для збереження і підтвердив вибір
                {
                    // Спроба зберегти зображення у вибраному місці
                    try
                    {
                        bmp_for_draw.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("It's impossible to save image", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) // Обробник події кліку на кнопку "Очистити"
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(SystemColors.Window);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) // Обробник події руху миші над PictureBox
        {
            if (e.Button == MouseButtons.Left) // Якщо ліва кнопка миші натиснута
            {
                using (Graphics g = Graphics.FromImage(pictureBox1.Image)) // Створення посилання на об'єкт класу Graphics для малювання на зображенні
                {
                    if (dozvil == true) // Якщо дозволено малювання (натиснута ліва кнопка миші)
                    {
                        g.DrawLine(pen1, start_point, e.Location); // Малювання лінії від початкової точки до поточної позиції миші
                        start_point = e.Location; // Оновлення початкової точки для наступного малювання
                        pictureBox1.Invalidate(); // Оновлення PictureBox, щоб відобразити зміни на зображенні
                    }
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e) // Обробник події натискання кнопки миші над PictureBox
        {
            if (e.Button == MouseButtons.Left) // Якщо ліва кнопка миші натиснута
            {
                dozvil = true; // Дозволити малювання
                start_point = e.Location; // Зберегти початкову точку, де було натиснуто кнопку миші
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e) // Обробник події відпускання кнопки миші над PictureBox
        {
            if (e.Button == MouseButtons.Left) // Якщо ліва кнопка миші відпущена
            {
                dozvil = false; // Заборонити малювання
            }
        }
    }
}
