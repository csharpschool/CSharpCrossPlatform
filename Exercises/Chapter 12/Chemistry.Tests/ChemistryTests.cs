namespace Chemistry.Tests;

public class SubstancesTests
{
    [Fact]
    public void CanCreateLiquidInstance()
    {
        ISubstance substance = new Liquid("Water", 1);

        Assert.NotNull(substance);
        Assert.Equal("Water", substance.Name);
        Assert.Equal(1, substance.Mass);
        Assert.Equal(States.Liquid, substance.State);
    }

    [Fact]
    public void CanCreatePlasmaInstance()
    {
        ISubstance substance = new Plasma("Lightning", 1);

        Assert.NotNull(substance);
        Assert.Equal("Lightning", substance.Name);
        Assert.Equal(1, substance.Mass);
        Assert.Equal(States.Plasma, substance.State);
    }

    [Fact]
    public void CanCreateSolidInstance()
    {
        ISubstance substance = new Solid("Ice", 0.9);

        Assert.NotNull(substance);
        Assert.Equal("Ice", substance.Name);
        Assert.Equal(0.9, substance.Mass);
        Assert.Equal(States.Solid, substance.State);
    }

    [Fact]
    public void CanCreateGasInstance()
    {
        ISubstance substance = new Gas("Air", 0.1);

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
}