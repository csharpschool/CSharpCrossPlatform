namespace BlackJack.Records;

public record Score
{
    List<Card> PlayerCards { get; init; }
    List<Card> DealerCards { get; init; }
    public int PlayerScore { get; init; }
    public int DealerScore { get; init; }
    public string Winner { get; init; }

    public Score(int playerScore, int dealerScore, List<Card> playerCards, 
        List<Card> dealerCards, string winner) => 
        (PlayerScore, DealerScore, PlayerCards, DealerCards, Winner) = 
        (playerScore, dealerScore, playerCards, dealerCards, winner);
    
    public string GetPlayerCards() => 
        string.Join(" ", PlayerCards.Select(c => c.Symbol));
    public string GetDealerCards() =>
        string.Join(" ", DealerCards.Select(c => c.Symbol));
}
