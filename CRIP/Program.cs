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

#region redis��������
//redis����
var section = builder.Configuration.GetSection("Redis:Default");
//�����ַ���
string _connectionString = section.GetSection("Connection").Value;
//ʵ������
string _instanceName = section.GetSection("InstanceName").Value;
//Ĭ�����ݿ� 
int _defaultDB = int.Parse(section.GetSection("DefaultDB").Value ?? "0");
builder.Services.AddSingleton(new RedisHelper(_connectionString, _instanceName, _defaultDB));
#endregion

#region ����AutoMapper
//ɨ��profile�ļ� �������ļ���ϵͳ��ӳ�����profile����
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion

#region ע��Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "Ver:1.0.0",//�汾
        Title = "CRIP",//����
        Description = "��̨�ӿ�",//����
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "CRIP",
            Email = "3125156343@qq.com"
        }
    });

    var file = Path.Combine(AppContext.BaseDirectory, "CRIP.xml");  // xml�ĵ�����·��
    var path = Path.Combine(AppContext.BaseDirectory, file); // xml�ĵ�����·��
    options.IncludeXmlComments(path, true);      // true : ��ʾ��������ע��
    options.OrderActionsBy(o => o.RelativePath); // ��action�����ƽ�����������ж�����Ϳ��Կ���Ч���ˡ�

    #region swagger �� Jwt��֤
    //����Ȩ��С��
    options.OperationFilter<AddResponseHeadersFilter>();
    options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

    //��header�����token�����ݵ���̨
    options.OperationFilter<SecurityRequirementsOperationFilter>();
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "JWT��Ȩ(���ݽ�������ͷ�н��д���)ֱ���������������Bearer {token}(ע������֮����һ���ո�) \"",
        Name = "Authorization",//jwtĬ�ϵĲ�������
        In = ParameterLocation.Header,//jwtĬ�ϴ��Authorization��Ϣ��λ��(����ͷ��)
        Type = SecuritySchemeType.ApiKey
    });
    #endregion

});
#endregion

#region  IUrlHelper����ע��
builder.Services
       .AddSingleton<IActionContextAccessor, ActionContextAccessor>()
       .AddMvc();
#endregion

#region Jwt������
//ע��JWT��֤����,AddAuthentication��Ҫ����Ĭ�ϵ��������  AuthenticationSchemeĬ��ΪBearer
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options => //ʹ��lamada����JWT��֤ ��Bearer �� ����
{
    var secretByte = Encoding.UTF8.GetBytes(builder.Configuration["Authentication:SecretKey"]);
    options.TokenValidationParameters = new TokenValidationParameters()//TokenValidationParameters ��������֤����
    {
        //��һ���֣���֤token�ķ�����
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["Authentication:Issuer"],

        //�ڶ����֣���֤token�ĳ�����
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Authentication:Audience"],

        //�������֣���֤token�Ƿ����
        ValidateLifetime = true,

        //���һ���֣���token��˽Կ���룬���ҽ��м���
        IssuerSigningKey = new SymmetricSecurityKey(secretByte)

    };
});
#endregion

#region Identity

builder.Services.AddIdentity<CRIPUser, IdentityRole>(option =>
{
    #region �û�����ʽ
    //�û���������ַ�
    option.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789@.";
    //��Ҫ����
    option.User.RequireUniqueEmail = true;
    #endregion
    #region �����ʽ
    //��Ҫ����
    option.Password.RequireDigit = true;
    //����Ϊ8λ
    option.Password.RequiredLength = 8;
    //�����������ַ�
    option.Password.RequireNonAlphanumeric = false;
    #endregion
    //��֤�˻�ʧ�ܴ���
    option.Lockout.MaxFailedAccessAttempts = 10;
})//�û�����ģ�ͣ��û���ɫ����ģ��
  //ʹ��AddEFstores�����������Ĺ�ϵ����
 .AddEntityFrameworkStores<CRIPDbContext>()
 .AddDefaultTokenProviders();
#endregion

#region ʹ�������ַ����������ݿ�
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
#region JWT��Ȩ��֤�м��
app.UseRouting();         //�� app.UseRouting()֮����app.UseEndpoints(��֮ǰ�����Ӽ�Ȩ��Ȩ
app.UseAuthentication();  //��Ȩ��app.UseAuthentication()����û��Ƿ��¼
app.UseAuthorization();   //��Ȩ��app.UseAuthorization() ��Ȩ �����û��Ȩ�ޣ��Ƿ��ܹ����ʺ�����ҳ�湦��
#endregion

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
