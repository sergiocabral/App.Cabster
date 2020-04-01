using System;
using Cabrones.Test;
using FluentAssertions;
using Xunit;

namespace Cabster.Business.Entities
{
    public class ParticipantTest
    {
        [Fact]
        public void ao_criar_uma_instancia_as_propriedades_devem_ter_sue_valor_padrão()
        {
            // Arrange, Given
            // Act, When

            Participant entidade = null;
            Func<IEntity> criarEntidade = () => entidade = new Participant();
            Action lerEEscreverNaPropriedades = () => entidade.LerEEscreverEmTodasAsPropriedades();

            // Assert, Then

            criarEntidade.Should().NotThrow();
            entidade.Should().NotBeNull();

            entidade.Name.Should().BeEmpty();
            entidade.Active.Should().BeFalse();

            lerEEscreverNaPropriedades.Should().NotThrow();
        }

        [Fact]
        public void verificações_declarativa()
        {
            // Arrange, Given
            // Act, When

            var sut = typeof(Participant);

            // Assert, Then

            sut.AssertMyImplementations(
                typeof(IEntity));
            sut.AssertMyOwnImplementations(
                typeof(IEntity));
            sut.AssertMyOwnPublicPropertiesCount(4);
            sut.AssertPublicPropertyPresence("String Name { get; set; }");
            sut.AssertPublicPropertyPresence("Boolean Active { get; set; }");
            sut.AssertMyOwnPublicMethodsCount(0);

            sut.IsClass.Should().BeTrue();
        }
    }
}