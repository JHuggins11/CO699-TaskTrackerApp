using CO699_TaskTrackerApp.Models;

namespace CO699_TaskTrackerApp.Data
{
    /// <summary>
    /// Test data used to seed the database with sample users, user accounts and tasks.
    /// 
    /// Created: 15/02/2023
    /// Modified: 15/02/2023
    /// </summary>
    public class DbInitialiser
    {
        public static void Initialise(ApplicationDbContext context)
        {
            // TODO: Add method calls

        }

        private static void AddUsers(ApplicationDbContext context)
        {
            // Skip database seeding if any User records are found
            if (context.Users.Any())
            {
                return; 
            }

            // TODO: Continue
            var users = new User[]
            {
                new User
                {
                    Email = "user1@email.com",
                    
                }
            };
        }
    }
}
