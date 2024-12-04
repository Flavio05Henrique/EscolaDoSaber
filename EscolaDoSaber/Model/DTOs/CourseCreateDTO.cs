using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace EscolaDoSaber.Model.DTOs
{
    public class CourseCreateDTO
    {
        [Required]
        [StringLength(255)]
        public string Name { get; private set; }
        [Required]
        public int teacherId { get; private set; }

        public CourseCreateDTO(string name, int teacherId)
        {
            Name = name;
            this.teacherId = teacherId;
        }
    }
}
