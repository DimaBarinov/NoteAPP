using System;
using Newtonsoft.Json;
using NUnit.Framework;

namespace NoteApp.UnitTests
{
    [TestFixture]
    public class NoteTests
    {

        [Test]
        public void Title_GoodTitle_ReturnsSaveTitle()
        {
            // Setup
            Note note = new Note();
            var sourceTitle = "12345678901234567890123456789012345678901234567890";
            var expectedTitle = sourceTitle;

            // Act
            note.Title = sourceTitle;
            var actTitle = note.Title;

            // Assert
            Assert.AreEqual(expectedTitle, actTitle);
        }

        [Test]
        public void Title_TooLongTitle_ThrowsException()
        {
            // Setup
            Note note = new Note();
            var sourceTitle = "123456789012345678901234567890123456789012345678901";

            // Assert
            Assert.Throws<ArgumentException>
            (
                () =>
                {
                    // Act
                    note.Title = sourceTitle;
                }
            );
        }

        [Test]
        public void Title_EmptyTitle_ReturnsDefaultTitle()
        {
            // Setup
            Note note = new Note();
            var sourceTitle = "";
            var expectedTitle = "Без названия";

            // Act
            note.Title = sourceTitle;
            var actTitle = note.Title;

            // Assert
            Assert.AreEqual(expectedTitle, actTitle);
        }

        [Test]
        public void NoteText_GoodNoteText_ReturnsSaveNoteText()
        {
            // Setup
            Note note = new Note();
            var sourceNoteText = "Допустим, что это корректные тестовые данные!";
            var expectedNoteText = sourceNoteText;

            // Act
            note.NoteText = sourceNoteText;
            var actNoteText = note.NoteText;

            // Assert 
            Assert.AreEqual(expectedNoteText, actNoteText);
        }

        [Test]
        public void Created_GoodCreated_ReturnsSaveCreated()
        {
            // Setup
            Note note = new Note();
            var sourceCreated = new DateTime(2020, 12, 01);
            var expectedCreated = sourceCreated;

            // Act
            note.Created = sourceCreated;
            var actCreated = note.Created;
            
            // Assert
            Assert.AreEqual( expectedCreated, actCreated);
        }

        [Test]
        public void Modified_GoodModified_ReturnsSaveModified()
        {
            // Setup
            Note note = new Note();
            var sourceModified = new DateTime(2020, 12, 01);
            var expectedModified = sourceModified;

            // Act
            note.Modified = sourceModified;
            var actCreated = note.Modified;

            // Assert
            Assert.AreEqual(expectedModified, actCreated);
        }

        [Test]
        public void Clone_GoodClone_ReturnsSaveClone()
        {
            // Setup
            var sourceClone = new Note
            {
                Title = "TestTitle",
                NoteText = "TestNoteText",
                Category = NoteCategory.Others,
                Created = new DateTime(2020, 12, 01),
                Modified = new DateTime(2020, 12, 01)
            };
            var expectedClone = (Note) sourceClone.Clone();

            // Assert 
            Assert.AreEqual(expectedClone, sourceClone);
        }
    }
}
