using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using NSubstitute;

namespace Cabster
{
    /// <summary>
    ///     Utilitários para os testes.
    /// </summary>
    public static class TestExtensions
    {
        /// <summary>
        ///     Abrir e fechar um form.
        /// </summary>
        /// <param name="form">Form</param>
        public static T AbrirFecharDescartar<T>(this T form) where T : Form
        {
            form.Show();
            form.Close();

            return form;
        }
        
        /// <summary>
        ///     Descartar controles com 100% de teste de cobertura.
        /// </summary>
        /// <param name="control">Controle</param>
        public static T Descartar<T>(this T control) where T : Control
        {
            // Necessário para teste de cobertura atingir 100%.
            // components é um atributo criado pelo Visual Studio e usado pelo modo Design.
            // https://stackoverflow.com/questions/5069391/whats-the-purpose-of-the-components-icontainer-generated-by-the-winforms-design
            control
                .GetType()
                .GetField("components", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.SetValue(control, Substitute.For<IContainer>());

            ((IDisposable) control).Dispose();

            return control;
        }

        /// <summary>
        ///     Verifica a leitura e escrita em todas as propriedades da classe.
        /// </summary>
        /// <param name="instance">Instância.</param>
        public static void LerEEscreverEmTodasAsPropriedades(this object instance)
        {
            var properties = instance
                .GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public);

            foreach (var property in properties)
            {
                var value = property.GetValue(instance);
                property.SetValue(instance, value);
            }
        }
    }
}