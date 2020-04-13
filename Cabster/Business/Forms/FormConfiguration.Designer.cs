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
            this.buttonLanguageEnglish = new Cabster.Components.MyButton(this.components);
            this.buttonLanguagePortuguese = new Cabster.Components.MyButton(this.components);
            this.labelLanguage = new System.Windows.Forms.Label();
            this.labelShortcut = new System.Windows.Forms.Label();
            this.checkBoxShortcutControl = new System.Windows.Forms.CheckBox();
            this.checkBoxShortcutShift = new System.Windows.Forms.CheckBox();
            this.checkBoxShortcutAlt = new System.Windows.Forms.CheckBox();
            this.textBoxShortcutLetter = new System.Windows.Forms.TextBox();
            this.timerToSaveShortcut = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
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
            this.buttonLanguageEnglish.Location = new System.Drawing.Point(19, 153);
            this.buttonLanguageEnglish.Name = "buttonLanguageEnglish";
            this.buttonLanguageEnglish.NotTransparent = false;
            this.buttonLanguageEnglish.Size = new System.Drawing.Size(566, 50);
            this.buttonLanguageEnglish.TabIndex = 8;
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
            this.buttonLanguagePortuguese.Location = new System.Drawing.Point(19, 100);
            this.buttonLanguagePortuguese.Name = "buttonLanguagePortuguese";
            this.buttonLanguagePortuguese.NotTransparent = false;
            this.buttonLanguagePortuguese.Size = new System.Drawing.Size(566, 50);
            this.buttonLanguagePortuguese.TabIndex = 7;
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
            this.labelLanguage.BackColor = System.Drawing.Color.Transparent;
            this.labelLanguage.Location = new System.Drawing.Point(12, 70);
            this.labelLanguage.Name = "labelLanguage";
            this.labelLanguage.Size = new System.Drawing.Size(576, 21);
            this.labelLanguage.TabIndex = 6;
            this.labelLanguage.Text = "Text.Configuration.LanguageSelect";
            // 
            // labelShortcut
            // 
            this.labelShortcut.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left) |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.labelShortcut.BackColor = System.Drawing.Color.Transparent;
            this.labelShortcut.Location = new System.Drawing.Point(12, 220);
            this.labelShortcut.Name = "labelShortcut";
            this.labelShortcut.Size = new System.Drawing.Size(576, 21);
            this.labelShortcut.TabIndex = 9;
            this.labelShortcut.Text = "Text.Configuration.Shortcut";
            // 
            // checkBoxShortcutControl
            // 
            this.checkBoxShortcutControl.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxShortcutControl.AutoSize = true;
            this.checkBoxShortcutControl.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (127)))),
                ((int) (((byte) (127)))), ((int) (((byte) (127)))));
            this.checkBoxShortcutControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxShortcutControl.FlatAppearance.BorderColor =
                System.Drawing.Color.FromArgb(((int) (((byte) (224)))), ((int) (((byte) (224)))),
                    ((int) (((byte) (224)))));
            this.checkBoxShortcutControl.FlatAppearance.CheckedBackColor =
                System.Drawing.Color.FromArgb(((int) (((byte) (250)))), ((int) (((byte) (180)))),
                    ((int) (((byte) (20)))));
            this.checkBoxShortcutControl.FlatAppearance.MouseDownBackColor =
                System.Drawing.Color.FromArgb(((int) (((byte) (250)))), ((int) (((byte) (180)))),
                    ((int) (((byte) (20)))));
            this.checkBoxShortcutControl.FlatAppearance.MouseOverBackColor =
                System.Drawing.Color.FromArgb(((int) (((byte) (250)))), ((int) (((byte) (200)))),
                    ((int) (((byte) (100)))));
            this.checkBoxShortcutControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxShortcutControl.ForeColor = System.Drawing.Color.Black;
            this.checkBoxShortcutControl.Location = new System.Drawing.Point(26, 256);
            this.checkBoxShortcutControl.Name = "checkBoxShortcutControl";
            this.checkBoxShortcutControl.Size = new System.Drawing.Size(92, 29);
            this.checkBoxShortcutControl.TabIndex = 10;
            this.checkBoxShortcutControl.Text = "CONTROL";
            this.checkBoxShortcutControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxShortcutControl.UseVisualStyleBackColor = false;
            this.checkBoxShortcutControl.CheckedChanged +=
                new System.EventHandler(this.checkBoxShortcut_CheckedChanged);
            // 
            // checkBoxShortcutShift
            // 
            this.checkBoxShortcutShift.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxShortcutShift.AutoSize = true;
            this.checkBoxShortcutShift.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (127)))),
                ((int) (((byte) (127)))), ((int) (((byte) (127)))));
            this.checkBoxShortcutShift.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxShortcutShift.FlatAppearance.BorderColor =
                System.Drawing.Color.FromArgb(((int) (((byte) (224)))), ((int) (((byte) (224)))),
                    ((int) (((byte) (224)))));
            this.checkBoxShortcutShift.FlatAppearance.CheckedBackColor =
                System.Drawing.Color.FromArgb(((int) (((byte) (250)))), ((int) (((byte) (180)))),
                    ((int) (((byte) (20)))));
            this.checkBoxShortcutShift.FlatAppearance.MouseDownBackColor =
                System.Drawing.Color.FromArgb(((int) (((byte) (250)))), ((int) (((byte) (180)))),
                    ((int) (((byte) (20)))));
            this.checkBoxShortcutShift.FlatAppearance.MouseOverBackColor =
                System.Drawing.Color.FromArgb(((int) (((byte) (250)))), ((int) (((byte) (200)))),
                    ((int) (((byte) (100)))));
            this.checkBoxShortcutShift.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxShortcutShift.ForeColor = System.Drawing.Color.Black;
            this.checkBoxShortcutShift.Location = new System.Drawing.Point(130, 256);
            this.checkBoxShortcutShift.Name = "checkBoxShortcutShift";
            this.checkBoxShortcutShift.Size = new System.Drawing.Size(63, 29);
            this.checkBoxShortcutShift.TabIndex = 11;
            this.checkBoxShortcutShift.Text = "SHIFT";
            this.checkBoxShortcutShift.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxShortcutShift.UseVisualStyleBackColor = false;
            this.checkBoxShortcutShift.CheckedChanged += new System.EventHandler(this.checkBoxShortcut_CheckedChanged);
            // 
            // checkBoxShortcutAlt
            // 
            this.checkBoxShortcutAlt.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxShortcutAlt.AutoSize = true;
            this.checkBoxShortcutAlt.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (127)))),
                ((int) (((byte) (127)))), ((int) (((byte) (127)))));
            this.checkBoxShortcutAlt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxShortcutAlt.FlatAppearance.BorderColor =
                System.Drawing.Color.FromArgb(((int) (((byte) (224)))), ((int) (((byte) (224)))),
                    ((int) (((byte) (224)))));
            this.checkBoxShortcutAlt.FlatAppearance.CheckedBackColor =
                System.Drawing.Color.FromArgb(((int) (((byte) (250)))), ((int) (((byte) (180)))),
                    ((int) (((byte) (20)))));
            this.checkBoxShortcutAlt.FlatAppearance.MouseDownBackColor =
                System.Drawing.Color.FromArgb(((int) (((byte) (250)))), ((int) (((byte) (180)))),
                    ((int) (((byte) (20)))));
            this.checkBoxShortcutAlt.FlatAppearance.MouseOverBackColor =
                System.Drawing.Color.FromArgb(((int) (((byte) (250)))), ((int) (((byte) (200)))),
                    ((int) (((byte) (100)))));
            this.checkBoxShortcutAlt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxShortcutAlt.ForeColor = System.Drawing.Color.Black;
            this.checkBoxShortcutAlt.Location = new System.Drawing.Point(205, 256);
            this.checkBoxShortcutAlt.Name = "checkBoxShortcutAlt";
            this.checkBoxShortcutAlt.Size = new System.Drawing.Size(48, 29);
            this.checkBoxShortcutAlt.TabIndex = 12;
            this.checkBoxShortcutAlt.Text = "ALT";
            this.checkBoxShortcutAlt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxShortcutAlt.UseVisualStyleBackColor = false;
            this.checkBoxShortcutAlt.CheckedChanged += new System.EventHandler(this.checkBoxShortcut_CheckedChanged);
            // 
            // textBoxShortcutLetter
            // 
            this.textBoxShortcutLetter.BackColor = System.Drawing.Color.White;
            this.textBoxShortcutLetter.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.textBoxShortcutLetter.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (64)))),
                ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.textBoxShortcutLetter.Location = new System.Drawing.Point(265, 257);
            this.textBoxShortcutLetter.MaxLength = 1;
            this.textBoxShortcutLetter.Name = "textBoxShortcutLetter";
            this.textBoxShortcutLetter.Size = new System.Drawing.Size(37, 27);
            this.textBoxShortcutLetter.TabIndex = 13;
            this.textBoxShortcutLetter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxShortcutLetter.TextChanged += new System.EventHandler(this.textBoxShortcutLetter_TextChanged);
            this.textBoxShortcutLetter.Enter += new System.EventHandler(this.textBoxShortcutLetter_TextChanged);
            this.textBoxShortcutLetter.MouseUp +=
                new System.Windows.Forms.MouseEventHandler(this.textBoxShortcutLetter_TextChanged);
            // 
            // timerToSaveShortcut
            // 
            this.timerToSaveShortcut.Interval = 1000;
            this.timerToSaveShortcut.Tick += new System.EventHandler(this.timerToSaveShortcut_Tick);
            // 
            // FormConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.textBoxShortcutLetter);
            this.Controls.Add(this.checkBoxShortcutAlt);
            this.Controls.Add(this.checkBoxShortcutShift);
            this.Controls.Add(this.checkBoxShortcutControl);
            this.Controls.Add(this.labelShortcut);
            this.Controls.Add(this.buttonLanguageEnglish);
            this.Controls.Add(this.buttonLanguagePortuguese);
            this.Controls.Add(this.labelLanguage);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Name = "FormConfiguration";
            this.Text = "Text.Configuration.WindowTitle";
            this.Controls.SetChildIndex(this.labelLanguage, 0);
            this.Controls.SetChildIndex(this.buttonLanguagePortuguese, 0);
            this.Controls.SetChildIndex(this.buttonLanguageEnglish, 0);
            this.Controls.SetChildIndex(this.labelShortcut, 0);
            this.Controls.SetChildIndex(this.checkBoxShortcutControl, 0);
            this.Controls.SetChildIndex(this.checkBoxShortcutShift, 0);
            this.Controls.SetChildIndex(this.checkBoxShortcutAlt, 0);
            this.Controls.SetChildIndex(this.textBoxShortcutLetter, 0);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelLanguage;
        private Cabster.Components.MyButton buttonLanguagePortuguese;
        private Cabster.Components.MyButton buttonLanguageEnglish;
        private System.Windows.Forms.Label labelShortcut;
        private System.Windows.Forms.CheckBox checkBoxShortcutControl;
        private System.Windows.Forms.CheckBox checkBoxShortcutShift;
        private System.Windows.Forms.CheckBox checkBoxShortcutAlt;
        private System.Windows.Forms.TextBox textBoxShortcutLetter;
        private System.Windows.Forms.Timer timerToSaveShortcut;
    }
}