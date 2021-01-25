using System.Collections.Generic;
using System.Threading.Tasks;
using Labb4BugReport.Data.Models.Bugs;
using Labb4BugReport.Data.Shared.Requests;
using Labb4BugReport.Data.Shared.Views;

namespace Labb4BugReport.FrontEnd.Services
{
    public interface IBugReportService
    {
        Task<IEnumerable<BugReport>> GetAll();
        Task<BugReport> Get(int id);
        Task Post(NewBugReportRequest request);
        Task Put(int id, EditBugReportRequest request);
        Task Delete(int id);

    }
    public class BugReportService : IBugReportService
    {
        private readonly IHttpService _httpService;

        public BugReportService(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public async Task<IEnumerable<BugReport>> GetAll()
        {
            return await _httpService.Get<IEnumerable<BugReport>>("/BugReport");
        }

        public async Task<BugReport> Get(int id)
        {
            return await _httpService.Get<BugReport>($"/BugReport/{id}");
        }

        public async Task Post(NewBugReportRequest request)
        {
            await _httpService.Post("/BugReport", request);
        }

        public async Task Put(int id, EditBugReportRequest request)
        {
            throw new System.NotImplementedException();
        }

        public async Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}