using System;
using System.Text;
using System.IO; // Підключення простору імен для роботи з файлами
using System.Windows.Forms;

namespace text_editor
{
    public partial class Form1 : Form
    {
        private string currentFilePath = ""; // Змінна для зберігання шляху до файлу

        public Form1() // Конструктор форми
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) // Обробник кнопки "Відкрити"
        {
            if (!AskToSaveChanges()) // Якщо користувач скасував дію, то відкриття файлу не виконується
            { 
                return; 
            }

            if (openFileDialog1.ShowDialog() == DialogResult.OK) // Якщо користувач вибрав файл і підтвердив відкриття
            {
                currentFilePath = openFileDialog1.FileName;

                textBox1.Text = File.ReadAllText(currentFilePath, Encoding.UTF8); // Зчитування всього тексту із вибраного файлу

                textBox1.Modified = false; // Після відкриття файл ще не змінений

                this.Text = "Текстовий редактор - " + Path.GetFileName(currentFilePath); // Встановлення оновленої назви для форми 
                
                saveFileDialog1.FileName = currentFilePath; // Збереження шляху до вибраного файлу
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) // Обробник натискання кнопки "Зберегти як"
        {
            SaveTextAs(); // Виклик методу для збереження файлу
        }

        private bool SaveTextAs()
        {
            if (!string.IsNullOrEmpty(currentFilePath)) // Якщо файл уже був відкритий, то пропонується збереження під тим самим іменем
            {
                saveFileDialog1.FileName = currentFilePath; // Збереження шляху до вибраного файлу
            }

            if (saveFileDialog1.ShowDialog() == DialogResult.OK) // Якщо користувач натиснув "Ок" при збереженні файла
            {
                currentFilePath = saveFileDialog1.FileName; // Збереження шляху до цього файлу

                File.WriteAllText(currentFilePath, textBox1.Text, Encoding.UTF8); // Запис тексту із textBox1 у файл

                textBox1.Modified = false; // Після збереження змін уже немає

                this.Text = "Текстовий редактор - " + Path.GetFileName(currentFilePath); // Встановлення оновленої назви для форми

                return true;
            }

            return false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) // Обробник кнопки "Вийти"
        {
            this.Close(); // Закриття форми
        }

        private void Form1_Load(object sender, EventArgs e) // Завантаження форми
        {
            this.Text = "Текстовий редактор"; // Встановлення назви форми

            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"; // Встановлення пропонованих та доступних розширень для відкриття файлів
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"; // Встановлення пропонованих та доступних розширень для збереження файлів

            saveFileDialog1.DefaultExt = "txt"; // Встановлення стандартного розширення для файлів
            saveFileDialog1.AddExtension = true; // Встановлення можливості автоматично додавати розширення навіть якщо користувач його не вказав
            saveFileDialog1.OverwritePrompt = true; // Запитує, чи замінити файл, якщо він уже існує

            textBox1.Modified = false; // При запуску форми текст ще не змінювався
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) // Процес закриття форми
        {
            if (!AskToSaveChanges())  // Якщо користувач скасував дію, то закриття форми скасовується
            {
                e.Cancel = true;
            }
        }

        private bool AskToSaveChanges() // Метод, що запитує чи зберегти внесені зміни
        {
            if (textBox1.Modified == false) // Якщо текстове поле не було змінене
            { 
                return true; 
            }

            DialogResult result = MessageBox.Show(
                "Текст був змінений. Зберегти зміни?",
                "Закрити вікно",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question
            ); // Виклик діалогового вікна

            if (result == DialogResult.No) // Якщо користувач натиснув "Ні"
            { 
                return true; 
            }

            if (result == DialogResult.Cancel) // Якщо користувач натиснув "Відмінити"
            { 
                return false; 
            }

            if (result == DialogResult.Yes) // Якщо користувач натиснув "Так"
            { 
                return SaveTextAs(); // Виклик методу для збереження файлу
            }

            return true;
        }
    }
}
