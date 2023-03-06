using CRIP.Services.IRepositorys;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CRIP.Models;
using CRIP.Database;

namespace CRIP.Services.Repositorys
{
    public class UserRepository : BaseRepository<CRIPUser>, IUserRepository
    {
        private readonly CRIPDbContext _CRIPDbContext;
        public UserRepository(CRIPDbContext CRIPDbContext) : base(CRIPDbContext)
        {
            _CRIPDbContext = CRIPDbContext;
        }
        //添加角色给用户
        public async Task AddRoleToUserAsync(IdentityUserRole<string> identityUserRole)
        {   
            await _CRIPDbContext.Set<IdentityUserRole<string>>().AddAsync(identityUserRole);
        }
      
    }
}
