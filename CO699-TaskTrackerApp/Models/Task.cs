using System.ComponentModel.DataAnnotations;

namespace CO699_TaskTrackerApp.Models
{
    /// <summary>
    /// Represents a task that is associated with a specific user. A user can
    /// have zero, one or many tasks.
    /// 
    /// Created: 20/01/2023
    /// Modified: 20/01/2023
    /// </summary>
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(60), Required]
        public string Name { get; set; }

        [Required]
        public Priority Priority { get; set; }

        [DataType(DataType.Date), Required]
        public DateTime DueDate { get; set; }

        public DateTime? ReminderDate { get; set; }

        [MaxLength(350)]
        public string? Description { get; set; }

        [Required]
        public bool IsCompleted { get; set; } = false;

        // Navigation property
        public virtual User User { get; set; }
    }
}
