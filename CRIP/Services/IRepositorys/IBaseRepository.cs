namespace CRIP.Services.IRepositorys
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        //添加实体
        Task AddEntityAsync(TEntity entity);
        //删除实体
        void Delete(TEntity entity);
        // 批量删除实体
        void DeleteEntitys(List<TEntity> entity);
        //通过Id获得实体
        Task<TEntity> GetByIdAsync(string Id);

        //保存数据库
        Task SaveAsync();

    }
}
