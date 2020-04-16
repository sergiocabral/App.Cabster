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

            var task = Task.Run(() => Program.Main());
            Thread.Sleep(esperarUmTempoAtéAAplicaçãoIniciar);
            Program.DependencyResolver.GetInstanceRequired<IMediator>().Send(new ApplicationFinalize());
            Thread.Sleep(esperarUmTempoAtéAAplicaçãoIniciar);

            // Assert, Then

            task.IsCompleted.Should().BeTrue();
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
            sut.AssertMyOwnPublicPropertiesCount(2);
            sut.AssertPublicPropertyPresence("static IDependencyResolver DependencyResolver { get; set; }");
            sut.AssertPublicPropertyPresence("static ContainerData Data { get; }");
            sut.AssertMyOwnPublicMethodsCount(1);
            sut.AssertPublicMethodPresence("static Task Main(String[])");

            sut.IsClass.Should().BeTrue();
        }
    }
}