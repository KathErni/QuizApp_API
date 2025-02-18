using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using QuizApp.Domain.Data;
using QuizApp.Domain.DTO;
using QuizApp.Domain.Entity;

namespace QuizApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzesController : ControllerBase
    {
        private readonly QuizDbContext _context;
        private readonly IMapper _mapper;

        public QuizzesController(QuizDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        // GET: api/Quizzes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quiz>>> GetQuizzes()
        {
           var quiz = await _context.Quizzes.ToListAsync();
            var quizDTO = _mapper.Map<List<QuestionDTO>>(quiz);
            return Ok(quizDTO);
        }

        // GET: api/Quizzes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quiz>> GetQuiz(int id)
        {
            var quiz = await _context.Quizzes.FindAsync(id);

            if (quiz == null)
            {
                return NotFound();
            }
            var quizDTO = _mapper.Map<QuestionDTO>(quiz);

            return Ok(quizDTO);
        }

        // PUT: api/Quizzes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuiz(int id, [FromBody] CreateQuestion updateQuiz)
        {
            var quiz = await _context.Quizzes.FindAsync(id);
            if (quiz == null)
            {
                return NotFound();
            }
            _mapper.Map(updateQuiz, quiz);
            var updatedQuiz = _context.Quizzes.Update(quiz).Entity;
            var addedQuizDTO = _mapper.Map<QuestionDTO>(updatedQuiz);
            var addedQuiz = await _context.SaveChangesAsync();

            return Ok(addedQuiz);
        }

       // POST: api/Quizzes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostQuiz([FromBody] CreateQuestion newQuiz)
        {
           var quiz= _mapper.Map<Quiz>(newQuiz);

           var addedQuiz = _context.Quizzes.Add(quiz);
            var addedQuizDTO = _mapper.Map<QuestionDTO>(addedQuiz.Entity);
            await _context.SaveChangesAsync();


            return CreatedAtAction(nameof(GetQuiz), new { id = addedQuizDTO.QuizId }, addedQuizDTO);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuiz(int id)
        {
            var quiz = await _context.Quizzes.FindAsync(id);
            if (quiz == null)
            {
                return NotFound();
            }

            _context.Quizzes.Remove(quiz);
            await _context.SaveChangesAsync();

            return NoContent();
        }

   
    }
}
