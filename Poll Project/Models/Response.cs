using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Poll_Project.Models
{
    public class Response
    {
        public int ID { get; set; }
        public string Text { get; set; }

        [Required]
        public virtual Poll Poll { get; set; }
    }
}