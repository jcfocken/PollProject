using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Poll_Project.Models
{
    public class Question
    {
        public int ID { get; set; }
        public int PollID { get; set; }
        //[Required]
        public string Text { get; set; }

        //[MinLength(2, ErrorMessage ="Each question needs at least two answers")]
        public virtual ICollection<Answer> Answers { get; set; }
        //[Required]
        public virtual Poll Poll { get; set; }
    }

    public class Answer
    {
        public int ID { get; set; }
        [Required]
        public string Text { get; set; }
        public int QuestionID { get; set; }

    }
}