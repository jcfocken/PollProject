using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Poll_Project.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("PollContext", throwIfV1Schema: false)
        {
        }

        public IDbSet<Poll> Polls { get; set; }
        public IDbSet<Question> Questions { get; set; }
        public IDbSet<Response> Responses { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}