using System.Collections.Generic;
using System.Threading.Tasks;
using Labb4BugReport.Data.Models.Comments;
using Labb4BugReport.Data.Shared.Requests;

namespace Labb4BugReport.Services.CommentService
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetAll();
        Task<IEnumerable<Comment>> GetAllByUser(int id);
        Task<IEnumerable<Comment>> GetAllInReport(int id);
        Task<Comment> Get(int id);
        Task AddComment(NewCommentRequest request);
        Task EditComment(int id, Comment comment);
        Task RemoveComment(int id);
    }
}