namespace BlackJack.Classes;

public class Blackjack
{
   Deck deck = new();
   Player player;
   Dealer dealer;

   public List<Card> GetDealerCards() => dealer.Cards;
   public List<Card> GetPlayerCards() => player.Cards;
   public int GetPlayerScore() => player.Score;
   public int GetDealerScore() => dealer.Score;
   public bool Stays { get => player.Stays; }
   public string Winner { get; private set; } = string.Empty;

    public Blackjack()
    {
        player = new(this);
        dealer = new();
    }

    public void DealPlayerCard(int takeCards = 1) => player.AddCard(deck.DealCard(takeCards));
    public void DealDealerCard(int takeCards = 1, bool firstCards = false) 
    {
        var cards = deck.DealCard(takeCards);
        if(firstCards) cards.First().IsHidden = true;
        dealer.AddCard(cards);
    }
    public void NewGame()
    {
        Winner = string.Empty;
        deck.NewDeck();
        player = new(this);
        dealer = new();

        DealDealerCard(2, true);
        DealPlayerCard(2);
    }

    public void Stay()
    {
        player.Stays = true;
        dealer.Stays = true;

        if(!RuleEngine.BlackjackAndBustHandRules.Evaluate(player))
        {
            dealer.Cards.First().IsHidden = false;
            dealer.CalculateScore();
            while(dealer.Score < 17)
                DealDealerCard();
        }

        Winner = RuleEngine.DetermineWinnerRules.Evaluate(player, dealer);
    }
}