using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.Api {

    public class Classroom
    {
        [Key] 
        public int ClassroomId { get; set; } 

        [Required] 
        [MaxLength(100)] 
        public string ClassroomName { get; set; } 

        public ICollection<Student> Students { get; set; }
    }
    
}