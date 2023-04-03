
using Microsoft.AspNetCore.Identity;
using CRIP.Models;
using CRIP.Common;

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

        Task<PageList<CRIPUser>> GetAllUserAsync(string? keyword, string? FindString, string? userId, string? orderby, bool? desc, int pageNumber, int pageSize);

    }
}
