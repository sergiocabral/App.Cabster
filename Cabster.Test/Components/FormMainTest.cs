using System;
using Cabrones.Test;
using FluentAssertions;
using Xunit;

namespace Cabster.Components
{
    public class FormMainTest
    {
        [Fact]
        public void deve_ser_possível_criar_uma_instância_sem_falhar()
        {
            // Arrange, Given
            // Act, When

            Action criar = () => new FormMain()
                .AbrirFecharDescartar()
                .Descartar();

            // Assert, Then

            criar.Should().NotThrow();
        }

        [Fact]
        public void verificações_declarativa()
        {
            // Arrange, Given
            // Act, When

            var sut = typeof(FormMain);

            // Assert, Then

            sut.AssertMyOwnImplementations(typeof(FormBase));
            sut.AssertMyOwnPublicPropertiesCount(0);
            sut.AssertMyOwnPublicMethodsCount(0);

            sut.IsClass.Should().BeTrue();
        }
    }
}