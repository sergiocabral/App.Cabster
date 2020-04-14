namespace Cabster.Components
{
    partial class FormDialogAlert
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
            this.labelText = new System.Windows.Forms.Label();
            this.buttonDialogClose = new Cabster.Components.MyButton(this.components);
            this.SuspendLayout();
            // 
            // labelText
            // 
            this.labelText.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top |
                                                         System.Windows.Forms.AnchorStyles.Bottom) |
                                                        System.Windows.Forms.AnchorStyles.Left) |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.labelText.BackColor = System.Drawing.Color.Transparent;
            this.labelText.Location = new System.Drawing.Point(26, 23);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(348, 91);
            this.labelText.TabIndex = 6;
            this.labelText.Text = "Text Here";
            this.labelText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonDialogClose
            // 
            this.buttonDialogClose.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom |
                                                        System.Windows.Forms.AnchorStyles.Left) |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDialogClose.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (250)))),
                ((int) (((byte) (180)))), ((int) (((byte) (10)))));
            this.buttonDialogClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDialogClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int) (((byte) (252)))),
                ((int) (((byte) (208)))), ((int) (((byte) (107)))));
            this.buttonDialogClose.FlatAppearance.BorderSize = 3;
            this.buttonDialogClose.FlatAppearance.CheckedBackColor =
                System.Drawing.Color.FromArgb(((int) (((byte) (119)))), ((int) (((byte) (84)))),
                    ((int) (((byte) (2)))));
            this.buttonDialogClose.FlatAppearance.MouseDownBackColor =
                System.Drawing.Color.FromArgb(((int) (((byte) (119)))), ((int) (((byte) (84)))),
                    ((int) (((byte) (2)))));
            this.buttonDialogClose.FlatAppearance.MouseOverBackColor =
                System.Drawing.Color.FromArgb(((int) (((byte) (135)))), ((int) (((byte) (96)))),
                    ((int) (((byte) (3)))));
            this.buttonDialogClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDialogClose.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.buttonDialogClose.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (64)))),
                ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.buttonDialogClose.Location = new System.Drawing.Point(26, 127);
            this.buttonDialogClose.Name = "buttonDialogClose";
            this.buttonDialogClose.NotTransparent = false;
            this.buttonDialogClose.Size = new System.Drawing.Size(348, 47);
            this.buttonDialogClose.TabIndex = 5;
            this.buttonDialogClose.Text = "Window.DialogShow.ButtonClose";
            this.buttonDialogClose.UseText = false;
            this.buttonDialogClose.UseVisualStyleBackColor = false;
            this.buttonDialogClose.Click += new System.EventHandler(this.buttonDialogClose_Click);
            // 
            // FormDialogAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.labelText);
            this.Controls.Add(this.buttonDialogClose);
            this.Name = "FormDialogAlert";
            this.Text = "FormDialogAlert";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormDialogConfirm_KeyUp);
            this.Controls.SetChildIndex(this.buttonDialogClose, 0);
            this.Controls.SetChildIndex(this.labelText, 0);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label labelText;
        private Cabster.Components.MyButton buttonDialogClose;
    }
}