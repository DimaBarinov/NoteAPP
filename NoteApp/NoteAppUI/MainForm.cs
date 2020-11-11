using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using NoteApp;

namespace NoteAppUI
{
    public partial class MainForm : Form
    {   
        public MainForm()
        {
            InitializeComponent();
            ColorComboBox.Items.Add(NoteCategory.Documents);
            ColorComboBox.Items.Add(NoteCategory.Finance);
            ColorComboBox.Items.Add(NoteCategory.House);
            ColorComboBox.Items.Add(NoteCategory.Job);
            ColorComboBox.Items.Add(NoteCategory.People);
            ColorComboBox.Items.Add(NoteCategory.Sport);
            ColorComboBox.Items.Add(NoteCategory.Others);
            ColorComboBox.SelectedIndex = 0;


            Note note = new Note
            {
                Category = NoteCategory.Documents,
                Title = "Тест2",
                NoteText = "Test noteText!"
            };
            ///Сохранение в файл
            Project serialize = new Project { Notes = { note } };
            ProjectManager.SaveToFile(serialize, ProjectManager.PathFile());

            ///Загрузка из файла
            Project deserializa = ProjectManager.LoadToFile(ProjectManager.PathFile());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void ColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NumberTextBox_TextChanged(object sender, EventArgs e)
        {
            string text = NumberTextBox.Text;
            int number;
            if (int.TryParse(text, out number))
            {
                if (number >= 0 && number <= 100)
                {
                    this.Text = number.ToString();
                }
                else
                {
                    this.Text = "Число не входит в диапазон";
                    NumberTextBox.BackColor = Color.OrangeRed;
                }
            }
            else
            {
                this.Text = "Не число";
                NumberTextBox.BackColor = Color.Aquamarine;
            }
        }

        private void VisibilityCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = VisibilityCheckBox.Checked;
            VisibilityCheckBox.Checked = true;
            ColorComboBox.Enabled = isChecked;
        }

        private void LabelTextBox_Click(object sender, EventArgs e)
        {

        }

        private void LabelComboBox_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NotesForm NF = new NotesForm();
            NF.Show();
        }
    }
}
