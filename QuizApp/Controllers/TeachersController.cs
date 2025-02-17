//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using AutoMapper;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using QuizApp.Domain.Data;
//using QuizApp.Domain.Entity;

//namespace QuizApp.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class TeachersController : ControllerBase
//    {
//        private readonly QuizDbContext _context;
       

//        public TeachersController(QuizDbContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Teachers
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
//        {
//            var teacher = await _context.Teachers.ToListAsync();

//            return Ok(teacher);
//        }

//        // GET: api/Teachers/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Teacher>> GetTeacher(int id)
//        {
//            var teacher = await _context.Teachers.FindAsync(id);

//            if (teacher == null)
//            {
//                return NotFound();
//            }

//           return Ok(teacher);
//        }

//        // PUT: api/Teachers/5
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutTeacher(int id, Teacher teacher)
//        {
//            if (id != teacher.Id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(teacher).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!TeacherExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/Teachers
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost]
//        public async Task<ActionResult<Teacher>> PostTeacher(Teacher teacher)
//        {
//            _context.Teachers.Add(teacher);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetTeacher", new { id = teacher.Id }, teacher);
//        }

//        // DELETE: api/Teachers/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteTeacher(int id)
//        {
//            var teacher = await _context.Teachers.FindAsync(id);
//            if (teacher == null)
//            {
//                return NotFound();
//            }

//            _context.Teachers.Remove(teacher);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool TeacherExists(int id)
//        {
//            return _context.Teachers.Any(e => e.Id == id);
//        }
//    }
//}
