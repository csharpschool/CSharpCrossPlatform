namespace Calculator.Common;

public class Calc
{
    public string Calculation 
    {
        get 
        {
            var output = string.Empty;

            foreach (var op in Operations)
                output += $"{op.Value} {op.OperatorValue} ";
            
            return output;
        } 
    }
    public List<Operation> Operations { get; } = new();

    public void AddOperation(Operation operation) => Operations.Add(operation);
    public void Clear() => Operations.Clear();

    public (string calcualtion, double result) Calculate()
    {
        var output = Calculation;
        var result = CalculateResult();

        if(!double.IsNaN(result) && Operations.Count().Equals(1)) output = $"{result}";
        else if(!double.IsNaN(result) && output.Length > 0) output += $"{result}";

        return (output, result);
    }

    double CalculateResult() 
    {
        Operation? result = default;

        try
        {
            if(Operations.Count().Equals(0)) return double.NaN;
            if(Operations.Count().Equals(1)) return Operations.First().Value;

            foreach (var operation in Operations)
            {
                if (result == default) result = new Operation(operation.Value, operation.Operator);
                else result.Calculate(operation);
            }
        }
        catch (OverflowException ex)
        {
            ex.Data.Add("Calculation", Calculation);
            throw;
        }
        catch
        {
            throw;
        }

        return result?.Value ?? double.NaN;
    }
}