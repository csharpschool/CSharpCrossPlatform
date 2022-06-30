namespace Bookstore.Data;

public class Publisher : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public virtual ICollection<Book>? Books { get; set; }
    public virtual ICollection<Author>? Authors { get; set; }
}