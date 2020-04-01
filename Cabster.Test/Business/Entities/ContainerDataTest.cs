using System;
using Cabrones.Test;
using FluentAssertions;
using Xunit;

namespace Cabster.Business.Entities
{
    public class ContainerDataTest
    {
        [Fact]
        public void ao_criar_uma_instancia_as_propriedades_devem_ter_sue_valor_padrão()
        {
            // Arrange, Given
            // Act, When

            ContainerData entidade = null;
            Func<IEntity> criarEntidade = () => entidade = new ContainerData();
            Action lerEEscreverNaPropriedades = () => entidade.LerEEscreverEmTodasAsPropriedades();

            // Assert, Then

            criarEntidade.Should().NotThrow();
            entidade.Should().NotBeNull();

            entidade.Private.Should().NotBeNull();
            entidade.Shared.Should().NotBeNull();
            entidade.Temporary.Should().NotBeNull();

            lerEEscreverNaPropriedades.Should().NotThrow();
        }

        [Fact]
        public void verificações_declarativa()
        {
            // Arrange, Given
            // Act, When

            var sut = typeof(ContainerData);

            // Assert, Then

            sut.AssertMyImplementations(
                typeof(IEntity));
            sut.AssertMyOwnImplementations(
                typeof(IEntity));
            sut.AssertMyOwnPublicPropertiesCount(6);
            sut.AssertPublicPropertyPresence("Private Private { get; set; }");
            sut.AssertPublicPropertyPresence("Shared Shared { get; set; }");
            sut.AssertPublicPropertyPresence("Temporary Temporary { get; set; }");
            sut.AssertMyOwnPublicMethodsCount(0);

            sut.IsClass.Should().BeTrue();
        }
    }
}