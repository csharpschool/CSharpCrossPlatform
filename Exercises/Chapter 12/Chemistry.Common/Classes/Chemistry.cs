namespace Chemistry.Common;

public class Chemistry
{
    List<ISubstance> Substances { get; } = new();
    public string[] StateNames => Enum.GetNames(typeof(States));
    public States GetStateValue(string name) => (States)Enum.Parse(typeof(States), name);

    public Chemistry()
    {
        Add(new Solid("Ice", 0.9));
        Add(new Gas("Air", 0.1));
        Add(new Plasma("Lightning", 0.01));
        Add(new Liquid("Water", 1.0));
    }

    public ISubstance CreateSubstance(string name, double mass, string state) =>
    GetStateValue(state) switch
    {
        States.Liquid => new Liquid(name, mass),
        States.Gas => new Gas(name, mass),
        States.Plasma  => new Plasma(name, mass),
        States.Solid  => new Solid(name, mass),
        _             => throw new ArgumentException(
                            "State does not exist.", nameof(state)),
    };

    public void Add(string name, double mass, string state)
    {
        try
        {
            ISubstance substance = CreateSubstance(name, mass, state);
            Add(substance);
        }
        catch
        {
            throw;
        }
    }

    public void Add(ISubstance substance) => Substances.Add(substance);
    public List<ISubstance> Get() => Substances;
    public List<ISubstance> Get(Func<ISubstance, bool> expression) =>
        Substances.Where(expression).ToList();
}