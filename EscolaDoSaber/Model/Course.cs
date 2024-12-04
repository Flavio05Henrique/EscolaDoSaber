using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace EscolaDoSaber.Model
{
    public class Course
    {

        [Key]
        public int Id { get; private set; }
        [Required]
        [StringLength(255)]
        public string Name { get; private set; }
        [JsonIgnore]
        public virtual Teacher Teacher { get; set; }

        public Course(string name)
        {
            Name = name;
        }

        public void SetTeacher(Teacher t)
        {
            Teacher = t;
        }
    }
}
