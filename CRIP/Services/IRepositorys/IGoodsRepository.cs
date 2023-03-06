using CRIP.Common;
using CRIP.Models;
using Qiniu.Storage;
using StackExchange.Redis;

namespace CRIP.Services.IRepositorys
{
    public interface IGoodsRepository : IBaseRepository<Goods>
    {
        Task<PageList<Goods>> GetAllGoodsAsync(string? keyword, string? orderby, bool? desc, int pageNumber, int pageSize);
    }
}
