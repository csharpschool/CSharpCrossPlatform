namespace Bookstore.Common;

public class PublisherAuthorDTO
{
    public int PublisherId { get; set; } = 0;
    public int AuthorId { get; set; } = 0;

    public PublisherAuthorDTO(int authorId, int publisherId) => (AuthorId, PublisherId) = (authorId, publisherId);
}