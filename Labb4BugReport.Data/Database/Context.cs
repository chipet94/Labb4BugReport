using Labb4BugReport.Data.Models.Bugs;
using Labb4BugReport.Data.Models.Comments;
using Labb4BugReport.Data.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Labb4BugReport.Data.Database
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<BugReport> BugReports { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}