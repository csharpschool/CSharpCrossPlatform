namespace BlackJack.Classes;

public static class RuleEngine
{
    public static List<IHandRule> BlackjackAndBustHandRules => new()
    {
        new BlackjackRule(),
        new BustRule()
    };

    public static  List<IHandRule> StayAndBustHandRules => new()
    {
        new StayRule(),
        new BustRule()
    };

    public static List<IOutcomeRule> DetermineWinnerRules => new()
    {
        new BlackjackRule(),
        new PlayerBustRule(),
        new DealerBustRule(),
        new ScoreRule()
    };

    public static bool Evaluate(this IEnumerable<IHandRule> rules, PlayerBase person)
    {
        person.ChangeResult(Results.Unknown);
        foreach(var rule in rules)
        {
            rule.Evaluate(person);
            if(!person.Result.Equals(Results.Unknown)) break;
        }

        return !person.Result.Equals(Results.Unknown);
    }

    public static string Evaluate(this IEnumerable<IOutcomeRule> rules, Player player, Dealer dealer)
    {
        foreach(var rule in rules)
        {
            var result = rule.Evaluate(player, dealer);
            if(result.Satisfied) return result.Message;
        }

        return string.Empty;
    }
}