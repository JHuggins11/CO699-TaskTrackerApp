using CO699_TaskTrackerApp.Models;

namespace CO699_TaskTrackerApp.Data
{
    /// <summary>
    /// Test data used to seed the database with sample tasks.
    /// 
    /// Created: 15/02/2023
    /// Modified: 24/03/2023
    /// </summary>
    public class DbInitialiser
    {
        public static void Initialise(ApplicationDbContext context)
        {
            AddUserTasks(context);
        }

        private static void AddUserTasks(ApplicationDbContext context)
        {
            // Skip seeding if existing tasks in the database are found
            if (context.UserTask.Any())
            {
                return;
            }

            // Add sample tasks
            var userTasks = new UserTask[]
            {
                new UserTask
                {
                    // UserID = 
                    Name = "Complete homework",
                    Priority = Priority.Moderate,
                    DueDate = DateTime.Parse("2023-02-15"),
                    Description = "See assignment brief for more details."
                },

                new UserTask
                {
                    // UserID = 
                    Name = "Revise for exam",
                    Priority = Priority.High,
                    DueDate = DateTime.Parse("2023-03-24"),
                    Description = "Review past exam papers for practice."
                },

                new UserTask
                {
                    // UserID = 
                    Name = "Go shopping",
                    Priority = Priority.Low,
                    DueDate = DateTime.Parse("2023-03-26")
                }
            };

            context.UserTask.AddRange(userTasks);
            context.SaveChanges();
        }
    }
}
