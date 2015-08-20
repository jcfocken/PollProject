using Poll_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poll_Project.Models
{

    // For poll actions
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

    public class PollResultsViewModel
    {
        public PollResultsViewModel(Poll poll)
        {
            Poll = poll;
            numOfResponses = Poll.Responses.Count();
            AnswerCounts = new Dictionary<int, int>();
            foreach (Question question in Poll.Questions)
            {
                foreach (Answer answer in question.Answers)
                {
                    int count = 0;
                    foreach (Response response in Poll.Responses)
                    {
                        if (response.Selections != null)
                        {
                            foreach (Selection selection in response.Selections)
                            {
                                if (selection.AnswerID == answer.ID)
                                {
                                    count++;
                                }
                            }
                        }                        
                    }
                    AnswerCounts.Add(answer.ID, count);
                }
            }
        }

        public Poll Poll { get; set; }
        public int numOfResponses { get; set; }
        public Dictionary<int, int> AnswerCounts{ get; set; }



    }

    // For Question actions

    public class CreateQuestionViewModel
    {

        public CreateQuestionViewModel()
        {
        }

        public CreateQuestionViewModel(Poll poll)
        {
            PollID = poll.ID;
            PollTitle = poll.Title;
        }

        public int PollID { get; set; }
        public string PollTitle { get; set; }
        public string QuestionText { get; set; }
        public ICollection<string> Answers { get; set; }
    }

    
    // For Response actions

    public class CreateResponseViewModel
    {

        public CreateResponseViewModel()
        {
        }

        public CreateResponseViewModel(Poll poll)
        {
            Poll = poll;
        }

        public Poll Poll { get; set; }
        public List<Selection> Selections { get; set; }

    }
}