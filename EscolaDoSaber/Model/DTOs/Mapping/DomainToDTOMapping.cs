using AutoMapper;

namespace EscolaDoSaber.Model.DTOs.Mapping
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            CreateMap<TeacherCreateDTO, Teacher>();
            CreateMap<Teacher, TeacherCreateDTO>();
            CreateMap<StudentCreateDTO, Student>();
            CreateMap<Student, StudentResponseDTO>();
            CreateMap<StudentUpdateDTO, Student>();
            CreateMap<Student, StudentUpdateDTO>();
            CreateMap<CourseCreateDTO, Course>();
        }
    }
}
