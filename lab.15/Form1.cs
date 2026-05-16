using System;
using System.Windows.Forms;

namespace lab._15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "Тут відображатимуться результати...";
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                button4.Enabled = true;
                textBox1.Text = listBox1.SelectedItem.ToString();
                System.Type w = listBox1.SelectedItem.GetType();
                textBox2.Text = w.ToString();

            }
            else
            {
                button4.Enabled = false;
                textBox1.Text = "Тут відображатимуться результати...";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = listBox1.Items.Count;
            textBox1.Text = "К-сть символьних рядків: " + count.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool found = listBox1.Items.Contains(textBox3.Text);
            if (found)
            {
                MessageBox.Show("Рядок знайдено!", "УВАГА", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Рядок не знайдено!", "УВАГА", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text = "Тут відображатимуться результати...";
                textBox3.Clear();
                textBox3.Focus();
            }
            int index = listBox1.Items.IndexOf(textBox3.Text);
            if (index != -1)
            {
                textBox3.Clear();
                textBox1.Text = "Номер шуканого рядка: " + (index + 1).ToString();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBox3.Text))
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox4.Text))
            {
                button3.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = 0;
            if(listBox1.SelectedIndex != -1)
            {
                index = listBox1.SelectedIndex;
            }
            listBox1.Items.Insert(index, textBox4.Text);
            textBox4.Clear();
            MessageBox.Show("Рядок успішно додано!", "УВАГА", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox4.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            textBox2.Clear();
            MessageBox.Show("Рядок успішно видалено!", "УВАГА", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bool found = listBox1.Items.Contains(textBox5.Text);
            if (found)
            {
                listBox1.Items.Remove(textBox5.Text);
                MessageBox.Show("Рядок успішно видалено!", "УВАГА", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox5.Clear();
                textBox5.Focus();
            }
            else
            {
                MessageBox.Show("Такого рядка для видалення не знайдено!", "УВАГА", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            MessageBox.Show("Всі рядки успішно видалено!", "УВАГА", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string[] items = { "Тарас Шевченко", "'Гайдамаки'", "7 квітня", "1841 року" };
            listBox1.Items.AddRange(items);
            MessageBox.Show("Рядки успішно додано!", "УВАГА", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox5.Text))
            {
                button6.Enabled = true;
            }
            else
            {
                button6.Enabled = false;
            }
        }
    }
}
