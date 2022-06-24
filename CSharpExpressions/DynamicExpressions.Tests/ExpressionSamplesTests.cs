using FluentAssertions;

namespace DynamicExpressions.Tests
{
    public class ExpressionSamplesTests
    {
        [Fact]
        public void Adding()
        {
            ExpressionSamples.AddTwoInts(1, 3).Should().Be(4);
        }

        [Fact]
        public void DynamicFilter()
        {
            var result = ExpressionSamples.DynamicFilterByCategoryNameAndAmount("entertainment", 2);

            result.Single().Amount.Should().Be(34);
        }
    }
}