using System.ComponentModel.DataAnnotations;

namespace StudentDatabase.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        public string StudentName { get; set; }
    }
}