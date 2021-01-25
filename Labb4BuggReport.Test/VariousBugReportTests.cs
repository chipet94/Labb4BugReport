using System;
using System.Linq;
using System.Threading.Tasks;
using Labb4BuggReport.Test.Helpers;
using Labb4BugReport.Data.Database;
using Labb4BugReport.Data.Database.ContextExtensions;
using Labb4BugReport.Data.Models.Bugs;
using Labb4BugReport.Data.Shared.Requests;
using Labb4BugReport.Services.BugReportService;
using Labb4BugReport.Services.CommentService;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Labb4BuggReport.Test
{
    [TestClass]
    public class VariousBugReportTests
    {
        private Context _contextWithData;
        private IBugReportService _bugReportService;
        private ICommentService _commentService;
        
        [TestInitialize]
        public void Setup()
        {
            _contextWithData = new Context(ContextHelper.CreateOptions<Context>());
            
            _contextWithData.Database.EnsureCreated();
            _contextWithData.ApplySeedData();
            
            _commentService = new CommentService(_contextWithData);
            _bugReportService = new BugReportService(_contextWithData);
        }
        [TestMethod]
        public async Task NewBugReportTest()
        {
            var newBugReport = new NewBugReportRequest {PosterName = "asd", Title = "basdas", Description = "short"};
            
            // Tom databas
            await using var context = new Context(ContextHelper.CreateOptions<Context>());
            await context.Database.EnsureCreatedAsync();
            var bugReportService = new BugReportService(context);
            
            await bugReportService.AddNewReport(newBugReport);
            //Alla reports, ska bara finnas en.
            var reports = (await bugReportService.GetBugList()).ToArray();
            
            //kontoll bara en i databasen.
            Assert.AreEqual(1, reports.Count());
            //Samma värden. 
            Assert.AreEqual(reports.First().PosterName, newBugReport.PosterName);
            Assert.AreEqual(reports.First().Title, newBugReport.Title);
            Assert.AreEqual(reports.First().Description, newBugReport.Description);
            
            //todo test för felaktiga 
        }
        [TestMethod]
        public async Task EditBugReportTest()
        {
            var defaultReportDescription = (await _contextWithData.BugReports.FindAsync(2)).Description;
            var reportUpdate = new EditBugReportRequest
            {
                Id = 2, Description = "Updated"
            };
            await _bugReportService.EditReport(2, reportUpdate);
            var updatedReport = await _bugReportService.GetReport(2);
            
            Assert.AreNotEqual(defaultReportDescription, updatedReport.Description);
        }
        
        [TestMethod]
        public async Task NewCommentTest()
        {
            var report = _contextWithData.BugReports.FirstOrDefault();
            var newComment = new NewCommentRequest{PosterId = 1, Text = "Test Comment", BugReportId = report.Id};
            
            await _commentService.AddComment(newComment);
            var reportComments = (await _commentService.GetAllInReport(report.Id)).ToArray();
            
            Assert.AreEqual(reportComments.Last().Text, newComment.Text );
        }
        

    }
}