namespace CalculatorExample.Operations;

/// <summary>
/// Operation that multiplies multiple operands together.
/// </summary>
public class MultiplyOperation : IOperation
{
    public string Name => "multiply";
    
    public double Execute(double[] operands)
    {
        ArgumentNullException.ThrowIfNull(operands);
        
        if (operands.Length < 2)
        {
            throw new ArgumentException("Multiplication requires at least two operands", nameof(operands));
        }

        return operands.Aggregate((product, next) => product * next);
    }
}