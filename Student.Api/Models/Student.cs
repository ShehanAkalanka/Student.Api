using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.Api {
    public class Student
    {
        [Key] 
        public int StudentId { get; set; } // No need to display in the UI
        
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

        [NotMapped] // This property won't be stored in the database
        public int Age
        {
            get
            {
                // Automatically calculate the age based on DOB
                var today = DateTime.Today;
                var age = today.Year - DateOfBirth.Year;
                if (DateOfBirth.Date > today.AddYears(-age)) age--;
                return age;
            }
        }

        [Required]
        public int ClassroomId { get; set; } // Foreign key for Classroom

        [ForeignKey("ClassroomId")] // Links to the Classroom entity
        public Classroom Classroom { get; set; } // Navigation property for Classroom
    }
        
}