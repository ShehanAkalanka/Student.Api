using Microsoft.EntityFrameworkCore;

namespace Student.Api.Data{
    public class DataContext: DbContext{
        public DataContext(DbContextOptions options):base(options){

        }
        public DbSet<Student> Students {get;set;}
        public DbSet<Teacher> Teachers {get;set;}
        public DbSet<Classroom> Classrooms {get;set;}
        public DbSet<Subject> Subjects {get;set;}
        public DbSet<TeacherClassroom> TeacherClassrooms {get;set;}
        public DbSet<TeacherSubject> TeacherSubjects {get;set;}

        //here I'm overriding the OnModelCreating method in the DbContext base class
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TeacherClassroom>()
            .HasKey(tc => new{tc.TeacherId, tc.ClassroomId}); // this is a constraint that ensures no duplicate values are added with these key value pair

            modelBuilder.Entity<TeacherSubject>()
            .HasKey(ts=> new {ts.TeacherId, ts.SubjectId});
        }
    }
}