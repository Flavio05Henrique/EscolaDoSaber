using System.ComponentModel.DataAnnotations;

namespace EscolaDoSaber.Model.DTOs
{
    public class StudentCreateDTO
    {
        [Required]
        [StringLength(255)]
        public string Name { get; private set; }
        [Required]
        [Range(12,100)]
        public int Age { get; private set; }
        [Required]
        [RegularExpression("^\\d{3}\\.\\d{3}\\.\\d{3}-\\d{2}$", ErrorMessage = "Deve ser : 000.000.00-00")]
        public string Cpf { get; private set; }

        public StudentCreateDTO(string name, int age, string cpf)
        {
            var randomNum = new Random().Next(100000);
            Name = name;
            Age = age;
            Cpf = cpf;
        }
    }
}
