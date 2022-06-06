namespace Chemistry.Common;

public record Plasma : ISubstance
{
    public string Name { get; }
    public double Mass { get; }
    public States State => States.Plasma;

    public Plasma(string name, double mass) => (Name, Mass) = (name, mass);

    public string GetCompression() => $"{Name} ({State}): is compressible.";
    public string GetShape() => $"{Name} ({State}): doesn't have a shape or volume.";
    public string ParticleMovement() => $"{Name} ({State}): particles are spread out and move randomly; contain some free ions and electrons, which gives plasma its ability to conduct electricity.";
}
