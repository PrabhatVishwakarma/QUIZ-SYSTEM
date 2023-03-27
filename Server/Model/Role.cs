using System.ComponentModel.DataAnnotations;
using Tool.Server.Model;

namespace Tool.Server.Model;

public class Role
{
    [Key]
    public string RoleCode { get; set; }
    public string RoleDiscription { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int CreatedBy { get; set; }
    public int UpdatedBy { get; set; }

    //Navigation Properties
}
