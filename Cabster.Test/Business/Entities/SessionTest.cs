using System;
using Cabrones.Test;
using FluentAssertions;
using Xunit;

namespace Cabster.Business.Entities
{
    public class SessionTest
    {
        [Fact]
        public void ao_criar_uma_instancia_as_propriedades_devem_ter_sue_valor_padrão()
        {
            // Arrange, Given
            // Act, When

            Session entidade = null;
            Func<IEntity> criarEntidade = () => entidade = new Session();
            Action lerEEscreverNaPropriedades = () => entidade.LerEEscreverEmTodasAsPropriedades();

            // Assert, Then

            criarEntidade.Should().NotThrow();
            entidade.Should().NotBeNull();

            entidade.Guid.Should().BeEmpty();
            entidade.Name.Should().BeEmpty();
            entidade.Created.Should().Be(default);
            entidade.Updated.Should().Be(default);
            entidade.TimeStatistics.Should().NotBeNull();

            lerEEscreverNaPropriedades.Should().NotThrow();
        }

        [Fact]
        public void verificações_declarativa()
        {
            // Arrange, Given
            // Act, When

            var sut = typeof(Session);

            // Assert, Then

            sut.AssertMyImplementations(
                typeof(IEntity));
            sut.AssertMyOwnImplementations(
                typeof(IEntity));
            sut.AssertMyOwnPublicPropertiesCount(10);
            sut.AssertPublicPropertyPresence("Guid Guid { get; set; }");
            sut.AssertPublicPropertyPresence("String Name { get; set; }");
            sut.AssertPublicPropertyPresence("DateTimeOffset Created { get; set; }");
            sut.AssertPublicPropertyPresence("DateTimeOffset Updated { get; set; }");
            sut.AssertPublicPropertyPresence("TimeStatistics TimeStatistics { get; set; }");
            sut.AssertMyOwnPublicMethodsCount(0);

            sut.IsClass.Should().BeTrue();
        }
    }
}