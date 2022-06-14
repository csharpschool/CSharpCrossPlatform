namespace BlackJack.Classes;

public class StayRule : IHandRule
{
    public bool Evaluate(PlayerBase person)
    {
        if(person is Dealer)
            person.Stays = person.Score > 16;
        
        return person.Stays;
    } 
}
