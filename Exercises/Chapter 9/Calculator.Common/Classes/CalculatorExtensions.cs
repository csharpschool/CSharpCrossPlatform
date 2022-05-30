namespace Calculator.Common;

public static class CalculatorExtensions
{
    public static Operation ChangeOperator(this Operation result, Operators @operator) => result.SetOperator(@operator);
    public static Operation ChangeValue(this Operation result, double value) => result.SetValue(value);

    public static Operation Calculate(this Operation result, Operation operation) =>
        result.Operator switch
        {
            Operators.Add => result.ChangeValue(result.Value + operation.Value).ChangeOperator(operation.Operator),
            Operators.Subtract => result.ChangeValue(result.Value - operation.Value).ChangeOperator(operation.Operator),
            Operators.Divide => result.ChangeValue(result.Value / operation.Value).ChangeOperator(operation.Operator),
            Operators.Multiply => result.ChangeValue(result.Value * operation.Value).ChangeOperator(operation.Operator),
            Operators.Equals => result,
            _ => throw new ArgumentException("Opertion does not exist.", nameof(operation))
        };

}