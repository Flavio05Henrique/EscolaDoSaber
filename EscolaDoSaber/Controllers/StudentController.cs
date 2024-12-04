using AutoMapper;
using EscolaDoSaber.Infra;
using EscolaDoSaber.Model;
using EscolaDoSaber.Model.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDoSaber.Controllers
{
    [Route("/estudante")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private StudentDAL _studentDAL;
        private IMapper _mapper;

        public StudentController(StudentDAL studentDAL, IMapper mapper)
        {
            _studentDAL = studentDAL;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Add([FromBody]StudentCreateDTO studentDTO)
        {
            var student = _mapper.Map<Student>(studentDTO);
            _studentDAL.Add(student);
            return CreatedAtAction(nameof(FindOne), new { Id = student.Id }, _mapper.Map<StudentResponseDTO>(student));
        }

        [HttpGet("listar")]
        public IActionResult GetAll([FromQuery] int skip = 0, [FromQuery] int take = 25)
        {
            var list = _studentDAL.GetSome(skip, take);
            if (list.Count() == 0) return NotFound("Não a resgistros");
            return Ok(_mapper.Map<IEnumerable<StudentResponseDTO>>(list));

        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] StudentUpdateDTO studentDTO, int id)
        {
            var student = FindById(id);
            if (student == null) return NotFound();
            _studentDAL.Update(_mapper.Map(studentDTO, student));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = FindById(id);
            if (student == null) return NotFound();
            _studentDAL.Remove(student);
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult FindOne(int id)
        {
            var student = FindById(id);
            if (student == null) return NotFound();
            return Ok(_mapper.Map<StudentResponseDTO>(student));
        }

        private Student? FindById(int id)
        {
            var student = _studentDAL.FindBy(e => e.Id == id);
            return student;
        }
    }

}
