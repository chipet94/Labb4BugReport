using System.Collections.Generic;
using Labb4BugReport.Data.Models.Bugs;
using Labb4BugReport.Data.Models.Comments;
using Labb4BugReport.Data.Models.User.Enums;

namespace Labb4BugReport.Data.Models.User
{
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public AccountRole Role { get; set; } = AccountRole.User;
        public string Token { get; set; }
    }
}