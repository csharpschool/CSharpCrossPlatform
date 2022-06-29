namespace BlackJack.Classes;

public class Player : PlayerBase
{
    Action Stay { get; init; }
      
    public Player(Action stay) => Stay = stay;


    public override void AddCard(List<Card> cards)
    {
        Cards.AddRange(cards);
        CalculateScore();

        if(RuleEngine.BlackjackAndBustHandRules.Evaluate(this) && Stay is not null) Stay();
    }
}