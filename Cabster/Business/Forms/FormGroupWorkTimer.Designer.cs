namespace Cabster.Business.Forms
{
    partial class FormGroupWorkTimer
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
            this.labelDriverIcon = new System.Windows.Forms.Label();
            this.labelNavigatorIcon = new System.Windows.Forms.Label();
            this.labelDriver = new System.Windows.Forms.Label();
            this.labelNavigator = new System.Windows.Forms.Label();
            this.labelTimer = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // labelDriverIcon
            // 
            this.labelDriverIcon.Image = global::Cabster.Properties.Resources.iconParticipantDriver;
            this.labelDriverIcon.Location = new System.Drawing.Point(4, 40);
            this.labelDriverIcon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDriverIcon.Name = "labelDriverIcon";
            this.labelDriverIcon.Size = new System.Drawing.Size(35, 35);
            this.labelDriverIcon.TabIndex = 6;
            // 
            // labelNavigatorIcon
            // 
            this.labelNavigatorIcon.Image = global::Cabster.Properties.Resources.iconParticipantNavigator;
            this.labelNavigatorIcon.Location = new System.Drawing.Point(4, 81);
            this.labelNavigatorIcon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNavigatorIcon.Name = "labelNavigatorIcon";
            this.labelNavigatorIcon.Size = new System.Drawing.Size(35, 35);
            this.labelNavigatorIcon.TabIndex = 7;
            // 
            // labelDriver
            // 
            this.labelDriver.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left) |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.labelDriver.AutoEllipsis = true;
            this.labelDriver.Font = new System.Drawing.Font("Calibri", 13F);
            this.labelDriver.Location = new System.Drawing.Point(41, 47);
            this.labelDriver.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDriver.Name = "labelDriver";
            this.labelDriver.Size = new System.Drawing.Size(81, 23);
            this.labelDriver.TabIndex = 9;
            this.labelDriver.Text = "Driver";
            this.labelDriver.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelNavigator
            // 
            this.labelNavigator.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left) |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.labelNavigator.AutoEllipsis = true;
            this.labelNavigator.Font = new System.Drawing.Font("Calibri", 13F);
            this.labelNavigator.Location = new System.Drawing.Point(41, 88);
            this.labelNavigator.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNavigator.Name = "labelNavigator";
            this.labelNavigator.Size = new System.Drawing.Size(81, 23);
            this.labelNavigator.TabIndex = 10;
            this.labelNavigator.Text = "Navigator";
            this.labelNavigator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTimer
            // 
            this.labelTimer.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left) |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.labelTimer.AutoEllipsis = true;
            this.labelTimer.Font = new System.Drawing.Font("Lucida Console", 20F);
            this.labelTimer.Location = new System.Drawing.Point(-1, 0);
            this.labelTimer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(125, 40);
            this.labelTimer.TabIndex = 8;
            this.labelTimer.Text = "00:00";
            this.labelTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // FormGroupWorkTimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(125, 125);
            this.Controls.Add(this.labelTimer);
            this.Controls.Add(this.labelNavigator);
            this.Controls.Add(this.labelDriver);
            this.Controls.Add(this.labelNavigatorIcon);
            this.Controls.Add(this.labelDriverIcon);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.ForeColor = System.Drawing.Color.Gainsboro;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormGroupWorkTimer";
            this.Opacity = 0.6D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FormGroupWorkTimer";
            this.TopMost = true;
            this.ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Label labelDriverIcon;
        private System.Windows.Forms.Label labelNavigatorIcon;
        private System.Windows.Forms.Label labelDriver;
        private System.Windows.Forms.Label labelNavigator;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Timer timer;
    }
}