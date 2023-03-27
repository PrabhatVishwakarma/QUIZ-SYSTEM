using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tool.Shared;

public class QuizViewModel
{
    public int QuestionId { get; set; }
    public int QuizId
    {
        get;
        set;
    }

    [Required]
    [Display(Name = "QuizTitle")]
    public string QuizTitle
    {
        get;
        set;
    }
    [Required]
    [Display(Name = "Timer")]
    public double Timer
    {
        get;
        set;
    }

    public List<QuestionViewModel> Questions
    {
        get; set;
    }
}
