using System;
using Labb4BugReport.Data.Shared.Views;

namespace Labb4BugReport.Data.Models.Comments
{
    public class Comment
    {
        public int Id { get; set; }
        public int BugReportId { get; set; }
        public int PosterId { get; set; }
        public DateTime Posted { get; set; }
        public string Text { get; set; }
    }

    public class UserComment : Comment
    {
        public Poster Poster { get; set; }
    }
}