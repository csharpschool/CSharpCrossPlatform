namespace BlackJack.Interfaces;

interface IPlayer
{
    bool Stays { get; set; }
    int Score { get; set; }
    Card[] Cards { get; }
    Results Result { get; }

    void AddCard(Card[] cards);
    void CalculateScore();
}