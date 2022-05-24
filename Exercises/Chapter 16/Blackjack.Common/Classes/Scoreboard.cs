namespace BlackJack.Classes;

public class Scoreboard
{
    public List<Score> Scores { get; init; } = new();

    public void AddScore(object? sender, Score score) => Scores.Add(score);

    public void ClearScoreboard() => Scores.Clear();
}