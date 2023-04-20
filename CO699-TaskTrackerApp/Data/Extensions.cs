namespace CO699_TaskTrackerApp.Data
{
    /// <summary>
    /// Calls the DbInitialiser class to create the database with sample data if one does not already exist.
    /// Adapted from Microsoft's EF Core tutorial: https://learn.microsoft.com/en-gb/training/modules/persist-data-ef-core/4-interacting-data
    /// 
    /// Modified: 20/04/2023
    /// </summary>
    public static class Extensions
    {
        public static void CreateDbIfNotExists(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    context.Database.EnsureCreated();
                    DbInitialiser.Initialise(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Database creation failed, error occurred.");
                }
            }
        }
    }
}
