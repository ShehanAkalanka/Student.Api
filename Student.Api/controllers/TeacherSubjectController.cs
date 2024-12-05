using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet("GetSubjectDataByTeacherId")]
        public IActionResult GetSubjectDataByTeacherId(int teach_id){

            var SubjectList = _dataContext.TeacherSubjects
            .Where(ts=>ts.TeacherId ==teach_id)
            .Select(s=> new SubjectResponseModel{
                SubjectId = s.Subject.SubjectId,
                SubjectName = s.Subject.SubjectName
                })
            .ToList();

            return Ok(SubjectList);
        }

    }
}