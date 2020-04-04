using System;
using Cabrones.Test;
using Cabrones.Utils.Text;
using Cabster.Business;
using Cabster.Business.Entities;
using Cabster.Exceptions;
using Cabster.Properties;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Xunit;

// ReSharper disable AccessToDisposedClosure

namespace Cabster.Infrastructure
{
    public class DependencyResolverTest
    {
        [Theory]
        [InlineData((int) DependencyResolverLifeTime.PerContainer, true)]
        [InlineData((int) DependencyResolverLifeTime.PerScope, true)]
        [InlineData((int) DependencyResolverLifeTime.PerRequest, true)]
        [InlineData(10, false)]
        public void ao_registrar_um_serviço_deve_usar_um_tipo_válido(int tipo, bool válido)
        {
            // Arrange, Given

            using var dependencyResolver = new DependencyResolver() as IDependencyResolver;

            // Act, When

            Action registrar = () =>
                dependencyResolver.Register<DependencyResolverSimulation, DependencyResolverSimulation>(
                    (DependencyResolverLifeTime) tipo);

            // Assert, Then

            if (válido)
                registrar.Should().NotThrow();
            else
                registrar.Should().Throw<WrongArgumentException>()
                    .WithMessage(Resources.Exception_Common_WrongArgument
                        .QueryString("DependencyResolver", "Register", "lifetime"));
        }

        [Fact]
        public void deve_poder_receber_ServiceCollection_externamente()
        {
            // Arrange, Given

            var serviceCollection = Substitute.For<IServiceCollection>();

            // Act, When

            Action instanciar = () =>
            {
                using var _ = new DependencyResolver(serviceCollection);
            };

            // Assert, Then

            instanciar.Should().NotThrow();
        }

        [Fact]
        public void deve_ser_capaz_de_adicionar_serviços_de_instâncias_existentes_via_Type_como_Generic()
        {
            // Arrange, Given

            using var dependencyResolver = new DependencyResolver() as IDependencyResolver;
            var instância = new DependencyResolverSimulation();

            // Act, When

            Action adicionar = () =>
                dependencyResolver.AddInstance(instância);

            // Assert, Then

            adicionar.Should().NotThrow();
            dependencyResolver.GetInstance<DependencyResolverSimulation>().Should().BeSameAs(instância);
        }

        [Fact]
        public void deve_ser_capaz_de_adicionar_serviços_de_instâncias_existentes_via_Type_como_parâmetro()
        {
            // Arrange, Given

            using var dependencyResolver = new DependencyResolver() as IDependencyResolver;
            var instância = new DependencyResolverSimulation();

            // Act, When

            Action adicionar = () =>
                dependencyResolver.AddInstance(typeof(DependencyResolverSimulation), instância);

            // Assert, Then

            adicionar.Should().NotThrow();
            dependencyResolver.GetInstance<DependencyResolverSimulation>().Should().BeSameAs(instância);
        }

        [Fact]
        public void deve_ser_capaz_de_adicionar_serviços_via_Type_como_Generic()
        {
            // Arrange, Given

            using var dependencyResolver = new DependencyResolver() as IDependencyResolver;

            // Act, When

            Action adicionar = () =>
                dependencyResolver.Register<DependencyResolverSimulation, DependencyResolverSimulation>();

            // Assert, Then

            adicionar.Should().NotThrow();
        }

        [Fact]
        public void deve_ser_capaz_de_adicionar_serviços_via_Type_como_parâmetro()
        {
            // Arrange, Given

            using var dependencyResolver = new DependencyResolver() as IDependencyResolver;

            // Act, When

            Action adicionar = () => dependencyResolver.Register(typeof(DependencyResolverSimulation),
                typeof(DependencyResolverSimulation));

            // Assert, Then

            adicionar.Should().NotThrow();
        }

        [Fact]
        public void deve_ser_capaz_de_obter_um_serviço_via_Type_como_Generic()
        {
            // Arrange, Given

            using var dependencyResolver = new DependencyResolver() as IDependencyResolver;
            dependencyResolver.Register<DependencyResolverSimulation, DependencyResolverSimulation>();

            // Act, When

            var instância = dependencyResolver.GetInstance<DependencyResolverSimulation>();

            // Assert, Then

            instância.GetType().Should().Be(typeof(DependencyResolverSimulation));
        }

