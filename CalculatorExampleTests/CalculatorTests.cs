using CalculatorExample;
using CalculatorExample.Operations;
using FluentAssertions;

namespace CalculatorExampleTests;

public class CalculatorTests
{
    private readonly Calculator _calculator = new();
    
    [Fact]
    public void Valid_operation_is_added_to_operations_collection()
    {
        // Arrange
        var operation = new AddOperation();

        // Act
        _calculator.RegisterOperation(operation);

        // Assert
        _calculator.GetOperationNames().Should().Contain("add");
    }

    [Fact]
    public void Null_operation_registration_throws_argument_null_exception()
    {
        // Act
        var act = () => _calculator.RegisterOperation(null!);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void New_calculator_has_empty_operations_list()
    {
        // Act
        var names = _calculator.GetOperationNames();

        // Assert
        names.Should().BeEmpty();
    }

    [Fact]
    public void Calculator_returns_all_registered_operation_names()
    {
        // Arrange
        _calculator.RegisterOperation(new AddOperation());
        _calculator.RegisterOperation(new SubtractOperation());
        _calculator.RegisterOperation(new MultiplyOperation());

        // Act
        var names = _calculator.GetOperationNames().ToArray();

        // Assert
        names.Should().HaveCount(3);
        names.Should().Contain(["add", "subtract", "multiply"]);
    }

    [Fact]
    public void Registered_operation_executes_and_returns_correct_result()
    {
        // Arrange
        _calculator.RegisterOperation(new AddOperation());

        // Act
        var result = _calculator.Execute("add", 5, 7);

        // Assert
        result.Should().Be(12);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("   ")]
    public void Empty_or_null_operation_name_throws_argument_exception(string operationName)
    {
        // Act
        Action act = () => _calculator.Execute(operationName, 5, 7);

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("*Operation name cannot be null or empty*");
    }

    [Fact]
    public void Unregistered_operation_execution_throws_invalid_operation_exception()
    {
        // Act
        Action act = () => _calculator.Execute("nonexistent", 5, 7);

        // Assert
        act.Should().Throw<InvalidOperationException>()
            .WithMessage("*Operation 'nonexistent' is not registered*");
    }

    [Fact]
    public void Operation_names_are_case_insensitive()
    {
        // Arrange
        _calculator.RegisterOperation(new AddOperation());

        // Act
        var result1 = _calculator.Execute("add", 5, 7);
        var result2 = _calculator.Execute("ADD", 5, 7);
        var result3 = _calculator.Execute("Add", 5, 7);

        // Assert
        result1.Should().Be(12);
        result2.Should().Be(12);
        result3.Should().Be(12);
    }
}