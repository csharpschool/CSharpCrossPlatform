namespace BlackJack.Classes;

class Dealer : IPlayer
{
    public bool Stays { get; set; }
    public int Score { get; set; }
    public List<Card> Cards { get; private set; } = new();
    public Results Result { get; private set; } = Results.Unknown;

    public void AddCard(List<Card> cards)
    {
        Cards.AddRange(cards);
        CalculateScore();
        if (Score > 21) Result = Results.DealerLost;
    }
    
    public void CalculateScore()
    {
        Score = Cards.Sum(c => c.Value);
        var aces = Cards.Where(c => c.Value.Equals(1) && !c.IsHidden); // Fetch all aces

        // The score is low enough to add the ace with its high value of 11.
        // Because 1 has already been added with the Sum function, only 10 is added.
        foreach(var ace in aces)
            if (Score <= 11) Score += 10;
    }
}