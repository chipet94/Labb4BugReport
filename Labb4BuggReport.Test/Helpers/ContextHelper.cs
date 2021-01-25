using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Labb4BuggReport.Test.Helpers
{
    public class ContextHelper
    {
        public static DbContextOptions<T> CreateOptions<T>() where T : DbContext
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder
                { DataSource = ":memory:" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);
            connection.Open();
            
            var builder = new DbContextOptionsBuilder<T>();
            builder.UseSqlite(connection);
 
            return builder.Options;
        }
    }
}