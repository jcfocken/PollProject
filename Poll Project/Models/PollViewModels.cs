using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poll_Project.Models
{
    public class EditPollViewModel
    {
        public EditPollViewModel(Poll poll)
        {
            Poll = poll;
            Questions = poll.Questions;
        }

        public Poll Poll { get; set; }
        public ICollection<Question> Questions { get; set; }

    }

    public class DetailsPollViewModel
    {
        public DetailsPollViewModel(Poll poll)
        {
            Poll = poll;
            Questions = poll.Questions;
        }

        public Poll Poll { get; set; }
        public ICollection<Question> Questions { get; set; }

    }

    public class CreateQuestionViewModel
    {
        public CreateQuestionViewModel()
        {
        }

        public Poll Poll { get; set; }
        public Question Question { get; set; }

    }

    public class CreateResponseViewModel
    {
        public CreateResponseViewModel()
        {
        }

        public Poll Poll { get; set; }
        public Response Response { get; set; }

    }
}