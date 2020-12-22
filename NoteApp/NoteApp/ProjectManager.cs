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
        /// Имя сохраняемого файла.
        /// </summary>
        private const string fileName = @"/Note.json";
        //public static string PathFile()
        //{
        //    var path = PathDirectory();
        //    return path + @"/Note.json";
        //}

        public static string pathDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"/NoteApp/";

        /// <summary>
        /// Метод сериализации данных.
        /// </summary>
        /// <param name="project">Данные для сериализации.</param>
        /// <param name="filepath">Путь до файла</param>
        public static void SaveToFile(Project project, string filePath)
        {
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(pathDirectory);
            }
            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter(filePath + fileName))
            using (var writer = new JsonTextWriter(sw))
            {
                //Вызываем сериализацию и передаем объект, который хотим сериализовать.
                serializer.Serialize(writer, project);
            }
        }

        /// <summary>
        /// Метод десериализации данных.
        /// </summary>
        public static Project LoadFromFile(string filepath)
        {
            Project project;
            if (!Directory.Exists(filepath))
            {
                return new Project();
            }
            JsonSerializer serializer = new JsonSerializer();
            try
            {
                using (StreamReader sr = new StreamReader(filepath + fileName))
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
