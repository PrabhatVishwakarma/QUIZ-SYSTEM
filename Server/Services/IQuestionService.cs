using System.Collections.Generic;
using System.Threading.Tasks;
using Tool.Server.Model;

namespace Tool.Server.Services
{
    public interface IQuestionService
    {
        Task<Question> AddQuestion(Question question);
        Task<bool> UpdateQuestion(int id, Question question);
        Task<bool> DeleteQuestion(int id);
        Task<List<Question>> GetAllQuestion();
        Task<Question> GetQuestion(int id);
        Task<Question> GetQuestionByTextAsync(string questionText);
        Task<Question> GetQuestionByQuizIdAndTextAsync(int quizId, string questionText);
    }
}
