using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Poll_Project.Models
{
    public class Response
    {
        public Response()
        {
        }

        public Response(Poll poll)
        {
            Poll = poll;
        }

        public int ID { get; set; }
        public ICollection<Selection> Selections{ get; set; }

        [Required]
        public virtual Poll Poll { get; set; }
    }

    public class Selection
    {
        public int ID { get; set; }
        public int AnswerID { get; set; }

        public virtual Answer Answer { get; set; }
    }
}