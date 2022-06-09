namespace Chemistry.Common;

public record Liquid : Substance
{
    public override States State => GetState(GetType().Name);

    public Liquid(int id, string name, double mass) : base (id, name, mass) { }

    public override string GetCompression() => $"{Name} ({State}): does not compress easily.";
    public override string GetShape() => $"{Name} ({State}): assumes the shape of the part of the container which it occupies.";
    public override string ParticleMovement() => $"{Name} ({State}): particles can move/slide past one another.";
}