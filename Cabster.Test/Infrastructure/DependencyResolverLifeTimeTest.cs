using Cabrones.Test;
using FluentAssertions;
using Xunit;

namespace Cabster.Infrastructure
{
    public class DependencyResolverLifeTimeTest
    {
        [Fact]
        public void verificações_declarativas()
        {
            // Arrange, Given
            // Act, When

            var sut = typeof(DependencyResolverLifeTime);

            // Assert, Then

            sut.AssertEnumValuesCount(3);
            sut.AssertEnumValuesContains(
                "PerContainer",
                "PerScope",
                "PerRequest");
            sut.IsEnum.Should().BeTrue();

            1.Should().Be((int) DependencyResolverLifeTime.PerContainer);
            2.Should().Be((int) DependencyResolverLifeTime.PerScope);
            3.Should().Be((int) DependencyResolverLifeTime.PerRequest);
        }
    }
}