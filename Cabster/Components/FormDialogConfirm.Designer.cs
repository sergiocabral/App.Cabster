namespace Cabster.Components
{
    partial class FormDialogConfirm
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
            this.buttonDialogConfirm = new Cabster.Components.MyButton(this.components);
            this.buttonDialogCancel = new Cabster.Components.MyButton(this.components);
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
            // buttonDialogConfirm
            // 
            this.buttonDialogConfirm.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom |
                                                        System.Windows.Forms.AnchorStyles.Left) |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDialogConfirm.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (250)))),
                ((int) (((byte) (180)))), ((int) (((byte) (10)))));
            this.buttonDialogConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDialogConfirm.FlatAppearance.BorderColor =
                System.Drawing.Color.FromArgb(((int) (((byte) (252)))), ((int) (((byte) (208)))),
                    ((int) (((byte) (107)))));
            this.buttonDialogConfirm.FlatAppearance.BorderSize = 3;
            this.buttonDialogConfirm.FlatAppearance.CheckedBackColor =
                System.Drawing.Color.FromArgb(((int) (((byte) (119)))), ((int) (((byte) (84)))),
                    ((int) (((byte) (2)))));
            this.buttonDialogConfirm.FlatAppearance.MouseDownBackColor =
                System.Drawing.Color.FromArgb(((int) (((byte) (119)))), ((int) (((byte) (84)))),
                    ((int) (((byte) (2)))));
            this.buttonDialogConfirm.FlatAppearance.MouseOverBackColor =
                System.Drawing.Color.FromArgb(((int) (((byte) (135)))), ((int) (((byte) (96)))),
                    ((int) (((byte) (3)))));
            this.buttonDialogConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDialogConfirm.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.buttonDialogConfirm.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (64)))),
                ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.buttonDialogConfirm.Location = new System.Drawing.Point(205, 127);
            this.buttonDialogConfirm.Name = "buttonDialogConfirm";
            this.buttonDialogConfirm.NotTransparent = false;
            this.buttonDialogConfirm.Size = new System.Drawing.Size(169, 47);
            this.buttonDialogConfirm.TabIndex = 5;
            this.buttonDialogConfirm.Text = "Window.DialogShow.ButtonConfirm";
            this.buttonDialogConfirm.UseText = false;
            this.buttonDialogConfirm.UseVisualStyleBackColor = false;
            this.buttonDialogConfirm.Click += new System.EventHandler(this.buttonDialog_Click);
            // 
            // buttonDialogCancel
            // 
            this.buttonDialogCancel.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom |
                                                        System.Windows.Forms.AnchorStyles.Left) |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDialogCancel.BackColor = System.Drawing.Color.Silver;
            this.buttonDialogCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDialogCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int) (((byte) (217)))),
                ((int) (((byte) (217)))), ((int) (((byte) (217)))));
            this.buttonDialogCancel.FlatAppearance.BorderSize = 3;
            this.buttonDialogCancel.FlatAppearance.CheckedBackColor =
                System.Drawing.Color.FromArgb(((int) (((byte) (89)))), ((int) (((byte) (89)))),
                    ((int) (((byte) (89)))));
            this.buttonDialogCancel.FlatAppearance.MouseDownBackColor =
                System.Drawing.Color.FromArgb(((int) (((byte) (89)))), ((int) (((byte) (89)))),
                    ((int) (((byte) (89)))));
            this.buttonDialogCancel.FlatAppearance.MouseOverBackColor =
                System.Drawing.Color.FromArgb(((int) (((byte) (102)))), ((int) (((byte) (102)))),
                    ((int) (((byte) (102)))));
            this.buttonDialogCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDialogCancel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.buttonDialogCancel.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (64)))),
                ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.buttonDialogCancel.Location = new System.Drawing.Point(26, 127);
            this.buttonDialogCancel.Name = "buttonDialogCancel";
            this.buttonDialogCancel.NotTransparent = false;
            this.buttonDialogCancel.Size = new System.Drawing.Size(169, 47);
            this.buttonDialogCancel.TabIndex = 4;
            this.buttonDialogCancel.Text = "Window.DialogShow.ButtonCancel";
            this.buttonDialogCancel.UseText = false;
            this.buttonDialogCancel.UseVisualStyleBackColor = false;
            this.buttonDialogCancel.Click += new System.EventHandler(this.buttonDialog_Click);
            // 
            // FormDialogConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.buttonDialogCancel);
            this.Controls.Add(this.labelText);
            this.Controls.Add(this.buttonDialogConfirm);
            this.Name = "FormDialogConfirm";
            this.Text = "FormDialogAlert";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormDialogConfirm_KeyUp);
            this.Controls.SetChildIndex(this.buttonDialogConfirm, 0);
            this.Controls.SetChildIndex(this.labelText, 0);
            this.Controls.SetChildIndex(this.buttonDialogCancel, 0);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label labelText;
        private Cabster.Components.MyButton buttonDialogCancel;
        private Cabster.Components.MyButton buttonDialogConfirm;
    }
}