using System.ComponentModel.DataAnnotations;

namespace EscolaDoSaber.Model.DTOs
{
    public class StudentResponseDTO
    {
        public int Id;
        public string Name { get; private set; }
        public int Age { get; private set; }
        public int Registrtion { get; private set; }

        public StudentResponseDTO(string name, int age, int registrtion)
        {
            Name = name;
            Age = age;
            Registrtion = registrtion;
        }
    }
}
