using Cabrones.Test;
using Cabster.Components;
using FluentAssertions;
using Xunit;

namespace Cabster.Business.Forms
{
    public class FormGroupWorkTest
    {
        [Fact]
        public void verificações_declarativa()
        {
            // Arrange, Given
            // Act, When

            var sut = typeof(FormGroupWork);

            // Assert, Then

            sut.AssertMyOwnImplementations(
                typeof(FormLayout),
                typeof(IFormContainerData));
            sut.AssertMyOwnPublicPropertiesCount(0);
            sut.AssertMyOwnPublicMethodsCount(0);

            sut.IsClass.Should().BeTrue();
        }
    }
}