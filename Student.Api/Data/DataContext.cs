using Microsoft.EntityFrameworkCore;

namespace Student.Api.Data
{
    // this class responsible for connecting our models with our Database
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }

}