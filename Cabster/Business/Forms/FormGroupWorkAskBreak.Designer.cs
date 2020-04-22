namespace Cabster.Business.Forms
{
    partial class FormGroupWorkAskBreak
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
                new System.ComponentModel.ComponentResourceManager(typeof(FormGroupWorkAskBreak));
            this.timerToSaveParticipants = new System.Windows.Forms.Timer(this.components);
            this.timerToSaveTimes = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerToSaveParticipants
            // 
            this.timerToSaveParticipants.Interval = 10000;
            // 
            // timerToSaveTimes
            // 
            this.timerToSaveTimes.Interval = 10000;
            // 
            // FormGroupWorkBreak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 400);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "FormGroupWorkBreak";
            this.ShowButtonMinimize = true;
            this.ShowLogo = true;
            this.Text = "Window.GroupWork.WindowTitle";
            this.ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer timerToSaveParticipants;
        private System.Windows.Forms.Timer timerToSaveTimes;
    }
}