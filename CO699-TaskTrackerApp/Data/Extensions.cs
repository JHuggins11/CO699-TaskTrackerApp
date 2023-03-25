namespace CO699_TaskTrackerApp.Data
{
    // Reference: https://learn.microsoft.com/en-gb/training/modules/persist-data-ef-core/4-interacting-data
    public static class Extensions
    {
        // Seed database with sample data if none is currently set up
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
