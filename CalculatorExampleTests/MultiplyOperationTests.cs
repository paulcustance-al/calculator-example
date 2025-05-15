using CalculatorExample.Operations;
using FluentAssertions;

namespace CalculatorExampleTests;

public class MultiplyOperationTests
{
    private readonly MultiplyOperation _multiplyOperation = new();
    
    [Fact]
    public void Multiplying_two_numbers_returns_product_correctly()
    {
        // Arrange
        var operands = new double[] { 4, 5 };

        // Act
        var result = _multiplyOperation.Execute(operands);

        // Assert
        result.Should().Be(20);
    }

    [Fact]
    public void Multiplying_multiple_numbers_calculates_total_product()
    {
        // Arrange
        var operands = new double[] { 2, 3, 4 };

        // Act
        var result = _multiplyOperation.Execute(operands);

        // Assert
        result.Should().Be(24);
    }

    [Fact]
    public void Multiplication_with_single_operand_throws_exception()
    {
        // Arrange
        var operands = new double[] { 5 };

        // Act
        Action act = () => _multiplyOperation.Execute(operands);

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("*requires at least two operands*");
    }

    [Fact]
    public void Operation_name_is_multiply_lowercase()
    {
        // Arrange, Act & Assert
        _multiplyOperation.Name.Should().Be("multiply");
    }
}