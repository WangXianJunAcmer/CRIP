using AutoMapper;
using CRIP.Common;
using CRIP.Dtos;
using CRIP.Dtos.GoodsDtos;
using CRIP.Helper;
using CRIP.Models;
using CRIP.ResourceParameters;
using CRIP.Services.IRepositorys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using Pipelines.Sockets.Unofficial.Arenas;
using StackExchange.Redis;
using System.Security.Claims;

namespace CRIP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
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
        //链接生成工具
        private readonly IUrlHelper _urlHelper;
        //使用HttpContext的接口
        private readonly IHttpContextAccessor _httpContextAccessor;
        //用户仓库
        private readonly IGoodsRepository _goodsRepository;
        public GoodsController(
            IConfiguration configuration,
            UserManager<CRIPUser> userManager,
            SignInManager<CRIPUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IHttpContextAccessor httpContextAccessor,
            RedisHelper client,
            IGoodsRepository goodsRepository,
            IMapper mapper,
            IActionContextAccessor actionContextAccessor,//定义用于公开操作上下文的接口。
            IUrlHelperFactory urlHelperFactory
        )
        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _httpContextAccessor = httpContextAccessor;
            _redis = client.GetDatabase();
            _goodsRepository = goodsRepository;
            _mapper = mapper;
            //获取 IUrlHelper 与 关联的请求的 context 。
            _urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);//作为 HTTP 请求的一部分选择的执行操作的上下文对象
        }
        #endregion
        /// <summary>
        /// 通过Id获得商品
        /// </summary>
        /// <param name="goodId"></param>
        /// <returns></returns>

        [HttpGet("{goodId}", Name = "GetGoodsById")]
        public async Task<IActionResult> GetGoodByIdAsync([FromRoute] string goodId)
        {
            PagesResponse pagesResponse = new PagesResponse();
            var goodsFromRepo = await _goodsRepository.GetByIdAsync(goodId);
            if (goodsFromRepo == null)
            {
                pagesResponse.NotFound("商品不存在");
                return Ok(pagesResponse);
            }
            else
            {
                var goodsDto = _mapper.Map<GoodsDto>(goodsFromRepo);
                pagesResponse.Success(goodsDto);
                return Ok(pagesResponse);
            }
        }
        //私有方法


        #region 生成GetURL
        private string GenerateCripResourceURL(
          GoodsParameter goodsParameter,
          PaginationResourceParamaters paginationResourceParamaters,
          ResourceURLType type
          )
        {
            return type switch
            {
                ResourceURLType.PreviousPage => _urlHelper.Link("GetGoods",
                new
                {
                    keyword = goodsParameter.Keyword,
                    orderby = goodsParameter.OrderBy,
                    pageNumber = paginationResourceParamaters.PageNumber - 1,
                    pageSize = paginationResourceParamaters.PageSize
                }),
                ResourceURLType.NextPage => _urlHelper.Link("GetGoods",
                new
                {
                    keyword = goodsParameter.Keyword,
                    orderby = goodsParameter.OrderBy,
                    pageNumber = paginationResourceParamaters.PageNumber + 1,
                    pageSize = paginationResourceParamaters.PageSize
                }),
                _ => _urlHelper.Link("GetGoods",
                new
                {
                    keyword = goodsParameter.Keyword,
                    orderby = goodsParameter.OrderBy,
                    pageNumber = paginationResourceParamaters.PageNumber,
                    pageSize = paginationResourceParamaters.PageSize
                }
                )
            };
        }
        #endregion

        #region 多个资源CreateLinksForgoodsList
        private IEnumerable<LinkDto> CreateLinksForgoodsList(
          GoodsParameter goodsParameter,
          PaginationResourceParamaters paginationResourceParamaters
         )
        {
            var links = new List<LinkDto>();
            // 添加self，自我链接
            links.Add(new LinkDto(
                   GenerateCripResourceURL(
                        goodsParameter, paginationResourceParamaters, ResourceURLType.CurrnetPage),
                    "self",
                    "GET"
                ));

            // "api/touristRoutes"
            // 添加创建旅游路线
            links.Add(new LinkDto(
                    Url.Link("CreateGoods", null),
                    "create_goods",
                    "POST"
                ));

            return links;
        }
        #endregion

        #region 单一资源CreateLinkForgoods
        private LinkDto CreateLinkForgoods(
    string goodsId)
        {

            return new LinkDto(
                    Url.Link("GetGoodsById", new { goodsId }),
                    "self",
                    "GET"
                    );
        }
        #endregion

        #region goodsLinksForgoodsId
        private List<LinkDto> goodsLinksForgoodsId(
       IEnumerable<string> IDs)
        {
            List<LinkDto> res = new List<LinkDto>();
            IDs.ToList().ForEach(
                    id => {
                        res.Add(CreateLinkForgoods(id));
                    }
                    );

            return res;
        }
        #endregion  





        //API
        #region 获取分页与Hateoas 的goods数据
        /// <summary>
        /// 获取分页与Hateoas 的goods数据
        /// </summary>
        /// <param name="goodsParameter">keyword 模糊查找关键字，orderBy 根据什么排序，desc是否逆序 </param>
        /// <param name="paginationResourceParamaters">当前第几页，当前页数据量</param>
        /// <param name="mediaType">请求方式</param>
        /// <returns></returns>

        #region 设置允许请求的媒体类型
        [Produces(
            "application/json",
            "application/vnd.crip.hateoas+json",
            "application/vnd.crip.goods.simplify+json",
            "application/vnd.crip.goods.simplify.hateoas+json"
            )]
        #endregion

        [HttpGet(Name = "GetGoods")]
        public async Task<IActionResult> GetGoodsAsync(
            [FromQuery] GoodsParameter goodsParameter,
            [FromQuery] PaginationResourceParamaters paginationResourceParamaters,
            [FromHeader(Name = "Accept")] string mediaType
            )
        {
            PagesResponse pagesResponse = new PagesResponse();
            IEnumerable<GoodsSimplifyDto> goodssSimplifyDto = new List<GoodsSimplifyDto>();
            IEnumerable<GoodsDto> goodssDto = new List<GoodsDto>();
            bool isHateoas = false;
            StringSegment primaryMediaType = "";
            #region 获取资源与校验
            //获取媒体类型
            if (!MediaTypeHeaderValue
               .TryParse(mediaType, out MediaTypeHeaderValue parsedMediatype))
            {
                pagesResponse.BadRequest("未查找到媒体类型");
            }
            //从仓库获得分页资源
            var goodsRepo = await _goodsRepository
            .GetAllGoodsAsync(
                goodsParameter.Keyword,
                goodsParameter.OrderBy,
                goodsParameter.Desc,
                paginationResourceParamaters.PageNumber,
                paginationResourceParamaters.PageSize
                );
            var IDs = goodsRepo.Select(x => x.Id);

            if (goodsRepo == null || goodsRepo.Count() == 0)
            {
                pagesResponse.NotFound("未找到区域");
                return NotFound(pagesResponse);
            }
            #endregion

            #region 分页URL
            //上一页的url
            var previousPageLink = goodsRepo.HasPrevious
          ? GenerateCripResourceURL(
             goodsParameter, paginationResourceParamaters, ResourceURLType.PreviousPage)
          : null;
            //下一页的url
            var nextPageLink = goodsRepo.HasNext
          ? GenerateCripResourceURL(
             goodsParameter, paginationResourceParamaters, ResourceURLType.NextPage)
          : null;
            #endregion

            #region 设置URL

            // x-pagination水平分页
            var paginationMetadata = new
            {
                previousPageLink,
                nextPageLink,
                totalCount = goodsRepo.TotalCount,
                pageSize = goodsRepo.PageSize,
                currentPage = goodsRepo.CurrentPage,
                totalPages = goodsRepo.TotalPages
            };
            HttpResponseHelper httpResponseHelper = new HttpResponseHelper();


            //分页链接设置到响应头
            httpResponseHelper.SetHeader("x-pagination", Newtonsoft.Json.JsonConvert.SerializeObject(paginationMetadata), Response);//信息设置到header
            #endregion

            if (parsedMediatype != null)
            {
            #region 媒体资源类型获取
                //截取是否hateoas请求
                isHateoas = parsedMediatype.SubTypeWithoutSuffix
                    .EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
                //截取主要请求的媒体类型
                primaryMediaType = isHateoas
                    ? parsedMediatype.SubTypeWithoutSuffix
                        .Substring(0, parsedMediatype.SubTypeWithoutSuffix.Length - 8)
                    : parsedMediatype.SubTypeWithoutSuffix;

                //当请求的媒体类型为简化资源
                if (primaryMediaType == "vnd.crip.goods.simplify")
                {
                    goodssSimplifyDto = _mapper
                    .Map<IEnumerable<GoodsSimplifyDto>>(goodsRepo);
                }
                else//非简化资源时
                {
                    goodssDto = _mapper
                   .Map<IEnumerable<GoodsDto>>(goodsRepo);
                } 
            #endregion
            }

            #region 分类封装

            if (isHateoas)//请求Hateoas媒体资源
            {
                var links = CreateLinksForgoodsList(goodsParameter, paginationResourceParamaters);
                // var links = goodsLinksForgoodsId(IDs);
                if (primaryMediaType == "vnd.crip.goods.simplify")//简略资源时
                {
                    goodssSimplifyDto.ToList().ForEach(x => { x.Link = CreateLinkForgoods(x.Id); });
                    var hateoasRes = new
                    {
                        goodss = goodssSimplifyDto,
                        links = links
                    };
                    pagesResponse.Success(hateoasRes, "已查询");
                    return Ok(pagesResponse);
                }
                else                                              //整体资源时
                {
                    goodssDto.ToList().ForEach(x => { x.Link = CreateLinkForgoods(x.Id); });
                    var hateoasRes = new
                    {
                        goodss = goodssDto,
                        links = links
                    };
                    pagesResponse.Success(hateoasRes, "已查询");
                    return Ok(pagesResponse);
                }

            }
            else          //请求非Hateoas媒体资源
            {
                if (primaryMediaType == "vnd.crip.goods.simplify")//简略资源时
                {
                    goodssSimplifyDto.ToList().ForEach(x => { x.Link = CreateLinkForgoods(x.Id); });
                    var hateoasRes = new
                    {
                        goodss = goodssSimplifyDto,
                    };
                    pagesResponse.Success(hateoasRes, "已查询");
                    return Ok(pagesResponse);
                }
                else                                              //整体资源时
                {
                    goodssDto.ToList().ForEach(x => { x.Link = CreateLinkForgoods(x.Id); });
                    var hateoasRes = new
                    {
                        goodss = goodssDto,
                    };
                    pagesResponse.Success(hateoasRes, "已查询");
                    return Ok(pagesResponse);
                }
            }

            #endregion

        }
        #endregion

        /// <summary>
        /// 创建商品
        /// </summary>
        /// <param name="goodsCreateDto"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateGoods")]
        public async Task<IActionResult> CreateGoodAsync([FromBody] GoodsCreateDto goodsCreateDto)
        {
            PagesResponse pagesResponse = new PagesResponse();
            if (goodsCreateDto == null)
            {
                pagesResponse.BadRequest("商品信息不完整");
                return Ok(pagesResponse);
            }
            var goods = _mapper.Map<Goods>(goodsCreateDto);
            goods.Id = Guid.NewGuid().ToString();
            await _goodsRepository.AddEntityAsync(goods);
            await _goodsRepository.SaveAsync();
            var goodsDto = _mapper.Map<GoodsDto>(goods);
            pagesResponse.Success(goodsDto);
            return Ok(pagesResponse);

        }
        
        /// <summary>
        /// 修改商品
        /// </summary>
        /// <param name="goodsId"></param>
        /// <param name="jsonPatchDocument"></param>
        /// <returns></returns>
        [HttpPatch]
        public async Task<IActionResult> PartiallyUpdataGoods(
            [FromQuery] string goodsId,
            [FromBody] JsonPatchDocument<GoodsUpdateDto> jsonPatchDocument
            //将jsonPatch格式数据补全成TouristRouteForUpdateDto对象
            )
        { PagesResponse pagesResponse = new PagesResponse();
            var goodsRepo = await _goodsRepository.GetByIdAsync(goodsId);
            if (goodsRepo == null)
            {
                pagesResponse.NotFound("商品不存在");
                return Ok(pagesResponse);
            }
            var goodsToPatchRepo = _mapper.Map<GoodsUpdateDto>(goodsRepo);
            //将jsonpatch生成的TouristRouteForUpdateDto对象中的部分数据补全到从数据仓库中获得的对象
            jsonPatchDocument.ApplyTo(goodsToPatchRepo, ModelState);

            if (!TryValidateModel(goodsToPatchRepo))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(goodsToPatchRepo, goodsRepo);
            await _goodsRepository.SaveAsync();

            var goodsRes = _mapper.Map<GoodsDto>(goodsRepo);

            return CreatedAtRoute(
                "GetGoodsById",
                new { goodId = goodsRepo.Id },
                goodsRes
                );
        }

        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>

        [HttpDelete]
        public async Task<IActionResult> DeleteGoodsById([FromQuery] string goodsId)
        {
            PagesResponse pagesResponse = new PagesResponse();
            var goodsRepo = await _goodsRepository.GetByIdAsync(goodsId);
            if(goodsId==null)
            {
                pagesResponse.NotFound("商品不存在");
                return Ok(pagesResponse);   
            }
            else
            {
                _goodsRepository.Delete(goodsRepo);
                await  _goodsRepository.SaveAsync();
                pagesResponse.Success("删除成功");
                return Ok(pagesResponse);
            }
        }
    }
}
