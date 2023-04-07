using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.Shared
{
    public class ScoreViewModel
    {
        public int ScoreId { get; set; }
        public int QuizId { get; set; }
        public int ObtainedScore { get; set; }
        public IdentityUser Id { get; set; }

    }
}
