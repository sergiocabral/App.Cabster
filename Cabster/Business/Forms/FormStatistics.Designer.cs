namespace Cabster.Business.Forms
{
    partial class FormStatistics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStatistics));
            this.labelStart = new System.Windows.Forms.Label();
            this.labelRoundWork = new System.Windows.Forms.Label();
            this.labelTimeWork = new System.Windows.Forms.Label();
            this.labelRoundBreak = new System.Windows.Forms.Label();
            this.labelTimeBreak = new System.Windows.Forms.Label();
            this.buttonReset = new Cabster.Components.MyButton(this.components);
            this.labelStartValue = new System.Windows.Forms.Label();
            this.labelRoundWorkValue = new System.Windows.Forms.Label();
            this.labelTimeWorkValue = new System.Windows.Forms.Label();
            this.labelRoundBreakValue = new System.Windows.Forms.Label();
            this.labelTimeBreakValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelStart
            // 
            this.labelStart.BackColor = System.Drawing.Color.Transparent;
            this.labelStart.ForeColor = System.Drawing.Color.Silver;
            this.labelStart.Location = new System.Drawing.Point(15, 70);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(232, 19);
            this.labelStart.TabIndex = 12;
            this.labelStart.Text = "Window.Statistics.LabelStart";
            this.labelStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelRoundWork
            // 
            this.labelRoundWork.BackColor = System.Drawing.Color.Transparent;
            this.labelRoundWork.ForeColor = System.Drawing.Color.Silver;
            this.labelRoundWork.Location = new System.Drawing.Point(15, 100);
            this.labelRoundWork.Name = "labelRoundWork";
            this.labelRoundWork.Size = new System.Drawing.Size(232, 19);
            this.labelRoundWork.TabIndex = 13;
            this.labelRoundWork.Text = "Window.Statistics.LabelRoundWork";
            this.labelRoundWork.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelTimeWork
            // 
            this.labelTimeWork.BackColor = System.Drawing.Color.Transparent;
            this.labelTimeWork.ForeColor = System.Drawing.Color.Silver;
            this.labelTimeWork.Location = new System.Drawing.Point(15, 130);
            this.labelTimeWork.Name = "labelTimeWork";
            this.labelTimeWork.Size = new System.Drawing.Size(232, 19);
            this.labelTimeWork.TabIndex = 14;
            this.labelTimeWork.Text = "Window.Statistics.LabelTimeWork";
            this.labelTimeWork.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelRoundBreak
            // 
            this.labelRoundBreak.BackColor = System.Drawing.Color.Transparent;
            this.labelRoundBreak.ForeColor = System.Drawing.Color.Silver;
            this.labelRoundBreak.Location = new System.Drawing.Point(15, 160);
            this.labelRoundBreak.Name = "labelRoundBreak";
            this.labelRoundBreak.Size = new System.Drawing.Size(232, 19);
            this.labelRoundBreak.TabIndex = 15;
            this.labelRoundBreak.Text = "Window.Statistics.LabelRoundBreak";
            this.labelRoundBreak.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelTimeBreak
            // 
            this.labelTimeBreak.BackColor = System.Drawing.Color.Transparent;
            this.labelTimeBreak.ForeColor = System.Drawing.Color.Silver;
            this.labelTimeBreak.Location = new System.Drawing.Point(15, 190);
            this.labelTimeBreak.Name = "labelTimeBreak";
            this.labelTimeBreak.Size = new System.Drawing.Size(232, 19);
            this.labelTimeBreak.TabIndex = 16;
            this.labelTimeBreak.Text = "Window.Statistics.LabelTimeBreak";
            this.labelTimeBreak.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonReset
            // 
            this.buttonReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonReset.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.buttonReset.FlatAppearance.BorderSize = 3;
            this.buttonReset.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.buttonReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.buttonReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.buttonReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReset.Location = new System.Drawing.Point(19, 236);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.NotTransparent = false;
            this.buttonReset.Size = new System.Drawing.Size(228, 36);
            this.buttonReset.TabIndex = 17;
            this.buttonReset.Text = "Window.Statistics.ButtonReset";
            this.toolTip.SetToolTip(this.buttonReset, "Window.Statistics.ButtonResetHint");
            this.buttonReset.UseText = false;
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // labelStartValue
            // 
            this.labelStartValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStartValue.BackColor = System.Drawing.Color.Transparent;
            this.labelStartValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelStartValue.Location = new System.Drawing.Point(253, 70);
            this.labelStartValue.Name = "labelStartValue";
            this.labelStartValue.Size = new System.Drawing.Size(185, 19);
            this.labelStartValue.TabIndex = 18;
            this.labelStartValue.Text = "???";
            this.labelStartValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelRoundWorkValue
            // 
            this.labelRoundWorkValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRoundWorkValue.BackColor = System.Drawing.Color.Transparent;
            this.labelRoundWorkValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelRoundWorkValue.Location = new System.Drawing.Point(253, 100);
            this.labelRoundWorkValue.Name = "labelRoundWorkValue";
            this.labelRoundWorkValue.Size = new System.Drawing.Size(185, 19);
            this.labelRoundWorkValue.TabIndex = 19;
            this.labelRoundWorkValue.Text = "???";
            this.labelRoundWorkValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTimeWorkValue
            // 
            this.labelTimeWorkValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTimeWorkValue.BackColor = System.Drawing.Color.Transparent;
            this.labelTimeWorkValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelTimeWorkValue.Location = new System.Drawing.Point(253, 130);
            this.labelTimeWorkValue.Name = "labelTimeWorkValue";
            this.labelTimeWorkValue.Size = new System.Drawing.Size(185, 19);
            this.labelTimeWorkValue.TabIndex = 20;
            this.labelTimeWorkValue.Text = "???";
            this.labelTimeWorkValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelRoundBreakValue
            // 
            this.labelRoundBreakValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRoundBreakValue.BackColor = System.Drawing.Color.Transparent;
            this.labelRoundBreakValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelRoundBreakValue.Location = new System.Drawing.Point(253, 160);
            this.labelRoundBreakValue.Name = "labelRoundBreakValue";
            this.labelRoundBreakValue.Size = new System.Drawing.Size(185, 19);
            this.labelRoundBreakValue.TabIndex = 21;
            this.labelRoundBreakValue.Text = "???";
            this.labelRoundBreakValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTimeBreakValue
            // 
            this.labelTimeBreakValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTimeBreakValue.BackColor = System.Drawing.Color.Transparent;
            this.labelTimeBreakValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelTimeBreakValue.Location = new System.Drawing.Point(253, 190);
            this.labelTimeBreakValue.Name = "labelTimeBreakValue";
            this.labelTimeBreakValue.Size = new System.Drawing.Size(185, 19);
            this.labelTimeBreakValue.TabIndex = 22;
            this.labelTimeBreakValue.Text = "???";
            this.labelTimeBreakValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 330);
            this.Controls.Add(this.labelTimeBreakValue);
            this.Controls.Add(this.labelRoundBreakValue);
            this.Controls.Add(this.labelTimeWorkValue);
            this.Controls.Add(this.labelRoundWorkValue);
            this.Controls.Add(this.labelStartValue);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.labelTimeBreak);
            this.Controls.Add(this.labelRoundBreak);
            this.Controls.Add(this.labelTimeWork);
            this.Controls.Add(this.labelRoundWork);
            this.Controls.Add(this.labelStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(370, 330);
            this.Name = "FormStatistics";
            this.ShowButtonClose = true;
            this.ShowButtonMinimize = true;
            this.Text = "Window.Statistics.WindowTitle";
            this.Controls.SetChildIndex(this.labelStart, 0);
            this.Controls.SetChildIndex(this.labelRoundWork, 0);
            this.Controls.SetChildIndex(this.labelTimeWork, 0);
            this.Controls.SetChildIndex(this.labelRoundBreak, 0);
            this.Controls.SetChildIndex(this.labelTimeBreak, 0);
            this.Controls.SetChildIndex(this.buttonReset, 0);
            this.Controls.SetChildIndex(this.labelStartValue, 0);
            this.Controls.SetChildIndex(this.labelRoundWorkValue, 0);
            this.Controls.SetChildIndex(this.labelTimeWorkValue, 0);
            this.Controls.SetChildIndex(this.labelRoundBreakValue, 0);
            this.Controls.SetChildIndex(this.labelTimeBreakValue, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelStart;
        private System.Windows.Forms.Label labelRoundWork;
        private System.Windows.Forms.Label labelTimeWork;
        private System.Windows.Forms.Label labelRoundBreak;
        private System.Windows.Forms.Label labelTimeBreak;
        private System.Windows.Forms.Label labelStartValue;
        private System.Windows.Forms.Label labelRoundWorkValue;
        private System.Windows.Forms.Label labelTimeWorkValue;
        private System.Windows.Forms.Label labelRoundBreakValue;
        private System.Windows.Forms.Label labelTimeBreakValue;
        private Cabster.Components.MyButton buttonReset;
    }
}