using System;
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
            var note = new Note();
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
            var note = new Note();
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
            var note = new Note();
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
            var note = new Note();
            var sourceNoteText = "Допустим, что это корректные тестовые данные!";
            var expectedNoteText = sourceNoteText;

            // Act
            note.NoteText = sourceNoteText;
            var actNoteText = note.NoteText;

            // Assert 
            Assert.AreEqual(expectedNoteText, actNoteText);
        }
    }
}
