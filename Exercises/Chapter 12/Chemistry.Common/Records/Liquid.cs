namespace Chemistry.Common;

public record Liquid : ISubstance
{
    public string Name { get; }
    public double Mass { get; }
    public States State => States.Liquid;

    public Liquid(string name, double mass) => (Name, Mass) = (name, mass);

    public string GetCompression() => $"{Name} ({State}): does not compress easily.";
    public string GetShape() => $"{Name} ({State}): assumes the shape of the part of the container which it occupies.";
    public string ParticleMovement() => $"{Name} ({State}): particles can move/slide past one another.";
}