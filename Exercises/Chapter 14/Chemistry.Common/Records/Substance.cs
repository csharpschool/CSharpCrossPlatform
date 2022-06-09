namespace Chemistry.Common;

public abstract record Substance: IEquatable<Substance>
{
    public int Id { get; }
    public string Name { get; }
    public double Mass { get; }
    public abstract States State { get; }

    protected Substance(int id, string name, double mass) => (Id, Name, Mass) = (id, name, mass);

    protected States GetState(string name) => (States)Enum.Parse(typeof(States), name);
    public abstract string GetShape();
    public abstract string GetCompression();
    public abstract string ParticleMovement();

    public virtual string GetData() => $"{Name} {Mass} {State}";

    public virtual bool Equals(Substance? other)
    {
        if (other == null || GetType() != other.GetType()) return false;
        
        if(State == other.State) return true;
        
        return false;
    } 
    
    public override int GetHashCode() => base.GetHashCode();
}