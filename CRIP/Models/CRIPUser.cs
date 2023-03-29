using Microsoft.AspNetCore.Identity;
using ServiceStack.DataAnnotations;

namespace CRIP.Models
{/// <summary>
/// User
/// </summary>
    public class CRIPUser:IdentityUser
    {
   
        //角色
        public virtual ICollection<IdentityUserRole<string>>  UserRoles { get; set; }
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
        public virtual ICollection<IdentityUserToken<string>> Tokens { get; set; }
    }
}
