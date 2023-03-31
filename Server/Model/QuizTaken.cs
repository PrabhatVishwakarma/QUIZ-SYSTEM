using System.ComponentModel.DataAnnotations.Schema;

namespace Tool.Server.Model
{
    public class QuizTaken
    {
        public int QuizTakenId { get; set; }
        [ForeignKey("ScoreId")]
        public int ScoreId { get; set; }
        public Score Scores { get; set; }

        public Quiz? Quiz { get; set; }



    }
}