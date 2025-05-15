using CalculatorExample.Operations;
using FluentAssertions;

namespace CalculatorExampleTests
{
    public class DivideOperationTests
    {
        private readonly DivideOperation _divideOperation = new();

        [Fact]
        public void Operation_name_should_be_divide()
        {
            // Act & Assert
            _divideOperation.Name.Should().Be("divide");
        }

        [Theory]
        [InlineData(new[] { 10.0, 2.0 }, 5.0)]
        [InlineData(new[] { 20.0, 5.0 }, 4.0)]
        [InlineData(new[] { 100.0, 4.0 }, 25.0)]
        public void Dividing_two_numbers_should_return_correct_result(double[] operands, double expected)
        {
            // Act
            var result = _divideOperation.Execute(operands);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(new[] { 24.0, 2.0, 3.0 }, 4.0)]
        [InlineData(new[] { 100.0, 2.0, 5.0 }, 10.0)]
        [InlineData(new[] { 48.0, 2.0, 3.0, 2.0 }, 4.0)]
        public void Dividing_multiple_numbers_should_work_sequentially(double[] operands, double expected)
        {
            // Act
            var result = _divideOperation.Execute(operands);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Passing_null_operands_should_throw_argument_null_exception()
        {
            // Act
            var act = () => _divideOperation.Execute(null!);

            // Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(new double[0])]
        [InlineData(new[] { 10.0 })]
        public void Division_should_require_at_least_two_operands(double[] operands)
        {
            // Act
            var act = () => _divideOperation.Execute(operands);

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage("*requires at least two operands*");
        }

        [Theory]
        [InlineData(new[] { 10.0, 0.0 })]
        [InlineData(new[] { 20.0, 5.0, 0.0 })]
        public void Dividing_by_zero_should_throw_divide_by_zero_exception(double[] operands)
        {
            // Act
            var act = () => _divideOperation.Execute(operands);

            // Assert
            act.Should().Throw<DivideByZeroException>()
                .WithMessage("*Cannot divide by zero*");
        }

        [Theory]
        [InlineData(new[] { 10.0, 1e-15 })]
        [InlineData(new[] { 5.0, 1e-16 })]
        public void Dividing_by_very_small_numbers_should_be_treated_as_division_by_zero(double[] operands)
        {
            // Act
            var act = () => _divideOperation.Execute(operands);

            // Assert
            act.Should().Throw<DivideByZeroException>()
                .WithMessage("*very small value*");
        }

        [Fact]
        public void Division_by_extremely_small_numbers_should_throw_divide_by_zero_exception()
        {
            // Arrange
            var operands = new[] { 1.0, double.Epsilon };

            // Act
            var act = () => _divideOperation.Execute(operands);

            // Act & Assert
            act.Should().Throw<DivideByZeroException>()
                .WithMessage("*very small value*");
        }

        [Theory]
        [InlineData(new[] { 10.5, 2.0 }, 5.25)]
        [InlineData(new[] { 7.5, 1.5 }, 5.0)]
        [InlineData(new[] { 0.3, 0.1 }, 3.0)]
        public void Dividing_decimal_numbers_should_return_precise_results(double[] operands, double expected)
        {
            // Act
            var result = _divideOperation.Execute(operands);

            // Assert
            result.Should().BeApproximately(expected, 1e-10);
        }

        [Theory]
        [InlineData(new[] { -10.0, 2.0 }, -5.0)]
        [InlineData(new[] { 10.0, -2.0 }, -5.0)]
        [InlineData(new[] { -10.0, -2.0 }, 5.0)]
        [InlineData(new[] { -20.0, 2.0, -5.0 }, 2.0)]
        public void Dividing_negative_numbers_should_follow_mathematical_sign_rules(double[] operands, double expected)
        {
            // Act
            var result = _divideOperation.Execute(operands);

            // Assert
            result.Should().Be(expected);
        }
    }
}