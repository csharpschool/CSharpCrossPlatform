namespace Chemistry.Common;

public class Gas : ISubstance
{
    public string Name { get; }
    public double Mass { get; }
    public States State => States.Gas;

    public Gas(string name, double mass) => (Name, Mass) = (name, mass);

    public string GetCompression() =>  $"{Name} ({State}): is compressible.";
    public string GetShape() => $"{Name} ({State}): assumes the shape and volume of its container.";
    public string ParticleMovement() => $"{Name} ({State}): particles can move past one another.";
}