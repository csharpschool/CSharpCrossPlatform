namespace Bookstore.MiniAPI;

public static class ApiExtensions
{
    public static async Task<IResult> HttpGetAsync<TEntity, TDto>(this IDbService db, bool include = false) where TEntity : class where TDto : class => 
        Results.Ok(await db.GetAsync<TEntity, TDto>(include));
    public static async Task<IResult> HttpSingleAsync<TEntity, TDto>(this IDbService db, int id, bool include = false) where TEntity : class, IEntity where TDto : class
    {
        var result = await db.SingleAsync<TEntity, TDto>(e => e.Id.Equals(id), include);
        if (result is null) return Results.NotFound();
        return Results.Ok(result);
    }
    public static async Task<IResult> HttpPostAsync<TEntity, TBaseDto>(this IDbService db, TBaseDto dto) where TEntity : class, IEntity where TBaseDto : class
    {
        try
        {
            var entity = await db.AddAsync<TEntity, TBaseDto>(dto);
            if (await db.SaveChangesAsync())
            {
                var node = typeof(TEntity).Name.ToLower();
                return Results.Created($"/{node}s/{entity.Id}", entity);
            }
        }
        catch (Exception ex)
        {
            return Results.BadRequest($"Couldn't add the {typeof(TEntity).Name} entity.\n{ex}.");
        }

        return Results.BadRequest($"Couldn't add the {typeof(TEntity).Name} entity.");
    }
    public static async Task<IResult> HttpPutAsync<TEntity, TMiniDto>(this IDbService db, int id, TMiniDto dto) where TEntity : class, IEntity where TMiniDto : class
    {
        try
        {
            if (!await db.AnyAsync<TEntity>(e => e.Id.Equals(id))) return Results.NotFound();
            
            db.Update<TEntity, TMiniDto>(id, dto);
            if (await db.SaveChangesAsync()) return Results.NoContent();

        }
        catch (Exception ex)
        {
            return Results.BadRequest($"Couldn't update the {typeof(TEntity).Name} entity.\n{ex}.");
        }

        return Results.BadRequest($"Couldn't update the {typeof(TEntity).Name} entity.");
    }
    public static async Task<IResult> HttpDeleteAsync<TEntity>(this IDbService db, int id) where TEntity : class, IEntity
    {
        try
        {
            if(!await db.DeleteAsync<TEntity>(id)) return Results.NotFound();

            if (await db.SaveChangesAsync()) return Results.NoContent();
        }
        catch (Exception ex)
        {
            return Results.BadRequest($"Couldn't delete the {typeof(TEntity).Name} entity.\n{ex}.");
        }

        return Results.BadRequest($"Couldn't delete the {typeof(TEntity).Name} entity.");
    }
}