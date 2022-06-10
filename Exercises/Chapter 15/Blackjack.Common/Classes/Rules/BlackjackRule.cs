namespace BlackJack.Classes;

public class BlackjackRule : IHandRule
{
    public bool Evaluate(PlayerBase person)
    {
        var hasBlackjack = person.Cards.Count().Equals(2) && person.Score.Equals(21);
        if(hasBlackjack) person.ChangeResult(Results.BlackJack);
        return hasBlackjack;
    }
}