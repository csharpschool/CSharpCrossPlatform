namespace BlackJack.Interfaces;

interface IPlayer
{
    bool Stays { get; set; }
    int Score { get; set; }
    List<Card> Cards { get; }
    Results Result { get; }

    void AddCard(List<Card> cards);
    void CalculateScore();
}