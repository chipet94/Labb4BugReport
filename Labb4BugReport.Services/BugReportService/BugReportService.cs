using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labb4BugReport.Data.Database;
using Labb4BugReport.Data.Models.Bugs;
using Labb4BugReport.Data.Models.Bugs.Enums;
using Labb4BugReport.Data.Models.Bugs.Extensions;
using Labb4BugReport.Data.Models.Comments;
using Labb4BugReport.Data.Shared.Requests;
using Labb4BugReport.Data.Shared.Views;
using Microsoft.EntityFrameworkCore;

namespace Labb4BugReport.Services.BugReportService
{
    public class BugReportService : IBugReportService
    {
        private readonly Context _context;
        public BugReportService(Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<BugReport>> GetBugList()
        {
            return (await _context.BugReports.ToArrayAsync());
        }

        public async Task<BugReport> GetReport(int id)
        {
            return (await _context.BugReports.FindAsync(id));
        }

        public async Task RemoveReport(int id)
        {
            var report = await _context.BugReports.FindAsync(id);
            if (report == null)
                throw new InvalidOperationException($"No bug-report with id [{id}] exists. ");
            
            _context.BugReports.Remove(report);
            await _context.SaveChangesAsync();
        }
        
        public async Task RemoveReports(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new InvalidOperationException($"No title was provided");
            }
            var reports = await _context.BugReports.Where(x => x.Title == title).ToArrayAsync();
            if (reports == null)
                throw new InvalidOperationException($"No bug-reports with title [{title}] exists. ");
            
            _context.BugReports.RemoveRange(reports);
            await _context.SaveChangesAsync();
        } 

        public async Task AddNewReport(NewBugReportRequest request)
        {
            if (string.IsNullOrEmpty(request.PosterName))
                throw new Exception("No name was provided.");
            if (string.IsNullOrEmpty(request.Title))
                throw new Exception("No title was provided.");
            if (string.IsNullOrEmpty(request.Description))
                throw new Exception("No description was provided.");
            
            var report = new BugReport()
            {
                Title = request.Title,
                PosterName = request.PosterName,
                Description = request.Description,
                Posted = DateTime.Now,
                Status = BugStatus.New
            };
            try
            {
                await _context.BugReports.AddAsync(report);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task EditReport(int id, EditBugReportRequest request)
        {
            if (id != request.Id)
                throw new Exception("Provided id does not match request.");

            var selected = await _context.BugReports.FindAsync(request.Id);
            if (selected == null)
                throw new InvalidOperationException("Report not found");

            foreach (var prop in request.GetType().GetProperties())
            {
                var value = prop.GetValue(request, null);
                {
                    var bugProp = selected.GetType().GetProperty(prop.Name);
                    if (bugProp != null) bugProp.SetValue(selected, value);
                }
            }

            try
            {
                _context.BugReports.Update(selected);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}