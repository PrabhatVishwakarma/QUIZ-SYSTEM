using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tool.Server.Model
{
    public class Question
    {
        public Question()
        {
            this.UserAnswers = new HashSet<UserAnswer>();
        }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int QuestionId { get; set; }

        public int QuizId { get; set; }
        [ForeignKey("QuizId")]
        public Quiz Quiz { get; set; }
        [Required]
        public string QuestionText { get; set; }
        [Required]
        public string OptionOne { get; set; }
        [Required]
        public string OptionTwo { get; set; }
        [Required]
        public string OptionThree { get; set; }
        [Required]
        public string OptionFour { get; set; }

        [Required]
        public string IsCorrect { get; set; }
        public bool CheckBox1 { get; set; }
        public bool CheckBox2 { get; set; }
        public bool CheckBox3 { get; set; }
        public bool CheckBox4 { get; set; }
        public int QuestionOrder { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public byte[] QuestionMedia { get; set; }
        public string ToolTip { get; set; }
        public ICollection<UserAnswer> UserAnswers { get; set; }
    }
}
