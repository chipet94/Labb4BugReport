using System.Collections.Generic;
using System.Linq;
using Labb4BugReport.Data.Shared.Views;

namespace Labb4BugReport.Data.Models.Comments.Extensions
{
    public static class CommentExtensions
    {
        public static IEnumerable<PosterComment> ToPosterComments(this IEnumerable<Comment> comments)
        {
            return comments.Select(x => x.ToPosterComment());
        }
        public static PosterComment ToPosterComment(this Comment comment)
        {
            return new PosterComment()
            {
                Posted = comment.Posted,
                Text = comment.Text,
            };
        }
        
        public static UserComment ToUserComment(this Comment comment, Poster poster)
        {
            return new UserComment()
            {
                Id = comment.Id,
                PosterId = comment.PosterId,
                Poster = poster,
                BugReportId = comment.BugReportId,
                Posted = comment.Posted,
                Text = comment.Text
            };
        }
    }
}