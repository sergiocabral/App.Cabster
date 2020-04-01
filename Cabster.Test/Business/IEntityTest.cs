using Cabrones.Test;
using FluentAssertions;
using Xunit;

namespace Cabster.Business
{
    public class IEntityTest
    {
        [Fact]
        public void verificações_declarativa()
        {
            // Arrange, Given
            // Act, When

            var sut = typeof(IEntity);

            // Assert, Then

            sut.AssertMyImplementations();
            sut.AssertMyOwnImplementations();
            sut.AssertMyOwnPublicPropertiesCount(0);
            sut.AssertMyOwnPublicMethodsCount(0);

            sut.IsInterface.Should().BeTrue();
        }
    }
}