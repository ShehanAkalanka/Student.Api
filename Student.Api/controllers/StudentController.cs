using Microsoft.AspNetCore.Mvc;
using Student.Api.Data;
using Student.Api.Data.Dto;

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
        public IActionResult CreateStudent(StudentDto student){

            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            Student req = new Student{
                FirstName = student.FirstName,
                LastName = student.LastName,
                ContactPerson = student.ContactPerson,
                ContactNo = student.ContactNo,
                EmailAddress = student.EmailAddress,
                DateOfBirth = student.DateOfBirth,
                ClassroomId = student.ClassroomId
            };

            _dataContext.Students.Add(req);
            _dataContext.SaveChanges();
            return Ok(student);
        }
    }
}