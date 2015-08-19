using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poll_Project.Tests.FakeDB;
using Poll_Project.DAL;
using Poll_Project.Models;
using Poll_Project.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Poll_Project.Tests.Controllers
{
    [TestClass]
    public class PollsControllerTests
    {
        [TestMethod]
        public void PollPassedToQuestionCreateView()
        {
            // Arrange
            var fakeDB = new FakePollContext();
            fakeDB.Polls = new FakePollSet();
            fakeDB.Questions = new FakeDbSet<Question>();

            var poll = new Poll { ID = 1, Title = "Hello" };
            fakeDB.Polls.Add(poll);
            var poll2 = new Poll { ID = 2, Title = "world" };
            fakeDB.Polls.Add(poll2);

            QuestionsController controller = new QuestionsController(fakeDB);

            // Act
            ViewResult result = controller.Create("1") as ViewResult;
            CreateQuestionViewModel generatedViewModel = result.ViewData.Model as CreateQuestionViewModel;

            // Assert
            Assert.AreEqual(generatedViewModel.Poll.Title, "Hello");
        }
    }
}
