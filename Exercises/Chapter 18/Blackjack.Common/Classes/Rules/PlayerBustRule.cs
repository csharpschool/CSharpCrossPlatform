namespace BlackJack.Classes;

public class PlayerBustRule : IOutcomeRule
{
    public (bool Satisfied, string Message) Evaluate(Player player, Dealer dealer) =>
        IOutcomeRule.Evaluate(player, dealer, Results.Bust) ? (true, "Dealer wins.") : (false, "");
}