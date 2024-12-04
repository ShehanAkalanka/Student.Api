using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student.Api.Data;
using Student.Api.Data.Dto;
using Student.Api.Data.ResponseModels;

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

        // scenario - when selecting student data we have to select their classroom, teacher, subjects 
        // for this I'm going to create a response model(which is same as the dto but this we use for responses so in these we no need to use validations) - StudentResponseModel
        [HttpGet("GetStudentLDataById")]
        public IActionResult GetStudentLDataById(int id){

            var studentList = _dataContext.Students
            .Where(s=>s.StudentId ==id)
            .Select(s=> new StudentResponseMode{
                StudentId = s.StudentId,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Age = s.Age,
                ClassroomId = s.ClassroomId,
                ClassroomName = s.Classroom.ClassroomName,
                Teachers = _dataContext.Teachers
                            .Where(t=> t.TeacherClassrooms.Any(c=>c.ClassroomId==s.Classroom.ClassroomId))
                            .Select(t => new TeacherResponseModel{
                                TeacherId = t.TeacherId,
                                FirstName = t.FirstName,
                                Subjects = _dataContext.TeacherSubjects
                                .Where(ts=>ts.TeacherId==t.TeacherId)
                                .Select(sub=>new SubjectResponseModel{
                                    SubjectId = sub.Subject.SubjectId,
                                    SubjectName = sub.Subject.SubjectName
                                })
                                .ToList()
                            })
                            .ToList()
            })
            .FirstOrDefault();

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