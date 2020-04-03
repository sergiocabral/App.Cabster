using Cabrones.Test;
using Cabster.Business.Entities;
using FluentAssertions;
using Xunit;

namespace Cabster.Extensions
{
    public class TextExtensionsTest
    {
        [Fact]
        public void método_ToJson_e_método_FromJson_devem_ser_complementares_e_funcionar_para_classes_complexas()
        {
            // Arrange, Given

            var instânciaOriginal = new ContainerData();

            // Act, When

            var json = instânciaOriginal.ToJson();
            var instância2 = json.FromJson<ContainerData>();
            var json2 = instância2.ToJson();

            // Assert, Then

            json.Should().Be(json2);
        }

        [Fact]
        public void verificações_declarativa()
        {
            // Arrange, Given
            // Act, When

            var sut = typeof(TextExtensions);

            // Assert, Then

            sut.AssertMyImplementations();
            sut.AssertMyOwnImplementations();
            sut.AssertMyOwnPublicPropertiesCount(0);
            sut.AssertMyOwnPublicMethodsCount(2);
            sut.AssertPublicMethodPresence("static String ToJson<TEntity>(TEntity)");
            sut.AssertPublicMethodPresence("static TEntity FromJson<TEntity>(String)");

            sut.IsClass.Should().BeTrue();
        }
    }
}