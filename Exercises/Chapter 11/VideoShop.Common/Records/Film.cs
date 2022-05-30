namespace VideoShop.Common;

public record Film
{
    public int Id { get; }
    public string Title { get; }
    public int Year { get; }
    public List<Genre> Genres { get; } = new();

    public Film(int id, string title, int year, Genre? genre = default)
    {
        Id = id;
        Title = title;
        Year = year;
        this.AddGenre(genre);
    }
}