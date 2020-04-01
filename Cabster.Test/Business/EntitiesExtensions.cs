using Cabster.Business.Entities;
using FluentAssertions;
using Xunit;

namespace Cabster.Business
{
    public class EntitiesExtensionsTest
    {
        [Fact]
        public void método_ToJson_para_entidade_ContainerData_deve_retornar_um_json_válido()
        {
            // Arrange, Given

            var sut = new State();

            // Act, When

            var json = sut.ToJson();

            // Assert, Then

            json.Should().NotBeNull();
        }
    }
}