using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using CRIP.Database;
using CRIP.Helper;
using CRIP.Models;
using CRIP.Services.IRepositorys;
using CRIP.Services.Repositorys;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

#region redis服务依赖
//redis缓存
var section = builder.Configuration.GetSection("Redis:Default");
//连接字符串
string _connectionString = section.GetSection("Connection").Value;
//实例名称
string _instanceName = section.GetSection("InstanceName").Value;
//默认数据库 
int _defaultDB = int.Parse(section.GetSection("DefaultDB").Value ?? "0");
builder.Services.AddSingleton(new RedisHelper(_connectionString, _instanceName, _defaultDB));
#endregion

#region 配置AutoMapper
//扫描profile文件 （配置文件，系统的映射关由profile管理）
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion

#region 注册Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "Ver:1.0.0",//版本
        Title = "CRIP",//标题
        Description = "后台接口",//描述
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "CRIP",
            Email = "3125156343@qq.com"
        }
    });

    var file = Path.Combine(AppContext.BaseDirectory, "CRIP.xml");  // xml文档绝对路径
    var path = Path.Combine(AppContext.BaseDirectory, file); // xml文档绝对路径
    options.IncludeXmlComments(path, true);      // true : 显示控制器层注释
    options.OrderActionsBy(o => o.RelativePath); // 对action的名称进行排序，如果有多个，就可以看见效果了。

    #region swagger 用 Jwt验证
    //开启权限小锁
    options.OperationFilter<AddResponseHeadersFilter>();
    options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

    //在header中添加token，传递到后台
    options.OperationFilter<SecurityRequirementsOperationFilter>();
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "JWT授权(数据将在请求头中进行传递)直接在下面框中输入Bearer {token}(注意两者之间是一个空格) \"",
        Name = "Authorization",//jwt默认的参数名称
        In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
        Type = SecuritySchemeType.ApiKey
    });
    #endregion

});
#endregion

#region  IUrlHelper服务注入
builder.Services
       .AddSingleton<IActionContextAccessor, ActionContextAccessor>()
       .AddMvc();
#endregion

#region Jwt的配置
//注册JWT认证服务,AddAuthentication需要填入默认的身份类型  AuthenticationScheme默认为Bearer
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options => //使用lamada配置JWT认证 ，Bearer ： 承载
{
    var secretByte = Encoding.UTF8.GetBytes(builder.Configuration["Authentication:SecretKey"]);
    options.TokenValidationParameters = new TokenValidationParameters()//TokenValidationParameters ：令牌验证参数
    {
        //第一部分，验证token的发布者
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["Authentication:Issuer"],

        //第二部分，验证token的持有者
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Authentication:Audience"],

        //第三部分，验证token是否过期
        ValidateLifetime = true,

        //最后一部分，将token的私钥传入，并且进行加密
        IssuerSigningKey = new SymmetricSecurityKey(secretByte)

    };
});
#endregion

#region Identity

builder.Services.AddIdentity<CRIPUser, IdentityRole>(option =>
{
    #region 用户名格式
    //用户名允许的字符
    option.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789@.";
    //需要邮箱
    option.User.RequireUniqueEmail = true;
    #endregion
    #region 密码格式
    //需要数字
    option.Password.RequireDigit = true;
    //长度为8位
    option.Password.RequiredLength = 8;
    //不允许特殊字符
    option.Password.RequireNonAlphanumeric = false;
    #endregion
    //验证账户失败次数
    option.Lockout.MaxFailedAccessAttempts = 10;
})//用户数据模型，用户角色数据模型
  //使用AddEFstores来连接上下文关系对象
 .AddEntityFrameworkStores<CRIPDbContext>()
 .AddDefaultTokenProviders();
#endregion

#region 使用连接字符串连接数据库
builder.Services.AddDbContext<CRIPDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DbStr"));
});
#endregion

builder.Services.AddTransient<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
#region JWT授权认证中间件
app.UseRouting();         //在 app.UseRouting()之后，在app.UseEndpoints(）之前，增加鉴权授权
app.UseAuthentication();  //鉴权：app.UseAuthentication()检测用户是否登录
app.UseAuthorization();   //授权：app.UseAuthorization() 授权 检测有没有权限，是否能够访问后续的页面功能
#endregion

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
