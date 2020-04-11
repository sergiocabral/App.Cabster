using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cabster.Business.Messenger.Notification;
using Cabster.Components;
using MediatR;

namespace Cabster.Business.Forms
{
    /// <summary>
    /// Janela de configuração
    /// </summary>
    public partial class FormConfiguration : FormLayout
    {
        /// <summary>
        /// Construtor.
        /// </summary>
        public FormConfiguration()
        {
            InitializeComponent();
            InitializeComponent2();
        }

        /// <summary>
        /// Inicializa controles.
        /// </summary>
        private void InitializeComponent2()
        {
        }
    }
}
