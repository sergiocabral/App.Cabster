using System;
using System.Windows.Forms;
using Cabrones.Test;
using FluentAssertions;
using Xunit;

// ReSharper disable AccessToDisposedClosure

namespace Cabster.Extensions
{
    public class ControlAbleToOperateFormExtensionsTest
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
        public void método_MakeAbleToResizeForm_deve_poder_ativar_e_desativar_sem_falhar()
        {
            // Arrange, Given

            using var form = new Form();
            using var button = new Button();
            form.Controls.Add(button);

            // Act, When

            Action ativar = () => button.MakeAbleToResizeForm();
            Action desativar = () => button.MakeAbleToResizeForm(false);

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

            var sut = typeof(ControlAbleToOperateFormExtensions);

            // Assert, Then

            sut.AssertMyImplementations();
            sut.AssertMyOwnImplementations();
            sut.AssertMyOwnPublicPropertiesCount(0);
            sut.AssertMyOwnPublicMethodsCount(2);
            sut.AssertPublicMethodPresence("static Void MakeAbleToMoveForm(Control, Boolean = 'True')");
            sut.AssertPublicMethodPresence("static Void MakeAbleToResizeForm(Control, Boolean = 'True')");

            sut.IsClass.Should().BeTrue();
        }
    }
}