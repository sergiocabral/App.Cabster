using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using Cabrones.Test;
using FluentAssertions;
using Xunit;

namespace Cabster.Exceptions
{
    public class WrongOperationExceptionTest
    {
        [Fact]
        public void verificações_declarativas()
        {
            // Arrange, Given
            // Act, When

            var sut = typeof(WrongOperationException);

            // Assert, Then

            sut.AssertMyImplementations(
                typeof(DomainException),
                typeof(Exception),
                typeof(ISerializable), typeof(_Exception));
            sut.AssertMyOwnImplementations(
                typeof(DomainException));
            sut.AssertMyOwnPublicPropertiesCount(0);
            sut.AssertMyOwnPublicMethodsCount(0);

            sut.IsClass.Should().BeTrue();
        }

        [Fact]
        public void verificar_mensagem_padrão()
        {
            // Arrange, Given

            var mensagem = this.Fixture<string>();
            var innerException = new Exception();

            // Act, When

            var sut = new WrongOperationException(mensagem, innerException);

            // Assert, Then

            sut.Message.Should().Be(mensagem);
            sut.InnerException.Should().BeSameAs(innerException);
        }
    }
}