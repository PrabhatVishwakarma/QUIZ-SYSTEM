using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tool.Server.Model;

public class QuestionType
{
    [Key]
    public int QuestionTypeId { get; set; }
    public string Type { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int UpdatedBy { get; set; }
    public int CreatedBy { get; set; }

    //Navigation properties
    public int QuestionId { get; set; }
    [ForeignKey("QuestionId")]

    public Question Question { get; set; }


}
