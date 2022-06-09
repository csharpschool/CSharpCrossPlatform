namespace Chemistry.Common;

public record Gas : Substance
{
    public override States State => GetState(GetType().Name);

    public Gas(int id, string name, double mass) : base (id, name, mass) { }

    public override string GetCompression() =>  $"{Name} ({State}): is compressible.";
    public override string GetShape() => $"{Name} ({State}): assumes the shape and volume of its container.";
    public override string ParticleMovement() => $"{Name} ({State}): particles can move past one another.";
}