using System;
using System.Text.RegularExpressions;
using Cabrones.Test;
using Cabster.Business.Entities;
using Cabster.Business.Enums;
using FluentAssertions;
using Xunit;

namespace Cabster.Extensions
{
    public class TextExtensionsTest
    {
        [Fact]
        public void método_FromJson_para_uma_string_deve_retornar_uma_instância()
        {
            // Arrange, Given

            var mode = this.Fixture<StateMode>();
            var currentTime = this.Fixture<DateTimeOffset>();
            var json = $"{{\"Mode\":{(int) mode},\"CurrentTime\":\"{currentTime:O}\"}}";

            // Act, When

            var instância = json.FromJson<State>();

            // Assert, Then

            instância.Mode.Should().Be(mode);
            instância.CurrentTime.Should().Be(currentTime);
        }

        [Fact]
        public void método_ToJson_e_método_FromJson_devem_ser_complementares_e_funcionar_para_classes_complexas()
        {
            // Arrange, Given

            var instânciaOriginal = new ContainerData();

            // Act, When

            var json = instânciaOriginal.ToJson();
            var instância2 = json.FromJson<ContainerData>();
            var json2 = instância2.ToJson();

            // Assert, Then

            json.Should().Be(json2);
        }

        [Fact]
        public void método_ToJson_para_uma_instância_deve_retornar_um_json()
        {
            // Arrange, Given

            var instância = new State
            {
                Mode = this.Fixture<StateMode>(),
                CurrentTime = this.Fixture<DateTimeOffset>()
            };
            
            var jsonEsperado = 
                $"{{\"Mode\":{(int) instância.Mode},\"CurrentTime\":\"{instância.CurrentTime:O}\"}}";
            jsonEsperado = Regex.Replace(jsonEsperado, @"(?<=[0-9]{6})0(?=-[0-9]{2}:[0-9]{2})", string.Empty);

            // Act, When

            var jsonObtido = instância.ToJson();

            // Assert, Then

            jsonObtido.Should().Be(jsonEsperado);
        }

        [Fact]
        public void verificações_declarativa()
        {
            // Arrange, Given
            // Act, When

            var sut = typeof(TextExtensions);

            // Assert, Then

            sut.AssertMyImplementations();
            sut.AssertMyOwnImplementations();
            sut.AssertMyOwnPublicPropertiesCount(0);
            sut.AssertMyOwnPublicMethodsCount(2);
            sut.AssertPublicMethodPresence("static String ToJson<TEntity>(TEntity)");
            sut.AssertPublicMethodPresence("static TEntity FromJson<TEntity>(String)");

            sut.IsClass.Should().BeTrue();
        }
    }
}