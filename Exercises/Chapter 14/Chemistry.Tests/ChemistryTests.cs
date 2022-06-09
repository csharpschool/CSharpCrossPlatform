namespace Chemistry.Tests;

public class SubstancesTests
{
    [Fact]
    public void CanCreateLiquidInstance()
    {
        Substance substance = new Liquid(4, "Water", 1);

        Assert.NotNull(substance);
        Assert.Equal("Water", substance.Name);
        Assert.Equal(1, substance.Mass);
        Assert.Equal(States.Liquid, substance.State);
    }

    [Fact]
    public void CanCreatePlasmaInstance()
    {
        Substance substance = new Plasma(3, "Lightning", 1);

        Assert.NotNull(substance);
        Assert.Equal("Lightning", substance.Name);
        Assert.Equal(1, substance.Mass);
        Assert.Equal(States.Plasma, substance.State);
    }

    [Fact]
    public void CanCreateSolidInstance()
    {
        Substance substance = new Solid(1, "Ice", 0.9);

        Assert.NotNull(substance);
        Assert.Equal("Ice", substance.Name);
        Assert.Equal(0.9, substance.Mass);
        Assert.Equal(States.Solid, substance.State);
    }

    [Fact]
    public void CanCreateGasInstance()
    {
        Substance substance = new Gas(2, "Air", 0.1);

        Assert.NotNull(substance);
        Assert.Equal("Air", substance.Name);
        Assert.Equal(0.1, substance.Mass);
        Assert.Equal(States.Gas, substance.State);
    }

    [Fact]
    public void CanCreateSubstancesInstance()
    {
        var substances = new Common.Chemistry();

        Assert.NotNull(substances);
        Assert.NotEmpty(substances.SateNames);
        Assert.Equal(States.Liquid, substances.GetStateValue("Liquid"));
        Assert.NotEmpty(substances.Get());
        Assert.NotEmpty(substances.Get(m => m.State.Equals(States.Liquid)));
    }

    [Fact]
    public void SubstancesAreEqual()
    {
        Substance substance1 = new Gas(2, "Gas 1", 0.1);
        Substance substance2 = new Gas(3, "Gas 2", 0.2);

        var equal = substance1.SameState(substance2);

        Assert.Equal(true, equal);
    }

    [Fact]
    public void SubstancesAreNotEqual()
    {
        Substance substance1 = new Liquid(4, "Liquid", 1);
        Substance substance2 = new Gas(3, "Gas 2", 0.2);

        var equal = substance1.SameState(substance2);

        Assert.Equal(false, equal);
    }

}