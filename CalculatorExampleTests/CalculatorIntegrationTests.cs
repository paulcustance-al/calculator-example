using CalculatorExample;
using CalculatorExample.Operations;
using FluentAssertions;

namespace CalculatorExampleTests
{
    public class CalculatorIntegrationTests
    {
        private readonly Calculator _calculator = new();
        
        [Fact]
        public void Complete_calculator_can_perform_all_basic_math_operations()
        {
            // Arrange
            _calculator.RegisterOperation(new AddOperation());
            _calculator.RegisterOperation(new SubtractOperation());
            _calculator.RegisterOperation(new MultiplyOperation());
            _calculator.RegisterOperation(new DivideOperation());
            _calculator.RegisterOperation(new SquareRootOperation());

            // Act & Assert
            _calculator.Execute("add", 5, 7).Should().Be(12);
            _calculator.Execute("subtract", 10, 3).Should().Be(7);
            _calculator.Execute("multiply", 4, 5).Should().Be(20);
            _calculator.Execute("divide", 20, 4).Should().Be(5);
            _calculator.Execute("sqrt", 16).Should().Be(4);
        }

        [Fact]
        public void Complex_expression_with_chained_operations_calculates_correct_result()
        {
            // Arrange
            _calculator.RegisterOperation(new AddOperation());
            _calculator.RegisterOperation(new MultiplyOperation());
            _calculator.RegisterOperation(new SquareRootOperation());

            // Act - (3 + 6) * 2 = 18, sqrt(18) ≈ 4.24
            var intermediateResult1 = _calculator.Execute("add", 3, 6);
            var intermediateResult2 = _calculator.Execute("multiply", intermediateResult1, 2);
            var finalResult = _calculator.Execute("sqrt", intermediateResult2);

            // Assert
            finalResult.Should().BeApproximately(4.24, 0.01);
        }

        [Fact]
        public void New_operation_with_duplicate_name_overrides_existing_implementation()
        {
            // Arrange
            _calculator.RegisterOperation(new AddOperation());
            var customAddOperation = new CustomAddOperation();

            // Act
            _calculator.RegisterOperation(customAddOperation);
            var result = _calculator.Execute("add", 3, 4);

            // Assert
            result.Should().Be(12); // 3 * 4 = 12, not 7
        }

        private class CustomAddOperation : IOperation
        {
            public string Name => "add";

            public double Execute(double[] operands)
            {
                if (operands.Length < 2)
                    throw new ArgumentException("Custom addition requires at least two operands");

                var result = operands[0];
                for (var i = 1; i < operands.Length; i++)
                    result *= operands[i]; // Multiply instead of add

                return result;
            }
        }
    }
}