namespace BlackJack.Classes;

class Player : PlayerBase
{
    Action Stay { get; init; }
      
    public Player(Action stay) => Stay = stay;

    public override void AddCard(Card[] cards)
    {
        ConcatCards(cards);

        CalculateScore();
        if(Score == 21 && cards.Count().Equals(2))
        {
            ChangeResult(Results.BlackJack);
            if(Stay is not null) Stay();
        }
        if (Score > 21)
        {
            ChangeResult(Results.PlayerLost);
            if(Stay is not null) Stay();
        }
    }
}