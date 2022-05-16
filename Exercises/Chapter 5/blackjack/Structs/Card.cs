namespace BlackJack.Structs;

public struct Card
{
    const string _back = "🂠";
    string _symbol = string.Empty;
    public bool IsHidden { get; set; }
    public string Symbol { get { return IsHidden ? _back : _symbol; } }
    public int Value { get; set; }
    public bool IsRemoved { get; set; } = false;
    public Card(string symbol, int value, bool isHidden = false)
    {
        _symbol = symbol;
        Value = value;
        IsHidden = isHidden;
    }
}