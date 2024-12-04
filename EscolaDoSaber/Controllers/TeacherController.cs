using AutoMapper;
using EscolaDoSaber.Infra;
using EscolaDoSaber.Model;
using EscolaDoSaber.Model.DTOs;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDoSaber.Controllers
{
    [Route("/professor")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private TeacherDAL _teacherDAL;
        private IMapper _mapper;

        public TeacherController(TeacherDAL teacherDAL, IMapper mapper)
        {
            _teacherDAL = teacherDAL;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Add([FromBody]TeacherCreateDTO teacherDTO)
        {
            var teacher = _mapper.Map<Teacher>(teacherDTO);
            _teacherDAL.Add(teacher);
            return CreatedAtAction(nameof(FindOne), new { id = teacher.Id }, _mapper.Map<TeacherResponseDTO>(teacher));
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult GetAll([FromQuery]int skip = 0, [FromQuery]int take = 25)
        {
            var list = _teacherDAL.GetSome(skip, take);
            if (list.Count() == 0) return NotFound("Não a registros!");
            var mappedList = _mapper.Map<IEnumerable<TeacherCreateDTO>>(list);
            return Ok(mappedList);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] TeacherCreateDTO teacherDTO, int id)
        {
            var teacher = FindById(id);
            if (teacher == null) return NotFound();
            _teacherDAL.Update(_mapper.Map(teacherDTO, teacher));
            return NoContent();

        }

        [HttpPatch("{id}")]
        public IActionResult UpdatePatch(JsonPatchDocument<TeacherCreateDTO> patch, int id)
        {
            var teacher = FindById(id);
            if (teacher == null) return NotFound();

            var TeacherToUpdate = _mapper.Map<TeacherCreateDTO>(teacher);
            patch.ApplyTo(TeacherToUpdate, ModelState);

            if(!TryValidateModel(TeacherToUpdate))
            {
                return ValidationProblem(ModelState);
            }

            _teacherDAL.Update(_mapper.Map(TeacherToUpdate, teacher));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var teacher = FindById(id);
            if (teacher == null) return NotFound();

            _teacherDAL.Remove(teacher);
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult FindOne(int id)
        {
            var teacher = FindById(id);  
            if(teacher == null) return NotFound();
            return Ok(_mapper.Map<TeacherResponseDTO>(teacher));
        }

        private Teacher FindById(int id)
        {
            var teacher = _teacherDAL.FindBy(e => e.Id == id);
            return teacher;
        }
    }
}
