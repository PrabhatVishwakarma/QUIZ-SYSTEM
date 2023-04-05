using Microsoft.EntityFrameworkCore;
using System;
using Tool.Server.Model;

namespace Tool.Server.Repository
{
    public class QuizRepository : IRepository<Quiz>
    {

        readonly AppDbContext _dbContext;
        public QuizRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<Quiz> CreateAsync(Quiz _object)
        {
            var obj = await _dbContext.Quizs.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }
        public async Task UpdateAsync(Quiz _object)
        {
            _dbContext.Quizs.Update(_object);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<Quiz>> GetAllAsync()
        {
            return await _dbContext.Quizs.ToListAsync();
        }

        public async Task<Quiz> GetByIdAsync(int Id)
        {
            return await _dbContext.Quizs.FirstOrDefaultAsync(x => x.QuizId == Id);
        }

        Task IRepository<Quiz>.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Quiz> GetByIdAsync(int quizId, string userId) {
            throw new NotImplementedException();
        }
    }
}