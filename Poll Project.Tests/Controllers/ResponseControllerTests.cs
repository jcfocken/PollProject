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
    public class ResponseControllerTests
    {
        [TestMethod]
        public void ResponseCreated()
        {
            // Arrange
            // Arrange
            var fakeDB = new FakePollContext();
            fakeDB.Polls = new FakePollSet();
            fakeDB.Questions = new FakeDbSet<Question>();
            fakeDB.Answers = new FakeDbSet<Answer>();
            fakeDB.Responses = new FakeResponseSet();
            fakeDB.Selections = new FakeDbSet<Selection>();

            var poll1 = new Poll { ID = 1, Title = "Hello" };
            fakeDB.Polls.Add(poll1);
            var answer1 = new Answer { ID = 1, Text = "Answer1", QuestionID = 1 };
            fakeDB.Answers.Add(answer1);
            var question1 = new Question { ID = 1, Poll = poll1, Text = "Question1", Answers = new List<Answer> { answer1 } };
            fakeDB.Questions.Add(question1);
            var selection1 = new Selection { ID = 1, Answer = answer1, AnswerID = 1 };
            fakeDB.Selections.Add(selection1);
            var response1 = new Response { ID = 1, Poll = poll1, Selections = new List<Selection> { selection1 } };
            fakeDB.Responses.Add(response1);

            ResponsesController controller = new ResponsesController(fakeDB);

            CreateResponseViewModel viewmodel = new CreateResponseViewModel
            {
                Poll = poll1,
                Selections = new List<int> { 1 }
            };
            // Act
            ViewResult result = controller.Create(viewmodel) as ViewResult;

            // Assert
            //
            Assert.AreEqual(fakeDB.Responses.Find(1).Selections.First().AnswerID, 1);
        }
    }
}
