using Microsoft.AspNetCore.Identity;

namespace kurikulum.Models.Entity.Identity
{
    public class AppUser:IdentityUser<string>
    {

        public string FullName { get; set; }    

        public string UserId { get; set; }  


        public string ReplayPassword { get; set; }  
    }
}
