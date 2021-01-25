using System;
using System.ComponentModel.DataAnnotations;

namespace Labb4BugReport.Data.Shared.Requests
{
    public class NewCommentRequest
    {
        [Required]
        public int BugReportId { get; set; }
        public int PosterId { get; set; } = 0;
        [Required, MinLength(3, ErrorMessage = "comment too short"), MaxLength(500, ErrorMessage = "Title too long.")]
        public string Text { get; set; }
    }
}