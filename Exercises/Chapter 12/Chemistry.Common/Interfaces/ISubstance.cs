namespace Chemistry.Common;

public interface ISubstance
{
    string Name { get; }
    double Mass { get; }
    States State { get; }

    string GetShape();
    string GetCompression();
    string ParticleMovement();
}