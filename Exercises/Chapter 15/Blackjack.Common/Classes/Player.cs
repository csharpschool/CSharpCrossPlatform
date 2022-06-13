namespace BlackJack.Classes;

public class Player : PlayerBase
{
    Blackjack Game { get; set; }
      
    public Player(Blackjack game) => Game = game;

    public override void AddCard(List<Card> cards)
    {
        Cards.AddRange(cards);
        CalculateScore();

        if(RuleEngine.BlackjackAndBustHandRules.Evaluate(this)) Game.Stay();
    }
}