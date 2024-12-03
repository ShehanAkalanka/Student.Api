using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        /* get user data by user id -- here I only get the data 
        from student entity I'm not considering getting 
        the classroom data or teacher data or subject data related to student*/
        [HttpGet("GetStudentLDataById")]
        public IActionResult GetStudentList(int id){
            var studentList = _dataContext.Students.Where(s=>s.StudentId ==id).FirstOrDefault();
            return Ok(studentList);
        }

        [HttpGet("GetStudentList")]
        public async Task<IActionResult> GetStudentList(){
            var studentList =await _dataContext.Students.ToListAsync();
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

        [HttpGet("updateStudentDetails")]
        public IActionResult updateStudentDetails(int s_id, StudentDto studentDto){
            var studentList = _dataContext.Students.ToList();
            return Ok(studentList);// with 200 status code
        }


        [HttpPut("{id}")]
        public IActionResult UpdateStudent([FromRoute] int id, StudentDto studentRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var student = _dataContext.Students.FirstOrDefault(i => i.StudentId == id);

            if (student == null)
            {
                return NotFound(new { message = $"Student with ID {id} not found." });
            }


            student.FirstName = !string.IsNullOrEmpty(studentRequest.FirstName)?studentRequest.FirstName:student.FirstName;
            student.LastName = studentRequest.LastName;
            student.ContactPerson = studentRequest.ContactPerson;
            student.ContactNo = studentRequest.ContactNo;
            student.EmailAddress = studentRequest.EmailAddress;
            student.DateOfBirth = studentRequest.DateOfBirth;
            student.ClassroomId = studentRequest.ClassroomId;

            _dataContext.SaveChanges();

            return CreatedAtAction(nameof(GetStudentList), new { id = student.StudentId }, student);
        }
    }
}