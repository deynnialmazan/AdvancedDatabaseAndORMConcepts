using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AdvancedDatabase_Lab4.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [MinLength(3, ErrorMessage = "The firstname must have at least 3 characters.")]
        [MaxLength(25)]
        [DisplayName("First name")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [MinLength(3, ErrorMessage = "The lastname must have at least 3 characters.")]
        [MaxLength(25)]
        [DisplayName("Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", 
            ErrorMessage = "Please enter a valid phone number in the format xxx-xxx-xxxx.")]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }
    }
}
