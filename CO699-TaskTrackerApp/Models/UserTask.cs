using System.ComponentModel.DataAnnotations;

namespace CO699_TaskTrackerApp.Models
{
    /// <summary>
    /// Represents a task that is associated with a specific user. A user can
    /// have zero, one or many tasks.
    /// 
    /// Created: 20/01/2023
    /// Modified: 30/01/2023
    /// </summary>
    public class UserTask
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Task Name"), MaxLength(60), Required]
        public string Name { get; set; }

        [Required]
        public Priority Priority { get; set; }

        [Display(Name = "Due Date"), DataType(DataType.Date), Required]
        public DateTime DueDate { get; set; }

        [Display(Name = "Reminder")]
        public DateTime? ReminderDate { get; set; }

        [MaxLength(350)]
        public string? Description { get; set; }

        [Required]
        public bool IsCompleted { get; set; } = false;

        // Navigation property
        public virtual User User { get; set; }
    }
}
