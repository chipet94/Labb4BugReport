using System;

namespace Labb4BugReport.Data.Shared.Views
{
    public class PosterComment
    {
        public Poster Poster { get; set; }
        public DateTime Posted { get; set; }
        public string Text { get; set; }
    }
}