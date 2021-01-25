using System.ComponentModel.DataAnnotations;

namespace Labb4BugReport.Data.Shared.Requests
{
    public class EditBugReportRequest
    {
        [Required]
        public int Id { get; set; }
        [Required, MinLength(3), MaxLength(20)]
        public string PosterName { get; set; }
        [Required, MinLength(3), MaxLength(70)]
        public string Title { get; set; }
        [Required, MinLength(10)]
        public string Description { get; set; }
        public int Status { get; set; }
    }
}