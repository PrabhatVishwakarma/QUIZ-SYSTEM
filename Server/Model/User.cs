using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tool.Server.Model
{
    [Table("User", Schema = "dbo")]
    public class User
    {
        public User()
        {
            this.Scores = new HashSet<Score>();
        }
        [Key]
        public int UserId { get; set; }

        public string RoleCode { get; set; }
        [ForeignKey("RoleCode")]
        public Role Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Mobile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserSummary { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

        //Navigation Properties
        public virtual ICollection<Score> Scores { get; set; }


    }
}

