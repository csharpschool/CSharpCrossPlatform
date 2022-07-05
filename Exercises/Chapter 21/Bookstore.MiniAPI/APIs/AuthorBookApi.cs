namespace Bookstore.MiniAPI;

public class AuthorBookApi : IApi
{
    public void Register(WebApplication app)
    {
        app.MapPost($"/api/AuthorBooks", HttpPost);
        app.MapDelete($"/api/AuthorBooks", HttpDelete);
    }

    public async Task<IResult> HttpDelete(IDbService db, int bookId, int authorId)
    {
        try
        {
            db.IncludeNavigations<Book>();
            var book = await db.SingleAsync<Book>(e => e.Id.Equals(bookId));
            var author = await db.SingleAsync<Author>(e => e.Id.Equals(authorId));

            if (book is null || author is null) return Results.NotFound();

            book.Authors?.Remove(author);

            if (await db.SaveChangesAsync()) return Results.NoContent();
        }
        catch (Exception ex)
        {
            return Results.BadRequest($"Couldn't delete the {typeof(Author).Name} entity.\n{ex}.");
        }

        return Results.BadRequest($"Couldn't delete the {typeof(Author).Name} entity.");
    }
    public async Task<IResult> HttpPost(IDbService db, AuthorBookDTO dto)
    {
        try
        {
            db.IncludeNavigations<Book>();
            db.IncludeNavigations<Author>();
            var book = await db.SingleAsync<Book>(e => e.Id.Equals(dto.BookId));
            var author = await db.SingleAsync<Author>(e => e.Id.Equals(dto.AuthorId));

            if (book is null || author is null) return Results.NotFound();

            book.Authors?.Add(author);
            author.Books?.Add(book);
            if(book.Publisher is not null) author.Publishers?.Add(book.Publisher);

            if (await db.SaveChangesAsync()) return Results.Ok($"Added {author.FirstName} {author.LastName} to {book.Title}.");
        }
        catch (Exception ex)
        {
            return Results.BadRequest($"Couldn't add the {typeof(Author).Name} to the book.\n{ex}.");
        }

        return Results.BadRequest($"Couldn't add the {typeof(Author).Name}  to the book.");
    }
}
