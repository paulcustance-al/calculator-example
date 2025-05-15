namespace CalculatorExample.Operations;

/// <summary>
/// Operation that adds multiple operands together.
/// </summary>
public class AddOperation : IOperation
{
    public string Name => "add";

    public double Execute(double[] operands)
    {
        ArgumentNullException.ThrowIfNull(operands);
        
        if (operands.Length < 2)
        {
            throw new ArgumentException("Addition requires at least two operands", nameof(operands));
        }

        return operands.Sum();
    }
}