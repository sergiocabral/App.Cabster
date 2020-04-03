namespace Cabster.Business.Forms
{
    partial class FormWorkGroup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(FormWorkGroup));
            this.buttonMinimize = new Cabster.Components.MyButton(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonMinimize
            // 
            this.buttonMinimize.BackColor = System.Drawing.Color.Transparent;
            this.buttonMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonMinimize.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int) (((byte) (140)))),
                ((int) (((byte) (140)))), ((int) (((byte) (140)))));
            this.buttonMinimize.FlatAppearance.BorderSize = 0;
            this.buttonMinimize.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinimize.Image = ((System.Drawing.Image) (resources.GetObject("buttonMinimize.Image")));
            this.buttonMinimize.Location = new System.Drawing.Point(620, 0);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.Size = new System.Drawing.Size(50, 50);
            this.buttonMinimize.TabIndex = 12;
            this.buttonMinimize.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(329, 177);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(228, 76);
            this.button1.TabIndex = 2;
            this.button1.Text = "Action.ResizeWindow";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FormConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 475);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Name = "FormConfiguration";
            this.ShowLogo = true;
            this.Text = "FormConfiguration";
            this.Controls.SetChildIndex(this.button1, 0);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private Cabster.Components.MyButton buttonMinimize;
    }
}