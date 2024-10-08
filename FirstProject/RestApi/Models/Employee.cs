using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApi.Models
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
            this.Name = name;
            this.Age = age;
            this.Photo = photo;
        }
    }
}
