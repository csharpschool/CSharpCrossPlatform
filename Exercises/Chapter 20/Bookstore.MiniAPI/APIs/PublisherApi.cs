namespace Bookstore.MiniAPI;

public class PublisherApi : IApi
{
    public void Register(WebApplication app) => app.Register<Publisher, PublisherDTO, PublisherMiniDTO, PublisherBaseDTO>();
}
