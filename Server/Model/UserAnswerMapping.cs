using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tool.Server.Model;

namespace Tool.Server.Model;

public class UserAnswerMapping
{
    [Key]
    public int UserAnsweringMappingId { get; set; }
    public int Attempt { get; set; }
    public int QuestionId { get; set; }
    [ForeignKey("QuestionId")]
    public int UserSelectedOption { get; set; }
    public int Score { get; set; }

    //Navigation Properties
    public Question Question { get; set; }

}
