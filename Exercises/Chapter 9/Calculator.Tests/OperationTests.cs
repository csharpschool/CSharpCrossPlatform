namespace Calculator.Tests;

public class OperationTests
{
    [Fact]
    public void CanCreateOperationInstance()
    {
        var operation = new Operation(10, Operators.Multiply);

        Assert.NotNull(operation);
        Assert.Equal(10, operation.Value);
        Assert.Equal(Operators.Multiply, operation.Operator);
    }

    [Fact]
    public void CanChangeVlauesInOperationInstance()
    {
        var operation = new Operation(10, Operators.Multiply);

        operation.SetValue(20);
        operation.SetOperator(Operators.Divide);
        
        Assert.Equal(20, operation.Value);
        Assert.Equal(Operators.Divide, operation.Operator);
    }

    [Fact]
    public void CanChangeValueWithExtensionMethodsInAnOperationInstance()
    {
        var operation = new Operation(10, Operators.Multiply);
        
        operation.ChangeValue(20);

        Assert.Equal(20, operation.Value);
    }

    [Fact]
    public void CanChangeOperatorWithExtensionMethodsInAnOperationInstance()
    {
        var operation = new Operation(10, Operators.Multiply);
        
        operation.ChangeOperator(Operators.Divide);

        Assert.Equal(Operators.Divide, operation.Operator);
    }

    [Fact]
    public void CanCalculateWithTheCalculateExtensionMethodInAnOperationInstance()
    {
        var operation1 = new Operation(10, Operators.Multiply);
        var operation2 = new Operation(20, Operators.Equals);

        var result = operation1.Calculate(operation2);

        Assert.Equal(200, result.Value);
        Assert.Equal(Operators.Equals, result.Operator);
    }
}