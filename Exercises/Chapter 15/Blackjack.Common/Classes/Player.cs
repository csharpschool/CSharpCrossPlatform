namespace BlackJack.Classes;

public class Player : PlayerBase
{
    Blackjack Game { get; set; }
      
    public Player(Blackjack game) => Game = game;

    public override void AddCard(List<Card> cards)
    {
        Cards.AddRange(cards);
        CalculateScore();

       /*  if(Score == 21 && cards.Count().Equals(2))
        {
            ChangeResult(Results.BlackJack);
            Game.Stay();
        }
        if (Score > 21)
        {
            ChangeResult(Results.PlayerLost);
            Game.Stay();
        } */

        if(RuleEngine.BlackjackAndBustHandRules.Evaluate(this)) Game.Stay();
    }
}