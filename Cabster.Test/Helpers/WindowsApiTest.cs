using System;
using Cabrones.Test;
using FluentAssertions;
using Xunit;

namespace Cabster.Helpers
{
    public class WindowsApiTest
    {
        [Fact]
        public void a_correção_do_cursor_do_mouse_não_deve_falhar()
        {
            // Arrange, Given
            // Act, When

            Action corrigir = WindowsApi.FixCursorHand;

            // Assert, Then

            corrigir.Should().NotThrow();
        }

        [Fact]
        public void verificações_declarativa()
        {
            // Arrange, Given
            // Act, When

            var sut = typeof(WindowsApi);

            // Assert, Then

            sut.AssertMyImplementations();
            sut.AssertMyOwnImplementations();
            sut.AssertMyOwnPublicPropertiesCount(0);
            sut.AssertMyOwnPublicMethodsCount(1);
            sut.AssertPublicMethodPresence("static Void FixCursorHand()");

            sut.IsClass.Should().BeTrue();
        }
    }
}