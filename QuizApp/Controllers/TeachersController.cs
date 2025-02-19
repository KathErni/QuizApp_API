using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizApp.Domain.Data;
using QuizApp.Domain.DTO;
using QuizApp.Domain.Entity;

namespace QuizApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly QuizDbContext _context;
        private readonly IMapper _mapper;


        public TeachersController(QuizDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Teachers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
        {
            var teacher = await _context.Teachers.ToListAsync();

            return Ok(teacher);
        }

        // GET: api/Teachers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacher(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);

            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(teacher);
        }

        // PUT: api/Teachers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher(int id, [FromBody] UpdateTeacher updateTeacher)
        {
            var teacher = await _context.Quizzes.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            _mapper.Map(updateTeacher, teacher);
            var updatedTeacher = _context.Quizzes.Update(teacher).Entity;
            var addedTeacherDto = _mapper.Map<TeacherDTO>(updatedTeacher);
            var addedTeacher = await _context.SaveChangesAsync();

            return Ok(addedTeacher);
        }

        // POST: api/Teachers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostTeacher([FromBody] CreateTeacher newTeacher)
        {
            var teacher = _mapper.Map<Quiz>(newTeacher);

            var addedTeacher = _context.Quizzes.Add(teacher);
            var addedTeacherDto = _mapper.Map<TeacherDTO>(addedTeacher.Entity);
            await _context.SaveChangesAsync();


            return CreatedAtAction(nameof(GetTeacher), new { id = addedTeacherDto.Id }, addedTeacherDto);
        }


        // DELETE: api/Teachers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeacherExists(int id)
        {
            return _context.Teachers.Any(e => e.Id == id);
        }
    }
}
