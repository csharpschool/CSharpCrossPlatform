namespace Bookstore.Common;

public class AuthorBookDTO
{
    public int AuthorId { get; set; } = 0;
    public int BookId { get; set; } = 0;

    public AuthorBookDTO(int authorId, int bookId) => (AuthorId, BookId) = (authorId, bookId);
}

