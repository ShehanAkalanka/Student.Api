using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.Api {
    public class Subject
    {
        [Key] // Marks SubjectId as the primary key
        public int SubjectId { get; set; } // No need to display in the UI

        [Required] // Makes this field mandatory
        [MaxLength(100)] // Limits the length of the subject name to 100 characters
        public string SubjectName { get; set; } // Subject Name *

        public ICollection<TeacherSubject> TeacherSubjects {get; set;}
    }
}