namespace Student.Api {
    public class TeacherResponseModel
    {
        public int TeacherId { get; set; } // No need to display in the UI

        public string FirstName { get; set; } // First Name *
        public string LastName { get; set; } // Last Name
        public string ContactNo { get; set; } // Contact No *
        public string EmailAddress { get; set; } // Email Address *
        public ICollection<SubjectResponseModel> Subjects {get; set;}
    }
}