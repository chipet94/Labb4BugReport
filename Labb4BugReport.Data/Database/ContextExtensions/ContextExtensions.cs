using Labb4BugReport.Data.Database.Seeding;

namespace Labb4BugReport.Data.Database.ContextExtensions
{
    public static class ContextExtension
    {
        public static void ApplySeedData(this Context context)
        {
            SeedData.Seed(context);
        }
    }
}