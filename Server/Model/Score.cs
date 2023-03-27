using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tool.Server.Model;

public class Score
{
    [Key]
    public int ScoreId { get; set; }
    public int QuizId { get; set; }
    [ForeignKey("QuizId")]
    public int ObtainedScore { get; set; }

    //Navigation Properties
    public Quiz Quiz { get; set; }
}
