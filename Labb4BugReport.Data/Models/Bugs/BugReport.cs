using System;
using System.Collections.Generic;
using Labb4BugReport.Data.Models.Bugs.Enums;

namespace Labb4BugReport.Data.Models.Bugs
{
    public class BugReport
    {
        public int Id { get; set; }
        public int PosterId { get; set; }
        public DateTime Posted { get; set; }
        public string PosterName { get; set; } = "Anon";
        public string Title { get; set; }
        public BugStatus Status { get; set; }
        public string Description { get; set; }
    }
}