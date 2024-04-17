using Microsoft.EntityFrameworkCore;
using UniforBackend.DAL.Data;

namespace UniforBackend.API.Helpers
{
    public class InitialDataHelper
    {
        public static void InitializeDatabase(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                // Check if the Categories table exists
                if (!dbContext.Categorias.Any())
                {
                    // Read SQL script file
                    string script = File.ReadAllText("DatabaseInit.sql");

                    // Execute SQL commands
                    dbContext.Database.ExecuteSqlRaw(script);
                }
            }
        }
    }
}
