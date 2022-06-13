namespace BlackJack.Classes;

public class ScoreRule : IOutcomeRule
{
    public (bool Satisfied, string Message) Evaluate(Player player, Dealer dealer)
    {
        if(player is not null && dealer is not null)
        {
            if(player.Score > dealer.Score) return (true, "Player wins");
            else if(player.Score < dealer.Score) return (true, "Dealer wins");

            else return (true, "Draw");
        }

        return (false, "");
    }
}
