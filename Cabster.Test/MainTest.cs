using System.Threading;
using System.Threading.Tasks;
using Cabrones.Test;
using Cabster.Business.Messenger.Request;
using FluentAssertions;
using MediatR;
using Xunit;

namespace Cabster
{
    public class MainTest
    {
        [Fact]
        public void iniciar_a_aplicação_não_pode_falhar()
        {
            // Arrange, Given

            const int esperarUmTempoAtéAAplicaçãoIniciar = 3000;

            // Act, When

            var thread = new Thread(() =>
            {
                Task.Run(() =>
                {
                    Thread.Sleep((int) (esperarUmTempoAtéAAplicaçãoIniciar * 0.9));
                    Program.DependencyResolver.GetInstanceRequired<IMediator>()
                        .Send(new FinalizeApplication());
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
            sut.AssertMyOwnPublicPropertiesCount(1);
            sut.AssertPublicPropertyPresence("static IDependencyResolver DependencyResolver { get; set; }");
            sut.AssertMyOwnPublicMethodsCount(1);
            sut.AssertPublicMethodPresence("static Void Main(String[])");

            sut.IsClass.Should().BeTrue();
        }
    }
}