        [Fact]
        public void deve_ser_capaz_de_obter_um_serviço_via_Type_como_Generic_indicando_se_é_obrigatório()
        {
            // Arrange, Given

            using var dependencyResolver = new DependencyResolver() as IDependencyResolver;
            dependencyResolver.Register<DependencyResolverSimulation, DependencyResolverSimulation>();

            // Act, When

            Func<object> obterServiçoExistente =
                () => dependencyResolver.GetInstanceRequired<DependencyResolverSimulation>();
            Func<object> obterServiçoInexistente =
                () => dependencyResolver.GetInstanceRequired<DependencyResolver>();

            // Assert, Then

            obterServiçoExistente.Should().NotThrow()
                .Which.Should().NotBeNull();

            obterServiçoInexistente.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void deve_ser_capaz_de_obter_um_serviço_via_Type_como_parâmetro()
        {
            // Arrange, Given

            using var dependencyResolver = new DependencyResolver() as IDependencyResolver;
            dependencyResolver.Register(typeof(DependencyResolverSimulation),
                typeof(DependencyResolverSimulation));

            // Act, When

            var instância = dependencyResolver.GetInstance(typeof(DependencyResolverSimulation));

            // Assert, Then

            instância.GetType().Should().Be(typeof(DependencyResolverSimulation));
        }

        [Fact]
        public void deve_ser_capaz_de_obter_um_serviço_via_Type_como_parâmetro_indicando_se_é_obrigatório()
        {
            // Arrange, Given

            using var dependencyResolver = new DependencyResolver() as IDependencyResolver;
            dependencyResolver.Register<DependencyResolverSimulation, DependencyResolverSimulation>();

            // Act, When

            Func<object> obterServiçoExistente =
                () => dependencyResolver.GetInstanceRequired(typeof(DependencyResolverSimulation));
            Func<object> obterServiçoInexistente =
                () => dependencyResolver.GetInstanceRequired(typeof(DependencyResolver));

            // Assert, Then

            obterServiçoExistente.Should().NotThrow()
                .Which.Should().NotBeNull();

            obterServiçoInexistente.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void deve_ser_capaz_de_verificar_se_um_escopo_está_ativo_ou_já_foi_liberado()
        {
            // Arrange, Given

            using var dependencyResolver = new DependencyResolver() as IDependencyResolver;
            var escopoInvalido = Guid.NewGuid();
            var escopoLiberado = dependencyResolver.CreateScope();
            dependencyResolver.DisposeScope(escopoLiberado);
            var escopoAtivo = dependencyResolver.CreateScope();

            // Act, When

            var escopoInvalidoEstáAtivo = dependencyResolver.IsActive(escopoInvalido);
            var escopoLiberadoEstáAtivo = dependencyResolver.IsActive(escopoLiberado);
            var escopoAtivoEstáAtivo = dependencyResolver.IsActive(escopoAtivo);

            // Assert, Then

            escopoInvalidoEstáAtivo.Should().BeFalse();
            escopoLiberadoEstáAtivo.Should().BeFalse();
            escopoAtivoEstáAtivo.Should().BeTrue();
        }

        [Fact]
        public void deve_ser_possível_apagar_um_escopo_criado()
        {
            // Arrange, Given

            using var dependencyResolver = new DependencyResolver() as IDependencyResolver;
            var escopo = dependencyResolver.CreateScope();

            // Act, When

            Action removerEscopo = () => dependencyResolver.DisposeScope(escopo);

            // Assert, Then

            removerEscopo.Should().NotThrow();
        }

        [Fact]
        public void deve_ser_possível_criar_um_escopo()
        {
            // Arrange, Given

            using var dependencyResolver = new DependencyResolver() as IDependencyResolver;

            // Act, When

            Action criarEscopo = () => dependencyResolver.CreateScope();

            // Assert, Then

            criarEscopo.Should().NotThrow();
        }

        [Fact]
        public void dispara_exception_ao_apagar_um_escopo_não_existente()
        {
            // Arrange, Given

            using var dependencyResolver = new DependencyResolver() as IDependencyResolver;
            var escopoQueNãoExiste = this.Fixture<Guid>();

            // Act, When

            Action removerEscopoQueNãoExiste = () => dependencyResolver.DisposeScope(escopoQueNãoExiste);

            // Assert, Then

            removerEscopoQueNãoExiste.Should().Throw<WrongArgumentException>()
                .WithMessage(Resources.Exception_Common_WrongArgument
                    .QueryString("DependencyResolver", "ValidateScope", "scope"));
        }

        [Fact]
        public void dispara_exception_ao_obter_um_serviço_via_Type_como_Generic_de_um_escopo_não_existente()
        {
            // Arrange, Given

            using var dependencyResolver = new DependencyResolver() as IDependencyResolver;
            var escopoQueNãoExiste = this.Fixture<Guid>();
            dependencyResolver.Register<DependencyResolverSimulation, DependencyResolverSimulation>(
                DependencyResolverLifeTime.PerScope);

            // Act, When

            Action obterServiçoDeEscopoQueNãoExiste =
                () => dependencyResolver.GetInstance<DependencyResolverSimulation>(escopoQueNãoExiste);

            // Assert, Then

            obterServiçoDeEscopoQueNãoExiste.Should().Throw<WrongArgumentException>()
                .WithMessage(Resources.Exception_Common_WrongArgument
                    .QueryString("DependencyResolver", "ValidateScope", "scope"));
        }

        [Fact]
        public void dispara_exception_ao_obter_um_serviço_via_Type_como_parâmetro_de_um_escopo_não_existente()
        {
            // Arrange, Given

            using var dependencyResolver = new DependencyResolver() as IDependencyResolver;
            var escopoQueNãoExiste = this.Fixture<Guid>();
            dependencyResolver.Register(typeof(DependencyResolverSimulation),
                typeof(DependencyResolverSimulation), DependencyResolverLifeTime.PerScope);

            // Act, When

            Action obterServiçoDeEscopoQueNãoExiste =
                () => dependencyResolver.GetInstance(typeof(DependencyResolverSimulation), escopoQueNãoExiste);

            // Assert, Then

            obterServiçoDeEscopoQueNãoExiste.Should().Throw<WrongArgumentException>()
                .WithMessage(Resources.Exception_Common_WrongArgument
                    .QueryString("DependencyResolver", "ValidateScope", "scope"));
        }

        [Fact]
        public void liberar_um_escopo_pai_deve_liberar_todos_os_escopos_filhos()
        {
            // Arrange, Given

            using var dependencyResolver = new DependencyResolver() as IDependencyResolver;
            var escopoPai = dependencyResolver.CreateScope();
            var escopoFilho = dependencyResolver.CreateScope(escopoPai);
            var escopoNeto = dependencyResolver.CreateScope(escopoFilho);

            // Act, When

            dependencyResolver.DisposeScope(escopoPai);
            var escopoPaiFoiLiberado = !dependencyResolver.IsActive(escopoPai);
            var escopoFilhoFoiLiberado = !dependencyResolver.IsActive(escopoFilho);
            var escopoNetoFoiLiberado = !dependencyResolver.IsActive(escopoNeto);

            // Assert, Then

            escopoPaiFoiLiberado.Should().BeTrue();
            escopoFilhoFoiLiberado.Should().BeTrue();
            escopoNetoFoiLiberado.Should().BeTrue();
        }

        [Fact]
        public void permite_criar_escopo_dentro_de_outro_escopo()
        {
            // Arrange, Given

            using var dependencyResolver = new DependencyResolver() as IDependencyResolver;

            // Act, When

            Action criarEscoposAninhados = () =>
                dependencyResolver.CreateScope(
                    dependencyResolver.CreateScope(
                        dependencyResolver.CreateScope()));

            // Assert, Then

            criarEscoposAninhados.Should().NotThrow();
        }

        [Fact]
        public void se_não_receber_ServiceCollection_externamente_é_proibido_informar_o_ServiceProvider()
        {
            // Arrange, Given

            using var dependencyResolver = new DependencyResolver();
            var serviceProvider = Substitute.For<IServiceProvider>();

            // Act, When

            Action informarServiceProvider = () => dependencyResolver.SetServiceProvider(serviceProvider);

            // Assert, Then

            informarServiceProvider.Should().Throw<WrongOperationException>()
                .WithMessage(Resources.Exception_Infrastructure_ConfigurationIsManagedInternally
                    .QueryString(nameof(DependencyResolver)));
        }

        [Fact]
        public void se_receber_ServiceCollection_externamente_é_obrigatório_informar_o_ServiceProvider()
        {
            // Arrange, Given

            var serviceCollection = Substitute.For<IServiceCollection>();

            using var dependencyResolver = new DependencyResolver(serviceCollection);
            dependencyResolver.Register<IEntity, ContainerData>();

            // Act, When

            Action nãoInformandoServiceProvider = () =>
                dependencyResolver.GetInstance<IEntity>();

            Action informandoServiceProvider = () =>
            {
                dependencyResolver.SetServiceProvider(Substitute.For<IServiceProvider>());
                dependencyResolver.GetInstance<IEntity>();
            };

            // Assert, Then

            nãoInformandoServiceProvider.Should().Throw<WrongOperationException>()
                .WithMessage(Resources.Exception_Infrastructure_ConfigurationIsManagedExternally
                    .QueryString(nameof(DependencyResolver)));

            informandoServiceProvider.Should().NotThrow();
        }

        [Fact]
        public void se_receber_ServiceCollection_externamente_não_pode_registrar_novos_serviços_depois_de_inicializado()
        {
            // Arrange, Given

            var serviceCollection = Substitute.For<IServiceCollection>();
            using var dependencyResolver = new DependencyResolver(serviceCollection);
            var serviceProvider = Substitute.For<IServiceProvider>();

            // Act, When

            Action adicionarServiçoEInicializar = () =>
            {
                dependencyResolver.Register<IEntity, ContainerData>();
                dependencyResolver.SetServiceProvider(serviceProvider);
                dependencyResolver.GetInstance<IEntity>();
            };

            // Assert, Then

            adicionarServiçoEInicializar.Should().NotThrow();
            adicionarServiçoEInicializar.Should().Throw<WrongOperationException>()
                .WithMessage(Resources.Exception_Infrastructure_ConfigurationIsManagedExternally
                    .QueryString(nameof(DependencyResolver)));
        }

        [Fact]
        public void
            verifica_se_a_liberação_do_escopo_libera_as_instâncias_associadas_em_escopos_filhos_quando_via_Type_como_Generic()
        {
            // Arrange, Given

            using var dependencyResolver = new DependencyResolver() as IDependencyResolver;
            dependencyResolver.Register<DependencyResolverSimulation, DependencyResolverSimulation>(
                DependencyResolverLifeTime.PerScope);
            var escopoPai = dependencyResolver.CreateScope();
            var escopoFilho = dependencyResolver.CreateScope(escopoPai);
            var escopoNeto = dependencyResolver.CreateScope(escopoFilho);

            var liberadoQuantasVezes = 0;

            var instânciaNoPai = dependencyResolver.GetInstance<DependencyResolverSimulation>(escopoPai);
            var instânciaNoFilho = dependencyResolver.GetInstance<DependencyResolverSimulation>(escopoFilho);
            var instânciaNoNeto = dependencyResolver.GetInstance<DependencyResolverSimulation>(escopoNeto);

            instânciaNoPai.Disposed += () => liberadoQuantasVezes++;
            instânciaNoFilho.Disposed += () => liberadoQuantasVezes++;
            instânciaNoNeto.Disposed += () => liberadoQuantasVezes++;

            // Act, When

            dependencyResolver.DisposeScope(escopoPai);

            // Assert, Then

            liberadoQuantasVezes.Should().Be(3);
        }

        [Fact]
        public void
            verifica_se_a_liberação_do_escopo_libera_as_instâncias_associadas_em_escopos_filhos_quando_via_Type_como_parâmetro()
        {
            // Arrange, Given

            using var dependencyResolver = new DependencyResolver() as IDependencyResolver;
            dependencyResolver.Register(typeof(DependencyResolverSimulation),
                typeof(DependencyResolverSimulation), DependencyResolverLifeTime.PerScope);
            var escopoPai = dependencyResolver.CreateScope();
            var escopoFilho = dependencyResolver.CreateScope(escopoPai);
            var escopoNeto = dependencyResolver.CreateScope(escopoFilho);

            var liberadoQuantasVezes = 0;

            var instânciaNoPai =
                (DependencyResolverSimulation) dependencyResolver.GetInstance(
                    typeof(DependencyResolverSimulation), escopoPai);
            var instânciaNoFilho =
                (DependencyResolverSimulation) dependencyResolver.GetInstance(
                    typeof(DependencyResolverSimulation), escopoFilho);
            var instânciaNoNeto =
                (DependencyResolverSimulation) dependencyResolver.GetInstance(
                    typeof(DependencyResolverSimulation), escopoNeto);

            instânciaNoPai.Disposed += () => liberadoQuantasVezes++;
            instânciaNoFilho.Disposed += () => liberadoQuantasVezes++;
            instânciaNoNeto.Disposed += () => liberadoQuantasVezes++;

            // Act, When

            dependencyResolver.DisposeScope(escopoPai);

            // Assert, Then

            liberadoQuantasVezes.Should().Be(3);
        }

        [Fact]
        public void verifica_se_a_liberação_do_escopo_libera_as_instâncias_associadas_quando_via_Type_como_Generic()
        {
            // Arrange, Given

            using var dependencyResolver = new DependencyResolver() as IDependencyResolver;
            dependencyResolver.Register<DependencyResolverSimulation, DependencyResolverSimulation>(
                DependencyResolverLifeTime.PerScope);
            var escopo = dependencyResolver.CreateScope();

            var liberadoQuantasVezes = 0;
            var instância = dependencyResolver.GetInstance<DependencyResolverSimulation>(escopo);
            instância.Disposed += () => liberadoQuantasVezes++;

            // Act, When

            dependencyResolver.DisposeScope(escopo);

            // Assert, Then

            liberadoQuantasVezes.Should().Be(1);
        }

        [Fact]
        public void verifica_se_a_liberação_do_escopo_libera_as_instâncias_associadas_quando_via_Type_como_parâmetro()
        {
            // Arrange, Given

            using var dependencyResolver = new DependencyResolver() as IDependencyResolver;
            dependencyResolver.Register(typeof(DependencyResolverSimulation),
                typeof(DependencyResolverSimulation), DependencyResolverLifeTime.PerScope);
            var escopo = dependencyResolver.CreateScope();

            var liberadoQuantasVezes = 0;
            var instância =
                (DependencyResolverSimulation) dependencyResolver.GetInstance(
                    typeof(DependencyResolverSimulation), escopo);
            instância.Disposed += () => liberadoQuantasVezes++;

            // Act, When

            dependencyResolver.DisposeScope(escopo);

            // Assert, Then

            liberadoQuantasVezes.Should().Be(1);
        }

        [Fact]
        public void verifica_se_está_sendo_respeitado_o_escopo_do_serviço_tipo_PerContainer_via_Type_como_Generic()
        {
            // Arrange, Given

            using var dependencyResolver = new DependencyResolver() as IDependencyResolver;
            // ReSharper disable once RedundantArgumentDefaultValue
            dependencyResolver.Register<DependencyResolverSimulation, DependencyResolverSimulation>(
                DependencyResolverLifeTime.PerContainer);

            // Act, When

            var instância1 = dependencyResolver.GetInstance<DependencyResolverSimulation>();
            var instância2 = dependencyResolver.GetInstance<DependencyResolverSimulation>();

            // Assert, Then

            instância1.Should().BeSameAs(instância2);
            instância1.Identificador.Should().Be(instância2.Identificador);
        }

        [Fact]
        public void verifica_se_está_sendo_respeitado_o_escopo_do_serviço_tipo_PerContainer_via_Type_como_parâmetro()
        {
            // Arrange, Given

            using var dependencyResolver = new DependencyResolver() as IDependencyResolver;
            // ReSharper disable once RedundantArgumentDefaultValue
            dependencyResolver.Register(typeof(DependencyResolverSimulation),
                typeof(DependencyResolverSimulation), DependencyResolverLifeTime.PerContainer);

            // Act, When

            var instância1 =
                (DependencyResolverSimulation) dependencyResolver.GetInstance(
                    typeof(DependencyResolverSimulation));
            var instância2 =
                (DependencyResolverSimulation) dependencyResolver.GetInstance(
                    typeof(DependencyResolverSimulation));

            // Assert, Then

            instância1.Should().BeSameAs(instância2);
            instância1.Identificador.Should().Be(instância2.Identificador);
        }

        [Fact]
        public void verifica_se_está_sendo_respeitado_o_escopo_do_serviço_tipo_PerRequest_via_Type_como_Generic()
        {
            // Arrange, Given

            using var dependencyResolver = new DependencyResolver() as IDependencyResolver;
            // ReSharper disable once RedundantArgumentDefaultValue
            dependencyResolver.Register<DependencyResolverSimulation, DependencyResolverSimulation>(
                DependencyResolverLifeTime.PerRequest);

            // Act, When

            var instância1 = dependencyResolver.GetInstance<DependencyResolverSimulation>();
            var instância2 = dependencyResolver.GetInstance<DependencyResolverSimulation>();

            // Assert, Then

            instância1.Should().NotBeSameAs(instância2);
            instância1.Identificador.Should().NotBe(instância2.Identificador);
        }

        [Fact]
        public void verifica_se_está_sendo_respeitado_o_escopo_do_serviço_tipo_PerRequest_via_Type_como_parâmetro()
        {
            // Arrange, Given

            using var dependencyResolver = new DependencyResolver() as IDependencyResolver;
            // ReSharper disable once RedundantArgumentDefaultValue
            dependencyResolver.Register(typeof(DependencyResolverSimulation),
                typeof(DependencyResolverSimulation), DependencyResolverLifeTime.PerRequest);

            // Act, When

            var instância1 =
                (DependencyResolverSimulation) dependencyResolver.GetInstance(
                    typeof(DependencyResolverSimulation));
            var instância2 =
                (DependencyResolverSimulation) dependencyResolver.GetInstance(
                    typeof(DependencyResolverSimulation));

            // Assert, Then

            instância1.Should().NotBeSameAs(instância2);
            instância1.Identificador.Should().NotBe(instância2.Identificador);
        }

        [Fact]
        public void verifica_se_está_sendo_respeitado_o_escopo_do_serviço_tipo_PerScope_via_Type_como_Generic()
        {
            // Arrange, Given

            using var dependencyResolver = new DependencyResolver() as IDependencyResolver;
            dependencyResolver.Register<DependencyResolverSimulation, DependencyResolverSimulation>(
                DependencyResolverLifeTime.PerScope);

            // Act, When

            var escopo1 = dependencyResolver.CreateScope();
            var instância1A = dependencyResolver.GetInstance<DependencyResolverSimulation>(escopo1);
            var instância1B = dependencyResolver.GetInstance<DependencyResolverSimulation>(escopo1);
            var escopo2 = dependencyResolver.CreateScope();
            var instância2A = dependencyResolver.GetInstance<DependencyResolverSimulation>(escopo2);
            var instância2B = dependencyResolver.GetInstance<DependencyResolverSimulation>(escopo2);

            // Assert, Then

            instância1A.Should().BeSameAs(instância1B);
            instância1A.Identificador.Should().Be(instância1B.Identificador);

            instância2A.Should().BeSameAs(instância2B);
            instância2A.Identificador.Should().Be(instância2B.Identificador);

            instância1A.Should().NotBeSameAs(instância2A);
            instância1A.Identificador.Should().NotBe(instância2A.Identificador);
        }

        [Fact]
        public void verifica_se_está_sendo_respeitado_o_escopo_do_serviço_tipo_PerScope_via_Type_como_parâmetro()
        {
            // Arrange, Given

            using var dependencyResolver = new DependencyResolver() as IDependencyResolver;
            dependencyResolver.Register(typeof(DependencyResolverSimulation),
                typeof(DependencyResolverSimulation), DependencyResolverLifeTime.PerScope);

            // Act, When

            var escopo1 = dependencyResolver.CreateScope();
            var instância1A =
                (DependencyResolverSimulation) dependencyResolver.GetInstance(
                    typeof(DependencyResolverSimulation), escopo1);
            var instância1B =
                (DependencyResolverSimulation) dependencyResolver.GetInstance(
                    typeof(DependencyResolverSimulation), escopo1);
            var escopo2 = dependencyResolver.CreateScope();
            var instância2A =
                (DependencyResolverSimulation) dependencyResolver.GetInstance(
                    typeof(DependencyResolverSimulation), escopo2);
            var instância2B =
                (DependencyResolverSimulation) dependencyResolver.GetInstance(
                    typeof(DependencyResolverSimulation), escopo2);

            // Assert, Then

            instância1A.Should().BeSameAs(instância1B);
            instância1A.Identificador.Should().Be(instância1B.Identificador);

            instância2A.Should().BeSameAs(instância2B);
            instância2A.Identificador.Should().Be(instância2B.Identificador);

            instância1A.Should().NotBeSameAs(instância2A);
            instância1A.Identificador.Should().NotBe(instância2A.Identificador);
        }

        [Fact]
        public void verificações_declarativas()
        {
            // Arrange, Given
            // Act, When

            var sut = typeof(DependencyResolver);

            // Assert, Then

            sut.AssertMyImplementations(
                typeof(IDependencyResolver),
                typeof(IDisposable));
            sut.AssertMyOwnImplementations(
                typeof(IDependencyResolver));
            sut.AssertMyOwnPublicPropertiesCount(2);
            sut.AssertPublicPropertyPresence("static IDependencyResolver Default { get; set; }");
            sut.AssertMyOwnPublicMethodsCount(1);
            sut.AssertPublicMethodPresence("Void SetServiceProvider(IServiceProvider)");

            sut.IsClass.Should().BeTrue();
        }
    }
}