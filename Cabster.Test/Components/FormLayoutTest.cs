using Cabrones.Test;
using FluentAssertions;
using Xunit;

namespace Cabster.Components
{
    public class FormLayoutTest
    {
        [Fact]
        public void verificações_declarativa()
        {
            // Arrange, Given
            // Act, When

            var sut = typeof(FormLayout);

            // Assert, Then

            sut.AssertMyOwnImplementations(
                typeof(FormBase),
                typeof(IFormLayout));
            sut.AssertMyOwnPublicPropertiesCount(0);
            sut.AssertMyOwnPublicMethodsCount(0);

            sut.IsClass.Should().BeTrue();
        }
    }
}