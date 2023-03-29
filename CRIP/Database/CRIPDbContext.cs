using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CRIP.Models;

namespace CRIP.Database
{
    public class CRIPDbContext:IdentityDbContext<CRIPUser>
    {
        public CRIPDbContext(DbContextOptions<CRIPDbContext> options) : base(options)
        { 

        }
        /// <summary>
        /// 用户
        /// </summary>
        public DbSet<CRIPUser> CRIPUsers { get; set; }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<LineItem> LineItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            #region 添加管理员
            //更新了原先User的外键变为CRIPUser的外键,绑定CRIPUser外键
            builder.Entity<CRIPUser>
           (
                user => user.HasMany(x => x.UserRoles)   //每一个用户对应多个角色
                .WithOne()                                //每一个角色
                .HasForeignKey(u => u.UserId).IsRequired()//角色的配置(必须有UserId)
           );
            //添加管理员角色
            var adminGuid = "308660dc-ae51-480f-824d-7dca6714c3e2";
            builder.Entity<IdentityRole>().HasData
            (
                new IdentityRole()
                {
                    Id = adminGuid,
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                }
            );


            //添加管理员的用户
            var adminUserId = "90184155-dee0-40c9-bb1e-b5ed07afc04e";
            //Hash工具
            var passwordHasher = new PasswordHasher<CRIPUser>();
            CRIPUser adminUser = new CRIPUser()
            {
                Id = adminUserId,
                UserName = "Admin@qq.com",         
                Email = "CRIPAdmin@qq.com",   
            };
            //Hash密码
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "123456");
            builder.Entity<CRIPUser>().HasData(adminUser);


            //给管理员用户添加管理员角色
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {
                    UserId = adminUserId,
                    RoleId = adminGuid
                }
            );
            #endregion

            #region 添加普通用户角色
            //添加普通用户角色
            var ordinaryUserGuid = "ce82c36a-ca40-8e0a-3b89-53dc06850c3c";
            builder.Entity<IdentityRole>().HasData
            (
              new IdentityRole()
              {
                  Id = ordinaryUserGuid,
                  Name = "OrdinaryUser",
                  NormalizedName = "ordinaryUser".ToUpper()
              }
            );
            #endregion

            #region 给管理员用户添加普通用户角色
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {
                    UserId = adminUserId,
                    RoleId = ordinaryUserGuid
                }
            );
            #endregion

            base.OnModelCreating(builder);
        }


    }
}
