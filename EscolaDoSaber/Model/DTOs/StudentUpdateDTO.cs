using System.ComponentModel.DataAnnotations;

namespace EscolaDoSaber.Model.DTOs
{
    public class StudentUpdateDTO
    {

        [Required]
        [StringLength(255)]
        public string Name { get; private set; }
        [Required]
        [Range(12, 100)]
        public int Age { get; private set; }

        public StudentUpdateDTO(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
