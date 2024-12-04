using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EscolaDoSaber.Model.DTOs
{
    public class TeacherCreateDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        [StringLength(255, ErrorMessage = "Maximo de caracteres : 255")]
        public string Name { get; private set; }
        [Required]
        [StringLength(80, ErrorMessage = "Maximo de caracteres : 80")]
        public string Discipline { get; set; }
        [Required]
        [Range(3000, 10000, ErrorMessage = "Salario min : 3000, max : 10000")]
        public float Wage { get; private set; }
        [Required]
        [RegularExpression("^\\d{3}\\.\\d{3}\\.\\d{3}-\\d{2}$", ErrorMessage = "Deve ser : 000.000.00-00")]
        public string Cpf { get; private set; }

        public TeacherCreateDTO(string name, string discipline, float wage, string cpf)
        {
            Name = name;
            Discipline = discipline;
            Wage = wage;
            Cpf = cpf;
        }
    }
}
