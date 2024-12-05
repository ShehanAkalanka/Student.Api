namespace Student.Api {
    public class StudentResponseModel
    {
        public int StudentId { get; set; } // No need to display in the UI
        public string FirstName { get; set; } // First Name *
        public string LastName { get; set; } // Last Name *
        public string ContactPerson { get; set; } // Contact Person *
        public string ContactNo { get; set; } // Contact No *
        public string EmailAddress { get; set; } // Email Address *
        public DateTime DateOfBirth { get; set; } // Date of birth *

        public int Age
        {
            get;set;
            // {
            //     // Automatically calculate the age based on DOB
            //     var today = DateTime.Today;
            //     var age = today.Year - DateOfBirth.Year;
            //     if (DateOfBirth.Date > today.AddYears(-age)) age--;
            //     return age;
            // }
        }
        public string ClassroomName { get; set; }
        public ClassroomResponseModel Classroom { get; set; } 
        public List<TeacherResponseModel> Teachers { get; set; }
        public List<SubjectResponseModel> Subjects { get; set; }

    }
}