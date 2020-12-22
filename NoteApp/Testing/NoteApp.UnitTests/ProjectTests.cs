using System;
using NUnit.Framework;

namespace NoteApp.UnitTests
{
    [TestFixture]
    public class ProjectTests
    {
        [Test]
        public void Project_CreateProject_ReturnsNotEmptyProject()
        {
            // Act
            Project actProject = new Project();

            // Assert 
            Assert.IsNotNull(actProject);
        }
    }
}
