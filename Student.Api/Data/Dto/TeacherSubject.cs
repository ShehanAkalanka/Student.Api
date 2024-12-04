using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.Api.Data.Dto{
     public class TeacherSubjectDto{

        [Required(ErrorMessage = "Teacher Id is required")]
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }

        [Required(ErrorMessage = "Subject Id is required")]
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
    }
}