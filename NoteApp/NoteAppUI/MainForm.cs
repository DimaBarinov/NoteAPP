using System;
using System.Windows.Forms;
using NoteApp;

namespace NoteAppUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Note note = new Note
            {
                Category = NoteCategory.Documents,
                Title = "Тест1",
                NoteText = "Test noteText!"
            };
            ///Сохранение в файл
            Project serialize = new Project { Notes = { note } };
            ProjectManager.SaveFile(serialize, filepath());

            ///Загрузка из файла
            Project deserializa = ProjectManager.LoadFile(filepath());
        }

        /// <summary>
        /// Путь сохранения файла
        /// </summary>
        private static string filepath()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return path + @"\NoteApp\Note.txt";
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
        }


    }
}
