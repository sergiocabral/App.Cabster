using System;
using Cabrones.Test;
using FluentAssertions;
using Xunit;

namespace Cabster.Business.Entities
{
    public class TimeParametersTest
    {
        [Fact]
        public void ao_criar_uma_instancia_as_propriedades_devem_ter_sue_valor_padrão()
        {
            // Arrange, Given
            // Act, When

            TimeParameters entidade = null;
            Func<IEntity> criarEntidade = () => entidade = new TimeParameters();
            Action lerEEscreverNaPropriedades = () => entidade.LerEEscreverEmTodasAsPropriedades();

            // Assert, Then

            criarEntidade.Should().NotThrow();
            entidade.Should().NotBeNull();

            entidade.MinutesToWork.Should().Be(0);
            entidade.MinutesToBreak.Should().Be(0);
            entidade.RoundsUpToTheBreak.Should().Be(0);

            lerEEscreverNaPropriedades.Should().NotThrow();
        }

        [Fact]
        public void verificações_declarativa()
        {
            // Arrange, Given
            // Act, When

            var sut = typeof(TimeParameters);

            // Assert, Then

            sut.AssertMyImplementations(
                typeof(IEntity));
            sut.AssertMyOwnImplementations(
                typeof(IEntity));
            sut.AssertMyOwnPublicPropertiesCount(6);
            sut.AssertPublicPropertyPresence("Int32 MinutesToWork { get; set; }");
            sut.AssertPublicPropertyPresence("Int32 MinutesToBreak { get; set; }");
            sut.AssertPublicPropertyPresence("Int32 RoundsUpToTheBreak { get; set; }");
            sut.AssertMyOwnPublicMethodsCount(0);

            sut.IsClass.Should().BeTrue();
        }
    }
}