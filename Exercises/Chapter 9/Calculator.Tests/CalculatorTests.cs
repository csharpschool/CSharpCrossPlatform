namespace Calculator.Tests;

public class CalculatorTests
{
    [Fact]
    public void CanCreateCalculatorInstance()
    {
        var calculator = new Calc();

        Assert.NotNull(calculator);
    }

    [Fact]
    public void CanAddOperationToCalculatorInstance()
    {
        var calculator = new Calc();
        var operation = new Operation(10, Operators.Multiply);
        calculator.AddOperation(operation);

        Assert.Contains(operation, calculator.Operations);
    }

    [Fact]
    public void CanCalculateWithEmptyListCalculatorInstance()
    {
        var calculator = new Calc();
        var result = calculator.Calculate();

        Assert.Equal(string.Empty, result.calcualtion);
        Assert.Equal(double.NaN, result.result);
    }

    [Fact]
    public void CanCalculateWithOneOperationCalculatorInstance()
    {
        var calculator = new Calc();
        var operation = new Operation(10, Operators.Multiply);
        calculator.AddOperation(operation);
        var result = calculator.Calculate();

        Assert.Contains(operation, calculator.Operations);
        Assert.Equal("10", result.calcualtion);
        Assert.Equal(10, result.result);
    }

    [Fact]
    public void CanCalculateWithManyOperationsCalculatorInstance()
    {
        var calculator = new Calc();
        var operation1 = new Operation(10, Operators.Multiply);
        var operation2 = new Operation(20, Operators.Divide);
        // 10 x 20  = 200
        var operation3 = new Operation(2, Operators.Add);
        // 200 / 2  = 100
        var operation4 = new Operation(30, Operators.Subtract);
        // 100 + 30 = 130
        var operation5 = new Operation(50, Operators.Equals);
        // 130 - 50 = 80

        calculator.AddOperation(operation1);
        calculator.AddOperation(operation2);
        calculator.AddOperation(operation3);
        calculator.AddOperation(operation4);
        calculator.AddOperation(operation5);
        var result = calculator.Calculate();

        Assert.Equal(80, result.result);
        Assert.Equal("10 x 20 / 2 + 30 - 50 = 80", result.calcualtion);
    }

    [Fact]
    public void CanClearCalculator()
    {
        var calculator = new Calc();
        var operation = new Operation(10, Operators.Multiply);

        calculator.AddOperation(operation);
        var count = calculator.Operations.Count();
        calculator.Clear();

        Assert.Equal(1, count);
        Assert.Empty(calculator.Operations);
    }
}