namespace VideoShop.Tests;

public class ShopTests
{
    [Fact]
    public void CanCreateGenreInstance()
    {
        var genre = new Genre(1, "Action");

        Assert.NotNull(genre);
        Assert.Equal(1, genre.Id);
        Assert.Equal("Action", genre.Name);
    }

    [Fact]
    public void CanCreateInstanceWithGenre()
    {
        var genre = new Genre(1, "Action");
        var film = new Film(1, "The Title", 1920, genre);

        Assert.NotNull(film);
        Assert.Equal(1, film.Id);
        Assert.Equal(1920, film.Year);
        Assert.Equal("The Title", film.Title);
        Assert.NotEmpty(film.Genres);
    }

    [Fact]
    public void CanCreateInstanceWithoutGenre()
    {
        var film = new Film(1, "The Title", 1920);

        Assert.NotNull(film);
        Assert.Equal(1, film.Id);
        Assert.Equal(1920, film.Year);
        Assert.Equal("The Title", film.Title);
        Assert.Empty(film.Genres);
    }
}