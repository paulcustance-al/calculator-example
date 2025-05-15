using CalculatorExample;
using CalculatorExample.Operations;

var calculator = new Calculator();

// Register basic operations
calculator.RegisterOperation(new AddOperation());
calculator.RegisterOperation(new SubtractOperation());
calculator.RegisterOperation(new MultiplyOperation());
calculator.RegisterOperation(new DivideOperation());

// Register advanced operations
calculator.RegisterOperation(new PowerOperation());

// Use the calculator
Console.WriteLine("Available operations: " + string.Join(", ", calculator.GetOperationNames()));
Console.WriteLine("2 + 3 = " + calculator.Execute("add", 2, 3));
Console.WriteLine("5 - 2 = " + calculator.Execute("subtract", 5, 2));
Console.WriteLine("4 * 3 = " + calculator.Execute("multiply", 4, 3));
Console.WriteLine("10 / 2 = " + calculator.Execute("divide", 10, 2));
Console.WriteLine("2^3 = " + calculator.Execute("power", 2, 3));

// Example of how you can add more operations at runtime
calculator.RegisterOperation(new SquareRootOperation());
Console.WriteLine("√16 = " + calculator.Execute("sqrt", 16));