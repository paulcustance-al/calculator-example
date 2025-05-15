namespace CalculatorExample.Operations;

/// <summary>
/// Operation that divides multiple operands.
/// </summary>
public class DivideOperation : IOperation
{
    public string Name => "divide";

    public double Execute(double[] operands)
    {
        ArgumentNullException.ThrowIfNull(operands);
    
        if (operands.Length < 2)
        {
            throw new ArgumentException("Division requires at least two operands", nameof(operands));
        }

        var result = operands[0];
        const double epsilon = 1e-14; // Threshold for "effectively zero" in double precision
    
        for (var i = 1; i < operands.Length; i++)
        {
            // Check if divisor is effectively zero using epsilon comparison
            if (Math.Abs(operands[i]) < epsilon)
            {
                throw new DivideByZeroException($"Cannot divide by zero or very small value at operand position {i}");
            }
        
            result /= operands[i];
        
            // Check for potential overflow or underflow
            if (double.IsInfinity(result) || double.IsNaN(result))
            {
                throw new OverflowException($"Division operation resulted in {(double.IsNaN(result) ? "NaN" : "infinity")} at step {i}");
            }
        }

        return result;
    }
}