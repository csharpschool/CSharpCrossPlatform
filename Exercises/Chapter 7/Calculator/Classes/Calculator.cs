namespace Calculator.Classes;

class Calc
{
    public double Add(double value1, double value2) => value1 + value2;
    public double Subtract(double value1, double value2) => value1 - value2;
    // Division by 0 results in an unhandled exception 
    // if placed in a try-block, else infinity
    public double Divide(double value1, double value2) => value1 / value2;
    public double Multiply(double value1, double value2) => value1 * value2;

    private string Output(double value1, double value2, double result, char @operator) =>
        $"{value1} {@operator} {value2} = {result}";
    
    public void Add(double value1, double value2, out string output) => 
        output = Output(value1, value2, Add(value1, value2), '+');

    public void Subtract(double value1, double value2, out string output) => 
        output = Output(value1, value2, Subtract(value1, value2), '-');

    public void Divide(double value1, double value2, out string output) => 
        output = Output(value1, value2, Divide(value1, value2), '/');
    
    public void Multiply(double value1, double value2, out string output) => 
        output = Output(value1, value2, Multiply(value1, value2), 'x');
}
