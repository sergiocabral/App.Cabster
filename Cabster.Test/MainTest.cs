using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cabrones.Test;
using FluentAssertions;
using Xunit;

namespace Cabster
{
    public class MainTest
    {
        [Fact]
        public void iniciar_a_aplicação_não_pode_falhar()
        {
            // Arrange, Given

            const int esperarUmTempoAtéAAplicaçãoIniciar = 5000;

            // Act, When

            Exception falha = null;
            var thread = new Thread(() =>
            {
                Task.Run(() =>
                {
                    Thread.Sleep(esperarUmTempoAtéAAplicaçãoIniciar - 1000);
                    Application.OpenForms[0].Close();
                });
                Program.Main();
            });
            thread.Start();
            Thread.Sleep(esperarUmTempoAtéAAplicaçãoIniciar);

            // Assert, Then

            thread.IsAlive.Should().BeFalse();
        }

        [Fact]
        public void verificações_declarativa()
        {
            // Arrange, Given
            // Act, When

            var sut = typeof(Program);

            // Assert, Then

            sut.AssertMyImplementations();
            sut.AssertMyOwnImplementations();
            sut.AssertMyOwnPublicPropertiesCount(0);
            sut.AssertMyOwnPublicMethodsCount(1);
            sut.AssertPublicMethodPresence("static Void Main()");

            sut.IsClass.Should().BeTrue();
        }
    }
}