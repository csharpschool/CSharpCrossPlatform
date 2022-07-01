namespace Bookstore.Data;

public class DbService : IDbService
{
    private readonly BookstoreContext _db;
    private readonly IMapper _mapper;

    public DbService(BookstoreContext db, IMapper mapper) => (_db, _mapper) = (db, mapper);

    public void IncludeNavigations<TEntity>() where TEntity : class
    {
        // Skip Navigation Properties are used for many-to-many
        // relationsips (ICollection) and Navigation Properties
        // are used for one-to-many relationsips.
        var entityType = _db.Model.FindEntityType(typeof(TEntity));
        if (entityType == null) return;
        
        var skipNavigationProperties = entityType.GetDeclaredSkipNavigations().Select(s => s.Name);
        var navigationProperties = entityType.GetNavigations().Select(s => s.Name);
        foreach (var name in navigationProperties.Union(skipNavigationProperties))
            _db.Set<TEntity>().Include(name).Load();
    }
    public async Task<TEntity?> SingleAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class =>
        await _db.Set<TEntity>().SingleOrDefaultAsync(expression);
    public async Task<TDto> SingleAsync<TEntity, TDto>(Expression<Func<TEntity, bool>> expression, bool include = false) where TEntity : class where TDto : class
    {
        if (include) IncludeNavigations<TEntity>();
        var entity = await SingleAsync(expression); //await _db.Set<TEntity>().SingleOrDefaultAsync(expression);
        return _mapper.Map<TDto>(entity);
    }
    public async Task<List<TDto>> GetAsync<TEntity, TDto>(bool include = false) where TEntity : class where TDto : class
    {
        if (include) IncludeNavigations<TEntity>();
        var entities = await _db.Set<TEntity>().ToListAsync();
        return _mapper.Map<List<TDto>>(entities);
    }
    public async Task<TEntity> AddAsync<TEntity, TDto>(TDto dto) where TEntity : class where TDto : class
    {
        var entity = _mapper.Map<TEntity>(dto);
        await _db.Set<TEntity>().AddAsync(entity);
        return entity;
    }
    public void Update<TEntity, TDto>(int id, TDto dto) where TEntity : class, IEntity where TDto : class
    {
        var entity = _mapper.Map<TEntity>(dto);
        entity.Id = id;
        _db.Set<TEntity>().Update(entity);
    }
    public async Task<bool> DeleteAsync<TEntity>(int id) where TEntity : class, IEntity
    {
        try 
        {
            var entity = await SingleAsync<TEntity>(e => e.Id.Equals(id));
            if (entity is null) return false;
            _db.Remove(entity);
        }
        catch { throw; }

        return true;
    }
    public async Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class =>
        await _db.Set<TEntity>().AnyAsync(expression);
    public async Task<bool> SaveChangesAsync() => await _db.SaveChangesAsync() >= 0;
}