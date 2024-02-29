using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Team0413.Models
{
    public class TaskEntry
    {
        // primary key
        [Key]
        [Required]

        public int TaskId { get; set; }

        [Required]
        // task
        public char Task {  get; set; }

        // due date
        public DateOnly? DueDate { get; set; }

        // quadrant
        [Required]
        public int Quadrant { get; set; }

        // category
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public bool? Completed { get; set; }
    }
}
