using System.ComponentModel.DataAnnotations;

namespace Tool.Server.Model
{
    public class Quiz
    {
        public Quiz()
        {
            this.Questions = new HashSet<Question>();
            this.Scores = new HashSet<Score>();
            this.QuizReports = new HashSet<QuizReport>();
        }

        [Key]
        public int QuizId { get; set; }
        [MaxLength(25)]
        public string QuizTitle { get; set; }
        public int MaxScore { get; set; }
        public int PassingScore { get; set; }
        public string QuizLevel { get; set; }
        public double Timer { get; set; }
        public int PublishedBy { get; set; }
        public DateTime PublishedAt { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int DeletedBy { get; set; }

        //Navigation Properties

        public ICollection<Question> Questions { get; set; }
        public ICollection<QuizReport> QuizReports { get; set; }
        public ICollection<Score> Scores { get; set; }

    }
}
