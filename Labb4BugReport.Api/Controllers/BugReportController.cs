using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labb4BugReport.Data.Models.Bugs;
using Labb4BugReport.Data.Shared.Requests;
using Labb4BugReport.Data.Shared.Views;
using Labb4BugReport.Services.BugReportService;
using Microsoft.AspNetCore.Mvc;

namespace Labb4BugReport.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BugReportController : ControllerBase
    {
        private readonly IBugReportService _service;
        public BugReportController(IBugReportService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<IEnumerable<BugReport>> GetList()
        {
            return await _service.GetBugList();
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<BugReport> GetDetails(int id)
        {
            return await _service.GetReport(id);
        }
        [HttpPost]
        public async Task<IActionResult> NewBugReport([FromBody]NewBugReportRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _service.AddNewReport(request);
            }
            catch (Exception e)
            {
                return BadRequest(e?.Message);
            }

            return NoContent();
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> EditBugReport(int id, EditBugReportRequest request)
        {
            try
            {
                await _service.EditReport(id, request);
            }
            catch (Exception e)
            {
                return BadRequest(e?.Message);
            }

            return NoContent();
        }
    }
}