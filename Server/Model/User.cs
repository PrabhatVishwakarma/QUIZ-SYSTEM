using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tool.Server.Model
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Scores = new HashSet<Score>();
        }


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserSummary { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        //Navigation Properties
        public virtual ICollection<Score> Scores { get; set; }


    }
}
