namespace BlackJack.Classes;

class Dealer : IPlayer
{
    public bool Stays { get; set; }
    public int Score { get; set; }
    public Card[] Cards { get; private set; } = new Card[0];
    public Results Result { get; private set; } = Results.Unknown;

    public void AddCard(Card[] cards)
    {
        Cards = Cards.Concat(cards).ToArray();

        if (!Stays) cards[0].IsHidden = true;
        CalculateScore();
        if (Score > 21) Result = Results.DealerLost;
    }
    
    public void CalculateScore()
    {
        Score = Cards.Where(c => !c.IsHidden).Sum(c => c.Value);
        var aces = Cards.Where(c => c.Value.Equals(1) && !c.IsHidden); // Fetch all aces

        // The score is low enough to add the ace with its high value of 11.
        // Because 1 has already been added with the Sum function, only 10 is added.
        foreach(var ace in aces)
            if (Score <= 11) Score += 10;
    }
}