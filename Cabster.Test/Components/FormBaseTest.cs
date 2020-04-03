using System;
using System.Windows.Forms;
using Cabrones.Test;
using Cabster.Properties;
using FluentAssertions;
using Xunit;

namespace Cabster.Components
{
    public class FormBaseTest
    {
        [Fact]
        public void deve_ser_possível_criar_uma_instância_sem_falhar()
        {
            // Arrange, Given
            // Act, When

            Action criar = () => new FormBase()
                .AbrirFecharDescartar()
                .Descartar();

            // Assert, Then

            criar.Should().NotThrow();
        }

        [Fact]
        public void o_título_da_janela_deve_ser_o_nome_do_aplicativo()
        {
            // Arrange, Given

            using var form = new FormBase();
            form.Show();

            // Act, When

            var título = form.Text;

            // Assert, Then

            título.Should().Be(Resources.Name_System);
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