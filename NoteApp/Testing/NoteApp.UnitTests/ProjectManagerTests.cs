using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;

namespace NoteApp.UnitTests
{
    public class ProjectManagerTests
    {
        public Project PrepareProject()
        {
            var sourceProject = new Project();
            sourceProject.Notes.Add(new Note()
            {
                Title = "Title",
                NoteText = "NoteText",
                Category = NoteCategory.Documents,
                Created = new DateTime(2020, 12, 12),
                Modified = new DateTime(2020, 12, 12)
            });
            sourceProject.Notes.Add(new Note()
            {
                Title = "Title1",
                NoteText = "NoteText1",
                Category = NoteCategory.Finance,
                Created = new DateTime(2020, 12, 12),
                Modified = new DateTime(2020, 12, 12)
            });
            return sourceProject;
        }

        [Test]
        public void SaveToFile_CorrectProject_FileSavedCorrectly()
        {
            // Setup
            var sourceProject = PrepareProject(); 
            var location = Assembly.GetExecutingAssembly().Location;
            var directoryTestData = Directory.CreateDirectory(Path.GetDirectoryName(location) + @"\TestData");
            var actualFileName = directoryTestData + @"\actualProject.json";
            var expectedFileName = directoryTestData + @"\expectedProject.json";

            if (File.Exists(actualFileName))
            {
                File.Delete(actualFileName);
            }

            // Act
            ProjectManager.SaveToFile(sourceProject, actualFileName);

            // Assert
            var actualFileContent = File.ReadAllText(actualFileName);
            var expectedFileContent = File.ReadAllText(expectedFileName);
            Assert.AreEqual(expectedFileContent, actualFileContent);

        }

        [Test]
        public void LoadFromFile_CorrectProject_FileLoadCorrectly()
        {
            // Setup
            var sourceProject = PrepareProject();
            var location = Assembly.GetExecutingAssembly().Location;
            var directoryTestData = Directory.CreateDirectory(Path.GetDirectoryName(location) + @"\TestData");
            var expectedFileName = directoryTestData + @"\expectedProject.json";

            // Act
            var actualProject = ProjectManager.LoadFromFile(expectedFileName);

            // Assert
            Assert.AreEqual(sourceProject.Notes.Count, actualProject.Notes.Count);
            Assert.Multiple(() =>
            {
                for (int i = 0; i < sourceProject.Notes.Count; i++)
                {
                    Assert.AreEqual(sourceProject.Notes[i], actualProject.Notes[i]);
                }
            });
        }

        [Test]
        public void LoadFromFile_NoCorrectProject_CreatedNewProject()
        {
            // Setup
            var location = Assembly.GetExecutingAssembly().Location;
            var directoryTestData = Directory.CreateDirectory(Path.GetDirectoryName(location) + @"\TestData");
            var expectedFileName = directoryTestData + @"\noCorrectProject.json";

            // Act
            var actualProject = ProjectManager.LoadFromFile(expectedFileName);

            // Assert
            Assert.NotNull(actualProject);
        }

        [Test]
        public void DefaultPath_GoodDefaultPath_ReturnsSaveDefaultPath()
        {
            // Setup
            var expectedDefaultPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\NoteApp\Note.notes";

            // Act
            var actualDefaultPat = ProjectManager.DefaultPath;

            // Assert
            Assert.AreEqual(expectedDefaultPath, actualDefaultPat);

        }
    }
}
