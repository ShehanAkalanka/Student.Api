using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.Api.Data.Dto{
     public class TeacherClassroomDto{

        [Required(ErrorMessage = "Teacher Id is required")]
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }

        [Required(ErrorMessage = "Classroom Id is required")]
        [ForeignKey("Classroom")]
        public int ClassroomId { get; set; }
    }
}