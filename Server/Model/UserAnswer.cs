using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Tool.Server.Model;

public class UserAnswer
{
    [Key]
    public int UserAnswerId { get; set; }
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public int Attempt { get; set; }
    public int QuestionId { get; set; }
    [ForeignKey("QuestionId")]

    public int UserSelectedOption { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int CreatedBy { get; set; }
    public int UpdatedBy { get; set; }
    public string Comment { get; set; }

    //Navigation Properties
    public Question Question { get; set; }
}
