using System.Collections.Generic;
using System.Threading.Tasks;
using Labb4BugReport.Data.Models.Comments;
using Labb4BugReport.Data.Shared.Requests;

namespace Labb4BugReport.FrontEnd.Services
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetAll();
        Task<IEnumerable<UserComment>> GetAllInReport(int id);
        Task<IEnumerable<Comment>> GetAllByUser(int id);
        Task AddNewComment(NewCommentRequest request);
        Task<Comment> Get(int id);
        Task Delete(int id);
    }

    public class CommentService : ICommentService
    {
        private readonly IHttpService _httpService;

        public CommentService(IHttpService httpService)
        {
            _httpService = httpService;
        }
        
        public async Task<IEnumerable<Comment>> GetAll()
        {
            return await _httpService.Get<IEnumerable<Comment>>("/Comment");
        }

        public async Task<IEnumerable<UserComment>> GetAllInReport(int id)
        {
            return await _httpService.Get<IEnumerable<UserComment>>($"/Comment/BugReport/{id}");
        }

        public async Task<IEnumerable<Comment>> GetAllByUser(int id)
        {
            return await _httpService.Get<IEnumerable<Comment>>($"/Comment/User/{id}");
        }

        public async Task AddNewComment(NewCommentRequest request)
        {
            await _httpService.Post("/Comment", request);
        }

        public async Task<Comment> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}