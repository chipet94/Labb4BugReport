using System;
using System.Collections.Generic;
using System.Linq;
using Labb4BugReport.Data.Models.Bugs;
using Labb4BugReport.Data.Models.Bugs.Enums;
using Labb4BugReport.Data.Models.Comments;

namespace Labb4BugReport.Data.Database.Seeding
{
    public class SeedData
    {
        public static void Seed(Context context)
        {
            context.Database.EnsureCreated();

            if (!context.BugReports.Any())
            {
                var bugReports = new[]
                {
                    new BugReport(){ Id = 1, Title = "Bug-Report 1",
                        Description = "Asdasdasda asdasda asdasdas dasda sd", Posted = DateTime.Now,
                        Status = BugStatus.Approved, PosterName = "Göran"},
                    new BugReport(){ Id = 2, Title = "Bug-Report 2", 
                        Description = "Asdasdasda asdasda asdasdas dasda sd", Posted = DateTime.Now,
                        Status = BugStatus.Denied, PosterName = "Lasse"},
                    new BugReport(){ Id = 3, Title = "Bug-Report 3", 
                        Description = "Asdasdasda asdasda asdasdas dasda sd", Posted = DateTime.Now,
                        Status = BugStatus.Fixed },
                    new BugReport(){ Id = 4, Title = "Bug-Report 4",
                        Description = "Asdasdasda asdasda asdasdas dasda sd", Posted = DateTime.Now,
                        Status = BugStatus.New },
                };
                context.BugReports.AddRange(bugReports);
                context.SaveChanges();
            }
            if (!context.Comments.Any())
            {
                var comments = new List<Comment>();
                var commentId = 1;
                for (int i = 1; i <= context.BugReports.Count(); i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        var comment = new Comment()
                        {
                            Id = commentId, Posted = DateTime.Now, BugReportId = i, PosterId = 0,
                            Text = "asdasd asdasd asdasda sdas dasd asdasdasd asdas dasd"
                        };
                        comments.Add(comment);
                        commentId++;
                    }
                }

                context.Comments.AddRange(comments);
                context.SaveChanges();
            }
            
            context.SaveChanges();
        }

    }
}