using CalculatorExample.Operations;
using FluentAssertions;

namespace CalculatorExampleTests;

public class AddOperationTests
{
    private readonly AddOperation _addOperation = new();
    
    [Fact]
    public void Adding_two_numbers_returns_correct_sum()
    {
        // Arrange
        var operands = new double[] { 5, 7 };

        // Act
        var result = _addOperation.Execute(operands);

        // Assert
        result.Should().Be(12);
    }

    [Fact]
    public void Adding_multiple_numbers_calculates_total_sum()
    {
        // Arrange
        var operands = new double[] { 1, 2, 3, 4, 5 };

        // Act
        var result = _addOperation.Execute(operands);

        // Assert
        result.Should().Be(15);
    }

    [Fact]
    public void Addition_with_single_operand_throws_an_exception()
    {
        // Arrange
        var operands = new double[] { 5 };

        // Act
        Action act = () => _addOperation.Execute(operands);

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("*requires at least two operands*");
    }

    [Fact]
    public void Operation_name_is_add_lowercase()
    {
        // Arrange
        var operation = new AddOperation();

        // Act & Assert
        operation.Name.Should().Be("add");
    }
}