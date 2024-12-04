using Student.Api;

namespace Student.Api.Data.ResponseModels
{
    public class StudentResponseMode
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactedPerson { get; set; }
        public string ContactNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public int ClassroomId { get; set; }
        public string ClassroomName { get; set; }
        public List<TeacherResponseModel> Teachers { get; set; }
    }
}