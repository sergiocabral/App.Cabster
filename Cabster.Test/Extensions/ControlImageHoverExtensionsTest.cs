using System;
using System.Windows.Forms;
using Cabrones.Test;
using Cabster.Properties;
using FluentAssertions;
using Xunit;

namespace Cabster.Extensions
{
    public class ControlImageHoverExtensionsTest
    {
        [Fact]
        public void método_MakeImageHover_deve_ativar_comportamento_MouseHover_para_troca_de_imagem()
        {
            // Arrange, Given

            var button = new Button();
            const string propriedade = "BackgroundImage";
            var imagemLeave = Resources.buttonCloseLeave;
            var imagemEnter = Resources.buttonCloseLeave;

            // Act, When

            Action aplicar = () => button.MakeImageHover(propriedade, imagemLeave, imagemEnter);

            // Assert, Then

            button.BackgroundImage.Should().BeNull();
            aplicar.Should().NotThrow();
            button.BackgroundImage.Should().BeSameAs(imagemLeave);
        }

        [Fact]
        public void método_MakeImageHover_deve_poder_remover_o_comportamento()
        {
            // Arrange, Given

            var button = new Button {BackgroundImage = Resources.FormBackground};
            var imagemOriginal = button.BackgroundImage;
            const string propriedade = "BackgroundImage";
            var imagem1 = Resources.buttonCloseLeave;

            // Act, When

            button.MakeImageHover(propriedade, imagem1);
            var imagemConsultada1 = button.BackgroundImage;

            button.MakeImageHover(propriedade);
            var imagemConsultada2 = button.BackgroundImage;

            // Assert, Then

            imagemConsultada1.Should().BeSameAs(imagem1);
            imagemConsultada2.Should().BeSameAs(imagemOriginal);
        }

        [Fact]
        public void método_MakeImageHover_deve_poder_trocar_a_imagem()
        {
            // Arrange, Given

            var button = new Button();
            const string propriedade = "BackgroundImage";
            var imagem1 = Resources.buttonCloseLeave;
            var imagem2 = Resources.buttonCloseLeave;

            // Act, When

            button.MakeImageHover(propriedade, imagem1, imagem2);
            var imagemConsultada1 = button.BackgroundImage;

            button.MakeImageHover(propriedade, imagem2, imagem1);
            var imagemConsultada2 = button.BackgroundImage;

            // Assert, Then

            imagemConsultada1.Should().BeSameAs(imagem1);
            imagemConsultada2.Should().BeSameAs(imagem2);
        }

        [Fact]
        public void verificações_declarativa()
        {
            // Arrange, Given
            // Act, When

            var sut = typeof(ControlImageHoverExtensions);

            // Assert, Then

            sut.AssertMyImplementations();
            sut.AssertMyOwnImplementations();
            sut.AssertMyOwnPublicPropertiesCount(0);
            sut.AssertMyOwnPublicMethodsCount(1);
            sut.AssertPublicMethodPresence(
                "static Void MakeImageHover(Control, String, Image = null, Image = null)");

            sut.IsClass.Should().BeTrue();
        }
    }
}