using System;
using System.Collections.Generic;
using System.Text;

namespace NoteApp
{   
    /// <summary>
    /// Класс, который содержит список всех заметок
    /// </summary>
    class Project
    {
        /// <summary>
        /// Содержит список всех заметок
        /// </summary>
        public List<Note> Notes { get; set; } = new List<Note>();
    }
}
