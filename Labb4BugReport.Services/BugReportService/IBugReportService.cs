using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Labb4BugReport.Data.Models.Bugs;
using Labb4BugReport.Data.Shared.Requests;
using Labb4BugReport.Data.Shared.Views;

namespace Labb4BugReport.Services.BugReportService
{
    public interface IBugReportService
    {
        Task<IEnumerable<BugReport>> GetBugList();
        Task<BugReport> GetReport(int id);
        Task RemoveReport(int id);
        Task RemoveReports(string title);
        Task AddNewReport(NewBugReportRequest request);
        Task EditReport(int id, EditBugReportRequest request);
    }
}