using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManagement.Models
{
    public class Task
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }

        public bool IsCompleted { get; set; } = false;

        [Display(Name = "Created On")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}