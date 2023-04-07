using Tool.Server.Model;

namespace Tool.Server.Services 
{
    public interface IScoreService 
    {
        Task<Score> AddScore(Score score);
      
        Task<Score> GetScoreById(int quizId, string userId);

    }
}
