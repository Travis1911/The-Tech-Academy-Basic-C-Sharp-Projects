using System.Data.Entity;
using StudentDatabase.Models;

namespace StudentDatabase.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext()
            : base("StudentDB")
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}