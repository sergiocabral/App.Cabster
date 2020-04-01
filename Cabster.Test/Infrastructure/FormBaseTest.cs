using System;
using Cabrones.Test;
using Cabster.Properties;
using FluentAssertions;
using Xunit;

namespace Cabster.Infrastructure
{
    public class FormBaseTest
    {
        [Fact]
        public void deve_ser_possível_criar_uma_instância_sem_falhar()
        {
            // Arrange, Given
            // Act, When

            Action criar = () => new FormBase().CriarAbrirFecharDescartar();

            // Assert, Then

            criar.Should().NotThrow();
        }

        [Fact]
        public void o_título_da_janela_deve_ser_o_nome_do_aplicativo()
        {
            // Arrange, Given

            var form = new FormBase();

            // Act, When

            var título = form.Text;

            // Assert, Then

            título.Should().Be(Resources.System_Name);
        }

        [Fact]
        public void verificações_declarativa()
        {
            // Arrange, Given
            // Act, When

            var sut = typeof(FormBase);

            // Assert, Then

            sut.AssertMyOwnImplementations();
            sut.AssertMyOwnPublicPropertiesCount(0);
            sut.AssertMyOwnPublicMethodsCount(0);

            sut.IsClass.Should().BeTrue();
        }
    }
}