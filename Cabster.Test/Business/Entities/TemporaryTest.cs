using System;
using Cabrones.Test;
using FluentAssertions;
using Xunit;

namespace Cabster.Business.Entities
{
    public class TemporaryTest
    {
        [Fact]
        public void ao_criar_uma_instancia_as_propriedades_devem_ter_sue_valor_padrão()
        {
            // Arrange, Given
            // Act, When

            Temporary entidade = null;
            Func<IEntity> criarEntidade = () => entidade = new Temporary();
            Action lerEEscreverNaPropriedades = () => entidade.LerEEscreverEmTodasAsPropriedades();

            // Assert, Then

            criarEntidade.Should().NotThrow();
            entidade.Should().NotBeNull();

            entidade.CurrentSessions.Should().NotBeNull();

            lerEEscreverNaPropriedades.Should().NotThrow();
        }

        [Fact]
        public void verificações_declarativa()
        {
            // Arrange, Given
            // Act, When

            var sut = typeof(Temporary);

            // Assert, Then

            sut.AssertMyImplementations(
                typeof(IEntity));
            sut.AssertMyOwnImplementations(
                typeof(IEntity));
            sut.AssertMyOwnPublicPropertiesCount(2);
            sut.AssertPublicPropertyPresence("IList<Session> CurrentSessions { get; set; }");
            sut.AssertMyOwnPublicMethodsCount(0);

            sut.IsClass.Should().BeTrue();
        }
    }
}