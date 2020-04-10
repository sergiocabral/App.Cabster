using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Cabster.Extensions;

namespace Cabster.Components
{
    /// <summary>
    ///     Painel para arrastar e soltar elementos.
    /// </summary>
    public partial class MyFlowPanel : Panel
    {
        /// <summary>
        ///     Index de cada controle no container.
        /// </summary>
        private readonly Dictionary<Control, int> _positions = new Dictionary<Control, int>();

        /// <summary>
        ///     Construtor.
        /// </summary>
        public MyFlowPanel()
        {
            InitializeComponent();
            InitializeComponent2();
        }

        /// <summary>
        ///     Construtor.
        /// </summary>
        /// <param name="container">Container</param>
        public MyFlowPanel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            InitializeComponent2();
        }

        /// <summary>
        ///     Inicializa o componente.
        /// </summary>
        private void InitializeComponent2()
        {
            HandleCreated += (sender, args) =>
            {
                foreach (Control control in Controls) OnControlAdded(this, new ControlEventArgs(control));
                var index = 0;
                this.MakeChildrenOrganized(control => _positions[control] = index++);
            };
            Resize += OnResize;
            ControlAdded += OnControlAdded;
        }

        private void OnControlAdded(object sender, ControlEventArgs e)
        {
            var control = e.Control;
            control.MakeAbleToMoveWithMouse();
            control.MouseUp += ControlOnMouseUp;
            if (control is MyButton myButton) myButton.UpdateSizeToText();
            _positions[control] = _positions.Count;
            OnResize(this, null);
        }

        /// <summary>
        ///     Ao mudar o tamanho do container.
        /// </summary>
        /// <param name="sender">Origem do evento.</param>
        /// <param name="args">Informações do evento.</param>
        private void OnResize(object sender, EventArgs? args)
        {
            if (_positions.Count == 0) return;
            this.MakeChildrenOrganized(control => _positions[control]);
        }

        /// <summary>
        ///     Quando um controle no container é solto pelo mouse.
        /// </summary>
        /// <param name="sender">Origem do evento.</param>
        /// <param name="args">Informações do evento.</param>
        private void ControlOnMouseUp(object sender, MouseEventArgs args)
        {
            // Controle sendo arrastado.
            var target = (Control) sender;

            // Control que contem todos os outros. 
            var container = target.Parent;

            // Lista de todos os outros controles em ordem.
            var controls = container
                .Controls
                .OfType<Control>()
                .Except(new[] {target})
                .GroupBy(control => control.Top)
                .OrderBy(line => line.Key)
                .SelectMany(line => line
                    .OrderBy(control => control.Left))
                .ToList();

            // Lista dos controles em posição acima.
            var sameRegionControls = controls
                .Where(control => control.Bottom >= target.Top && control.Top <= target.Bottom)
                .ToList();

            // O Controle não caiu em cima de nenhum outro.
            if (sameRegionControls.Count == 0)
            {
                // Se a lista era vazia, adiciona nela.
                if (controls.Count == 0) controls.Add(target);

                // Se caiu acima do topo é o primeiro.
                else if (controls[0].Top > target.Top) controls.Insert(0, target);

                // Então caiu no final.
                else controls.Add(target);
            }

            // O controle caiu em cima de alguns outros.
            else
            {
                var sameLineControls = sameRegionControls
                    // Agrupa por linha.
                    .GroupBy(control => control.Top + control.Height / 2)

                    // Ordena as linhas pela mais próxima primeira.
                    .OrderBy(group => Math.Abs(target.Top + target.Height / 2 - group.Key))

                    // Seleciona a primeira linha que é a mais próxima do controle alvo.
                    .First();

                var next = sameLineControls
                    // Seleciona o primeiro control depois do control alvo.
                    .FirstOrDefault(control => control.Left > target.Left);

                controls.Insert(
                    next != null

                        // Insere na lista no lugar do controle encontrado.
                        ? controls.IndexOf(next)

                        // Se não encontrar fica na última posição
                        : controls.IndexOf(sameLineControls.Last()) + 1,
                    target);
            }

            _positions.Clear();
            this.MakeChildrenOrganized(control => _positions[control] = controls.IndexOf(control));
            target.MakeHighlight();
        }
    }
}