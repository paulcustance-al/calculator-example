namespace CalculatorExample;

public interface IOperation
{
    string Name { get; }
    
    double Execute(double[] operands);
}