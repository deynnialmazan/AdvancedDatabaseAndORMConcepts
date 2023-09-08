using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FirstDbMVCApp.Models
{
    public class Student
    {
        [DisplayName("Student Number")]
        public Guid Id { get; set; }

        [Required]
        public string FullName { get; set; }

        // [ForeignKey("Course")] -- in this way we can indicate that CourseId is
        // the foreign key of Course object
        [DisplayName("Course Id")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; } = null;
    }
}