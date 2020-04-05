namespace Cabster.Business.Forms
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
            this.flowLayoutPanel1 = new System.Windows.Forms.Panel();
            this.myButton1 = new Cabster.Components.MyButton(this.components);
            this.myButton2 = new Cabster.Components.MyButton(this.components);
            this.myButton3 = new Cabster.Components.MyButton(this.components);
            this.myButton4 = new Cabster.Components.MyButton(this.components);
            this.myButton5 = new Cabster.Components.MyButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDurationOfEachRound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDurationOfEachBreak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBreakStartsAfterHowManyRounds)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
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
            this.labelDurationOfEachRound_Part1.BackColor = System.Drawing.Color.Transparent;
            this.labelDurationOfEachRound_Part1.Location = new System.Drawing.Point(19, 170);
            this.labelDurationOfEachRound_Part1.Name = "labelDurationOfEachRound_Part1";
            this.labelDurationOfEachRound_Part1.Size = new System.Drawing.Size(218, 21);
            this.labelDurationOfEachRound_Part1.TabIndex = 3;
            this.labelDurationOfEachRound_Part1.Text = "Text.WorkGroup.DurationOfEachRound_Part1";
            this.labelDurationOfEachRound_Part1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDownDurationOfEachRound
            // 
            this.numericUpDownDurationOfEachRound.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownDurationOfEachRound.Location = new System.Drawing.Point(244, 170);
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
            this.labelDurationOfEachRound_Part2.BackColor = System.Drawing.Color.Transparent;
            this.labelDurationOfEachRound_Part2.Location = new System.Drawing.Point(320, 170);
            this.labelDurationOfEachRound_Part2.Name = "labelDurationOfEachRound_Part2";
            this.labelDurationOfEachRound_Part2.Size = new System.Drawing.Size(284, 21);
            this.labelDurationOfEachRound_Part2.TabIndex = 5;
            this.labelDurationOfEachRound_Part2.Text = "Text.WorkGroup.DurationOfEachRound_Part2";
            this.labelDurationOfEachRound_Part2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDurationOfEachBreak_Part2
            // 
            this.labelDurationOfEachBreak_Part2.BackColor = System.Drawing.Color.Transparent;
            this.labelDurationOfEachBreak_Part2.Location = new System.Drawing.Point(320, 203);
            this.labelDurationOfEachBreak_Part2.Name = "labelDurationOfEachBreak_Part2";
            this.labelDurationOfEachBreak_Part2.Size = new System.Drawing.Size(284, 21);
            this.labelDurationOfEachBreak_Part2.TabIndex = 8;
            this.labelDurationOfEachBreak_Part2.Text = "Text.WorkGroup.DurationOfEachBreak_Part2";
            this.labelDurationOfEachBreak_Part2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDownDurationOfEachBreak
            // 
            this.numericUpDownDurationOfEachBreak.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownDurationOfEachBreak.Location = new System.Drawing.Point(244, 203);
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
            this.labelDurationOfEachBreak_Part1.BackColor = System.Drawing.Color.Transparent;
            this.labelDurationOfEachBreak_Part1.Location = new System.Drawing.Point(19, 203);
            this.labelDurationOfEachBreak_Part1.Name = "labelDurationOfEachBreak_Part1";
            this.labelDurationOfEachBreak_Part1.Size = new System.Drawing.Size(218, 21);
            this.labelDurationOfEachBreak_Part1.TabIndex = 6;
            this.labelDurationOfEachBreak_Part1.Text = "Text.WorkGroup.DurationOfEachBreak_Part1";
            this.labelDurationOfEachBreak_Part1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelBreakStartsAfterHowManyRounds_Part2
            // 
            this.labelBreakStartsAfterHowManyRounds_Part2.BackColor = System.Drawing.Color.Transparent;
            this.labelBreakStartsAfterHowManyRounds_Part2.Location = new System.Drawing.Point(320, 238);
            this.labelBreakStartsAfterHowManyRounds_Part2.Name = "labelBreakStartsAfterHowManyRounds_Part2";
            this.labelBreakStartsAfterHowManyRounds_Part2.Size = new System.Drawing.Size(284, 21);
            this.labelBreakStartsAfterHowManyRounds_Part2.TabIndex = 11;
            this.labelBreakStartsAfterHowManyRounds_Part2.Text = "Text.WorkGroup.BreakStartsAfterHowManyRounds_Part2";
            this.labelBreakStartsAfterHowManyRounds_Part2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDownBreakStartsAfterHowManyRounds
            // 
            this.numericUpDownBreakStartsAfterHowManyRounds.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownBreakStartsAfterHowManyRounds.Location = new System.Drawing.Point(244, 236);
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
            this.labelBreakStartsAfterHowManyRounds_Part1.BackColor = System.Drawing.Color.Transparent;
            this.labelBreakStartsAfterHowManyRounds_Part1.Location = new System.Drawing.Point(19, 238);
            this.labelBreakStartsAfterHowManyRounds_Part1.Name = "labelBreakStartsAfterHowManyRounds_Part1";
            this.labelBreakStartsAfterHowManyRounds_Part1.Size = new System.Drawing.Size(218, 21);
            this.labelBreakStartsAfterHowManyRounds_Part1.TabIndex = 9;
            this.labelBreakStartsAfterHowManyRounds_Part1.Text = "Text.WorkGroup.BreakStartsAfterHowManyRounds_Part1";
            this.labelBreakStartsAfterHowManyRounds_Part1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.myButton1);
            this.flowLayoutPanel1.Controls.Add(this.myButton2);
            this.flowLayoutPanel1.Controls.Add(this.myButton3);
            this.flowLayoutPanel1.Controls.Add(this.myButton4);
            this.flowLayoutPanel1.Controls.Add(this.myButton5);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(63, 286);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(607, 136);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // myButton1
            // 
            this.myButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.myButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.myButton1.FlatAppearance.BorderSize = 3;
            this.myButton1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.myButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.myButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.myButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.myButton1.Location = new System.Drawing.Point(3, 3);
            this.myButton1.Name = "myButton1";
            this.myButton1.Size = new System.Drawing.Size(120, 43);
            this.myButton1.TabIndex = 0;
            this.myButton1.Text = "myButton1";
            this.myButton1.UseVisualStyleBackColor = true;
            // 
            // myButton2
            // 
            this.myButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.myButton2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.myButton2.FlatAppearance.BorderSize = 3;
            this.myButton2.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.myButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.myButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.myButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.myButton2.Location = new System.Drawing.Point(129, 3);
            this.myButton2.Name = "myButton2";
            this.myButton2.Size = new System.Drawing.Size(120, 43);
            this.myButton2.TabIndex = 1;
            this.myButton2.Text = "myButton2";
            this.myButton2.UseVisualStyleBackColor = true;
            // 
            // myButton3
            // 
            this.myButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.myButton3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.myButton3.FlatAppearance.BorderSize = 3;
            this.myButton3.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.myButton3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.myButton3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.myButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.myButton3.Location = new System.Drawing.Point(255, 3);
            this.myButton3.Name = "myButton3";
            this.myButton3.Size = new System.Drawing.Size(120, 43);
            this.myButton3.TabIndex = 2;
            this.myButton3.Text = "myButton3";
            this.myButton3.UseVisualStyleBackColor = true;
            // 
            // myButton4
            // 
            this.myButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.myButton4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.myButton4.FlatAppearance.BorderSize = 3;
            this.myButton4.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.myButton4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.myButton4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.myButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.myButton4.Location = new System.Drawing.Point(381, 3);
            this.myButton4.Name = "myButton4";
            this.myButton4.Size = new System.Drawing.Size(120, 43);
            this.myButton4.TabIndex = 3;
            this.myButton4.Text = "myButton4";
            this.myButton4.UseVisualStyleBackColor = true;
            // 
            // myButton5
            // 
            this.myButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.myButton5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.myButton5.FlatAppearance.BorderSize = 3;
            this.myButton5.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.myButton5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.myButton5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.myButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.myButton5.Location = new System.Drawing.Point(3, 52);
            this.myButton5.Name = "myButton5";
            this.myButton5.Size = new System.Drawing.Size(120, 43);
            this.myButton5.TabIndex = 4;
            this.myButton5.Text = "myButton5";
            this.myButton5.UseVisualStyleBackColor = true;
            // 
            // FormWorkGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 475);
            this.Controls.Add(this.flowLayoutPanel1);
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
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDurationOfEachRound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDurationOfEachBreak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBreakStartsAfterHowManyRounds)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Panel flowLayoutPanel1;
        private Components.MyButton myButton1;
        private Components.MyButton myButton2;
        private Components.MyButton myButton3;
        private Components.MyButton myButton4;
        private Components.MyButton myButton5;
    }
}