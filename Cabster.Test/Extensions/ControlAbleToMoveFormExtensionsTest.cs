using System;
using System.Windows.Forms;
using Cabrones.Test;
using FluentAssertions;
using Xunit;

// ReSharper disable AccessToDisposedClosure

namespace Cabster.Extensions
{
    public class ControlAbleToMoveFormExtensionsTest
    {
        [Fact]
        public void método_MakeAbleToMoveForm_deve_poder_ativar_e_desativar_sem_falhar()
        {
            // Arrange, Given

            using var form = new Form();
            using var button = new Button();
            form.Controls.Add(button);

            // Act, When

            Action ativar = () => button.MakeAbleToMoveForm();
            Action desativar = () => button.MakeAbleToMoveForm(false);

            // Assert, Then

            ativar.Should().NotThrow();
            ativar.Should().NotThrow();
            desativar.Should().NotThrow();
            desativar.Should().NotThrow();
        }

        [Fact]
        public void verificações_declarativa()
        {
            // Arrange, Given
            // Act, When

            var sut = typeof(ControlAbleToMoveFormExtensions);

            // Assert, Then

            sut.AssertMyImplementations();
            sut.AssertMyOwnImplementations();
            sut.AssertMyOwnPublicPropertiesCount(0);
            sut.AssertMyOwnPublicMethodsCount(1);
            sut.AssertPublicMethodPresence("static Void MakeAbleToMoveForm(Control, Boolean = 'True')");

            sut.IsClass.Should().BeTrue();
        }
    }
}