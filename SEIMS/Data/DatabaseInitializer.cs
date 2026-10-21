using Microsoft.EntityFrameworkCore;
using SEIMS.Services;

namespace SEIMS.Data
{
    public static class DatabaseInitializer
    {
        /// <summary>
        /// If migration files exist (created with Add-Migration in the Package Manager Console)
        /// they are applied; otherwise the schema is created straight from the model.
        /// </summary>
        public static void Initialize(FileLogger log)
        {
            using (var db = new SeimsDbContext())
            {
                if (db.Database.GetMigrations().Any())
                {
                    db.Database.Migrate();
                    log.Write("Database migrated (EF Core migrations).");
                }
                else
                {
                    db.Database.EnsureCreated();
                    log.Write("Database created from model (no migrations found).");
                }

                SeedData.Seed(db);
            }
        }
    }
}
