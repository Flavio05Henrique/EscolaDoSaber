using System.ComponentModel.DataAnnotations;

namespace EscolaDoSaber.Model.DTOs
{
    public class TeacherResponseDTO
    {
        public string Name { get; private set; }
        public string Discipline { get; set; }
        public float Wage { get; private set; }
        public string Cpf { get; private set; }

        public TeacherResponseDTO(string name, string discipline, float wage, string cpf)
        {
            Name = name;
            Discipline = discipline;
            Wage = wage;
            Cpf = cpf;
        }
    }
}
