﻿using System.ComponentModel.DataAnnotations;

namespace CO699_TaskTrackerApp.Models
{
    /// <summary>
    /// Represents a user account in the application.
    /// 
    /// Created: 19/01/2023
    /// Modified: 15/02/2023
    /// </summary>
    public class User
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.EmailAddress), MaxLength(50), Required]
        public string Email { get; set; }

        // TODO: Check if this is needed
        [DataType(DataType.Password), MinLength(8), MaxLength(40), Required]
        public string Password { get; set; }

        // TODO: Check if this is needed
        [Required]
        public bool Is2FAEnabled { get; set; } = false;

        [DataType(DataType.Date), Required]
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
