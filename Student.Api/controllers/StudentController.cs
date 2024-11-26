using Microsoft.AspNetCore.Mvc;

namespace Student.Api {
    public class StudentController: ControllerBase
    { private static List<Student> studentList = new List<Student>
        {
            new Student { Name = "John Doe", Address = "123 Main St" },
            new Student { Name = "Jane Smith", Address = "456 Elm St" },
            new Student { Name = "Emily Johnson", Address = "789 Oak St" }
        };
        
        [HttpGet("GetStudentList")]
        public IActionResult GetStudentList(){
            return Ok("studentList");// with 200 status code
        }

        [HttpPost("CreateStudent")]
        public IActionResult CreateStudent(Student student){
            return Ok(student);// with 200 status code
        }
    }
}