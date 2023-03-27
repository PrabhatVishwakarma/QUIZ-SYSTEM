using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Tool.Server.Model;

namespace Tool.Server.Services
{
    public class QuizService : IQuizService
    {
        private readonly IRepository<Quiz> _quiz;
        private Quiz addedQuiz;
        private readonly AppDbContext _context;


        public QuizService(AppDbContext context, IRepository<Quiz> quiz)
        {
            _context = context;
            _quiz = quiz;
        }
        public async Task<Quiz> AddQuizCategory(Quiz quiz)
        {
            return addedQuiz = await _quiz.CreateAsync(quiz);
        }

        public async Task<List<Quiz>> GetAllAsync()
        {
            return await _quiz.GetAllAsync();
        }

        public async Task<List<Quiz>> GetAllQuizCategory()
        {
            return await _quiz.GetAllAsync();
        }

        public async Task<bool> DeleteQuizCategory(int id)
        {
            await _quiz.DeleteAsync(id);
            return true;
        }

        public async Task<Quiz> GetQuizCategory(int id)
        {
            return await _quiz.GetByIdAsync(id);
        }

        public async Task<Quiz> GetQuizByTitleAsync(string quizTitle)
        {
            return await _context.Quizs.FirstOrDefaultAsync(q => q.QuizTitle == quizTitle);
        }

        public Task<bool> UpdateQuizCategory(int id, Quiz quiz)
        {
            throw new NotImplementedException();
        }
    }
}