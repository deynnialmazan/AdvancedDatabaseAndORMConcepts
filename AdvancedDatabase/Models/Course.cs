using System.ComponentModel.DataAnnotations;

namespace FirstDbMVCApp.Models
{
    public class Course
    {
        public int Id { get; set; }

        // With adding these, it is not necessary to create validations in get/set 
        [Required]
        [MinLength(5)]
        [MaxLength(250)]
        public string Title { get; set; }

        public HashSet<Student> EnrolledStudents = new HashSet<Student>();
    }
}
