using System;
using Cabrones.Test;
using FluentAssertions;
using Xunit;
// ReSharper disable InconsistentNaming

namespace Cabster.Infrastructure
{
    public class IDependencyResolverTest
    {
        [Fact]
        public void verificações_declarativas()
        {
            // Arrange, Given
            // Act, When

            var sut = typeof(IDependencyResolver);

            // Assert, Then

            sut.AssertMyImplementations(
                typeof(IDisposable));
            sut.AssertMyOwnImplementations();
            sut.AssertMyOwnPublicPropertiesCount(0);
            sut.AssertMyOwnPublicMethodsCount(11);
            sut.AssertPublicMethodPresence("Guid CreateScope(Nullable<Guid> = null)");
            sut.AssertPublicMethodPresence("Void DisposeScope(Guid)");
            sut.AssertPublicMethodPresence("Boolean IsActive(Guid)");
            sut.AssertPublicMethodPresence("TService GetInstance<TService>(Nullable<Guid> = null)");
            sut.AssertPublicMethodPresence("Object GetInstance(Type, Nullable<Guid> = null)");
            sut.AssertPublicMethodPresence("TService GetInstanceRequired<TService>(Nullable<Guid> = null)");
            sut.AssertPublicMethodPresence("Object GetInstanceRequired(Type, Nullable<Guid> = null)");
            sut.AssertPublicMethodPresence(
                "Void Register<TService, TImplementation>(DependencyResolverLifeTime = 'PerContainer')");
            sut.AssertPublicMethodPresence("Void Register(Type, Type, DependencyResolverLifeTime = 'PerContainer')");
            sut.AssertPublicMethodPresence("Void AddInstance<TService>(TService)");
            sut.AssertPublicMethodPresence("Void AddInstance(Type, Object)");

            sut.IsInterface.Should().BeTrue();
        }
    }
}