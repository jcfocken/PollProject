using Poll_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poll_Project.Models
{
    public interface IApplicationDbContext
    {
        IDbSet<Poll> Polls { get; set; }
        IDbSet<Question> Questions { get; set; }
        IDbSet<Answer> Answers { get; set; }
        IDbSet<Response> Responses { get; set; }
        IDbSet<Selection> Selections { get; set; }


        int SaveChanges();
        void Dispose();
        void SetModified(object entity);
    }
}
