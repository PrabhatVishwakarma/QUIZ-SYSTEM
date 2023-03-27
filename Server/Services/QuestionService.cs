using Microsoft.EntityFrameworkCore;
using Tool.Server.Model;



namespace Tool.Server.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IRepository<Question> _question;
        private readonly AppDbContext _context;
        private Question addedQuestion;



        public QuestionService(AppDbContext context, IRepository<Question> question)
        {
            _context = context;
            _question = question;
        }



        public async Task<Question> AddQuestion(Question question)
        {
            await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();
            return question;

            //return await _question.CreateAsync(question);
        }



        public async Task<bool> UpdateQuestion(int id, Question question)
        {
            var data = await _question.GetByIdAsync(id);



            if (data != null)
            {
                data.QuestionText = question.QuestionText;
                data.OptionOne = question.OptionOne;
                data.OptionTwo = question.OptionTwo;
                data.OptionThree = question.OptionThree;
                data.OptionFour = question.OptionFour;
                data.IsCorrect = question.IsCorrect;
                data.CheckBox1 = question.CheckBox1;
                data.CheckBox2 = question.CheckBox2;
                data.CheckBox3 = question.CheckBox3;
                data.CheckBox4 = question.CheckBox4;

                await _question.UpdateAsync(data);
                return true;
            }
            else
            {
                return false;
            }
        }



        public async Task<bool> DeleteQuestion(int id)
        {
            await _question.DeleteAsync(id);
            return true;
        }



        public async Task<List<Question>> GetAllQuestion()
        {
            return await _question.GetAllAsync();
        }



        public async Task<Question> GetQuestionByTextAsync(string questionText)
        {
            return await _context.Questions.FirstOrDefaultAsync(q => q.QuestionText == questionText);
        }
        public async Task<Question> GetQuestion(int id)
        {
            return await _context.Questions.Include(q => q.Quiz).Where(a => a.QuestionId == id).FirstOrDefaultAsync();
        }
        public async Task<Question> GetQuestionByQuizIdAndTextAsync(int quizId, string questionText)
        {
            return await _context.Questions.Include(q => q.Quiz).FirstOrDefaultAsync(q => q.QuizId == quizId && q.QuestionText == questionText);
        }
    }
}