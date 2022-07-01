var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookstoreContext>(
    options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("BookstoreConnection")));

ConfigureAutoMapper(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/books/{id}", async Task<IResult> (BookstoreContext db, int id) =>
{
    var result = await db.Books.SingleAsync(e => e.Id.Equals(id));
    if (result is null) return Results.NotFound();
    return Results.Ok(result); 
});

app.MapGet("/api/books", async Task<IResult> (BookstoreContext db) =>
    Results.Ok(await db.Books.ToListAsync())); 

app.MapPost("/api/books", async Task<IResult> (BookstoreContext db, IMapper _mapper, BookBaseDTO dto) =>
{
     try
    {
        var book = _mapper.Map<Book>(dto);
        await db.Set<Book>().AddAsync(book);
        if (await db.SaveChangesAsync() >= 0)
            return Results.Created($"/Books/{book.Id}", book);
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Couldn't add the book.\n{ex}.");
    }

    return Results.BadRequest($"Couldn't add the book.");
});
app.MapPut("/api/books/{id}", async Task<IResult> (BookstoreContext db, IMapper _mapper, int id, BookMiniDTO dto) =>
{
     try
    {
        if (!await db.Set<Book>().AnyAsync(e => e.Id.Equals(id))) return Results.NotFound();
            
        var book = _mapper.Map<Book>(dto);
        db.Set<Book>().Update(book);
        if (await db.SaveChangesAsync() >= 0)
            return Results.NoContent();
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Couldn't update the book.\n{ex}.");
    }

    return Results.BadRequest($"Couldn't update the book.");
});
app.MapDelete("/api/books/{id}", async Task<IResult> (BookstoreContext db, IMapper _mapper, int id) =>
{
     try
    {
        var entity = await db.Set<Book>().SingleOrDefaultAsync(e => e.Id.Equals(id));

        if (entity is null) return Results.NotFound();
        
        db.Remove(entity);

        if (await db.SaveChangesAsync() >= 0)
            return Results.NoContent();
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Couldn't remove the book.\n{ex}.");
    }

    return Results.BadRequest($"Couldn't remove the book.");
});


app.Run();

void ConfigureAutoMapper(IServiceCollection services)
{
    var config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Book, BookBaseDTO>().ReverseMap();
        cfg.CreateMap<Book, BookMiniDTO>().ReverseMap();
        cfg.CreateMap<Book, BookDTO>().ReverseMap();
        cfg.CreateMap<Publisher, PublisherBaseDTO>().ReverseMap();
        cfg.CreateMap<Publisher, PublisherMiniDTO>().ReverseMap();
        cfg.CreateMap<Publisher, PublisherDTO>().ReverseMap();
        cfg.CreateMap<Author, AuthorBaseDTO>().ReverseMap();
        cfg.CreateMap<Author, AuthorMiniDTO>().ReverseMap();
        cfg.CreateMap<Author, AuthorDTO>().ReverseMap();
    });
    var mapper = config.CreateMapper();
    services.AddSingleton(mapper);
}

