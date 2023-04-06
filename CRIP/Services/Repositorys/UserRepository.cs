using CRIP.Services.IRepositorys;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CRIP.Models;
using CRIP.Database;
using CRIP.Common;
using StackExchange.Redis;

namespace CRIP.Services.Repositorys
{
    public class UserRepository : BaseRepository<CRIPUser>, IUserRepository
    {
        private readonly CRIPDbContext _CRIPDbContext;
        //获取或设置配置值的IConfiguration接口
        private readonly IConfiguration _configuration;
        //用户工具包
        private readonly UserManager<CRIPUser> _userManager;
        //登录工具包
        private readonly SignInManager<CRIPUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserRepository(CRIPDbContext CRIPDbContext, IConfiguration configuration, RoleManager<IdentityRole> roleManager,UserManager<CRIPUser> userManager, SignInManager<CRIPUser> signInManager) : base(CRIPDbContext)
        {
            _CRIPDbContext = CRIPDbContext;
            _configuration = configuration;
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        //添加角色给用户
        public async Task AddRoleToUserAsync(IdentityUserRole<string> identityUserRole)
        {   
            await _CRIPDbContext.Set<IdentityUserRole<string>>().AddAsync(identityUserRole);
        }
        /// <summary>
        /// 分页获得多个User
        /// </summary>
        /// <param name="keyword">模糊查找键值</param>
        /// <param name="orderby">安装什么排序，默认name，可选number，place</param>
        /// <param name="desc">是否倒叙，默认否</param>
        /// <param name="pageNumber">页数</param>
        /// <param name="pageSize">页面内容数量</param>
        /// <returns></returns>
        public async Task<PageList<CRIPUser>> GetAllUserAsync(string? keyword, string? FindString,string? userId, string? orderby, bool? desc, int pageNumber, int pageSize)
        {
            //获取集合
            IQueryable<CRIPUser> result = _CRIPDbContext.CRIPUsers;
            
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();
                if(FindString=="username")
                {
                    result = result.Where(t => t.UserName.Contains(keyword));
                }
                else if(FindString== "address")//判断用户角色是不是doctor，且地址包含keyword
                {
                    result = result.Where(u =>
                    _CRIPDbContext.UserRoles.FirstOrDefault(r =>r.UserId == userId).RoleId.Equals(_configuration["Roles:doctorGuid"])
                    &&u.Address.Contains(keyword));

                }
              
            }

            result = orderby switch
            {
                _ => (desc == true) ? result.OrderByDescending(a => a.UserName) : result.OrderBy(a => a.UserName)
            };

            return await PageList<CRIPUser>.CreateAsync(pageNumber, pageSize, result);
        }
    }
}
