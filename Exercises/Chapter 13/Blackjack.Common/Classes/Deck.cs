using BlackJack.Records;
namespace BlackJack.Classes;

class Deck
{
    string[] unicodeCards = { "🂡", "🂢", "🂣", "🂤", "🂥", "🂦", "🂧", "🂨", "🂩", "🂪", "🂫", "🂭", "🂮" };
    Stack<Card> deck = new();

    IEnumerable<Card> CreateDeck()
    {
        for(int i = 0; i < 4; i++)
            for(int j = 0; j < unicodeCards.Length; j++)
            {
                var value = j > 9 ? 10 : j + 1;
                yield return new Card(unicodeCards[j], value);
            }
    }

    void ShuffleDeck(List<Card> cards)
    {
        var random = new Random();
        while(cards.Count > 0)
        {
            var index = random.Next(cards.Count());
            var card = cards.ElementAt(index);
            deck.Push(card);
            cards.RemoveAt(index);
        }
    }

    public void NewDeck()
    {
        var cards = CreateDeck().ToList(); 
        ShuffleDeck(cards);
    }

    public List<Card> DealCard(int takeCards = 1)
    {
        List<Card> cards = new();
        for(int i = 0; i < takeCards; i++)
        {
            try
            {
                cards.Add(deck.Pop());
            }
            catch{}
        }
        return cards;
    }
}