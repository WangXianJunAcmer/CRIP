using CRIP.Services.IRepositorys;
using Microsoft.EntityFrameworkCore;
using CRIP.Database;

namespace CRIP.Services.Repositorys
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new ()
    {
        private CRIPDbContext _CRIPDbContext;
        public BaseRepository(CRIPDbContext CRIPDbContext)
        {
            _CRIPDbContext = CRIPDbContext;
        }
        public void Delete (TEntity entity)
        {
            _CRIPDbContext.Remove(entity);
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
         return  await _CRIPDbContext.FindAsync<TEntity>(id);
        }
        #region 批量删除实体
        public void DeleteEntitys(List<TEntity> entity)
        {
            _CRIPDbContext.RemoveRange(entity);
        }
        #endregion
        public async Task SaveAsync()
        {
            await _CRIPDbContext.SaveChangesAsync();
        }

        public async Task AddEntityAsync(TEntity entity)
        {
         await  _CRIPDbContext.AddAsync(entity);
        }
    }

}
