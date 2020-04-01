using System;
using System.Windows.Forms;
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
    }
}