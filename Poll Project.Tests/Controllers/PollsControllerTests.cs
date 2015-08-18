﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            fakeDB.Polls = new FakeDbSet<Poll>();

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
    }
}