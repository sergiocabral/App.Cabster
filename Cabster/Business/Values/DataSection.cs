using System;

namespace Cabster.Business.Values
{
    /// <summary>
    ///     Seções de dados do aplicativo.
    /// </summary>
    [Flags]
    public enum DataSection
    {
        /// <summary>
        ///     Todas as seções
        /// </summary>
        All =
            0b_1111_1111_1111,

        /// <summary>
        ///     ApplicationSet
        /// </summary>
        Application =
            0b_0000_0000_1111,

        /// <summary>
        ///     ApplicationSet: Idioma
        /// </summary>
        ApplicationLanguage =
            0b_0000_0000_0001,

        /// <summary>
        ///     ApplicationSet: Tecla de atalho
        /// </summary>
        ApplicationShortcut =
            0b_0000_0000_0010,

        /// <summary>
        ///     ApplicationSet: Bloqueio de tela
        /// </summary>
        ApplicationLockScreen =
            0b_0000_0000_0100,

        /// <summary>
        ///     WorkGroupSet
        /// </summary>
        WorkGroup =
            0b_0000_1111_0000,

        /// <summary>
        ///     WorkGroupSet: Tempos.
        /// </summary>
        WorkGroupTimes =
            0b_0000_0001_0000,

        /// <summary>
        ///     WorkGroupSet: Participantes.
        /// </summary>
        WorkGroupParticipants =
            0b_0000_0010_0000,

        /// <summary>
        ///     WorkGroupSet: Temporizador
        /// </summary>
        WorkGroupTimer =
            0b_0000_0100_0000
    }
}