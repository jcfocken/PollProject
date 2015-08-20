using Poll_Project.DAL;
using Poll_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poll_Project.Tests.FakeDB
{
    public class FakePollContext : IApplicationDbContext
    {
        public IDbSet<Poll> Polls { get; set; }
        public IDbSet<Question> Questions { get; set; }
        public IDbSet<Answer> Answers { get; set; }
        public IDbSet<Response> Responses { get; set; }
        public IDbSet<Selection> Selections { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            return 0;
        }

        public void SetModified(object entity)
        {
            throw new NotImplementedException();
        }
    }
}
