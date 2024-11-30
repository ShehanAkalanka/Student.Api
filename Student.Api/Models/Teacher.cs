using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.Api {
    public class Teacher
    {
        [Key] // Marks TeacherId as the primary key
        public int TeacherId { get; set; } // No need to display in the UI

        [Required] // Makes this field mandatory
        [MaxLength(50)] // Limits the length of the first name to 50 characters
        public string FirstName { get; set; } // First Name *

        [MaxLength(50)] // Limits the length of the last name to 50 characters
        public string LastName { get; set; } // Last Name

        [Required]
        [Phone] // Ensures the format of a phone number
        [MaxLength(15)]
        public string ContactNo { get; set; } // Contact No *

        [Required]
        [EmailAddress] // Ensures a valid email format
        public string EmailAddress { get; set; } // Email Address *

        public ICollection<TeacherSubject> TeacherSubjects {get; set;}
    }
}