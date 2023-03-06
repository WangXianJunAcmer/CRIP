using Microsoft.EntityFrameworkCore;

namespace CRIP.Common
{
    public class PageList<T> : List<T>
    {
        //总页数
        public int TotalPages { get; private set; }
        //总数
        public int TotalCount { get; private set; }
        //是否有上一页
        public bool HasPrevious => CurrentPage > 1;
        //是否有下一页
        public bool HasNext => CurrentPage < TotalPages;
        //当前页
        public int CurrentPage { get; set; }
        //每页大小
        public int PageSize { get; set; }

        public PageList(int totalCount, int currentPage, int pageSize, List<T> items)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            AddRange(items);
            TotalCount = totalCount;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        }

        public static async Task<PageList<T>> CreateAsync(
            int currentPage, int pageSize, IQueryable<T> result)
        {
            var totalCount = await result.CountAsync();

            var skip = (currentPage - 1) * pageSize;
            result = result.Skip(skip);  //跳过数据

            result = result.Take(pageSize);//获取指定数据量的数据

            var items = await result.ToListAsync();

            return new PageList<T>(totalCount, currentPage, pageSize, items);
        }
    }
}
