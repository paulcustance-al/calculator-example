namespace CalculatorExample;

public class Calculator
{
    private readonly Dictionary<string, IOperation> _operations = new(StringComparer.OrdinalIgnoreCase);

    public void RegisterOperation(IOperation operation)
    {
        ArgumentNullException.ThrowIfNull(operation);

        _operations[operation.Name] = operation;
    }

    public double Execute(string operationName, params double[] operands)
    {
        if (string.IsNullOrWhiteSpace(operationName))
            throw new ArgumentException("Operation name cannot be null or empty", nameof(operationName));

        if (!_operations.TryGetValue(operationName, out var operation))
            throw new InvalidOperationException($"Operation '{operationName}' is not registered");

        return operation.Execute(operands);
    }

    public IEnumerable<string> GetOperationNames()
    {
        return _operations.Keys;
    }
}