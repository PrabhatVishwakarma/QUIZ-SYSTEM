using System.Threading.Tasks;
using Tool.Server.Model;


public interface IQuizService
{
    Task<Quiz> AddQuizCategory(Quiz quiz);

    Task<List<Quiz>> GetAllQuizCategory();
    Task<Quiz> GetQuizCategory(int id);

    Task<bool> UpdateQuizCategory(int id, Quiz quiz);

    Task<bool> DeleteQuizCategory(int id);
    Task<Quiz> GetQuizByTitleAsync(string quizTitle);


}