using System;
using NoteApp;
using System.Windows.Forms;
using System.Drawing;

namespace NoteAppUI
{
    public partial class NoteForm : Form
    {
        private Note _tempNote = new Note();

        /// <summary>
        /// Временное хранилище данных
        /// </summary>
        public Note TempNote
        {
            get => _tempNote;
            set
            {
                _tempNote = value;
                TitleTextBox.Text = value.Title;
                NoteTextTextBox.Text = value.NoteText;
                CategoryComboBox.Text = value.Category.ToString();
                CreatedDateTimePicker.Value = value.Created;
                ModifiedDateTimePicker.Value = value.Modified;
            }
        }

        public NoteForm()
        {
            InitializeComponent();
            CategoryComboBox.DataSource = Enum.GetValues(typeof(NoteCategory));
        }

        /// <summary>
        /// OK
        /// </summary>
        private void OkButton_Click(object sender, EventArgs e)
        {
            NewNote();
        }

        /// <summary>
        /// Cancel
        /// </summary>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void NewNote()
        {
            try
            {
                string text = TitleTextBox.Text;
                TempNote.Title = text;
                TempNote.NoteText = NoteTextTextBox.Text;
                TempNote.Created = CreatedDateTimePicker.Value;
                TempNote.Modified = ModifiedDateTimePicker.Value;
                TempNote.Category = (NoteCategory)CategoryComboBox.SelectedItem;
                DialogResult = DialogResult.OK;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void TitleTextBox_TextChanged(object sender, EventArgs e)
        {
            if (TitleTextBox.Text.Length > 50)
            {
                TitleTextBox.BackColor = Color.LightCoral;
            }
            else
            {
                TitleTextBox.BackColor = Color.White;
            }
        }
    }
}
