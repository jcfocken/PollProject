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
        public IDbSet<Response> Responses { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            return 0;
        }
    }
}
