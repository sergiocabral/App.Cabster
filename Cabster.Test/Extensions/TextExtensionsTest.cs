using System;
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
        public void método_ToJson_para_uma_instância_deve_retornar_um_json()
        {
            // Arrange, Given

            var instância = new State
            {
                Mode = this.Fixture<StateMode>(),
                CurrentTime = this.Fixture<DateTimeOffset>()
            };

            // Act, When

            var json = instância.ToJson();

            // Assert, Then

            json.Should().Be($"{{\"Mode\":{(int) instância.Mode},\"CurrentTime\":\"{instância.CurrentTime:O}\"}}");
        }
    }
}