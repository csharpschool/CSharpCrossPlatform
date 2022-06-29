namespace BlackJack.Classes;

public class BlackjackRule : IHandRule, IOutcomeRule
{
    public bool Evaluate(PlayerBase person)
    {
        var hasBlackjack = person.Cards.Count().Equals(2) && person.Score.Equals(21);
        if(hasBlackjack) person.ChangeResult(Results.BlackJack);
        return hasBlackjack;
    }

    public (bool Satisfied, string Message) Evaluate(Player player, Dealer dealer) =>
        IOutcomeRule.Evaluate(player, dealer, Results.BlackJack) ? (true, "Player wins with Blackjack") : (false, "");
}