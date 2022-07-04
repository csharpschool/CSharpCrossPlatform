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
RegisterServices(builder.Services);

var app = builder.Build();

RegisterMiddleware(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

/* app.MapGet("/api/books/{id}", async Task<IResult> (IDbService db, int id, bool include) =>
    await db.HttpSingleAsync<Book, BookDTO>(id, include));
app.MapGet("/api/books", async Task<IResult> (IDbService db, bool include) =>
    await db.HttpGetAsync<Book, BookDTO>(include));
app.MapPost("/api/books", async Task<IResult> (IDbService db, BookBaseDTO dto) =>
    await db.HttpPostAsync<Book, BookBaseDTO>(dto));
app.MapPut("/api/books/{id}", async Task<IResult> (IDbService db, int id, BookMiniDTO dto) =>
    await db.HttpPutAsync<Book, BookMiniDTO>(id, dto));
app.MapDelete("/api/books/{id}", async Task<IResult> (IDbService db, int id) =>
    await db.HttpDeleteAsync<Book>(id)); */

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

void RegisterServices(IServiceCollection services)
{
    services.AddScoped<IDbService, DbService>();
    services.AddTransient<IApi, BookApi>();
    services.AddTransient<IApi, PublisherApi>();
    services.AddTransient<IApi, AuthorApi>();
}

void RegisterMiddleware(WebApplication app)
{
    var apis = app.Services.GetServices<IApi>();
    foreach (var api in apis)
    {
        if (api is null) throw new InvalidProgramException("Couldn't register API.");

        api.Register(app);
    }
}