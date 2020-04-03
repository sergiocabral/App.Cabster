using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using Cabrones.Test;
using Cabrones.Utils.Text;
using Cabster.Properties;
using FluentAssertions;
using Xunit;

namespace Cabster.Exceptions
{
    public class WrongArgumentExceptionTest
    {
        [Fact]
        public void verificações_declarativas()
        {
            // Arrange, Given
            // Act, When

            var sut = typeof(WrongArgumentException);

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

            var nomeDaClasse = this.Fixture<string>();
            var nomeDoMétodo = this.Fixture<string>();
            var nomeDoArgumento = this.Fixture<string>();

            // Act, When

            var sut = new WrongArgumentException(
                nomeDaClasse,
                nomeDoMétodo,
                nomeDoArgumento);

            // Assert, Then

            sut.Message.Should().Be(Resources.Exception_Common_WrongArgument
                .QueryString(nomeDaClasse, nomeDoMétodo, nomeDoArgumento));
        }
    }
}