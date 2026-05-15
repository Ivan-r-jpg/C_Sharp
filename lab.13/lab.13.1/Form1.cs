// Підключення простору імен
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace lab._13._1
{
    public partial class Form1 : Form // Клас форми
    {
        public Form1() // Конструктор форми
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // Обробник події натискання кнопки
        {
            
            Graphics g = Graphics.FromHwnd(this.Handle); // Створення посилання на об'єкт Graphics для малювання на формі

            // Налаштування параметрів пера, кисті та шрифту
            Pen myPen = new Pen(Color.BlueViolet);
            myPen.Width = 2;
            myPen.DashStyle = DashStyle.DashDot;

            HatchBrush myBrush = new HatchBrush(HatchStyle.Cross, Color.DeepPink); // Створення пензлика з візерунком
            
            Font myFont = new Font("Arial Black", 14); // Створення шрифту для тексту

            // Визначення координат та розмірів прямокутника
            int x = 250;
            int y = 140;
            int width = 300;
            int height = 150;

            Rectangle myRect = new Rectangle(x, y, width, height);

            g.FillRectangle(myBrush, myRect); // Заповнення прямокутника візерунком

            g.DrawRectangle(myPen, myRect); // Малювання контуру прямокутника

            Brush textBrush = Brushes.Yellow; // Створення пензлика для тексту

            g.DrawString("Мій прямокутник!", myFont, textBrush, x + 45, y + (height / 2) - 10); // Вставлення тексту всередину прямокутника

            button1.Enabled = false; // Вимкнення кнопки після натискання, щоб запобігти повторному малюванню
        }
    }
}
