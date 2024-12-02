using Microsoft.AspNetCore.Mvc;
using Student.Api.Data;
using Student.Api.Data.Dto;

namespace Student.Api {
    public class TeacherClassroomController: ControllerBase
    {
        private readonly DataContext _dataContext;  

        public TeacherClassroomController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost("CreateTeacherClassroomRelation")]
        public IActionResult CreateTeacherClassroomRelation(TeacherClassroomDto req){

            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            TeacherClassroom teacherClassroom = new TeacherClassroom {
                TeacherId = req.TeacherId,
                ClassroomId = req.ClassroomId
            };

            _dataContext.TeacherClassrooms.Add(teacherClassroom);
            _dataContext.SaveChanges();
            return Ok();
        }
    }
}