public class DealerBustRule: IOutcomeRule
{
    public (bool Satisfied, string Message) Evaluate(Player player, Dealer dealer) => 
        dealer is not null && dealer.Result.Equals(Results.Bust) ? (true, "Player wins") : (false, "");
}