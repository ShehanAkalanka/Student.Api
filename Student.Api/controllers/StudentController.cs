using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student.Api.Data;

namespace Student.Api {
    public class StudentController: ControllerBase
    {
         private readonly DataContext _dataContext;  

        public StudentController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("GetStudentList")]
        public IActionResult GetStudentList(){
            var studentList = _dataContext.Students.ToList();
            return Ok(studentList);// with 200 status code
        }

        [HttpPost("CreateStudent")]
        public IActionResult CreateStudent(Student student){
            _dataContext.Students.Add(student);
            _dataContext.SaveChanges();
            return Ok(student);
        }
    }
}