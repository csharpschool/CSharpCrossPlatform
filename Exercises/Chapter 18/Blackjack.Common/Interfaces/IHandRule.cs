namespace BlackJack.Interfaces;

public interface IHandRule
{
    bool Evaluate(PlayerBase person);
}