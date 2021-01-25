using System;
using System.ComponentModel.DataAnnotations;
using Labb4BugReport.Data.Models.Bugs.Enums;

namespace Labb4BugReport.Data.Shared.Requests
{
    public class NewBugReportRequest
    {        
        [Required, MinLength(3, ErrorMessage = "Too short Name"), MaxLength(20, ErrorMessage = "Too long name.")]
        public string PosterName { get; set; } = "Anon";
        [Required, MinLength(3, ErrorMessage = "Title too short"), MaxLength(70, ErrorMessage = "Title too long.")]
        public string Title { get; set; }
        [Required, MinLength(10, ErrorMessage = "You need atleast 10 characters in a description")]
        public string Description { get; set; }
    }
    
}