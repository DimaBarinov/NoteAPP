using System;
using System.IO;
using Newtonsoft.Json;

namespace NoteApp
{
    /// <summary>
    /// Класс менеджера проекта
    /// </summary>
    public static class ProjectManager
    {
        /// <summary>
        /// Путь по которому сохраняется файл.
        /// </summary>
        public static string PathFile()
        {
            var path = PathDirectory();
            return path + @"\Note.txt";
        }

        /// <summary>
        /// Папка в которую сохраняется файл.
        /// </summary>
        public static string PathDirectory()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return path + @"\NoteApp\";
        }

        /// <summary>
        /// Метод сериализации данных.
        /// </summary>
        /// <param name="project">Данные для сериализации.</param>
        /// <param name="filepath">Путь до файла</param>
        public static void SaveFile(Project project, string filepath)
        {
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(PathDirectory());
            }
            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter(filepath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                //Вызываем сериализацию и передаем объект, который хотим сериализовать.
                serializer.Serialize(writer, project);
            }
        }

        /// <summary>
        /// Метод десериализации данных.
        /// </summary>
        public static Project LoadFile(string filepath)
        {
            Project project;
            if (!Directory.Exists(filepath))
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
