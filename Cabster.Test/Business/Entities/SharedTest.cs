using System;
using Cabrones.Test;
using FluentAssertions;
using Xunit;

namespace Cabster.Business.Entities
{
    public class SharedTest
    {
        [Fact]
        public void ao_criar_uma_instancia_as_propriedades_devem_ter_sue_valor_padrão()
        {
            // Arrange, Given
            // Act, When

            Shared entidade = null;
            Func<IEntity> criarEntidade = () => entidade = new Shared();
            Action lerEEscreverNaPropriedades = () => entidade.LerEEscreverEmTodasAsPropriedades();

            // Assert, Then

            criarEntidade.Should().NotThrow();
            entidade.Should().NotBeNull();

            entidade.TimeParameters.Should().NotBeNull();
            entidade.Participants.Should().NotBeNull();
            entidade.State.Should().NotBeNull();

            lerEEscreverNaPropriedades.Should().NotThrow();
        }

        [Fact]
        public void verificações_declarativa()
        {
            // Arrange, Given
            // Act, When

            var sut = typeof(Shared);

            // Assert, Then

            sut.AssertMyImplementations(
                typeof(IEntity));
            sut.AssertMyOwnImplementations(
                typeof(IEntity));
            sut.AssertMyOwnPublicPropertiesCount(6);
            sut.AssertPublicPropertyPresence("TimeParameters TimeParameters { get; set; }");
            sut.AssertPublicPropertyPresence("IList<Participant> Participants { get; set; }");
            sut.AssertPublicPropertyPresence("State State { get; set; }");
            sut.AssertMyOwnPublicMethodsCount(0);

            sut.IsClass.Should().BeTrue();
        }
    }
}