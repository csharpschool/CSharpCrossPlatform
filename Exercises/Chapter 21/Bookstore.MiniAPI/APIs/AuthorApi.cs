namespace Bookstore.MiniAPI;

public class AuthorApi : IApi
{
    public void Register(WebApplication app) => app.Register<Author, AuthorDTO, AuthorMiniDTO, AuthorBaseDTO>();
}


