using System;
using Cabrones.Test;
using Cabster.Business.Enums;
using FluentAssertions;
using Xunit;

namespace Cabster.Business.Entities
{
    public class StateTest
    {
        [Fact]
        public void ao_criar_uma_instancia_as_propriedades_devem_ter_sue_valor_padrão()
        {
            // Arrange, Given
            // Act, When

            State entidade = null;
            Func<IEntity> criarEntidade = () => entidade = new State();
            Action lerEEscreverNaPropriedades = () => entidade.LerEEscreverEmTodasAsPropriedades();

            // Assert, Then

            criarEntidade.Should().NotThrow();
            entidade.Should().NotBeNull();

            entidade.Mode.Should().Be(default(StateMode));
            entidade.CurrentTime.Should().Be(default);

            lerEEscreverNaPropriedades.Should().NotThrow();
        }

        [Fact]
        public void verificações_declarativa()
        {
            // Arrange, Given
            // Act, When

            var sut = typeof(State);

            // Assert, Then

            sut.AssertMyImplementations(
                typeof(IEntity));
            sut.AssertMyOwnImplementations(
                typeof(IEntity));
            sut.AssertMyOwnPublicPropertiesCount(4);
            sut.AssertPublicPropertyPresence("StateMode Mode { get; set; }");
            sut.AssertPublicPropertyPresence("DateTimeOffset CurrentTime { get; set; }");
            sut.AssertMyOwnPublicMethodsCount(0);

            sut.IsClass.Should().BeTrue();
        }
    }
}