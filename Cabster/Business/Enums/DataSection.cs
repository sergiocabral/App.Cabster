using System;

namespace Cabster.Business.Enums
{
    /// <summary>
    ///     Seções de dados do aplicativo.
    /// </summary>
    [Flags]
    public enum DataSection
    {
        /// <summary>
        ///     Todas as seções.
        /// </summary>
        All =
            0b_1111_1111,

        /// <summary>
        ///     ApplicationSet
        /// </summary>
        Application =
            0b_0000_1111,

        /// <summary>
        ///     ApplicationSet: Idioma.
        /// </summary>
        ApplicationLanguage =
            0b_0000_0001
    }
}