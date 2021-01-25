using System;
using System.Collections;
using System.Collections.Generic;
using Labb4BugReport.Data.Models.Bugs;
using Labb4BugReport.Data.Models.Bugs.Enums;

namespace Labb4BugReport.Data.Shared.Views
{
    public abstract class BugViewModel
    {
        public int Id { get; set; }
        public DateTime Posted { get; set; }
        public string PosterName { get; set; }
        public string Title { get; set; }
        public BugStatus Status { get; set; }
    }
    public class BugListItem : BugViewModel
    {
        public int CommentCount { get; set; }
    }
    public class DetailedBug : BugViewModel
    {
        public string Description { get; set; }
        public IEnumerable<PosterComment> Comments { get; set; }
    }
    
}