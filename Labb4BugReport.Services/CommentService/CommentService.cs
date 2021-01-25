using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labb4BugReport.Data.Database;
using Labb4BugReport.Data.Models.Comments;
using Labb4BugReport.Data.Shared.Requests;
using Microsoft.EntityFrameworkCore;

namespace Labb4BugReport.Services.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly Context _context;

        public CommentService(Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Comment>> GetAll()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetAllByUser(int id)
        {
            return await _context.Comments.Where(c => c.PosterId == id).ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetAllInReport(int id)
        {
            return (await _context.Comments.Where(c => c.BugReportId == id).ToListAsync());
        }

        public async Task<Comment> Get(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task AddComment(NewCommentRequest request)
        {
            var comment = new Comment()
            {
                PosterId = request.PosterId,
                BugReportId = request.BugReportId,
                Text = request.Text,
                Posted = DateTime.Now,
            };
            try
            {
                await _context.Comments.AddAsync(comment);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task EditComment(int id, Comment comment)
        {
            throw new System.NotImplementedException();
        }

        public async Task RemoveComment(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}