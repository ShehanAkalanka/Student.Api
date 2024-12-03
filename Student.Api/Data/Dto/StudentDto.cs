using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.Api.Data.Dto{
    public class StudentDto
    {
        
        [Required] // Makes this field mandatory
        [MaxLength(50)] // Limits the length of the name to 50 characters
        public string FirstName { get; set; } // First Name *

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } // Last Name *

        [Required]
        [MaxLength(50)]
        public string ContactPerson { get; set; } // Contact Person *

        [Required]
        [Phone] // Ensures the format of a phone number
        [MaxLength(15)]
        public string ContactNo { get; set; } // Contact No *

        [Required]
        [EmailAddress] // Ensures a valid email format
        public string EmailAddress { get; set; } // Email Address *

        [Required]
        [DataType(DataType.Date)] // Specifies this field as a date
        public DateTime DateOfBirth { get; set; } // Date of birth *

        [Required]
        public int ClassroomId { get; set; } // Foreign key for Classroom
    }
}