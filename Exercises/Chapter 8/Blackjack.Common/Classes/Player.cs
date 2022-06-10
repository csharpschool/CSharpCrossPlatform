using BlackJack.Records;
using BlackJack.Enums;
namespace BlackJack.Classes;

class Player
{
    Blackjack Game { get; set; }
    public bool Stays { get; set; }
    public Card[] Cards { get; private set; } = new Card[0];
    public int Score { get; set; }
    public PlayerTypes PlayerType { get; init; }
    public Results Result { get; private set; } = Results.Unknown;

    public Player(PlayerTypes playerType, Blackjack game) => (PlayerType, Game) = (playerType, game);

    void CalculateScore()
    {
        Score = Cards.Sum(c => c.Value);
        var aces = Cards.Where(c => c.Value.Equals(1) && !c.IsHidden); // Fetch all aces

        // The score is low enough to add the ace with its high value of 11.
        // Because 1 has already been added with the Sum function, only 10 is added.
        foreach(var ace in aces)
            if (Score <= 11) Score += 10;
    }

    public void AddCard(Card[] cards)
    {
        Cards = Cards.Concat(cards).ToArray();

        if(PlayerType.Equals(PlayerTypes.Player))
        {
            CalculateScore();
            if(Score == 21 && cards.Count().Equals(2))
            {
                Result = Results.BlackJack;
                Game.Stay();
            }
            if (Score > 21)
            {
                Result = Results.PlayerLost;
                Game.Stay();
            }
        }
        else
        {
            CalculateScore();
            if (Score > 21) Result = Results.DealerLost;
        }
    }
}