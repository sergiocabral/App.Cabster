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
        public void método_ToJson_para_entidade_ContainerData_deve_retornar_um_json_válido()
        {
            // Arrange, Given

            var sut = new Form();

            // Act, When

            Action invisível = () => sut.MakeInvisible();
            Action visível = () => sut.MakeInvisible(false);

            // Assert, Then

            invisível.Should().NotThrow();
            sut.ShowInTaskbar.Should().BeFalse();

            visível.Should().NotThrow();
            sut.ShowInTaskbar.Should().BeTrue();
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