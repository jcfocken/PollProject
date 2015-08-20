using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poll_Project.Controllers;
using Poll_Project.Models;
using Poll_Project.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Poll_Project.Tests.FakeDB;

namespace Poll_Project.Controllers.Tests
{
    [TestClass()]
    public class PollsControllerTests
    {
        [TestMethod()]
        public void PollsPassedToIndexView()
        {
            // Arrange
            var fakeDB = new FakePollContext();
            fakeDB.Polls = new FakePollSet();

            var poll = new Poll { ID = 1, Title = "Hello" };
            fakeDB.Polls.Add(poll);
            var poll2 = new Poll { ID = 2, Title = "world" };
            fakeDB.Polls.Add(poll2);

            PollsController controller = new PollsController(fakeDB);

            // Act
            ViewResult result = controller.Index() as ViewResult;
            IEnumerable<Poll> polls = result.ViewData.Model as IEnumerable<Poll>;

            // Assert
            Assert.AreEqual(polls.ElementAt(0).Title , "Hello");
            Assert.AreEqual(polls.ElementAt(1).Title, "world");
        }

        [TestMethod()]
        public void PollPassedToDetailsView()
        {
            // Arrange
            var fakeDB = new FakePollContext();
            fakeDB.Polls = new FakePollSet();

            var poll = new Poll { ID = 1, Title = "Hello" };
            fakeDB.Polls.Add(poll);
            var poll2 = new Poll { ID = 2, Title = "world" };
            fakeDB.Polls.Add(poll2);

            PollsController controller = new PollsController(fakeDB);

            // Act
            ViewResult result = controller.Details(1) as ViewResult;
            DetailsPollViewModel resultPoll = result.ViewData.Model as DetailsPollViewModel;

            // Assert
            Assert.AreEqual(resultPoll.Poll.Title, "Hello");

            // Act
            ViewResult result2 = controller.Details(2) as ViewResult;
            DetailsPollViewModel resultPoll2 = result2.ViewData.Model as DetailsPollViewModel;

            // Assert
            Assert.AreEqual(resultPoll2.Poll.Title, "world");
        }


        [TestMethod()]
        public void PollPassedToPollResultView()
        {
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


            PollsController controller = new PollsController(fakeDB);

            // Act
            ViewResult result = controller.Results(1) as ViewResult;
            PollResultsViewModel viewmodel = result.ViewData.Model as PollResultsViewModel;

            // Assert
            Assert.AreEqual(viewmodel.Poll.Title, "Hello");
        }

        [TestMethod()]
        public void ResponsesCountPassedToPollResultView()
        {
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


            PollsController controller = new PollsController(fakeDB);

            // Act
            ViewResult result = controller.Results(0) as ViewResult;
            PollResultsViewModel viewmodel = result.ViewData.Model as PollResultsViewModel;

            // Assert
            Assert.AreEqual(viewmodel.numOfResponses, 1);
        }

    }
}