namespace Chemistry.Common;

public abstract record Substance
{
    public string Name { get; }
    public double Mass { get; }
    public abstract States State { get; }

    protected Substance(string name, double mass) => (Name, Mass) = (name, mass);

    protected States GetState(string name) => (States)Enum.Parse(typeof(States), name);
    public abstract string GetShape();
    public abstract string GetCompression();
    public abstract string ParticleMovement();

    public virtual string GetData() => $"{Name} {Mass} {State}";
}