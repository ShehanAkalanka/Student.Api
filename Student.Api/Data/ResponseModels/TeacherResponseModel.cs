using Student.Api;

namespace Student.Api.Data.ResponseModels
{
    public class TeacherResponseModel
    {
         public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TeacherName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public List<SubjectResponseModel> Subjects { get; set; }
        public List<ClassroomResponseModel> Classrooms { get; set; }
    }
}