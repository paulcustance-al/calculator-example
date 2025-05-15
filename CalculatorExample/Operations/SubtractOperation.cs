namespace CalculatorExample.Operations;

public class SubtractOperation : IOperation
{
    public string Name => "subtract";

    public double Execute(double[] operands)
    {
        if (operands.Length < 2)
            throw new ArgumentException("Subtraction requires at least two operands");

        var result = operands[0];
        for (var i = 1; i < operands.Length; i++) result -= operands[i];
        return result;
    }
}