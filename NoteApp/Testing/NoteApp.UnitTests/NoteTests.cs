using System;
using Newtonsoft.Json;
using NUnit.Framework;

namespace NoteApp.UnitTests
{
    [TestFixture]
    public class NoteTests
    {
        private Note _note;

        [SetUp]
        public void InitNote()
        {
            _note = new Note();
        }

        [Test]
        public void Title_GoodTitle_ReturnsSaveTitle()
        {
            // Setup
            var sourceTitle = "12345678901234567890123456789012345678901234567890";
            var expectedTitle = sourceTitle;

            // Act
            _note.Title = sourceTitle;
            var actTitle = _note.Title;

            // Assert
            Assert.AreEqual(expectedTitle, actTitle);
        }

        [Test]
        public void Title_TooLongTitle_ThrowsException()
        {
            // Setup
            var sourceTitle = "123456789012345678901234567890123456789012345678901";

            // Assert
            Assert.Throws<ArgumentException>
            (
                () =>
                {
                    // Act
                    _note.Title = sourceTitle;
                }
            );
        }

        [Test]
        public void Title_EmptyTitle_ReturnsDefaultTitle()
        {
            // Setup
            var sourceTitle = "";
            var expectedTitle = "Без названия";

            // Act
            _note.Title = sourceTitle;
            var actTitle = _note.Title;

            // Assert
            Assert.AreEqual(expectedTitle, actTitle);
        }

        [Test]
        public void NoteText_GoodNoteText_ReturnsSaveNoteText()
        {
            // Setup
            var sourceNoteText = "Допустим, что это корректные тестовые данные!";
            var expectedNoteText = sourceNoteText;

            // Act
            _note.NoteText = sourceNoteText;
            var actNoteText = _note.NoteText;

            // Assert 
            Assert.AreEqual(expectedNoteText, actNoteText);
        }

        [Test]
        public void Created_GoodCreated_ReturnsSaveCreated()
        {
            // Setup
            var sourceCreated = new DateTime(2020, 12, 01);
            var expectedCreated = sourceCreated;

            // Act
            _note.Created = sourceCreated;
            var actCreated = _note.Created;
            
            // Assert
            Assert.AreEqual( expectedCreated, actCreated);
        }

        [Test]
        public void Modified_GoodModified_ReturnsSaveModified()
        {
            // Setup
            var sourceModified = new DateTime(2020, 12, 01);
            var expectedModified = sourceModified;

            // Act
            _note.Modified = sourceModified;
            var actCreated = _note.Modified;

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
            var expectedClone = (Note) sourceClone.Clone(); /*JsonConvert.SerializeObject(sourceClone);*/

            // Assert 
            Assert.AreEqual(expectedClone, sourceClone);
        }
    }
}
