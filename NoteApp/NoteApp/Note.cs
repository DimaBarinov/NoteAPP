using System;

namespace NoteApp
{
    /// <summary>
    /// Класс содержит основную информацию о заметке
    /// </summary>
    public class Note : Project, ICloneable
    {

        /// <summary>
        /// Название заметки
        /// </summary>
        private string _title;

        /// <summary>
        /// Категории заметки
        /// </summary>
        private NoteCategory _сategory;

        /// <summary>
        /// Текст заметки
        /// </summary>
        private string _noteText;

        /// <summary>
        /// Время создания заметки
        /// </summary> 
        private DateTime _сreated;

        /// <summary>
        /// Время последнего изменения заметки
        /// </summary>
        private DateTime _modified;


        /// <summary>
        /// Свойство названия заметки
        /// Длина названия заметки не должна превышать 50 символов
        /// Название по умолчанию - "Без названия"
        /// </summary>
        public string Title
        {
            get => _title;
            set
            {
                if (value.ToString().Length > 50)
                {
                    throw new ArgumentException("Длина названия не должна превышать 50 символов");
                }
                else
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        _title = "Без названия";
                    }
                    else
                    {
                        _title = value;
                    }
                    Modified = DateTime.Now;
                }
            }
        }

        /// <summary>
        /// Свойство категории заметки
        /// </summary>
        public NoteCategory Category
        {
            get => _сategory;
            set
            {
                _сategory = value;
                Modified = DateTime.Now;
            }

        }

        /// <summary>
        /// Свойство текста заметки
        /// </summary>
        public string NoteText
        {
            get => _noteText;
            set
            {
                _noteText = value;
                Modified = DateTime.Now;
            }
        }

        /// <summary>
        /// Свойство времени создания заметки
        /// </summary>
        public DateTime Created { get; set; } = DateTime.Now;

        /// <summary>
        /// Свойство времени последнего редактирования заметки
        /// </summary>
        public DateTime Modified { get; set; } = DateTime.Now;

        /// <summary>
        /// Метод клонирования
        /// </summary>
        /// <returns>Возвращает копию класса Note</returns>
        public object Clone()
        {
            return new Note
            {
                Title = this.Title,
                Category = this.Category,
                NoteText = this.NoteText,
                Created = this.Created,
                Modified = this.Modified,
            };
        }

        public override bool Equals(object obj)
        {
            if (obj is Note note)
            {
                return (note.Title == this.Title) &&
                       (note.NoteText == this.NoteText) &&
                       (note.Created == this.Created) &&
                       (note.Modified == this.Modified) &&
                       (note.Category == this.Category);
            }
            return false;
        }

    }
}
