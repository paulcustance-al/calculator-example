using CalculatorExample.Operations;
using FluentAssertions;

namespace CalculatorExampleTests;

public class SquareRootOperationTests
{
    private readonly SquareRootOperation _squareRootOperation = new();
    
    [Fact]
    public void Square_root_of_positive_number_returns_correct_result()
    {
        // Arrange
        var operands = new double[] { 16 };

        // Act
        var result = _squareRootOperation.Execute(operands);

        // Assert
        result.Should().Be(4);
    }

    [Fact]
    public void Square_root_of_negative_number_throws_argument_exception()
    {
        // Arrange
        var operands = new double[] { -4 };

        // Act
        Action act = () => _squareRootOperation.Execute(operands);

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("*Cannot calculate square root of a negative number*");
    }

    [Fact]
    public void Square_root_requires_exactly_one_operand()
    {
        // Arrange
        var operands = new double[] { 4, 9 };

        // Act
        Action act = () => _squareRootOperation.Execute(operands);

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("*requires exactly one operand*");
    }

    [Fact]
    public void Operation_name_is_sqrt()
    {
        // Arrange, Act & Assert
        _squareRootOperation.Name.Should().Be("sqrt");
    }
}