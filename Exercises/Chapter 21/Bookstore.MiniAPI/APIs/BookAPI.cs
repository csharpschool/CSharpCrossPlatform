namespace Bookstore.MiniAPI;

public class BookApi : IApi
{
    public void Register(WebApplication app) => 
        app.Register<Book, BookDTO, BookMiniDTO, BookBaseDTO>();
}