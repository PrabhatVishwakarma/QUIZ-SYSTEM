using Microsoft.EntityFrameworkCore;
using Tool.Server.Model;

namespace Tool.Server.Repository 
{
    public class ScoreRepository : IRepository<Score> {

        readonly AppDbContext _dbContext;
        public ScoreRepository(AppDbContext appDbContext) {
            _dbContext = appDbContext;
        }
        public async Task<Score> CreateAsync(Score _object) {
            var obj = await _dbContext.Scores.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public Task DeleteAsync(int id) {
            throw new NotImplementedException();
        }

        public Task<List<Score>> GetAllAsync() {
            throw new NotImplementedException();
        }

        public Task<Score> GetByIdAsync(int Id) {
            throw new NotImplementedException();
        }

        public async Task<Score> GetByIdAsync(int quizId, string userId) 
        {
            return await _dbContext.Scores.FirstOrDefaultAsync(x => (x.QuizId == quizId && x.Id == userId));
        }

        public Task UpdateAsync(Score _object) {
            throw new NotImplementedException();
        }
    }
}
