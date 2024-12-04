using System.ComponentModel.DataAnnotations;

namespace EscolaDoSaber.Model
{
    public class Student
    {
        [Key]
        public int Id { get; private set; }
        [Required]
        [StringLength(255)]
        public string Name { get; private set; }
        [Required]
        [Range(12, 100)]
        public int Age { get; private set; }
        [Required]
        [RegularExpression("^\\d{3}\\.\\d{3}\\.\\d{3}-\\d{2}$", ErrorMessage = "Deve ser : 000.000.00-00")]
        public string Cpf { get; private set; }
        public int Registrtion { get; private set; }
        public DateTime RegistrtionDate { get; private set; }

        public Student(string name, int age, string cpf)
        {
            var randomNum = new Random().Next(100000);
            Name = name;
            Age = age;
            Cpf = cpf;
            Registrtion = randomNum;
            RegistrtionDate = DateTime.Now;
        }
    }
}
