
using Microsoft.AspNetCore.Identity;
using CRIP.Models;

namespace CRIP.Services.IRepositorys
{
    public interface IUserRepository : IBaseRepository<CRIPUser>
    {
    /// <summary>
    /// 添加role给user
    /// </summary>
    /// <param name="identityUserRole"></param>
    /// <returns></returns>
        Task AddRoleToUserAsync(IdentityUserRole<string> identityUserRole);
 
        
   
    }
}
