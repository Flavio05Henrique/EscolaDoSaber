namespace EscolaDoSaber.Model.DTOs
{
    public class CourseResponseDTO
    {

        public int Id { get; private set; }//Provisorio.
        public string Name { get; private set; }
        public string Teacher { get; private set; }
        public string Discipline { get; private set; }
        public CourseResponseDTO(Teacher teacher, Course course)
        {
            Id = course.Id;
            Name = course.Name;
            Teacher = teacher.Name;
            Discipline = teacher.Discipline;
        }
    }
}
