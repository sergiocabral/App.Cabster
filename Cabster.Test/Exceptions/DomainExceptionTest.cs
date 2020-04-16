using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using Cabrones.Test;
using FluentAssertions;
using Xunit;

namespace Cabster.Exceptions
{
    public class DomainExceptionTest
    {
        [Fact]
        public void deve_ser_possível_especificar_mensagem_e_exceção_interna()
        {
            // Arrange, Given

            var mensagem = this.Fixture<string>();
            var exception = this.Fixture<Exception>();

            // Act, When

            var sut = new DomainException(mensagem, exception);

            // Assert, Then

            sut.Message.Should().Be(mensagem);
            sut.InnerException.Should().BeSameAs(exception);
        }

        [Fact]
        public void se_não_informar_mensagem_deve_usar_a_mensagem_padrão()
        {
            // Arrange, Given

            var mensagemEsperada = $"{Assembly.GetAssembly(typeof(Program)).FullName} generic exception.";

            // Act, When

            var sut = new DomainException();

            // Assert, Then

            sut.Message.Should().Be(mensagemEsperada);
        }

        [Fact]
        public void verificações_declarativas()
        {
            // Arrange, Given
            // Act, When

            var sut = typeof(DomainException);

            // Assert, Then

            sut.AssertMyImplementations(typeof(Exception), typeof(ISerializable), typeof(_Exception));
            sut.AssertMyOwnImplementations();
            sut.AssertMyOwnPublicPropertiesCount(0);
            sut.AssertMyOwnPublicMethodsCount(0);

            sut.IsClass.Should().BeTrue();
        }
    }
}