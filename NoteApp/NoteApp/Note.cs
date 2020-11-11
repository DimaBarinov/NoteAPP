using System;

namespace NoteApp
{
    public class Note : ICloneable
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
        private readonly DateTime _сreate = DateTime.Now;

        /// <summary>
        /// Время последнего изменения заметки
        /// </summary>
        private DateTime _modify;


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
                    if (string.IsNullOrEmpty (value))
                    {
                        _title = "Без названия";
                    }
                    else
                    {
                        _title = value;
                    }
                    Modify = DateTime.Now;
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
                Modify = DateTime.Now;
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
                Modify = DateTime.Now;
            }
        }

        /// <summary>
        /// Свойство времени создания заметки
        /// </summary>
        public DateTime Create
        {
            get => _сreate;
        }

        /// <summary>
        /// Свойство времени последнего редактирования заметки
        /// </summary>
        public DateTime Modify
        {
            get => _modify;
            set
            {
                _modify = DateTime.Now;
            }
        }

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
                Modify = this.Modify,
            };
        }
        
    }
}
