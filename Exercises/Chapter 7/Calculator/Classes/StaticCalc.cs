namespace Calculator.Classes;

static class StaticCalc
{
    public static double Add(double value1, double value2) => value1 + value2;
    public static double Subtract(double value1, double value2) => value1 - value2;
    // Division by 0 results in an unhandled exception 
    // if placed in a try-block, else infinity
    public static double Divide(double value1, double value2) => value1 / value2;
    public static double Multiply(double value1, double value2) => value1 * value2;

    private static string Output(double value1, double value2, double result, char @operator) =>
        $"{value1} {@operator} {value2} = {result}";
    
    public static void Add(double value1, double value2, out string output) => 
        output = Output(value1, value2, Add(value1, value2), '+');

    public static void Subtract(double value1, double value2, out string output) => 
        output = Output(value1, value2, Subtract(value1, value2), '-');

    public static void Divide(double value1, double value2, out string output) => 
        output = Output(value1, value2, Divide(value1, value2), '/');
    
    public static void Multiply(double value1, double value2, out string output) => 
        output = Output(value1, value2, Multiply(value1, value2), 'x');
}
