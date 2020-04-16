using System;
using System.Windows.Forms;
using Cabrones.Test;
using Cabster.Extensions;
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

            Action corrigir = () => Cursors.Hand.FixesForTheOperatingSystemCursor();

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
            sut.AssertMyOwnPublicMethodsCount(7);
            sut.AssertPublicMethodPresence("static Void FixCursorHand()");
            sut.AssertPublicMethodPresence("static Void EnableRepaint(HandleRef, Boolean)");
            sut.AssertPublicMethodPresence("static String GetWindowText(IntPtr)");
            sut.AssertPublicMethodPresence("static Int32 GetWindowZOrder(IntPtr)");
            sut.AssertPublicMethodPresence("static Boolean RegisterHotKey(IntPtr, Int32, UInt32, UInt32)");
            sut.AssertPublicMethodPresence("static Boolean UnregisterHotKey(IntPtr, Int32)");
            sut.AssertPublicMethodPresence("static Boolean ShowWindow(IntPtr, Boolean)");

            sut.IsClass.Should().BeTrue();
        }
    }
}