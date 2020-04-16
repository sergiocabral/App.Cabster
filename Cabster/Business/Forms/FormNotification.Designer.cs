namespace Cabster.Business.Forms
{
    partial class FormNotification
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
                new System.ComponentModel.ComponentResourceManager(typeof(FormNotification));
            this.timerToSaveShortcut = new System.Windows.Forms.Timer(this.components);
            this.panelMessages = new System.Windows.Forms.Panel();
            this.labelNoNotification = new System.Windows.Forms.Label();
            this.panelMessages.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMessages
            // 
            this.panelMessages.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top |
                                                         System.Windows.Forms.AnchorStyles.Bottom) |
                                                        System.Windows.Forms.AnchorStyles.Left) |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.panelMessages.AutoScroll = true;
            this.panelMessages.BackColor = System.Drawing.Color.Transparent;
            this.panelMessages.Controls.Add(this.labelNoNotification);
            this.panelMessages.Location = new System.Drawing.Point(18, 68);
            this.panelMessages.Name = "panelMessages";
            this.panelMessages.Size = new System.Drawing.Size(414, 214);
            this.panelMessages.TabIndex = 12;
            // 
            // labelNoNotification
            // 
            this.labelNoNotification.AutoSize = true;
            this.labelNoNotification.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelNoNotification.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (224)))),
                ((int) (((byte) (224)))), ((int) (((byte) (224)))));
            this.labelNoNotification.Location = new System.Drawing.Point(0, 0);
            this.labelNoNotification.Name = "labelNoNotification";
            this.labelNoNotification.Size = new System.Drawing.Size(256, 19);
            this.labelNoNotification.TabIndex = 0;
            this.labelNoNotification.Text = "Window.Notification.NoNotification";
            // 
            // FormNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 300);
            this.Controls.Add(this.panelMessages);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Name = "FormNotification";
            this.ShowButtonMinimize = true;
            this.Text = "Window.Notification.WindowTitle";
            this.Controls.SetChildIndex(this.panelMessages, 0);
            this.panelMessages.ResumeLayout(false);
            this.panelMessages.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer timerToSaveShortcut;
        private System.Windows.Forms.Panel panelMessages;
        private System.Windows.Forms.Label labelNoNotification;
    }
}