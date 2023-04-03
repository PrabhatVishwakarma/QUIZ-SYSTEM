using System.ComponentModel.DataAnnotations;

namespace Tool.Shared
{
    public class QuestionViewModel
    {

        public int QuizId { get; set; }
        public int QuestionId { get; set; }

        [Required(ErrorMessage = "This field Cann't be empty")]
        [Display(Name = "Question Text")]
        public string QuestionText { get; set; }

        [Required]
        [Display(Name = "Option 1")]
        public string OptionOne { get; set; }

        [Required]
        [Display(Name = "Option 2")]
        public string OptionTwo { get; set; }

        [Required]
        [Display(Name = "Option 3")]
        public string OptionThree { get; set; }
        [Required]
        [Display(Name = "Option 4")]
        public string OptionFour { get; set; }


        public bool CheckBox1 { get; set; }
        public bool CheckBox2 { get; set; }
        public bool CheckBox3 { get; set; }
        public bool CheckBox4 { get; set; }


        public bool userAnswer1 { get; set; } = false;
        public bool userAnswer2 { get; set; } = false;
        public bool userAnswer3 { get; set; } = false;
        public bool userAnswer4 { get; set; } = false;

        public QuizViewModel Quiz { get; set; }

        public string IsCorrect { get; set; }
    }
}