using System;
using System.IO;
using Newtonsoft.Json;

namespace NoteApp
{
    /// <summary>
    /// Класс менеджера проекта
    /// </summary>
    class ProjectManadger
    {
        /// <summary>
        /// Путь по которому сохраняется файл.
        /// </summary>
        public string PathFile()
        {
            var filepath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return filepath + @"\NoteApp\Note.json";
        }

        /// <summary>
        /// Метод сериализации данных.
        /// </summary>
        /// <param name="data">Данные для сериализации.</param>
        /// <param name="filepath">Путь до файла</param>
        public void SaveFile(Project data, string filepath)
        {
            if (filepath == null)
            {
                filepath = PathFile();
            }
            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter(filepath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                //Вызываем сериализацию и передаем объект, который хотим сериализовать.
                serializer.Serialize(writer, data);
            }
        }

        /// <summary>
        /// Метод десериализации данных.
        /// </summary>
        public Project LoadFile(string filepath)
        {
            Project project;
            if (!File.Exists(filepath))
            {
                return new Project();
            }
            JsonSerializer serializer = new JsonSerializer();
            try
            {
                using (StreamReader sr = new StreamReader(filepath))
                using (JsonReader reader = new JsonTextReader(sr))
                    project = serializer.Deserialize<Project>(reader);
            }
            catch
            {
                return new Project();
            }
            return project;
        }
    }
}
