using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Labb4BugReport.Data.Shared.Views;

namespace Labb4BugReport.Data.Models.Bugs.Extensions
{
    public static class BugExtensions
    {
        public static BugListItem ToListItem(this BugReport bugReport)
            {
                return new BugListItem()
                {
                    Id= bugReport.Id,
                    Posted = bugReport.Posted,
                    PosterName = bugReport.PosterName,
                    Title = bugReport.Title,
                    Status = bugReport.Status,
                };
            }
        public static IEnumerable<BugListItem> ToListItems(this IEnumerable<BugReport> bugs)
        {
            return bugs.Select(x => x.ToListItem());
        }
        public static DetailedBug ToDetailedBug(this BugReport bugReport)
        {
            return new DetailedBug()
            {
                Id= bugReport.Id,
                Posted = bugReport.Posted,
                PosterName = bugReport.PosterName,
                Title = bugReport.Title,
                Status = bugReport.Status,
                Description = bugReport.Description,
            };
        }
    }
}