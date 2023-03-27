using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tool.Server.Model;

namespace Tool.Server.Model;

public class QuizReport
{
    [Key]
    public int QuizReportId { get; set; }
    public int QuizId { get; set; }
    [ForeignKey("QuizId")]
    public Quiz Quiz { get; set; }
    public int ObtainedScore { get; set; }
    public int PassingScore { get; set; }
    public string Result { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int CreatedBy { get; set; }
    public int UpdatedBy { get; set; }
    public string Comment { get; set; }
    public int Attempt { get; set; }
}
