using Labb4BugReport.Data.Shared.Views;

namespace Labb4BugReport.Data.Models.User.Extensions
{
    public static class AccountExtensions
    {
        public static Poster ToPoster(this Account account)
        {
            return new()
            {
                Id = account.Id,
                Username = account.Username,
                Role = account.Role.ToString()
            };
        }
    }
}