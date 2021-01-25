using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labb4BugReport.Data.Models.Comments;
using Labb4BugReport.Data.Models.Comments.Extensions;
using Labb4BugReport.Data.Shared.Requests;
using Labb4BugReport.Data.Shared.Views;
using Labb4BugReport.Services.CommentService;
using Microsoft.AspNetCore.Mvc;

namespace Labb4BugReport.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _service;
        public CommentController(ICommentService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IEnumerable<Comment>> GetAll()
        {
            return await _service.GetAll();
        }
        // GET
        [Route("{id}")]
        [HttpGet]
        public async Task<Comment> GetComment(int id)
        {
            return await _service.Get(id);
        }
        // [Route("BugReport/{id}")]
        // [HttpGet]
        // public async Task<IEnumerable<Comment>> GetReportComments(int id)
        // {
        //     return await _service.GetAllInReport(id);
        // }
        [Route("BugReport/{id}")]
        [HttpGet]
        public async Task<IEnumerable<UserComment>> GetReportComments_Detailed(int id)
        {
            var comments = (IEnumerable<UserComment>)(await _service.GetAllInReport(id)).Select(x => x.ToUserComment(new Poster()
            {
                Id = x.PosterId,
                Role = "Visitor",
                Username = "Anon"
            }));
            return comments;
        }
        [Route("User/{id}")]
        [HttpGet]
        public async Task<IEnumerable<Comment>> GetUserComments(int id)
        {
            return await _service.GetAllByUser(id);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(NewCommentRequest request)
        {
            try
            {
                await _service.AddComment(request);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e?.Message);
                throw;
            }
        }
    }
}