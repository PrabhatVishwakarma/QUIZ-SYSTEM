using System.Collections.Generic;
using System.Threading.Tasks;
using Tool.Server.Model;
using Microsoft.EntityFrameworkCore;

namespace Tool.Server.Repository
{
    public class QuestionRepository : IRepository<Question>
    {
        private readonly AppDbContext _dbContext;

        public QuestionRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Question> CreateAsync(Question _object)
        {

            var obj = await _dbContext.Questions.AddAsync(_object);
            await _dbContext.SaveChangesAsync();
            return obj.Entity;
        }

        public async Task UpdateAsync(Question _object)
        {
            _dbContext.Questions.Update(_object);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Question>> GetAllAsync()
        {
            return await _dbContext.Questions.ToListAsync();
        }

        public async Task<Question> GetByIdAsync(int id)
        {
            return await _dbContext.Questions.FirstOrDefaultAsync(x => x.QuestionId == id);
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _dbContext.Questions.FirstOrDefaultAsync(x => x.QuestionId == id);

            if (data != null)
            {
                _dbContext.Questions.Remove(data);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
