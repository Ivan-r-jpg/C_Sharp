// Підключення основних директив для роботи з формами
using System;
using System.Windows.Forms;

namespace lab._13._2
{
    public partial class Form2 : Form // Клас Form1
    {
        public Form2() // Конструктор класу
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) // Обробник події для першої круглої кнопки
        {
            if (radioButton1.Checked) // Якщо перша кнопка обрана
            {
                checkBox1.Checked = true;
                checkBox2.Checked = false;
                checkBox3.Checked = true;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                textBox1.Text = "До сплати: 350 грн!";  
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) // Обробник події для другої круглої кнопки
        {
            if (radioButton2.Checked) // Якщо друга кнопка обрана
            {
                checkBox1.Checked = false;
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = false;
                checkBox5.Checked = true;
                textBox1.Text = "До сплати: 500 грн!";
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e) // Обробник події для третьої круглої кнопки
        {
            if (radioButton3.Checked) // Якщо третя кнопка обрана
            {
                checkBox1.Checked = false;
                checkBox2.Checked = true;
                checkBox3.Checked = false;
                checkBox4.Checked = true;
                checkBox5.Checked = true;
                textBox1.Text = "До сплати: 760 грн!";
            }
        }
    }
}
