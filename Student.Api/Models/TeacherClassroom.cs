using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.Api {
    public class TeacherClassroom{
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Teacher Id is required")]
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        [Required(ErrorMessage = "Classroom Id is required")]
        [ForeignKey("Classroom")]
        public int ClassroomId { get; set; }
        public Classroom Classroom { get; set; }
    }
}