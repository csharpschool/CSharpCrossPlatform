namespace BlackJack.Classes;

public class BustRule : IHandRule
{
    public bool Evaluate(PlayerBase person) 
    {
        var isBust = person.Score > 21;
        if(isBust) person.ChangeResult(Results.Bust);
        return isBust;
    }
}