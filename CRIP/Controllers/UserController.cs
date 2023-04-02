using CRIP.ResourceParameters;
using CRIP.Services.IRepositorys;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using CRIP.Common;
using CRIP.Helper;
using CRIP.Models;
using StackExchange.Redis;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CRIP.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Net.Http.Headers;
using AutoMapper;
using CRIP.Dtos;
using CRIP.Dtos.GoodsDtos;
using CRIP.Services.Repositorys;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRIP.Controllers
{/// <summary>
/// 用户控制器
/// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region 依赖注入
        //用户工具包
        private readonly UserManager<CRIPUser> _userManager;
        //登录工具包
        private readonly SignInManager<CRIPUser> _signInManager;
        //角色工具包
        private readonly RoleManager<IdentityRole> _roleManager;
        //AutoMapper
        private readonly IMapper _mapper;
        //获取或设置配置值的IConfiguration接口
        private readonly IConfiguration _configuration;
        //缓存验证码
        private readonly IDatabase _redis;
        //使用HttpContext的接口
        private readonly IHttpContextAccessor _httpContextAccessor;
        //用户仓库
        private readonly IUserRepository _userRepository;
        //购物车仓库
        private readonly ICartRepository _cartRepository;
        public UserController(
            IConfiguration configuration,
            UserManager<CRIPUser> userManager,
            SignInManager<CRIPUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IHttpContextAccessor httpContextAccessor,
            RedisHelper client,
            IUserRepository userRepository,
            ICartRepository cartRepository,
            IMapper mapper
        )
        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _httpContextAccessor = httpContextAccessor;
            _redis = client.GetDatabase();
            _userRepository = userRepository;
            _mapper = mapper;
            _cartRepository = cartRepository;
        }
        #endregion

        #region 登录
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginParameter"></param>
        /// <returns></returns>
        [HttpPost("Login")]//     auth/login
        public async Task<IActionResult> LoginAsync([FromBody] LoginParameter loginParameter)
        {
            PagesResponse pagesResponse = new PagesResponse();

            #region 参数解释
            /*1.验证用户名密码
               参数
             userName
             String
             登录所用的用户名。
             password
             String
             尝试登录时所用的密码。
             isPersistent
             Boolean
             指示在关闭浏览器后登录 cookie 是否应保持不变的标志。
             lockoutOnFailure
             Boolean
             指示登录失败时是否应锁定用户帐户的标志。
            */
            #endregion
            //查询数据库中user
            var userFromRepo = await _userManager.FindByEmailAsync(loginParameter.Email);
            if (userFromRepo == null)
            {
                pagesResponse.BadRequest("用户不存在!");
                return BadRequest(pagesResponse);
            }
            #region 1.验证数据
            var loginResult = await _signInManager.PasswordSignInAsync(
                userFromRepo.UserName,
                loginParameter.Password,
                false,
                false
                );


            if (!loginResult.Succeeded)
            {
                pagesResponse.BadRequest("账号或密码错误");
                return BadRequest(pagesResponse);
            }
            #endregion

            #region 2.创建JWT
            //验证成功取得数据
            #region header
            var signingAlgorithm = SecurityAlgorithms.HmacSha256;
            #endregion

            #region payload
            var claims = new List<Claim>//直接使用[]不可使用Add（因为是数组）
            {
                new Claim(JwtRegisteredClaimNames.Sub,userFromRepo.Id),// id的专有名称 Sub
               // new Claim(ClaimTypes.Role,"Admin")
            };
            var RoleNames = await _userManager.GetRolesAsync(userFromRepo);//获得角色列表

            foreach (var roleName in RoleNames)
            {
                var roleClaim = new Claim(ClaimTypes.Role, roleName);
                //Console.WriteLine(roleClaim);
                claims.Add(roleClaim);
            }
            #endregion

            #region signiture
            //需要读取appsetting配置文件，所以要把配置文件服务的依赖通过IOC容器从构建函数注入进来
            var secretByte = Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]);//将私钥以UTF8编码并输出字节
            var signingKey = new SymmetricSecurityKey(secretByte);//然后使用非对称算法对私钥进行加密
            var signingCredentials = new SigningCredentials(signingKey, signingAlgorithm); //最后使用HS256验证一下非对称加密后的私钥,SigningCredentials表示用于生成数字签名的加密密钥和安全算法。
            var token = new JwtSecurityToken(

                    issuer: _configuration["Authentication:Issuer"],
                    audience: _configuration["Authentication:Audience"],

                    claims,

                    notBefore: DateTime.Now,//发布时间
                    expires: DateTime.Now.AddHours(12),//设置有效期时间

                    signingCredentials//数字签名
                    /*
                    issuer:"fakexiecheng.com",//发布token者
                    audience:"fakexiecheng.com",//发布给,对于我们项目而言，应当是项目前端，
                    因为我们将频繁使用issuer与audience，我们可以给该俩对象转移到配置文件中
                     */
                    );//通过数据创建Jwt token
            var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);//使用JwtSecurityTokenHandler来以字符串的形式输出token
            #endregion

            #endregion

            #region 3.封装数据
            var role = RoleNames[0]; // _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);//获得角色  
            var roleValue = role == null ? "Error" : role;
            #region 测试内容-响应头设置
            /*
            IdentityUser currentUser = await _userManager.GetUserAsync(HttpContext.User); 获取当前登录用户
            HttpResponseHelper httpResponseHelper = new HttpResponseHelper();
            httpResponseHelper.SetHeader("Role", roleValue,Response);
            httpResponseHelper.SetHeader("LoginToken",tokenStr,Response);
            */

            /*
            Response.Headers.Add("Role", roleValue);
            Response.Headers["access-control-expose-headers"] = "Role";

            Response.Headers.Add("LoginToken", tokenStr);
            Response.Headers["access-control-expose-headers"] = "LoginToken";
            */
            #endregion

            var data = new
            {
                Token = tokenStr,
                Role = roleValue,
            };
            #endregion

            pagesResponse.Success(data, "登录成功");

            return Ok(pagesResponse);
        }
        #endregion

        #region 注册
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="registerParameter"></param>
        /// <returns></returns>
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterParameter registerParameter)
        {
            PagesResponse pagesResponse = new PagesResponse();

            #region 校验


            //如果能从cache获得"邮箱"-对应的验证码 会赋值给code 从而取得，是个hash关系在缓存里，缓存有时效，可以设置
            var IsHaveUser = await _userManager.FindByEmailAsync(registerParameter.Email);
            if (IsHaveUser != null)
            {
                pagesResponse.BadRequest("该邮箱已被注册");
                return Ok(pagesResponse);
            }
            string? code = await _redis.StringGetAsync(registerParameter.Email);//验证码
            if (code == null)//查看是否为空
            {
                pagesResponse.BadRequest("验证码已过期");
                return Ok(pagesResponse);
            }
            else if (registerParameter.Code != code)//校验验证码
            {
                pagesResponse.BadRequest("验证码错误");
                return Ok(pagesResponse);
            }
            #endregion

            #region 创建用户
            //新建用户
            CRIPUser user = new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = registerParameter.UserName,
                Email = registerParameter.Email,
                Address = registerParameter.Address
            };

            Cart cart = new Cart()
            {
                Id = Guid.NewGuid().ToString(),
                UserId = user.Id
            };
            await _cartRepository.AddEntityAsync(cart);
            //将用户插入到表里，并Hash密码
            var Res = await _userManager.CreateAsync(user, registerParameter.Password);
            IdentityUserRole<string> identityUserRole = new();
            if (registerParameter.Role == "Docter")
            {
                identityUserRole.UserId = user.Id;
                identityUserRole.RoleId = _configuration["Roles:doctorGuid"];

            }
            else if (registerParameter.Role == "ordinaryUser" || registerParameter.Role == "")
            {
                identityUserRole.UserId = user.Id;
                identityUserRole.RoleId = _configuration["Roles:ordinaryUserGuid"];

            }
            await _userRepository.AddRoleToUserAsync(identityUserRole); //绑定用户角色
            if (!Res.Succeeded)
            {
                pagesResponse.BadRequest("创建失败，请检查格式");
                return BadRequest(pagesResponse);
            }
            await _userRepository.SaveAsync();
            #endregion

            //_cache.Remove(registerParameter.Email);//成功以后清除缓存
            await _redis.KeyDeleteAsync(registerParameter.Email);
            pagesResponse.Success("注册成功");
            return Ok(pagesResponse);
        }
        #endregion

        #region 重置密码
        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="forgetPasswordParameter"></param>
        /// <returns></returns>
        [HttpPost("Password")]
        public async Task<IActionResult> ChangePasswordAsync([FromBody] ChangePasswordParameter forgetPasswordParameter)
        {
            PagesResponse pagesResponse = new PagesResponse();

            #region 校验
            string? code = await _redis.StringGetAsync(forgetPasswordParameter.Email);//验证码
            if (code == null)//查看是否为空
            {
                pagesResponse.BadRequest("验证码已过期");
                return Ok(pagesResponse);
            }
            //校验验证码
            if (forgetPasswordParameter.Code != code)
            {
                pagesResponse.BadRequest("验证码错误");
                return Ok(pagesResponse);
            }
            var user = await _userManager.FindByEmailAsync(forgetPasswordParameter.Email);//通过邮件获得用户
            if (user == null)
            {
                pagesResponse.NotFound("没有该用户");
                return Ok(pagesResponse);
            }
            #endregion
            #region 重置密码
            string token = await _userManager.GeneratePasswordResetTokenAsync(user);//生成密码重置token
            IdentityResult res = await _userManager.ResetPasswordAsync(user, token, forgetPasswordParameter.Password);   //重置密码

            if (!res.Succeeded)
            {
                pagesResponse.BadRequest("重置失败");
                return BadRequest(pagesResponse);
            }
            #endregion

            //_cache.Remove(registerParameter.Email);//成功以后清除缓存
            await _redis.KeyDeleteAsync(forgetPasswordParameter.Email);

            pagesResponse.Success("重置成功");
            return Ok(pagesResponse);
        }
        #endregion

        #region 单一资源CreateLinkForArea
        private IEnumerable<LinkDto> CreateLinkForUser()
        {
            var links = new List<LinkDto>();

            links.Add(
                new LinkDto(
                    Url.Link("GetUserMessage", null),
                    "self",
                    "GET"
                    )
                ); ;

            return links;
        }
        #endregion

        #region 发送注册邮件
        /// <summary>
        /// 发送注册邮件
        /// </summary>
        /// <param name="Email">邮箱</param>
        /// <returns></returns>
        [HttpPost("{Email}/Register")]
        public async Task<IActionResult> SendEmailToRegister(
            [FromRoute] string Email
         )
        {
            #region 校验
            PagesResponse pagesResponse = new PagesResponse();
            var user = await _userManager.FindByEmailAsync(Email);
            if (user != null)
            {
                pagesResponse.BadRequest("该邮箱已被注册");
                return BadRequest(pagesResponse);
            }
            if (Email == null)
            {
                pagesResponse.BadRequest("邮箱为空");
                return BadRequest(pagesResponse);
            }
            #endregion

            #region 生成并设置验证码
            // _cache.Remove(Email);//先清除上次的验证码
            await _redis.KeyDeleteAsync(Email);

            Random random = new Random();
            string code = random.Next(100000, 999999).ToString();//生成随机数100000~999999

            // var cacheEntryOptions = new MemoryCacheEntryOptions()
            //.SetAbsoluteExpiration(TimeSpan.FromMinutes(3));//设置缓存时间（三分钟）单位是毫秒

            //_cache.Set(Email, code, cacheEntryOptions); //服务端缓存邮箱的验证码通过cacheEntryOptions设置
            //  MailMessage mail = EmailHelper.EmailValidationMessage(code); 
            await _redis.StringSetAsync(Email, code, new TimeSpan(0, 3, 0));//redis設置時間
            #endregion

            #region 发送验证码
            EmailHelper.SetMessage("Closed regional integration platform", "您正在申请注册CRIP，您的验证码是：" + code + "，三分钟内有效", Email);
            if (!await EmailHelper.SendEmail())
            {
                pagesResponse.BadRequest("发送失败");
                return BadRequest(pagesResponse);
            }
            #endregion

            pagesResponse.Success("发送成功");
            return Ok(pagesResponse);

        }
        #endregion

        #region 发送重置密码邮件
        /// <summary>
        /// 发送重置密码邮件
        /// </summary>
        /// <param name="Email">邮箱</param>
        /// <returns></returns>
        [HttpPost("{Email}/Password")]
        public async Task<IActionResult> SendEmailToChangePassword(
            [FromRoute] string Email
         )
        {
            PagesResponse pagesResponse = new PagesResponse();
            #region 校验
            if (Email == null)
            {
                pagesResponse.BadRequest("邮箱为空");
                return BadRequest(pagesResponse);
            }
            #endregion

            #region 生成并设置验证码
            //随机数类
            Random random = new Random();
            string code = random.Next(100000, 999999).ToString();//生成随机数100000~999999

            // _cache.Remove(Email);//先清除上次的验证码
            await _redis.KeyDeleteAsync(Email);

            var cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(3));//设置缓存时间（三分钟）单位是毫秒

            await _redis.StringSetAsync(Email, code, new TimeSpan(0, 3, 0));//redis設置時間 
            #endregion

            #region 发送邮件
            EmailHelper.SetMessage("Closed regional integration platform", "您正在申请修改CRIP的密码，您的验证码是：" + code + "，三分钟内有效", Email);
            if (!await EmailHelper.SendEmail())
            {
                pagesResponse.BadRequest("发送失败");
                return BadRequest(pagesResponse);
            }
            #endregion

            pagesResponse.Success("发送成功");
            return Ok(pagesResponse);
        }
        #endregion

        #region 获得用户信息
        /// <summary>
        /// 获得用户信息
        /// </summary>
        /// <param name="mediaType"></param>
        /// <returns></returns>
        [Produces(
            "application/json",
            "application/vnd.CRIP.hateoas+json",
            "application/vnd.CRIP.User.simplify+json",
            "application/vnd.CRIP.User.simplify.hateoas+json"
            )]
        [HttpGet(Name = "GetUserMessage")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetUserMessage(
            [FromHeader(Name = "Accept")] string mediaType
          )
        {

            PagesResponse pagesResponse = new PagesResponse();

            //获取媒体类型
            if (!MediaTypeHeaderValue
               .TryParse(mediaType, out MediaTypeHeaderValue parsedMediatype))
            {
                pagesResponse.BadRequest("未查找到媒体类型");
                return BadRequest(pagesResponse);
            }
            //获取user
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                pagesResponse.NotFound("未找到用户");
                return NotFound(pagesResponse);
            }

            #region 媒体资源类型获取
            //截取是否hateoas请求
            bool isHateoas = parsedMediatype.SubTypeWithoutSuffix
                .EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
            //截取主要请求的媒体类型
            var primaryMediaType = isHateoas
                ? parsedMediatype.SubTypeWithoutSuffix
                    .Substring(0, parsedMediatype.SubTypeWithoutSuffix.Length - 8)
                : parsedMediatype.SubTypeWithoutSuffix;
            object usersDto;
            #endregion
            if (primaryMediaType == "vnd.CRIP.User.simplify")
            {
                usersDto = _mapper.Map<UserSimplifyDto>(user);
            }
            else
            {
                usersDto = _mapper.Map<UserDto>(user);
            }

            if (isHateoas)
            {
                var hateoasLinks = CreateLinkForUser();
                var hateoasRes = new
                {
                    userMessage = usersDto,
                    Links = hateoasLinks
                };
                pagesResponse.Success(hateoasRes);
            }
            else
            {
                var Res = new
                {
                    userMessage = usersDto,
                };
                pagesResponse.Success(Res);
            }
            return Ok(pagesResponse);

        }
        #endregion

        #region 获取分页与Hateoas   
        /// <summary>
        /// 获得Users
        /// </summary>
        /// <param name="getUserMessageParameterParameter"></param>
        /// <param name="paginationResourceParamaters"></param>
        /// <returns></returns>
        [HttpGet("Users")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetUsers(
            [FromQuery] GetUserMessageParameter getUserMessageParameterParameter,
            [FromQuery] PaginationResourceParamaters paginationResourceParamaters

            )
        {
            PagesResponse pagesResponse = new PagesResponse();
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;


            //从仓库获得分页资源
            var userRepo = await _userRepository
            .GetAllUserAsync(
                getUserMessageParameterParameter.Keyword,
                getUserMessageParameterParameter.FindByString,
                userId,
                getUserMessageParameterParameter.OrderBy,
                getUserMessageParameterParameter.Desc,
                paginationResourceParamaters.PageNumber,
                paginationResourceParamaters.PageSize
                );
          
            if (userRepo == null || userRepo.Count() == 0)
            {
                pagesResponse.NotFound("未找到用户");
                return NotFound(pagesResponse);
            }
            else
            {  var userDto = _mapper.Map< IEnumerable < UserDto >>(userRepo);
                pagesResponse.Success(userDto);
                return Ok(pagesResponse);
            }
 
       
        }
        #endregion
    }
}
