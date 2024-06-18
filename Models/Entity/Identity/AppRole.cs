using kurikulum.Models.Entity.Enum;
using Microsoft.AspNetCore.Identity;

namespace kurikulum.Models.Entity.Identity
{
    public class AppRole:IdentityRole<string>
    {
        public RoleModel Role { get; set; } 
    }
}
