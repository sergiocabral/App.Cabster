using System;
using System.ComponentModel;
using System.Windows.Forms;
using Cabrones.Test;
using Cabster.Properties;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Cabster.Components
{
    public class MyButtonTest
    {
        [Fact]
        public void deve_carregar_a_imagem_de_acordo_com_o_nome_do_botão()
        {
            // Arrange, Given

            using var form = new Form();

            var imagemOriginal = Resources.FormLayoutBackground;
            using var button = new MyButton(Substitute.For<IContainer>())
            {
                Name = "buttonClose",
                Image = imagemOriginal
            };

            form.Controls.Add(button);
            form.Show();

            // Act, When

            var imagem = button.Image;

            // Assert, Then

            imagem.Should().NotBeNull();
            imagem.Size.Should().Be(Resources.buttonCloseLeave.Size);
            imagem.Size.Should().NotBe(imagemOriginal.Size);
        }

        [Fact]
        public void deve_ser_possível_criar_uma_instância_sem_falhar()
        {
            // Arrange, Given
            // Act, When

            Action criar = () => new MyButton().Dispose();

            // Assert, Then

            criar.Should().NotThrow();
        }

        [Fact]
        public void não_deve_carregar_nenhuma_imagem_se_o_nome_do_botão_não_corresponder_a_nenhum_recurso()
        {
            // Arrange, Given

            using var form = new Form();

            var imagemOriginal = Resources.FormLayoutBackground;
            using var button = new MyButton(Substitute.For<IContainer>())
            {
                Name = this.Fixture<string>(),
                Image = imagemOriginal
            };

            form.Controls.Add(button);
            form.Show();

            // Act, When

            var imagem = button.Image;

            // Assert, Then

            imagem.Should().NotBeNull();
            imagem.Size.Should().Be(imagemOriginal.Size);

            button.Descartar();
        }

        [Fact]
        public void verificações_declarativa()
        {
            // Arrange, Given
            // Act, When

            var sut = typeof(MyButton);

            // Assert, Then

            sut.AssertMyOwnImplementations();
            sut.AssertMyOwnPublicPropertiesCount(0);
            sut.AssertMyOwnPublicMethodsCount(0);

            sut.IsClass.Should().BeTrue();
        }
    }
}