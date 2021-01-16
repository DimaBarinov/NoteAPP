using System;
using System.Collections.Generic;
using System.Linq;

namespace NoteApp
{
    /// <summary>
    /// Класс, который содержит список всех заметок
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Содержит список всех заметок
        /// </summary>
        public List<Note> Notes = new List<Note>();
       
        /// <summary>
        /// Текущий индекс заметки
        /// </summary>
        public int CurrentIndexNote { get; set; }

        public List<Note> SortByEditing(List<Note> _notesToSort)
        {
            return _notesToSort = _notesToSort.OrderByDescending(item => item.Modified).ToList();
        }
        public List<Note> SortByEditing(List<Note> _notesToSort, NoteCategory category)
        {
            return _notesToSort = _notesToSort.Where(item => item.Category == category).OrderByDescending(item => item.Modified).ToList();
        }
    }
}
