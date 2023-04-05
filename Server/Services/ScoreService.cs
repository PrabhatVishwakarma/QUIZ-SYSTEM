using Microsoft.EntityFrameworkCore;
using Tool.Server.Model;

namespace Tool.Server.Services {
    public class ScoreService : IScoreService 
    {
        private readonly IRepository<Score> _score;
        private readonly AppDbContext _context;
        private Score addedScore;

        public ScoreService(AppDbContext context, IRepository<Score> score) 
        {
            _context = context;
            _score = score;
        }

        public async Task<Score> AddScore(Score score) 
        {
            return addedScore = await _score.CreateAsync(score);
        }

        public async Task<Score> GetScoreById(int quizId, string userId) {
            return await _context.Scores.FirstOrDefaultAsync(q => (q.QuizId == quizId && q.Id == userId));
        }

        public async Task<Score> GetScoreByQuizId(int quizId) 
        {
            return await _context.Scores.FirstOrDefaultAsync(q => q.QuizId == quizId);
        }

        

        
    }
}
