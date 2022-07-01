namespace Bookstore.Data;

public interface IDbService
{
    void IncludeNavigations<TEntity>() where TEntity : class;
    Task<TEntity?> SingleAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class;
    Task<TDto> SingleAsync<TEntity, TDto>(Expression<Func<TEntity, bool>> expression, bool include = false) where TEntity : class where TDto : class;
    Task<List<TDto>> GetAsync<TEntity, TDto>(bool include = false) where TEntity : class where TDto : class;
    Task<TEntity> AddAsync<TEntity, TDto>(TDto dto) where TEntity : class where TDto : class;
    void Update<TEntity, TDto>(int id, TDto dto) where TEntity : class, IEntity where TDto : class;
    Task<bool> DeleteAsync<TEntity>(int id) where TEntity : class, IEntity;
    Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class;
    Task<bool> SaveChangesAsync();
}