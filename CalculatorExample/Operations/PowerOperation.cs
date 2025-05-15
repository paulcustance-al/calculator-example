namespace CalculatorExample.Operations;

/// <summary>
/// Operation that raises a base number to the power of an exponent.
/// </summary>
public class PowerOperation : IOperation
{
    public string Name => "power";
    
    public double Execute(double[] operands)
    {
        ArgumentNullException.ThrowIfNull(operands);
        
        if (operands.Length != 2)
        {
            throw new ArgumentException("Power operation requires exactly two operands", nameof(operands));
        }

        var baseNumber = operands[0];
        var exponent = operands[1];

        return Math.Pow(baseNumber, exponent);
    }
}