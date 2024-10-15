using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApi.Domain.Models
{
    [Table("employee")]
    public class Employee
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("age")]
        public int Age { get; set; }
        [Column("photo")]
        public string? Photo { get; set; }


        public Employee() { }
        public Employee(string name, int age, string? photo)
        {
            Name = name;
            Age = age;
            Photo = photo;
        }
    }
}
