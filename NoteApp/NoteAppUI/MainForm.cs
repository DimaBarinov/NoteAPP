using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using NoteApp;

namespace NoteAppUI
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Данные, которые будем передавать
        /// </summary>
        private Project _project = new Project();

        public MainForm()
        {
            InitializeComponent();
            CategoryComboBox.DataSource = Enum.GetValues(typeof(NoteCategory));
        }

        /// <summary>
        /// Добавление новой заметки
        /// </summary>
        private void AddNote()
        {
            NoteForm addNote = new NoteForm();
            DialogResult dialogResult = addNote.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                _project.Notes.Add(addNote.TempNote);
                NoteListBox.Items.Add(addNote.TempNote.Title);
                ProjectManager.SaveToFile(_project, ProjectManager.PathDirectory());
            }
        }

        private void EditNote()
        {
            if (NoteListBox.SelectedIndex != -1)
            {
                var selectedIndex = NoteListBox.SelectedIndex;
                var selectedNote = _project.Notes[selectedIndex];
                NoteForm editNote = new NoteForm { TempNote = selectedNote };
                DialogResult dialogResul = editNote.ShowDialog();
                if (dialogResul == DialogResult.OK)
                {
                    _project.Notes.RemoveAt(selectedIndex);
                    NoteListBox.Items.RemoveAt(selectedIndex);
                    _project.Notes.Insert(selectedIndex, editNote.TempNote);
                    NoteListBox.Items.Insert(selectedIndex, editNote.TempNote.Title);
                    NoteListBox.SelectedIndex = selectedIndex;
                    ProjectManager.SaveToFile(_project, ProjectManager.PathDirectory());
                }
            }
        }

        private void DeleteNote()
        {
            if(NoteListBox.SelectedIndex != -1)
            {
                DialogResult dialogResult = MessageBox.Show("Do you really want to remove this note: " + _project.Notes[NoteListBox.SelectedIndex].Title + "?",
                    "Are you sure", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if(dialogResult == DialogResult.OK)
                {
                    _project.Notes.RemoveAt(NoteListBox.SelectedIndex);
                    NoteListBox.Items.RemoveAt(NoteListBox.SelectedIndex);
                    ProjectManager.SaveToFile(_project, ProjectManager.PathDirectory());
                }
                RemoveSelection();
            }
        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void AddNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNote();
        }

        private void AddNoteButton_Click(object sender, EventArgs e)
        {
            AddNote();
        }

        private void editNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditNote();
        }

        private void EditNoteButton_Click(object sender, EventArgs e)
        {
            EditNote();
        }

        private void RempveNoteButton_Click(object sender, EventArgs e)
        {
            DeleteNote();
        }

        private void removeNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteNote();
        }

        private void NotesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NoteListBox.SelectedIndex >= 0)
            {
                var selectedIndex = NoteListBox.SelectedIndex;
                TitleLabel.Text = _project.Notes[selectedIndex].Title;
                Categorylabel.Text = _project.Notes[selectedIndex].Category.ToString();
                CreatedDateTimePicker.Value = _project.Notes[selectedIndex].Created;
                ModifiefDateTimePicker.Value = _project.Notes[selectedIndex].Modified;
                NoteTextTextBox.Text = _project.Notes[selectedIndex].NoteText;
            }
        }

        private void RemoveSelection()
        {
                NoteListBox.ClearSelected();
                TitleLabel.Text = "";
                Categorylabel.Text = "";
                CreatedDateTimePicker.Value = DateTime.Now;
                ModifiefDateTimePicker.Value = DateTime.Now;
                NoteTextTextBox.Text = "";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _project = ProjectManager.LoadToFile(ProjectManager.PathDirectory());
            foreach (var item in _project.Notes)
            {
                NoteListBox.Items.Add(item.Title);
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProjectManager.SaveToFile(_project, ProjectManager.PathDirectory());
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }
    }
}
