using BlackJack.Records;
namespace BlackJack.Classes;

class Deck
{
    string[] unicodeCards = { "🂡", "🂢", "🂣", "🂤", "🂥", "🂦", "🂧", "🂨", "🂩", "🂪", "🂫", "🂭", "🂮" };
    /* const int numberOfCards = 52;
    Card[] deck = new Card[numberOfCards]; */
    Stack<Card> deck = new();

    //Card[] CreateDeck()
    IEnumerable<Card> CreateDeck()
    {
        //var cards = new Card[numberOfCards];
        //var index = 0;
        for(int i = 0; i < 4; i++)
            for(int j = 0; j < unicodeCards.Length; j++)
            {
                var value = j > 9 ? 10 : j + 1;
                yield return new Card(unicodeCards[j], value);
                //cards[index] = new Card(unicodeCards[j], value);
                //index++;
            }

        //return cards;
    }

    //Card[] ShuffleDeck(Card[] cards)
    void ShuffleDeck(List<Card> cards)
    {
        //var shuffled = new Card[numberOfCards];
        var random = new Random();
        //var position = 0;
        //while(position < numberOfCards)
        while(cards.Count > 0)
        {
            var index = random.Next(cards.Count());
            var card = cards.ElementAt(index);
            deck.Push(card);
            cards.RemoveAt(index);
            //var index = random.Next(cards.Where(c => !c.IsRemoved).Count());
            //shuffled[position++] = cards[index];
            //cards[index].IsRemoved = true;
        }
        //return shuffled;
    }

    public void NewDeck()
    {
        var cards = CreateDeck().ToList(); 
        ShuffleDeck(cards);

        //deck = CreateDeck(); 
        //deck = ShuffleDeck(deck);
    }

    //public Card[] DealCard(int takeCards = 1)
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
        //var cards = deck[0..takeCards];
        //deck = deck[takeCards..];
        return cards;
    }
}