using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Tool.Server.Helpers;
using Tool.Server.Model;
using Tool.Shared.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tool.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {

        private readonly IQuizService _quizService;
        private readonly AppDbContext _dbContext;


        public QuizController(IQuizService quizService, AppDbContext dbContext)
        {
            _quizService = quizService;
            _dbContext = dbContext;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<Quiz> GetQuizById(int id)
        {
            var quiz = await _dbContext.Quizs.Include(q => q.Questions).Where(a => a.QuizId == id).FirstOrDefaultAsync();
            return quiz;
        }


        // GET: api/<QuizController>
        [HttpGet]
        [Route("all")]
        public async Task<List<Quiz>> GetAll([FromQuery] PaginationDTO pagination) 
        {
            var queryable = _dbContext.Quizs.AsQueryable();
            await HttpContext.InsertPaginationParameterInResponse(queryable, pagination.QuantityPerPage);
            return await queryable.Paginate(pagination).ToListAsync();
        }

        // POST api/<QuizController>
        public async Task<bool> Post([FromBody] Quiz quiz)
        {
            Console.WriteLine("hlelloo");

            // Check if the quiz already exists in the database
            Quiz existingQuiz = await _quizService.GetQuizByTitleAsync(quiz.QuizTitle);
            if (existingQuiz != null)
            {
                // Quiz already exists, return false to indicate failure
                return false;
            }

            // Quiz doesn't exist, add it to the database
            Quiz newQuiz = await _quizService.AddQuizCategory(quiz);
            if (newQuiz != null)
            {
                // Quiz added successfully, return true to indicate success
                return true;
            }
            else
            {
                // Quiz could not be added, return false to indicate failure
                return false;
            }
        }


        // PUT api/<QuizController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<QuizController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }

    }
}