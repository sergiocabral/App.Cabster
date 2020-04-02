using System;
using System.Windows.Forms;
using Cabrones.Test;
using FluentAssertions;
using Xunit;

namespace Cabster.Extensions
{
    public class FormInvisibleExtensionsTest
    {
        [Fact]
        public void método_MakeInvisible_deve_tornar_uma_janela_invisível()
        {
            // Arrange, Given

            var form = new Form();

            // Act, When

            Action invisível = () => form.MakeInvisible();
            Action visível = () => form.MakeInvisible(false);

            // Assert, Then

            invisível.Should().NotThrow();
            form.ShowInTaskbar.Should().BeFalse();

            visível.Should().NotThrow();
            form.ShowInTaskbar.Should().BeTrue();
        }

        [Fact]
        public void verificações_declarativa()
        {
            // Arrange, Given
            // Act, When

            var sut = typeof(FormInvisibleExtensions);

            // Assert, Then

            sut.AssertMyImplementations();
            sut.AssertMyOwnImplementations();
            sut.AssertMyOwnPublicPropertiesCount(0);
            sut.AssertMyOwnPublicMethodsCount(1);
            sut.AssertPublicMethodPresence("static Void MakeInvisible(Form, Boolean = 'True')");

            sut.IsClass.Should().BeTrue();
        }
    }
}