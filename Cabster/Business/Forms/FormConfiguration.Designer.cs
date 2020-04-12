namespace Cabster.Business.Forms
{
    partial class FormConfiguration
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
                new System.ComponentModel.ComponentResourceManager(typeof(FormConfiguration));
            this.panelLanguage = new System.Windows.Forms.Panel();
            this.buttonLanguageEnglish = new Cabster.Components.MyButton(this.components);
            this.buttonLanguagePortuguese = new Cabster.Components.MyButton(this.components);
            this.labelLanguage = new System.Windows.Forms.Label();
            this.panelLanguage.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLanguage
            // 
            this.panelLanguage.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left) |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.panelLanguage.BackColor = System.Drawing.Color.Transparent;
            this.panelLanguage.Controls.Add(this.buttonLanguageEnglish);
            this.panelLanguage.Controls.Add(this.buttonLanguagePortuguese);
            this.panelLanguage.Controls.Add(this.labelLanguage);
            this.panelLanguage.Location = new System.Drawing.Point(15, 64);
            this.panelLanguage.Name = "panelLanguage";
            this.panelLanguage.Size = new System.Drawing.Size(570, 135);
            this.panelLanguage.TabIndex = 11;
            // 
            // buttonLanguageEnglish
            // 
            this.buttonLanguageEnglish.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left) |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLanguageEnglish.BackColor = System.Drawing.Color.Transparent;
            this.buttonLanguageEnglish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLanguageEnglish.FlatAppearance.BorderColor =
                System.Drawing.Color.FromArgb(((int) (((byte) (255)))), ((int) (((byte) (255)))),
                    ((int) (((byte) (255)))));
            this.buttonLanguageEnglish.FlatAppearance.BorderSize = 0;
            this.buttonLanguageEnglish.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonLanguageEnglish.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonLanguageEnglish.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonLanguageEnglish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLanguageEnglish.Image =
                ((System.Drawing.Image) (resources.GetObject("buttonLanguageEnglish.Image")));
            this.buttonLanguageEnglish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLanguageEnglish.Location = new System.Drawing.Point(22, 83);
            this.buttonLanguageEnglish.Name = "buttonLanguageEnglish";
            this.buttonLanguageEnglish.NotTransparent = false;
            this.buttonLanguageEnglish.Size = new System.Drawing.Size(526, 50);
            this.buttonLanguageEnglish.TabIndex = 2;
            this.buttonLanguageEnglish.Text = "           Text.Configuration.LanguageEnglish";
            this.buttonLanguageEnglish.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLanguageEnglish.UseText = true;
            this.buttonLanguageEnglish.UseVisualStyleBackColor = false;
            this.buttonLanguageEnglish.Click += new System.EventHandler(this.buttonLanguage_Click);
            // 
            // buttonLanguagePortuguese
            // 
            this.buttonLanguagePortuguese.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left) |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLanguagePortuguese.BackColor = System.Drawing.Color.Transparent;
            this.buttonLanguagePortuguese.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLanguagePortuguese.FlatAppearance.BorderColor =
                System.Drawing.Color.FromArgb(((int) (((byte) (255)))), ((int) (((byte) (255)))),
                    ((int) (((byte) (255)))));
            this.buttonLanguagePortuguese.FlatAppearance.BorderSize = 0;
            this.buttonLanguagePortuguese.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonLanguagePortuguese.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonLanguagePortuguese.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonLanguagePortuguese.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLanguagePortuguese.Image =
                ((System.Drawing.Image) (resources.GetObject("buttonLanguagePortuguese.Image")));
            this.buttonLanguagePortuguese.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLanguagePortuguese.Location = new System.Drawing.Point(22, 36);
            this.buttonLanguagePortuguese.Name = "buttonLanguagePortuguese";
            this.buttonLanguagePortuguese.NotTransparent = false;
            this.buttonLanguagePortuguese.Size = new System.Drawing.Size(526, 50);
            this.buttonLanguagePortuguese.TabIndex = 1;
            this.buttonLanguagePortuguese.Text = "           Text.Configuration.LanguagePortuguese";
            this.buttonLanguagePortuguese.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLanguagePortuguese.UseText = true;
            this.buttonLanguagePortuguese.UseVisualStyleBackColor = false;
            this.buttonLanguagePortuguese.Click += new System.EventHandler(this.buttonLanguage_Click);
            // 
            // labelLanguage
            // 
            this.labelLanguage.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left) |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.labelLanguage.Location = new System.Drawing.Point(12, 12);
            this.labelLanguage.Name = "labelLanguage";
            this.labelLanguage.Size = new System.Drawing.Size(546, 21);
            this.labelLanguage.TabIndex = 0;
            this.labelLanguage.Text = "Text.Configuration.LanguageSelect";
            // 
            // FormConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.panelLanguage);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Name = "FormConfiguration";
            this.Text = "Text.Configuration.WindowTitle";
            this.Controls.SetChildIndex(this.panelLanguage, 0);
            this.panelLanguage.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label labelLanguage;
        private Cabster.Components.MyButton buttonLanguagePortuguese;
        private Cabster.Components.MyButton buttonLanguageEnglish;
        private System.Windows.Forms.Panel panelLanguage;
    }
}