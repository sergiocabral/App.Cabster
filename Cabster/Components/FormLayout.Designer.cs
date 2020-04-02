﻿namespace Cabster.Components
{
    partial class FormLayout
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
                new System.ComponentModel.ComponentResourceManager(typeof(FormLayout));
            this.panelTitle = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonClose = new Cabster.Components.MyButton(this.components);
            this.panelTitleMarginRight = new System.Windows.Forms.Panel();
            this.panelTitleMarginLeft = new System.Windows.Forms.Panel();
            this.buttonResize = new Cabster.Components.MyButton(this.components);
            this.panelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.Controls.Add(this.labelTitle);
            this.panelTitle.Controls.Add(this.buttonClose);
            this.panelTitle.Controls.Add(this.panelTitleMarginRight);
            this.panelTitle.Controls.Add(this.panelTitleMarginLeft);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Margin = new System.Windows.Forms.Padding(4);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(593, 50);
            this.panelTitle.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.labelTitle.Location = new System.Drawing.Point(15, 0);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(513, 50);
            this.labelTitle.TabIndex = 11;
            this.labelTitle.Text = "labelTitle";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int) (((byte) (140)))),
                ((int) (((byte) (140)))), ((int) (((byte) (140)))));
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Image = ((System.Drawing.Image) (resources.GetObject("buttonClose.Image")));
            this.buttonClose.Location = new System.Drawing.Point(528, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(50, 50);
            this.buttonClose.TabIndex = 9;
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // panelTitleMarginRight
            // 
            this.panelTitleMarginRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelTitleMarginRight.Location = new System.Drawing.Point(578, 0);
            this.panelTitleMarginRight.Margin = new System.Windows.Forms.Padding(4);
            this.panelTitleMarginRight.Name = "panelTitleMarginRight";
            this.panelTitleMarginRight.Size = new System.Drawing.Size(15, 50);
            this.panelTitleMarginRight.TabIndex = 6;
            // 
            // panelTitleMarginLeft
            // 
            this.panelTitleMarginLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTitleMarginLeft.Location = new System.Drawing.Point(0, 0);
            this.panelTitleMarginLeft.Margin = new System.Windows.Forms.Padding(4);
            this.panelTitleMarginLeft.Name = "panelTitleMarginLeft";
            this.panelTitleMarginLeft.Size = new System.Drawing.Size(15, 50);
            this.panelTitleMarginLeft.TabIndex = 4;
            // 
            // buttonResize
            // 
            this.buttonResize.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.buttonResize.BackColor = System.Drawing.Color.Transparent;
            this.buttonResize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonResize.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int) (((byte) (140)))),
                ((int) (((byte) (140)))), ((int) (((byte) (140)))));
            this.buttonResize.FlatAppearance.BorderSize = 0;
            this.buttonResize.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonResize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonResize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonResize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonResize.Image = ((System.Drawing.Image) (resources.GetObject("buttonResize.Image")));
            this.buttonResize.Location = new System.Drawing.Point(569, 388);
            this.buttonResize.Name = "buttonResize";
            this.buttonResize.Size = new System.Drawing.Size(24, 24);
            this.buttonResize.TabIndex = 1;
            this.buttonResize.UseVisualStyleBackColor = false;
            // 
            // FormLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (64)))), ((int) (((byte) (64)))),
                ((int) (((byte) (64)))));
            this.BackgroundImage = global::Cabster.Properties.Resources.FormBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(593, 411);
            this.Controls.Add(this.buttonResize);
            this.Controls.Add(this.panelTitle);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (224)))), ((int) (((byte) (224)))),
                ((int) (((byte) (224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormLayout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormLayout";
            this.panelTitle.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Panel panelTitleMarginLeft;
        private System.Windows.Forms.Panel panelTitleMarginRight;
        private System.Windows.Forms.Label labelTitle;
        private Cabster.Components.MyButton buttonClose;
        private Cabster.Components.MyButton buttonResize;
    }
}