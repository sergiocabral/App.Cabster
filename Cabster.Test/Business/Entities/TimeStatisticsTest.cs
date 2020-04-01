using System;
using Cabrones.Test;
using FluentAssertions;
using Xunit;

namespace Cabster.Business.Entities
{
    public class TimeStatisticsTest : IEntity
    {
        [Fact]
        public void ao_criar_uma_instancia_as_propriedades_devem_ter_sue_valor_padrão()
        {
            // Arrange, Given
            // Act, When

            TimeStatistics entidade = null;
            Func<IEntity> criarEntidade = () => entidade = new TimeStatistics();
            Action lerEEscreverNaPropriedades = () => entidade.LerEEscreverEmTodasAsPropriedades();

            // Assert, Then

            criarEntidade.Should().NotThrow();
            entidade.Should().NotBeNull();

            entidade.Start.Should().Be(default);
            entidade.SecondsOfWork.Should().Be(default);
            entidade.SecondsOfBreak.Should().Be(default);
            entidade.SecondsOfPause.Should().Be(default);
            entidade.CountRoundsOfWork.Should().Be(default);
            entidade.CountBreaks.Should().Be(default);

            lerEEscreverNaPropriedades.Should().NotThrow();
        }

        [Fact]
        public void verificações_declarativa()
        {
            // Arrange, Given
            // Act, When

            var sut = typeof(TimeStatistics);

            // Assert, Then

            sut.AssertMyImplementations(
                typeof(IEntity));
            sut.AssertMyOwnImplementations(
                typeof(IEntity));
            sut.AssertMyOwnPublicPropertiesCount(12);
            sut.AssertPublicPropertyPresence("DateTimeOffset Start { get; set; }");
            sut.AssertPublicPropertyPresence("Int32 SecondsOfWork { get; set; }");
            sut.AssertPublicPropertyPresence("Int32 SecondsOfBreak { get; set; }");
            sut.AssertPublicPropertyPresence("Int32 SecondsOfPause { get; set; }");
            sut.AssertPublicPropertyPresence("Int32 CountRoundsOfWork { get; set; }");
            sut.AssertPublicPropertyPresence("Int32 CountBreaks { get; set; }");
            sut.AssertMyOwnPublicMethodsCount(0);

            sut.IsClass.Should().BeTrue();
        }
    }
}