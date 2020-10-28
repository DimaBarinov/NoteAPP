using System;

namespace NoteApp
{
    public class Note //: ICloneable
    {

        /// <summary>
        /// Название заметки
        /// </summary>
        private string _title;

        /// <summary>
        /// Категории заметки
        /// </summary>
        private string _noteCategory;
        
        /// <summary>
        /// Текст заметки
        /// </summary>
        private string _noteText;

        /// <summary>
        /// Время создания заметки
        /// </summary>
        private DateTime _timeCreate;

        /// <summary>
        /// Время последнего изменения заметки
        /// </summary>
        private DateTime _timeLastChange;


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
                    if (value != String.Empty)
                    {
                        _title = value;
                    }
                    else
                    {
                        _title = "Без названия";
                    }
                    TimeLastChange = DateTime.Now;
                }
            }
        }

        /// <summary>
        /// Свойство категории заметки
        /// </summary>
        public string NoteCategory
        {
            get => _noteCategory;
            set
            {
                _noteCategory = value;
                TimeLastChange = DateTime.Now;
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
                TimeLastChange = DateTime.Now;
            }
        }

        /// <summary>
        /// Свойство времени создания заметки
        /// </summary>
        public DateTime TimeCreate
        {
            get => _timeCreate;
        }

        /// <summary>
        /// Свойство времени последнего редактирования заметки
        /// </summary>
        public DateTime TimeLastChange
        {
            get => _timeLastChange;
            set
            {
                _timeLastChange = DateTime.Now;
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
                NoteCategory = this.NoteCategory,
                NoteText = this.NoteText,
                TimeLastChange = this.TimeLastChange,
            };
        }
    }
}
