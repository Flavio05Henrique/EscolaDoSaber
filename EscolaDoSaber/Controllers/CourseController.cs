using AutoMapper;
using EscolaDoSaber.Infra;
using EscolaDoSaber.Model;
using EscolaDoSaber.Model.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDoSaber.Controllers
{
    [ApiController]
    [Route("/curso")]
    public class CourseController : ControllerBase
    {
        private CourseDAL _courseDAL;
        private TeacherDAL _teacherDAL;
        private IMapper _mapper;

        public CourseController(CourseDAL courseDAL, TeacherDAL teacherDAL, IMapper mapper)
        {
            _courseDAL = courseDAL;
            _teacherDAL = teacherDAL;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateCourse([FromBody]CourseCreateDTO courseDTO)
        {
            var teacher = _teacherDAL.FindBy(e => e.Id == courseDTO.teacherId);
            if (teacher == null) return NotFound("Id informado não consta");
            
            var course = _mapper.Map<Course>(courseDTO);
            course.SetTeacher(teacher);
            Console.WriteLine(course);
            _courseDAL.Add(course);
            return CreatedAtAction(nameof(FindOne), new { Id = course.Id }, course);
        }

        [HttpGet("teacher/{id}")]
        public IActionResult GetCourseTeacher(int id)
        {
          var teacher = _teacherDAL.FindBy(e => e.Id == id);
          if (teacher == null) return NotFound("Professor não registrado");

          var courses = new List<CourseResponseDTO>();
          foreach (Course c in teacher.Courses)
          {
                courses.Add(new CourseResponseDTO(teacher, c));
          }

          return Ok(courses);
        }

        [HttpGet("listar")]
        public IActionResult GetAll()
        {
            var courses = _courseDAL.GetAll().Select(c => new CourseResponseDTO(c.Teacher, c));
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public IActionResult FindOne(int id)
        {
            var course = FindById(id);
            if (course == null) return NotFound();
            return Ok(course);
        }

        private Course? FindById(int id)
        {
            var course = _courseDAL.FindBy(e => e.Id == id);
            return course;
        }
    }
}
