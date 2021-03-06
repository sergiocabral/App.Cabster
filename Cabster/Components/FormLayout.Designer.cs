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
            this.buttonMinimize = new Cabster.Components.MyButton(this.components);
            this.buttonClose = new Cabster.Components.MyButton(this.components);
            this.panelTitleMarginRight = new System.Windows.Forms.Panel();
            this.panelTitleMarginLeft = new System.Windows.Forms.Panel();
            this.buttonResize = new Cabster.Components.MyButton(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonNotification = new Cabster.Components.MyButton(this.components);
            this.panelLogo = new System.Windows.Forms.Panel();
            this.labelStatus = new System.Windows.Forms.Label();
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            this.panelMarginLeft = new System.Windows.Forms.Panel();
            this.panelMarginRight = new System.Windows.Forms.Panel();
            this.panelMarginBottom = new System.Windows.Forms.Panel();
            this.panelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (32)))), ((int) (((byte) (32)))),
                ((int) (((byte) (32)))));
            this.panelTitle.Controls.Add(this.labelTitle);
            this.panelTitle.Controls.Add(this.buttonMinimize);
            this.panelTitle.Controls.Add(this.buttonClose);
            this.panelTitle.Controls.Add(this.panelTitleMarginRight);
            this.panelTitle.Controls.Add(this.panelTitleMarginLeft);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Margin = new System.Windows.Forms.Padding(4);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(831, 50);
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
            this.labelTitle.Size = new System.Drawing.Size(701, 50);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "labelTitle";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonMinimize
            // 
            this.buttonMinimize.BackColor = System.Drawing.Color.Transparent;
            this.buttonMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonMinimize.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))),
                ((int) (((byte) (255)))), ((int) (((byte) (255)))), ((int) (((byte) (255)))));
            this.buttonMinimize.FlatAppearance.BorderSize = 0;
            this.buttonMinimize.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinimize.Image = ((System.Drawing.Image) (resources.GetObject("buttonMinimize.Image")));
            this.buttonMinimize.Location = new System.Drawing.Point(716, 0);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.NotTransparent = false;
            this.buttonMinimize.Size = new System.Drawing.Size(50, 50);
            this.buttonMinimize.TabIndex = 4;
            this.toolTip.SetToolTip(this.buttonMinimize, "Window.Layout.MinimizeWindow");
            this.buttonMinimize.UseText = false;
            this.buttonMinimize.UseVisualStyleBackColor = false;
            this.buttonMinimize.Click += new System.EventHandler(this.buttonMinimize_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))),
                ((int) (((byte) (255)))), ((int) (((byte) (255)))), ((int) (((byte) (255)))));
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Image = ((System.Drawing.Image) (resources.GetObject("buttonClose.Image")));
            this.buttonClose.Location = new System.Drawing.Point(766, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.NotTransparent = false;
            this.buttonClose.Size = new System.Drawing.Size(50, 50);
            this.buttonClose.TabIndex = 5;
            this.toolTip.SetToolTip(this.buttonClose, "Window.Layout.TerminateApplication");
            this.buttonClose.UseText = false;
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // panelTitleMarginRight
            // 
            this.panelTitleMarginRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelTitleMarginRight.Location = new System.Drawing.Point(816, 0);
            this.panelTitleMarginRight.Margin = new System.Windows.Forms.Padding(4);
            this.panelTitleMarginRight.Name = "panelTitleMarginRight";
            this.panelTitleMarginRight.Size = new System.Drawing.Size(15, 50);
            this.panelTitleMarginRight.TabIndex = 2;
            // 
            // panelTitleMarginLeft
            // 
            this.panelTitleMarginLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTitleMarginLeft.Location = new System.Drawing.Point(0, 0);
            this.panelTitleMarginLeft.Margin = new System.Windows.Forms.Padding(4);
            this.panelTitleMarginLeft.Name = "panelTitleMarginLeft";
            this.panelTitleMarginLeft.Size = new System.Drawing.Size(15, 50);
            this.panelTitleMarginLeft.TabIndex = 1;
            // 
            // buttonResize
            // 
            this.buttonResize.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.buttonResize.BackColor = System.Drawing.Color.Transparent;
            this.buttonResize.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.buttonResize.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))),
                ((int) (((byte) (255)))), ((int) (((byte) (255)))), ((int) (((byte) (255)))));
            this.buttonResize.FlatAppearance.BorderSize = 0;
            this.buttonResize.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonResize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonResize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonResize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonResize.Image = ((System.Drawing.Image) (resources.GetObject("buttonResize.Image")));
            this.buttonResize.Location = new System.Drawing.Point(807, 491);
            this.buttonResize.Name = "buttonResize";
            this.buttonResize.NotTransparent = false;
            this.buttonResize.Size = new System.Drawing.Size(24, 24);
            this.buttonResize.TabIndex = 11;
            this.toolTip.SetToolTip(this.buttonResize, "Window.Layout.ResizeWindow");
            this.buttonResize.UseText = false;
            this.buttonResize.UseVisualStyleBackColor = false;
            // 
            // toolTip
            // 
            this.toolTip.IsBalloon = true;
            // 
            // buttonNotification
            // 
            this.buttonNotification.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
                                                       System.Windows.Forms.AnchorStyles.Left)));
            this.buttonNotification.BackColor = System.Drawing.Color.Transparent;
            this.buttonNotification.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNotification.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))),
                ((int) (((byte) (255)))), ((int) (((byte) (255)))), ((int) (((byte) (255)))));
            this.buttonNotification.FlatAppearance.BorderSize = 0;
            this.buttonNotification.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonNotification.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonNotification.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonNotification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNotification.Image = ((System.Drawing.Image) (resources.GetObject("buttonNotification.Image")));
            this.buttonNotification.Location = new System.Drawing.Point(12, 480);
            this.buttonNotification.Name = "buttonNotification";
            this.buttonNotification.NotTransparent = false;
            this.buttonNotification.Size = new System.Drawing.Size(25, 25);
            this.buttonNotification.TabIndex = 9;
            this.toolTip.SetToolTip(this.buttonNotification, "Window.Layout.NotificationUser");
            this.buttonNotification.UseText = false;
            this.buttonNotification.UseVisualStyleBackColor = false;
            this.buttonNotification.Click += new System.EventHandler(this.buttonNotification_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.Transparent;
            this.panelLogo.BackgroundImage = global::Cabster.Properties.Resources.FormHeaderSapiensia;
            this.panelLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelLogo.Location = new System.Drawing.Point(0, 50);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(5, 100);
            this.panelLogo.TabIndex = 6;
            this.panelLogo.Visible = false;
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom |
                                                        System.Windows.Forms.AnchorStyles.Left) |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.labelStatus.BackColor = System.Drawing.Color.Transparent;
            this.labelStatus.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.labelStatus.Location = new System.Drawing.Point(43, 480);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(758, 25);
            this.labelStatus.TabIndex = 10;
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timerStatus
            // 
            this.timerStatus.Interval = 3000;
            this.timerStatus.Tick += new System.EventHandler(this.timerStatus_Tick);
            // 
            // panelMarginLeft
            // 
            this.panelMarginLeft.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (32)))),
                ((int) (((byte) (32)))), ((int) (((byte) (32)))));
            this.panelMarginLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMarginLeft.Location = new System.Drawing.Point(0, 50);
            this.panelMarginLeft.Name = "panelMarginLeft";
            this.panelMarginLeft.Size = new System.Drawing.Size(1, 464);
            this.panelMarginLeft.TabIndex = 6;
            // 
            // panelMarginRight
            // 
            this.panelMarginRight.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (32)))),
                ((int) (((byte) (32)))), ((int) (((byte) (32)))));
            this.panelMarginRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelMarginRight.Location = new System.Drawing.Point(830, 50);
            this.panelMarginRight.Name = "panelMarginRight";
            this.panelMarginRight.Size = new System.Drawing.Size(1, 464);
            this.panelMarginRight.TabIndex = 7;
            // 
            // panelMarginBottom
            // 
            this.panelMarginBottom.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (32)))),
                ((int) (((byte) (32)))), ((int) (((byte) (32)))));
            this.panelMarginBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelMarginBottom.Location = new System.Drawing.Point(1, 513);
            this.panelMarginBottom.Name = "panelMarginBottom";
            this.panelMarginBottom.Size = new System.Drawing.Size(829, 1);
            this.panelMarginBottom.TabIndex = 8;
            // 
            // FormLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (64)))), ((int) (((byte) (64)))),
                ((int) (((byte) (64)))));
            this.BackgroundImage = global::Cabster.Properties.Resources.FormLayoutBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(831, 514);
            this.Controls.Add(this.panelMarginBottom);
            this.Controls.Add(this.panelMarginRight);
            this.Controls.Add(this.panelMarginLeft);
            this.Controls.Add(this.buttonNotification);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.panelLogo);
            this.Controls.Add(this.buttonResize);
            this.Controls.Add(this.panelTitle);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (224)))), ((int) (((byte) (224)))),
                ((int) (((byte) (224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "FormLayout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormLayout";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLayout_FormClosing);
            this.SizeChanged += new System.EventHandler(this.FormLayout_SizeChanged);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormLayout_KeyUp);
            this.panelTitle.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Panel panelTitleMarginLeft;
        private System.Windows.Forms.Panel panelTitleMarginRight;
        private Cabster.Components.MyButton buttonResize;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Timer timerStatus;
        private Cabster.Components.MyButton buttonNotification;
        private Cabster.Components.MyButton buttonMinimize;
        private Cabster.Components.MyButton buttonClose;
        private System.Windows.Forms.Panel panelMarginLeft;
        private System.Windows.Forms.Panel panelMarginRight;
        private System.Windows.Forms.Panel panelMarginBottom;
        protected System.Windows.Forms.ToolTip toolTip;
    }
}