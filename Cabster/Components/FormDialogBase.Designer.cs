namespace Cabster.Components
{
    partial class FormDialogBase
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
            this.panelMarginLeft = new System.Windows.Forms.Panel();
            this.panelMarginRight = new System.Windows.Forms.Panel();
            this.panelMarginTop = new System.Windows.Forms.Panel();
            this.panelMarginBottom = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelMarginLeft
            // 
            this.panelMarginLeft.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (32)))),
                ((int) (((byte) (32)))), ((int) (((byte) (32)))));
            this.panelMarginLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMarginLeft.Location = new System.Drawing.Point(0, 0);
            this.panelMarginLeft.Name = "panelMarginLeft";
            this.panelMarginLeft.Size = new System.Drawing.Size(10, 489);
            this.panelMarginLeft.TabIndex = 0;
            // 
            // panelMarginRight
            // 
            this.panelMarginRight.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (32)))),
                ((int) (((byte) (32)))), ((int) (((byte) (32)))));
            this.panelMarginRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelMarginRight.Location = new System.Drawing.Point(806, 0);
            this.panelMarginRight.Name = "panelMarginRight";
            this.panelMarginRight.Size = new System.Drawing.Size(10, 489);
            this.panelMarginRight.TabIndex = 1;
            // 
            // panelMarginTop
            // 
            this.panelMarginTop.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (32)))),
                ((int) (((byte) (32)))), ((int) (((byte) (32)))));
            this.panelMarginTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMarginTop.Location = new System.Drawing.Point(10, 0);
            this.panelMarginTop.Name = "panelMarginTop";
            this.panelMarginTop.Size = new System.Drawing.Size(796, 10);
            this.panelMarginTop.TabIndex = 2;
            // 
            // panelMarginBottom
            // 
            this.panelMarginBottom.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (32)))),
                ((int) (((byte) (32)))), ((int) (((byte) (32)))));
            this.panelMarginBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelMarginBottom.Location = new System.Drawing.Point(10, 479);
            this.panelMarginBottom.Name = "panelMarginBottom";
            this.panelMarginBottom.Size = new System.Drawing.Size(796, 10);
            this.panelMarginBottom.TabIndex = 3;
            // 
            // FormDialogBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (64)))), ((int) (((byte) (64)))),
                ((int) (((byte) (64)))));
            this.BackgroundImage = global::Cabster.Properties.Resources.FormLayoutBackground;
            this.ClientSize = new System.Drawing.Size(816, 489);
            this.Controls.Add(this.panelMarginBottom);
            this.Controls.Add(this.panelMarginTop);
            this.Controls.Add(this.panelMarginRight);
            this.Controls.Add(this.panelMarginLeft);
            this.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (224)))), ((int) (((byte) (224)))),
                ((int) (((byte) (224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FormDialogBase";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormDialogShow";
            this.TopMost = true;
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelMarginLeft;
        private System.Windows.Forms.Panel panelMarginRight;
        private System.Windows.Forms.Panel panelMarginTop;
        private System.Windows.Forms.Panel panelMarginBottom;
    }
}