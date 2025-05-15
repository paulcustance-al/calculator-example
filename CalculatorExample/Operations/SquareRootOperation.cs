namespace CalculatorExample.Operations;

public class SquareRootOperation : IOperation
{
    public string Name => "sqrt";
        
    public double Execute(double[] operands)
    {
        if (operands.Length != 1)
            throw new ArgumentException("Square root operation requires exactly one operand");
                
        if (operands[0] < 0)
            throw new ArgumentException("Cannot calculate square root of a negative number");
                
        return Math.Sqrt(operands[0]);
    }
}
