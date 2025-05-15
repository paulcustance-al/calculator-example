using CalculatorExample.Operations;
using FluentAssertions;

namespace CalculatorExampleTests;

public class SubtractOperationTests
{
    private readonly SubtractOperation _subtractOperation = new();
    
    [Fact]
    public void Subtracting_two_numbers_returns_difference_correctly()
    {
        // Arrange
        var operands = new double[] { 10, 4 };

        // Act
        var result = _subtractOperation.Execute(operands);

        // Assert
        result.Should().Be(6);
    }

    [Fact]
    public void Subtracting_multiple_numbers_calculates_final_difference()
    {
        // Arrange
        var operands = new double[] { 20, 5, 3, 2 };

        // Act
        var result = _subtractOperation.Execute(operands);

        // Assert
        result.Should().Be(10);
    }

    [Fact]
    public void Subtraction_with_single_operand_throws_exception()
    {
        // Arrange
        var operands = new double[] { 5 };

        // Act
        Action act = () => _subtractOperation.Execute(operands);

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("*requires at least two operands*");
    }

    [Fact]
    public void Operation_name_is_subtract_lowercase()
    {
        // Arrange, Act & Assert
        _subtractOperation.Name.Should().Be("subtract");
    }
}