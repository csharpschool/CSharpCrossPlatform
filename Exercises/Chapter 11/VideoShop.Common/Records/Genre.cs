namespace VideoShop.Common;

public record Genre
{
    public int Id { get; }
    public string Name { get; set; }

    public Genre(int id, string name)
    {
        Id = id;
        Name = name;
    }
}