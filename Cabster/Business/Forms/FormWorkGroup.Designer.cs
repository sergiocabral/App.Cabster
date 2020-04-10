﻿namespace Cabster.Business.Forms
{
    partial class FormWorkGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWorkGroup));
            this.buttonMinimize = new Cabster.Components.MyButton(this.components);
            this.labelDurationOfEachRound_Part1 = new System.Windows.Forms.Label();
            this.numericUpDownDurationOfEachRound = new System.Windows.Forms.NumericUpDown();
            this.labelDurationOfEachRound_Part2 = new System.Windows.Forms.Label();
            this.labelDurationOfEachBreak_Part2 = new System.Windows.Forms.Label();
            this.numericUpDownDurationOfEachBreak = new System.Windows.Forms.NumericUpDown();
            this.labelDurationOfEachBreak_Part1 = new System.Windows.Forms.Label();
            this.labelBreakStartsAfterHowManyRounds_Part2 = new System.Windows.Forms.Label();
            this.numericUpDownBreakStartsAfterHowManyRounds = new System.Windows.Forms.NumericUpDown();
            this.labelBreakStartsAfterHowManyRounds_Part1 = new System.Windows.Forms.Label();
            this.myFlowPanel1 = new Cabster.Components.MyFlowPanel(this.components);
            this.textBoxAddParticipant = new Cabster.Components.MyTextBox(this.components);
            this.buttonAddParticipant = new Cabster.Components.MyButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDurationOfEachRound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDurationOfEachBreak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBreakStartsAfterHowManyRounds)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonMinimize
            // 
            this.buttonMinimize.BackColor = System.Drawing.Color.Transparent;
            this.buttonMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonMinimize.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.buttonMinimize.FlatAppearance.BorderSize = 0;
            this.buttonMinimize.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinimize.Image = ((System.Drawing.Image)(resources.GetObject("buttonMinimize.Image")));
            this.buttonMinimize.Location = new System.Drawing.Point(620, 0);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.Size = new System.Drawing.Size(50, 50);
            this.buttonMinimize.TabIndex = 12;
            this.buttonMinimize.UseVisualStyleBackColor = false;
            // 
            // labelDurationOfEachRound_Part1
            // 
            this.labelDurationOfEachRound_Part1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelDurationOfEachRound_Part1.BackColor = System.Drawing.Color.Transparent;
            this.labelDurationOfEachRound_Part1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelDurationOfEachRound_Part1.Location = new System.Drawing.Point(12, 370);
            this.labelDurationOfEachRound_Part1.Name = "labelDurationOfEachRound_Part1";
            this.labelDurationOfEachRound_Part1.Size = new System.Drawing.Size(194, 21);
            this.labelDurationOfEachRound_Part1.TabIndex = 3;
            this.labelDurationOfEachRound_Part1.Text = "Text.WorkGroup.DurationOfEachRound_Part1";
            this.labelDurationOfEachRound_Part1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDownDurationOfEachRound
            // 
            this.numericUpDownDurationOfEachRound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDownDurationOfEachRound.BackColor = System.Drawing.Color.WhiteSmoke;
            this.numericUpDownDurationOfEachRound.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownDurationOfEachRound.ForeColor = System.Drawing.Color.Black;
            this.numericUpDownDurationOfEachRound.Location = new System.Drawing.Point(213, 370);
            this.numericUpDownDurationOfEachRound.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDownDurationOfEachRound.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDurationOfEachRound.Name = "numericUpDownDurationOfEachRound";
            this.numericUpDownDurationOfEachRound.Size = new System.Drawing.Size(70, 27);
            this.numericUpDownDurationOfEachRound.TabIndex = 4;
            this.numericUpDownDurationOfEachRound.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownDurationOfEachRound.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDurationOfEachRound.ValueChanged += new System.EventHandler(this.UpdateControls);
            // 
            // labelDurationOfEachRound_Part2
            // 
            this.labelDurationOfEachRound_Part2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelDurationOfEachRound_Part2.BackColor = System.Drawing.Color.Transparent;
            this.labelDurationOfEachRound_Part2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelDurationOfEachRound_Part2.Location = new System.Drawing.Point(289, 370);
            this.labelDurationOfEachRound_Part2.Name = "labelDurationOfEachRound_Part2";
            this.labelDurationOfEachRound_Part2.Size = new System.Drawing.Size(218, 21);
            this.labelDurationOfEachRound_Part2.TabIndex = 5;
            this.labelDurationOfEachRound_Part2.Text = "Text.WorkGroup.DurationOfEachRound_Part2";
            this.labelDurationOfEachRound_Part2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDurationOfEachBreak_Part2
            // 
            this.labelDurationOfEachBreak_Part2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelDurationOfEachBreak_Part2.BackColor = System.Drawing.Color.Transparent;
            this.labelDurationOfEachBreak_Part2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelDurationOfEachBreak_Part2.Location = new System.Drawing.Point(289, 403);
            this.labelDurationOfEachBreak_Part2.Name = "labelDurationOfEachBreak_Part2";
            this.labelDurationOfEachBreak_Part2.Size = new System.Drawing.Size(218, 21);
            this.labelDurationOfEachBreak_Part2.TabIndex = 8;
            this.labelDurationOfEachBreak_Part2.Text = "Text.WorkGroup.DurationOfEachBreak_Part2";
            this.labelDurationOfEachBreak_Part2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDownDurationOfEachBreak
            // 
            this.numericUpDownDurationOfEachBreak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDownDurationOfEachBreak.BackColor = System.Drawing.Color.WhiteSmoke;
            this.numericUpDownDurationOfEachBreak.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownDurationOfEachBreak.ForeColor = System.Drawing.Color.Black;
            this.numericUpDownDurationOfEachBreak.Location = new System.Drawing.Point(213, 403);
            this.numericUpDownDurationOfEachBreak.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDownDurationOfEachBreak.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDurationOfEachBreak.Name = "numericUpDownDurationOfEachBreak";
            this.numericUpDownDurationOfEachBreak.Size = new System.Drawing.Size(70, 27);
            this.numericUpDownDurationOfEachBreak.TabIndex = 7;
            this.numericUpDownDurationOfEachBreak.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownDurationOfEachBreak.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelDurationOfEachBreak_Part1
            // 
            this.labelDurationOfEachBreak_Part1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelDurationOfEachBreak_Part1.BackColor = System.Drawing.Color.Transparent;
            this.labelDurationOfEachBreak_Part1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelDurationOfEachBreak_Part1.Location = new System.Drawing.Point(12, 403);
            this.labelDurationOfEachBreak_Part1.Name = "labelDurationOfEachBreak_Part1";
            this.labelDurationOfEachBreak_Part1.Size = new System.Drawing.Size(194, 21);
            this.labelDurationOfEachBreak_Part1.TabIndex = 6;
            this.labelDurationOfEachBreak_Part1.Text = "Text.WorkGroup.DurationOfEachBreak_Part1";
            this.labelDurationOfEachBreak_Part1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelBreakStartsAfterHowManyRounds_Part2
            // 
            this.labelBreakStartsAfterHowManyRounds_Part2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelBreakStartsAfterHowManyRounds_Part2.BackColor = System.Drawing.Color.Transparent;
            this.labelBreakStartsAfterHowManyRounds_Part2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelBreakStartsAfterHowManyRounds_Part2.Location = new System.Drawing.Point(289, 438);
            this.labelBreakStartsAfterHowManyRounds_Part2.Name = "labelBreakStartsAfterHowManyRounds_Part2";
            this.labelBreakStartsAfterHowManyRounds_Part2.Size = new System.Drawing.Size(218, 21);
            this.labelBreakStartsAfterHowManyRounds_Part2.TabIndex = 11;
            this.labelBreakStartsAfterHowManyRounds_Part2.Text = "Text.WorkGroup.BreakStartsAfterHowManyRounds_Part2";
            this.labelBreakStartsAfterHowManyRounds_Part2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDownBreakStartsAfterHowManyRounds
            // 
            this.numericUpDownBreakStartsAfterHowManyRounds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDownBreakStartsAfterHowManyRounds.BackColor = System.Drawing.Color.WhiteSmoke;
            this.numericUpDownBreakStartsAfterHowManyRounds.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownBreakStartsAfterHowManyRounds.ForeColor = System.Drawing.Color.Black;
            this.numericUpDownBreakStartsAfterHowManyRounds.Location = new System.Drawing.Point(213, 436);
            this.numericUpDownBreakStartsAfterHowManyRounds.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDownBreakStartsAfterHowManyRounds.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownBreakStartsAfterHowManyRounds.Name = "numericUpDownBreakStartsAfterHowManyRounds";
            this.numericUpDownBreakStartsAfterHowManyRounds.Size = new System.Drawing.Size(70, 27);
            this.numericUpDownBreakStartsAfterHowManyRounds.TabIndex = 10;
            this.numericUpDownBreakStartsAfterHowManyRounds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownBreakStartsAfterHowManyRounds.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownBreakStartsAfterHowManyRounds.ValueChanged += new System.EventHandler(this.UpdateControls);
            // 
            // labelBreakStartsAfterHowManyRounds_Part1
            // 
            this.labelBreakStartsAfterHowManyRounds_Part1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelBreakStartsAfterHowManyRounds_Part1.BackColor = System.Drawing.Color.Transparent;
            this.labelBreakStartsAfterHowManyRounds_Part1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelBreakStartsAfterHowManyRounds_Part1.Location = new System.Drawing.Point(12, 438);
            this.labelBreakStartsAfterHowManyRounds_Part1.Name = "labelBreakStartsAfterHowManyRounds_Part1";
            this.labelBreakStartsAfterHowManyRounds_Part1.Size = new System.Drawing.Size(194, 21);
            this.labelBreakStartsAfterHowManyRounds_Part1.TabIndex = 9;
            this.labelBreakStartsAfterHowManyRounds_Part1.Text = "Text.WorkGroup.BreakStartsAfterHowManyRounds_Part1";
            this.labelBreakStartsAfterHowManyRounds_Part1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // myFlowPanel1
            // 
            this.myFlowPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.myFlowPanel1.Location = new System.Drawing.Point(12, 156);
            this.myFlowPanel1.Name = "myFlowPanel1";
            this.myFlowPanel1.Size = new System.Drawing.Size(495, 200);
            this.myFlowPanel1.TabIndex = 12;
            // 
            // textBoxAddParticipant
            // 
            this.textBoxAddParticipant.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxAddParticipant.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxAddParticipant.ForeColor = System.Drawing.Color.Black;
            this.textBoxAddParticipant.Location = new System.Drawing.Point(293, 114);
            this.textBoxAddParticipant.Name = "textBoxAddParticipant";
            this.textBoxAddParticipant.Placeholder = "Text.WorkGroup.AddParticipant";
            this.textBoxAddParticipant.Size = new System.Drawing.Size(214, 23);
            this.textBoxAddParticipant.TabIndex = 13;
            // 
            // buttonAddParticipant
            // 
            this.buttonAddParticipant.BackColor = System.Drawing.Color.Transparent;
            this.buttonAddParticipant.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAddParticipant.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonAddParticipant.FlatAppearance.BorderSize = 0;
            this.buttonAddParticipant.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonAddParticipant.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonAddParticipant.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonAddParticipant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddParticipant.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddParticipant.Image")));
            this.buttonAddParticipant.Location = new System.Drawing.Point(248, 100);
            this.buttonAddParticipant.Name = "buttonAddParticipant";
            this.buttonAddParticipant.Size = new System.Drawing.Size(50, 50);
            this.buttonAddParticipant.TabIndex = 14;
            this.buttonAddParticipant.UseVisualStyleBackColor = false;
            // 
            // FormWorkGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 475);
            this.Controls.Add(this.textBoxAddParticipant);
            this.Controls.Add(this.buttonAddParticipant);
            this.Controls.Add(this.myFlowPanel1);
            this.Controls.Add(this.labelBreakStartsAfterHowManyRounds_Part2);
            this.Controls.Add(this.numericUpDownBreakStartsAfterHowManyRounds);
            this.Controls.Add(this.labelBreakStartsAfterHowManyRounds_Part1);
            this.Controls.Add(this.labelDurationOfEachBreak_Part2);
            this.Controls.Add(this.numericUpDownDurationOfEachBreak);
            this.Controls.Add(this.labelDurationOfEachBreak_Part1);
            this.Controls.Add(this.labelDurationOfEachRound_Part2);
            this.Controls.Add(this.numericUpDownDurationOfEachRound);
            this.Controls.Add(this.labelDurationOfEachRound_Part1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormWorkGroup";
            this.ShowLogo = true;
            this.Text = "FormWorkGroup";
            this.Controls.SetChildIndex(this.labelDurationOfEachRound_Part1, 0);
            this.Controls.SetChildIndex(this.numericUpDownDurationOfEachRound, 0);
            this.Controls.SetChildIndex(this.labelDurationOfEachRound_Part2, 0);
            this.Controls.SetChildIndex(this.labelDurationOfEachBreak_Part1, 0);
            this.Controls.SetChildIndex(this.numericUpDownDurationOfEachBreak, 0);
            this.Controls.SetChildIndex(this.labelDurationOfEachBreak_Part2, 0);
            this.Controls.SetChildIndex(this.labelBreakStartsAfterHowManyRounds_Part1, 0);
            this.Controls.SetChildIndex(this.numericUpDownBreakStartsAfterHowManyRounds, 0);
            this.Controls.SetChildIndex(this.labelBreakStartsAfterHowManyRounds_Part2, 0);
            this.Controls.SetChildIndex(this.myFlowPanel1, 0);
            this.Controls.SetChildIndex(this.buttonAddParticipant, 0);
            this.Controls.SetChildIndex(this.textBoxAddParticipant, 0);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDurationOfEachRound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDurationOfEachBreak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBreakStartsAfterHowManyRounds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Cabster.Components.MyButton buttonMinimize;
        private System.Windows.Forms.Label labelDurationOfEachRound_Part1;
        private System.Windows.Forms.NumericUpDown numericUpDownDurationOfEachRound;
        private System.Windows.Forms.Label labelDurationOfEachRound_Part2;
        private System.Windows.Forms.Label labelDurationOfEachBreak_Part2;
        private System.Windows.Forms.NumericUpDown numericUpDownDurationOfEachBreak;
        private System.Windows.Forms.Label labelDurationOfEachBreak_Part1;
        private System.Windows.Forms.Label labelBreakStartsAfterHowManyRounds_Part2;
        private System.Windows.Forms.NumericUpDown numericUpDownBreakStartsAfterHowManyRounds;
        private System.Windows.Forms.Label labelBreakStartsAfterHowManyRounds_Part1;
        private Cabster.Components.MyButton buttonAddParticipant;
        private Cabster.Components.MyTextBox textBoxAddParticipant;
        private Cabster.Components.MyFlowPanel myFlowPanel1;
    }
}