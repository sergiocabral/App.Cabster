namespace Cabster.Components
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
            this.panelTitle = new System.Windows.Forms.Panel();
            this.panelTitleRight = new System.Windows.Forms.Panel();
            this.panelTitleLeft = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.Controls.Add(this.labelTitle);
            this.panelTitle.Controls.Add(this.panelTitleLeft);
            this.panelTitle.Controls.Add(this.panelTitleRight);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(1029, 44);
            this.panelTitle.TabIndex = 0;
            // 
            // panelTitleRight
            // 
            this.panelTitleRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelTitleRight.Location = new System.Drawing.Point(729, 0);
            this.panelTitleRight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelTitleRight.Name = "panelTitleRight";
            this.panelTitleRight.Size = new System.Drawing.Size(300, 44);
            this.panelTitleRight.TabIndex = 2;
            // 
            // panelTitleLeft
            // 
            this.panelTitleLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTitleLeft.Location = new System.Drawing.Point(0, 0);
            this.panelTitleLeft.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelTitleLeft.Name = "panelTitleLeft";
            this.panelTitleLeft.Size = new System.Drawing.Size(30, 44);
            this.panelTitleLeft.TabIndex = 4;
            // 
            // labelTitle
            // 
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(30, 0);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(699, 44);
            this.labelTitle.TabIndex = 5;
            this.labelTitle.Text = "labelTitle";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(523, 248);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FormLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImage = global::Cabster.Properties.Resources.FormBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1029, 570);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panelTitle);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormLayout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormLayout";
            this.panelTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelTitleLeft;
        private System.Windows.Forms.Panel panelTitleRight;
        private System.Windows.Forms.Button button1;
    }
}