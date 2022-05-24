using BlackJack.Records;
namespace BlackJack.Classes;

class Deck
{
    string[] unicodeCards = { "🂡", "🂢", "🂣", "🂤", "🂥", "🂦", "🂧", "🂨", "🂩", "🂪", "🂫", "🂭", "🂮" };
    const int numberOfCards = 52;
    Card[] deck = new Card[numberOfCards];

    Card[] CreateDeck()
    {
        var cards = new Card[numberOfCards];
        var index = 0;
        for(int i = 0; i < 4; i++)
            for(int j = 0; j < unicodeCards.Length; j++)
            {
                var value = j > 9 ? 10 : j + 1;
                cards[index] = new Card(unicodeCards[j], value);
                index++;
            }

        return cards;
    }

    Card[] ShuffleDeck(Card[] cards)
    {
        var shuffled = new Card[numberOfCards];
        var random = new Random();
        var position = 0;
        while(position < numberOfCards)
        {
            var index = random.Next(cards.Where(c => !c.IsRemoved).Count());
            shuffled[position++] = cards[index];
            cards[index].IsRemoved = true;
        }
        return shuffled;
    }

    public void NewDeck()
    {
        deck = CreateDeck(); 
        deck = ShuffleDeck(deck);
    }

    public Card[] DealCard(int takeCards = 1)
    {
        var cards = deck[0..takeCards];
        deck = deck[takeCards..];
        return cards;
    }
}