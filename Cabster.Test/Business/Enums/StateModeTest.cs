using Cabrones.Test;
using FluentAssertions;
using Xunit;

namespace Cabster.Business.Enums
{
    public class StateModeTest
    {
        [Fact]
        public void verificações_declarativa()
        {
            // Arrange, Given
            // Act, When

            var sut = typeof(StateMode);

            // Assert, Then

            sut.AssertEnumValuesCount(1);
            sut.AssertEnumValuesContains(
                "ConfigurationWindow");

            0.Should().Be((int) StateMode.ConfigurationWindow);

            sut.IsEnum.Should().BeTrue();
        }
    }
}