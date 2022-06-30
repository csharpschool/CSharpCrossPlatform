namespace Bookstore.Common;

public class BookBaseDTO
{
    public string Title { get; set; } = string.Empty;
    public string Isbn { get; set; } = string.Empty;
    public int PublisherId { get; set; } = 0;
}

public class BookMiniDTO : BookBaseDTO
{
    public int Id { get; set; } = 0;
}

public class BookDTO : BookMiniDTO
{
    public PublisherMiniDTO Publisher { get; set; } = new();
    public List<AuthorMiniDTO> Authors { get; set; } = new();
}
