using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Poll_Project.Models
{
    public class Poll
    {
        public int ID { get; set; }
        //[Required]
        public string Title { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Response> Responses { get; set; }
    }
}