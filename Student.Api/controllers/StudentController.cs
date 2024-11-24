using Microsoft.AspNetCore.Mvc;

namespace Student.Api {
    public class StudentController: ControllerBase
    {
        private readonly string[] studentList = new[] { "John Doe", "Jane Smith", "Alice Johnson" };

        [HttpGet("GetStudentList")]
        public IActionResult GetStudentList(){
            return Ok(studentList);// with 200 status code
        }

        [HttpPost("CreateStudent")]
        public IActionResult CreateStudent(Student student){
            return Ok(student);// with 200 status code
        }
    }
}