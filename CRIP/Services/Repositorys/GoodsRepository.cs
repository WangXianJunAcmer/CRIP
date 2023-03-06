using CRIP.Common;
using CRIP.Database;
using CRIP.Models;
using CRIP.Services.IRepositorys;
using Microsoft.EntityFrameworkCore;
using Pipelines.Sockets.Unofficial.Arenas;

namespace CRIP.Services.Repositorys
{
    public class GoodsRepository : BaseRepository<Goods>, IGoodsRepository
    {
        private readonly CRIPDbContext _CRIPDbContext;
        public GoodsRepository(CRIPDbContext CRIPDbContext) : base(CRIPDbContext)
        {
            _CRIPDbContext = CRIPDbContext;
        }
        /// <summary>
        /// 分页获得多个goods
        /// </summary>
        /// <param name="keyword">模糊查找键值</param>
        /// <param name="orderby">安装什么排序，默认name，可选number，place</param>
        /// <param name="desc">是否倒叙，默认否</param>
        /// <param name="pageNumber">页数</param>
        /// <param name="pageSize">页面内容数量</param>
        /// <returns></returns>
        public async Task<PageList<Goods>> GetAllGoodsAsync(string? keyword, string? orderby, bool? desc, int pageNumber, int pageSize)
        {
            //获取集合
            IQueryable<Goods> result = _CRIPDbContext.Goods;

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();
                var result1 = result.Where(t => t.Info.Contains(keyword));
                var result2 = result.Where(t => t.Name.Contains(keyword));
                //Union<TSource>(IQueryable<TSource>, IEnumerable<TSource>)通过使用默认的相等比较器，生成两个序列的并集
                result = result2.Union(result1);
            }

            result = orderby switch
            {
                "quantity" => (desc == true) ? result.OrderByDescending(a => a.Quantity) : result.OrderBy(a => a.Quantity),
                "price" => (desc == true) ? result.OrderByDescending(a => a.Price) : result.OrderBy(a => a.Price),
                _ => (desc == true) ? result.OrderByDescending(a => a.Name) : result.OrderBy(a => a.Name)
            };

            return await PageList<Goods>.CreateAsync(pageNumber, pageSize, result);
        }
    }
}
