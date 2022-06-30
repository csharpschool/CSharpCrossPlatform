namespace Bookstore.Data;

public class Author : IEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public virtual ICollection<Book>? Books { get; set; }
    public virtual ICollection<Publisher>? Publishers { get; set; }
}