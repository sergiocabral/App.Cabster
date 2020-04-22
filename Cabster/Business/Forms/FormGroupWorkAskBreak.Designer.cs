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
            this.labelDescription = new System.Windows.Forms.Label();
            this.buttonSkip = new Cabster.Components.MyButton(this.components);
            this.buttonAccept = new Cabster.Components.MyButton(this.components);
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
            // labelDescription
            // 
            this.labelDescription.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top |
                                                         System.Windows.Forms.AnchorStyles.Bottom) |
                                                        System.Windows.Forms.AnchorStyles.Left) |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.labelDescription.BackColor = System.Drawing.Color.Transparent;
            this.labelDescription.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.labelDescription.Location = new System.Drawing.Point(12, 153);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(676, 152);
            this.labelDescription.TabIndex = 12;
            this.labelDescription.Text = "Window.GroupWorkAskBreak.Description";
            this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonSkip
            // 
            this.buttonSkip.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonSkip.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSkip.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int) (((byte) (140)))),
                ((int) (((byte) (140)))), ((int) (((byte) (140)))));
            this.buttonSkip.FlatAppearance.BorderSize = 3;
            this.buttonSkip.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (29)))),
                ((int) (((byte) (29)))), ((int) (((byte) (29)))));
            this.buttonSkip.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (29)))),
                ((int) (((byte) (29)))), ((int) (((byte) (29)))));
            this.buttonSkip.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (34)))),
                ((int) (((byte) (34)))), ((int) (((byte) (34)))));
            this.buttonSkip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSkip.Location = new System.Drawing.Point(12, 308);
            this.buttonSkip.Name = "buttonSkip";
            this.buttonSkip.NotTransparent = false;
            this.buttonSkip.Size = new System.Drawing.Size(330, 51);
            this.buttonSkip.TabIndex = 13;
            this.buttonSkip.Text = "Window.GroupWorkAskBreak.Skip";
            this.buttonSkip.UseText = false;
            this.buttonSkip.UseVisualStyleBackColor = true;
            this.buttonSkip.Click += new System.EventHandler(this.buttonSkip_Click);
            // 
            // buttonAccept
            // 
            this.buttonAccept.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonAccept.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (250)))),
                ((int) (((byte) (180)))), ((int) (((byte) (20)))));
            this.buttonAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAccept.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int) (((byte) (252)))),
                ((int) (((byte) (210)))), ((int) (((byte) (114)))));
            this.buttonAccept.FlatAppearance.BorderSize = 3;
            this.buttonAccept.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (123)))),
                ((int) (((byte) (87)))), ((int) (((byte) (2)))));
            this.buttonAccept.FlatAppearance.MouseDownBackColor =
                System.Drawing.Color.FromArgb(((int) (((byte) (123)))), ((int) (((byte) (87)))),
                    ((int) (((byte) (2)))));
            this.buttonAccept.FlatAppearance.MouseOverBackColor =
                System.Drawing.Color.FromArgb(((int) (((byte) (141)))), ((int) (((byte) (100)))),
                    ((int) (((byte) (3)))));
            this.buttonAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAccept.Location = new System.Drawing.Point(358, 308);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.NotTransparent = false;
            this.buttonAccept.Size = new System.Drawing.Size(330, 51);
            this.buttonAccept.TabIndex = 14;
            this.buttonAccept.Text = "Window.GroupWorkAskBreak.Accept";
            this.buttonAccept.UseText = false;
            this.buttonAccept.UseVisualStyleBackColor = false;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // FormGroupWorkAskBreak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 400);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.buttonSkip);
            this.Controls.Add(this.labelDescription);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "FormGroupWorkAskBreak";
            this.ShowButtonMinimize = true;
            this.ShowLogo = true;
            this.Text = "Window.GroupWorkAskBreak.WindowTitle";
            this.Controls.SetChildIndex(this.labelDescription, 0);
            this.Controls.SetChildIndex(this.buttonSkip, 0);
            this.Controls.SetChildIndex(this.buttonAccept, 0);
            this.ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer timerToSaveParticipants;
        private System.Windows.Forms.Timer timerToSaveTimes;
        private System.Windows.Forms.Label labelDescription;
        private Cabster.Components.MyButton buttonAccept;
        private Cabster.Components.MyButton buttonSkip;
    }
}