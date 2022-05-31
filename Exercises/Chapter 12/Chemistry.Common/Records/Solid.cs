namespace Chemistry.Common;

public record Solid : ISubstance
{
    public string Name { get; }
    public double Mass { get; }
    public States State => States.Solid;

    public Solid(string name, double mass) => (Name, Mass) = (name, mass);

    public string GetCompression() => $"{Name} ({State}): not easily compressible.";
    public string GetShape() => $"{Name} ({State}): retains a fixed volume and shape.";
    public string ParticleMovement() => $"{Name} ({State}): rigid - particles cannot move/slide past one another.";
}