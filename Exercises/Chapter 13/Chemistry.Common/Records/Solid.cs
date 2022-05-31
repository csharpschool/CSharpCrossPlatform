namespace Chemistry.Common;

public record Solid : Substance
{
    public override States State => GetState(GetType().Name);

    public Solid(string name, double mass) : base (name, mass) { }

    public override string GetCompression() => $"{Name} ({State}): not easily compressible.";
    public override string GetShape() => $"{Name} ({State}): retains a fixed volume and shape.";
    public override string ParticleMovement() => $"{Name} ({State}): rigid - particles cannot move/slide past one another.";
    public override sealed string GetData() => $"{Name} {Mass} This is a solid";
}