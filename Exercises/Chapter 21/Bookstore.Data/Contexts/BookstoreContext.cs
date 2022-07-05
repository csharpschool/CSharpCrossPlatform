namespace Bookstore.Data;

public class BookstoreContext : DbContext
{
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Publisher> Publishers => Set<Publisher>();

    public BookstoreContext(DbContextOptions<BookstoreContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        SeedData(builder);
    }

    private void SeedData(ModelBuilder builder)
    {
        #region *** ADD THIS SEED DATA TO MIGRATION ***
        /*
            migrationBuilder.InsertData(
                table: "AuthorPublisher",
                columns: new[] { "AuthorsId", "PublishersId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorsId", "BooksId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 2, 3 }
                });

         */
        #endregion

        var publishers = new List<Publisher>
        {
            new Publisher { Id = 1, Name = "Publisher 1" },
            new Publisher { Id = 2, Name = "Publisher 2" },
            new Publisher { Id = 3, Name = "Publisher 3" }
        };
        builder.Entity<Publisher>().HasData(publishers);

        var authors = new List<Author>
        {
            new Author { Id = 1, FirstName = "John", LastName = "Doe" },
            new Author { Id = 2, FirstName = "Jane", LastName = "Doe" }
        };
        builder.Entity<Author>().HasData(authors);

        var books = new List<Book>
        {
            new(){Id = 1,  Isbn = "ABC123", Title = "Title 1", PublisherId = 1 },
            new(){Id = 2,  Isbn = "BCD123", Title = "Title 2", PublisherId = 2 },
            new(){Id = 3,  Isbn = "XYZ987", Title = "Title 3", PublisherId = 3 },
        };
        builder.Entity<Book>().HasData(books);
    }
}