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

