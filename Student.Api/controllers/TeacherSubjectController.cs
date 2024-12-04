using Microsoft.AspNetCore.Mvc;
using Student.Api.Data;
using Student.Api.Data.Dto;

namespace Student.Api {
    public class TeacherSubjectController: ControllerBase
    {
        private readonly DataContext _dataContext;  

        public TeacherSubjectController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost("CreateTeacherSubjectRelation")]
        public IActionResult CreateTeacherSubjectRelation(TeacherSubjectDto req){

            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            TeacherSubject teacherSubject = new TeacherSubject {
                TeacherId = req.TeacherId,
                SubjectId = req.SubjectId
            };

            _dataContext.TeacherSubjects.Add(teacherSubject);
            _dataContext.SaveChanges();
            return Ok();
        }
    }
}