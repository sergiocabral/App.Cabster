using System;
using Cabrones.Test;
using Cabster.Components;
using FluentAssertions;
using Xunit;

namespace Cabster.Business.Forms
{
    public class FormConfigurationTest
    {
        [Fact]
        public void deve_ser_possível_criar_uma_instância_sem_falhar()
        {
            // Arrange, Given
            // Act, When

            Action criar = () => new FormConfiguration()
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

            var sut = typeof(FormConfiguration);

            // Assert, Then

            sut.AssertMyOwnImplementations(typeof(FormLayout));
            sut.AssertMyOwnPublicPropertiesCount(0);
            sut.AssertMyOwnPublicMethodsCount(0);

            sut.IsClass.Should().BeTrue();
        }
    }
}