namespace VideoShop.Common;

public static class GenreExtensions
{
    public static Film AddGenre(this Film film, Genre? genre)
    {
        if (genre != default) film.Genres?.Add(genre);
        return film;
    }

    public static List<Genre> AddGenre(this List<Genre> genres, string name)
    {
        if (name != default && name.Length > 0)
            genres.Add(new Genre(genres.Count + 1, name));

        return genres;
    }
}