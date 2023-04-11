using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tool.Server.Model;
using Tool.Server.Services;

namespace Tool.Server.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : Controller {

        private readonly IScoreService _scoreService;
        private readonly AppDbContext _Context;


        public ScoreController(IScoreService scoreService, AppDbContext Context) {
            _scoreService = scoreService;
            _Context = Context;
        }


        // GET: api/ScoreController/5
        [HttpGet("{scoreId}")]
        public async Task<ActionResult<Score>> GetScore(int scoreId)
        {
            var score = await _Context.Scores
                .Include(s => s.User)
                .Include(s => s.Quiz)
                .FirstOrDefaultAsync(s => s.ScoreId == scoreId);

            if (score == null)
            {
                return NotFound("Score not found.");
            }

            return Ok(score);
        }





        // GET: api/ScoreController/5
        [HttpGet("{quizId}/{userId}")]
        public async Task<ActionResult<Score>> GetScore(int quizId,string userId) 
        {
           return await _scoreService.GetScoreById(quizId, userId);
        }

        
        // POST: api/ScoreController
        [HttpPost]
        public async Task<ActionResult<Score>> PostScore([FromBody] Score score) {
            var quiz = await _Context.Quizs.FindAsync(score.QuizId);
            if (quiz == null) {
                return NotFound("Quiz not found.");
            }

            var user = await _Context.Users.FindAsync(score.Id);
            if (user == null) {
                return NotFound("User not found.");
            }

            _Context.Scores.Add(score);
            await _Context.SaveChangesAsync();

            return Ok(score);
        }
    }
}