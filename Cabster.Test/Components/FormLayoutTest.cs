using System;
using Cabrones.Test;
using FluentAssertions;
using Xunit;

namespace Cabster.Components
{
    public class FormLayoutTest
    {
        [Fact]
        public void deve_ser_possível_criar_uma_instância_sem_falhar()
        {
            // Arrange, Given
            // Act, When

            Action criar = () => new FormLayout()
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

            var sut = typeof(FormLayout);

            // Assert, Then

            sut.AssertMyOwnImplementations(typeof(FormBase));
            sut.AssertMyOwnPublicPropertiesCount(2);
            sut.AssertPublicPropertyPresence("Boolean ShowLogo { get; set; }");
            sut.AssertMyOwnPublicMethodsCount(4);
            sut.AssertPublicMethodPresence("Void add_ButtonMinimizeClick(Action)");
            sut.AssertPublicMethodPresence("Void remove_ButtonMinimizeClick(Action)");
            sut.AssertPublicMethodPresence("Void add_ButtonCloseClick(Action)");
            sut.AssertPublicMethodPresence("Void remove_ButtonCloseClick(Action)");

            sut.IsClass.Should().BeTrue();
        }
    }
}