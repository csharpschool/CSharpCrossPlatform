namespace BlackJack.Interfaces;

public interface IOutcomeRule
{
    (bool Satisfied, string Message) Evaluate(Player player, Dealer dealer);

    static bool Evaluate(Player player, Dealer dealer, Results result)
    {
        if(player is not null && player.Result.Equals(result))
        {
            if(dealer is not null && dealer.Cards.Count().Equals(2))
            {
                dealer.Cards[0].IsHidden = true;
                dealer.Score = dealer.Cards[1].Value;
            }

            return true;
        }

        return false;
    }
}
