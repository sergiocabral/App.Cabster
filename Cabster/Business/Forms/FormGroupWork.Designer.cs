namespace Cabster.Business.Forms
{
    partial class FormGroupWork
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
                new System.ComponentModel.ComponentResourceManager(typeof(FormGroupWork));
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
            this.panelParticipants = new Cabster.Components.MyFlowPanel(this.components);
            this.textBoxAddParticipant = new Cabster.Components.MyTextBox(this.components);
            this.buttonParticipantAdd = new Cabster.Components.MyButton(this.components);
            this.buttonParticipantSort = new Cabster.Components.MyButton(this.components);
            this.buttonStart = new Cabster.Components.MyButton(this.components);
            this.labelTips = new System.Windows.Forms.Label();
            this.buttonConfiguration = new Cabster.Components.MyButton(this.components);
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDownDurationOfEachRound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDownDurationOfEachBreak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDownBreakStartsAfterHowManyRounds)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonMinimize
            // 
            this.buttonMinimize.AutoSize = true;
            this.buttonMinimize.BackColor = System.Drawing.Color.Transparent;
            this.buttonMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonMinimize.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int) (((byte) (140)))),
                ((int) (((byte) (140)))), ((int) (((byte) (140)))));
            this.buttonMinimize.FlatAppearance.BorderSize = 0;
            this.buttonMinimize.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinimize.Image = ((System.Drawing.Image) (resources.GetObject("buttonMinimize.Image")));
            this.buttonMinimize.Location = new System.Drawing.Point(620, 0);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.NotTransparent = false;
            this.buttonMinimize.Size = new System.Drawing.Size(50, 50);
            this.buttonMinimize.TabIndex = 12;
            this.buttonMinimize.UseVisualStyleBackColor = false;
            // 
            // labelDurationOfEachRound_Part1
            // 
            this.labelDurationOfEachRound_Part1.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
                                                       System.Windows.Forms.AnchorStyles.Left)));
            this.labelDurationOfEachRound_Part1.BackColor = System.Drawing.Color.Transparent;
            this.labelDurationOfEachRound_Part1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelDurationOfEachRound_Part1.Location = new System.Drawing.Point(12, 263);
            this.labelDurationOfEachRound_Part1.Name = "labelDurationOfEachRound_Part1";
            this.labelDurationOfEachRound_Part1.Size = new System.Drawing.Size(194, 21);
            this.labelDurationOfEachRound_Part1.TabIndex = 13;
            this.labelDurationOfEachRound_Part1.Text = "Text.GroupWork.DurationOfEachRound_Part1";
            this.labelDurationOfEachRound_Part1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDownDurationOfEachRound
            // 
            this.numericUpDownDurationOfEachRound.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
                                                       System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDownDurationOfEachRound.BackColor = System.Drawing.Color.WhiteSmoke;
            this.numericUpDownDurationOfEachRound.Font = new System.Drawing.Font("Tahoma", 12F,
                System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.numericUpDownDurationOfEachRound.ForeColor = System.Drawing.Color.Black;
            this.numericUpDownDurationOfEachRound.Location = new System.Drawing.Point(213, 263);
            this.numericUpDownDurationOfEachRound.Maximum = new decimal(new int[] {999, 0, 0, 0});
            this.numericUpDownDurationOfEachRound.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.numericUpDownDurationOfEachRound.Name = "numericUpDownDurationOfEachRound";
            this.numericUpDownDurationOfEachRound.Size = new System.Drawing.Size(70, 27);
            this.numericUpDownDurationOfEachRound.TabIndex = 14;
            this.numericUpDownDurationOfEachRound.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownDurationOfEachRound.Value = new decimal(new int[] {1, 0, 0, 0});
            this.numericUpDownDurationOfEachRound.ValueChanged += new System.EventHandler(this.UpdateControls);
            // 
            // labelDurationOfEachRound_Part2
            // 
            this.labelDurationOfEachRound_Part2.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
                                                       System.Windows.Forms.AnchorStyles.Left)));
            this.labelDurationOfEachRound_Part2.BackColor = System.Drawing.Color.Transparent;
            this.labelDurationOfEachRound_Part2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelDurationOfEachRound_Part2.Location = new System.Drawing.Point(289, 263);
            this.labelDurationOfEachRound_Part2.Name = "labelDurationOfEachRound_Part2";
            this.labelDurationOfEachRound_Part2.Size = new System.Drawing.Size(271, 21);
            this.labelDurationOfEachRound_Part2.TabIndex = 15;
            this.labelDurationOfEachRound_Part2.Text = "Text.GroupWork.DurationOfEachRound_Part2";
            this.labelDurationOfEachRound_Part2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDurationOfEachBreak_Part2
            // 
            this.labelDurationOfEachBreak_Part2.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
                                                       System.Windows.Forms.AnchorStyles.Left)));
            this.labelDurationOfEachBreak_Part2.BackColor = System.Drawing.Color.Transparent;
            this.labelDurationOfEachBreak_Part2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelDurationOfEachBreak_Part2.Location = new System.Drawing.Point(289, 296);
            this.labelDurationOfEachBreak_Part2.Name = "labelDurationOfEachBreak_Part2";
            this.labelDurationOfEachBreak_Part2.Size = new System.Drawing.Size(271, 21);
            this.labelDurationOfEachBreak_Part2.TabIndex = 18;
            this.labelDurationOfEachBreak_Part2.Text = "Text.GroupWork.DurationOfEachBreak_Part2";
            this.labelDurationOfEachBreak_Part2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDownDurationOfEachBreak
            // 
            this.numericUpDownDurationOfEachBreak.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
                                                       System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDownDurationOfEachBreak.BackColor = System.Drawing.Color.WhiteSmoke;
            this.numericUpDownDurationOfEachBreak.Font = new System.Drawing.Font("Tahoma", 12F,
                System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.numericUpDownDurationOfEachBreak.ForeColor = System.Drawing.Color.Black;
            this.numericUpDownDurationOfEachBreak.Location = new System.Drawing.Point(213, 296);
            this.numericUpDownDurationOfEachBreak.Maximum = new decimal(new int[] {999, 0, 0, 0});
            this.numericUpDownDurationOfEachBreak.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.numericUpDownDurationOfEachBreak.Name = "numericUpDownDurationOfEachBreak";
            this.numericUpDownDurationOfEachBreak.Size = new System.Drawing.Size(70, 27);
            this.numericUpDownDurationOfEachBreak.TabIndex = 17;
            this.numericUpDownDurationOfEachBreak.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownDurationOfEachBreak.Value = new decimal(new int[] {1, 0, 0, 0});
            // 
            // labelDurationOfEachBreak_Part1
            // 
            this.labelDurationOfEachBreak_Part1.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
                                                       System.Windows.Forms.AnchorStyles.Left)));
            this.labelDurationOfEachBreak_Part1.BackColor = System.Drawing.Color.Transparent;
            this.labelDurationOfEachBreak_Part1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelDurationOfEachBreak_Part1.Location = new System.Drawing.Point(12, 296);
            this.labelDurationOfEachBreak_Part1.Name = "labelDurationOfEachBreak_Part1";
            this.labelDurationOfEachBreak_Part1.Size = new System.Drawing.Size(194, 21);
            this.labelDurationOfEachBreak_Part1.TabIndex = 16;
            this.labelDurationOfEachBreak_Part1.Text = "Text.GroupWork.DurationOfEachBreak_Part1";
            this.labelDurationOfEachBreak_Part1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelBreakStartsAfterHowManyRounds_Part2
            // 
            this.labelBreakStartsAfterHowManyRounds_Part2.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
                                                       System.Windows.Forms.AnchorStyles.Left)));
            this.labelBreakStartsAfterHowManyRounds_Part2.BackColor = System.Drawing.Color.Transparent;
            this.labelBreakStartsAfterHowManyRounds_Part2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelBreakStartsAfterHowManyRounds_Part2.Location = new System.Drawing.Point(289, 331);
            this.labelBreakStartsAfterHowManyRounds_Part2.Name = "labelBreakStartsAfterHowManyRounds_Part2";
            this.labelBreakStartsAfterHowManyRounds_Part2.Size = new System.Drawing.Size(271, 21);
            this.labelBreakStartsAfterHowManyRounds_Part2.TabIndex = 21;
            this.labelBreakStartsAfterHowManyRounds_Part2.Text = "Text.GroupWork.BreakStartsAfterHowManyRounds_Part2";
            this.labelBreakStartsAfterHowManyRounds_Part2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDownBreakStartsAfterHowManyRounds
            // 
            this.numericUpDownBreakStartsAfterHowManyRounds.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
                                                       System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDownBreakStartsAfterHowManyRounds.BackColor = System.Drawing.Color.WhiteSmoke;
            this.numericUpDownBreakStartsAfterHowManyRounds.Font = new System.Drawing.Font("Tahoma", 12F,
                System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.numericUpDownBreakStartsAfterHowManyRounds.ForeColor = System.Drawing.Color.Black;
            this.numericUpDownBreakStartsAfterHowManyRounds.Location = new System.Drawing.Point(213, 329);
            this.numericUpDownBreakStartsAfterHowManyRounds.Maximum = new decimal(new int[] {999, 0, 0, 0});
            this.numericUpDownBreakStartsAfterHowManyRounds.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.numericUpDownBreakStartsAfterHowManyRounds.Name = "numericUpDownBreakStartsAfterHowManyRounds";
            this.numericUpDownBreakStartsAfterHowManyRounds.Size = new System.Drawing.Size(70, 27);
            this.numericUpDownBreakStartsAfterHowManyRounds.TabIndex = 20;
            this.numericUpDownBreakStartsAfterHowManyRounds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownBreakStartsAfterHowManyRounds.Value = new decimal(new int[] {1, 0, 0, 0});
            this.numericUpDownBreakStartsAfterHowManyRounds.ValueChanged +=
                new System.EventHandler(this.UpdateControls);
            // 
            // labelBreakStartsAfterHowManyRounds_Part1
            // 
            this.labelBreakStartsAfterHowManyRounds_Part1.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
                                                       System.Windows.Forms.AnchorStyles.Left)));
            this.labelBreakStartsAfterHowManyRounds_Part1.BackColor = System.Drawing.Color.Transparent;
            this.labelBreakStartsAfterHowManyRounds_Part1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelBreakStartsAfterHowManyRounds_Part1.Location = new System.Drawing.Point(12, 331);
            this.labelBreakStartsAfterHowManyRounds_Part1.Name = "labelBreakStartsAfterHowManyRounds_Part1";
            this.labelBreakStartsAfterHowManyRounds_Part1.Size = new System.Drawing.Size(194, 21);
            this.labelBreakStartsAfterHowManyRounds_Part1.TabIndex = 19;
            this.labelBreakStartsAfterHowManyRounds_Part1.Text = "Text.GroupWork.BreakStartsAfterHowManyRounds_Part1";
            this.labelBreakStartsAfterHowManyRounds_Part1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelParticipants
            // 
            this.panelParticipants.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top |
                                                         System.Windows.Forms.AnchorStyles.Bottom) |
                                                        System.Windows.Forms.AnchorStyles.Left) |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.panelParticipants.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelParticipants.Location = new System.Drawing.Point(12, 156);
            this.panelParticipants.Name = "panelParticipants";
            this.panelParticipants.Size = new System.Drawing.Size(676, 94);
            this.panelParticipants.TabIndex = 12;
            // 
            // textBoxAddParticipant
            // 
            this.textBoxAddParticipant.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left) |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAddParticipant.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxAddParticipant.ForeColor = System.Drawing.Color.Black;
            this.textBoxAddParticipant.Location = new System.Drawing.Point(331, 116);
            this.textBoxAddParticipant.Name = "textBoxAddParticipant";
            this.textBoxAddParticipant.Placeholder = "Text.GroupWork.ParticipantAdd";
            this.textBoxAddParticipant.Size = new System.Drawing.Size(357, 27);
            this.textBoxAddParticipant.TabIndex = 9;
            this.textBoxAddParticipant.KeyUp +=
                new System.Windows.Forms.KeyEventHandler(this.textBoxAddParticipant_KeyUp);
            // 
            // buttonParticipantAdd
            // 
            this.buttonParticipantAdd.AutoSize = true;
            this.buttonParticipantAdd.BackColor = System.Drawing.Color.Transparent;
            this.buttonParticipantAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonParticipantAdd.FlatAppearance.BorderColor =
                System.Drawing.Color.FromArgb(((int) (((byte) (255)))), ((int) (((byte) (255)))),
                    ((int) (((byte) (255)))));
            this.buttonParticipantAdd.FlatAppearance.BorderSize = 0;
            this.buttonParticipantAdd.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonParticipantAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonParticipantAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonParticipantAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonParticipantAdd.Image =
                ((System.Drawing.Image) (resources.GetObject("buttonParticipantAdd.Image")));
            this.buttonParticipantAdd.Location = new System.Drawing.Point(298, 114);
            this.buttonParticipantAdd.Name = "buttonParticipantAdd";
            this.buttonParticipantAdd.NotTransparent = false;
            this.buttonParticipantAdd.Size = new System.Drawing.Size(31, 31);
            this.buttonParticipantAdd.TabIndex = 10;
            this.toolTip.SetToolTip(this.buttonParticipantAdd, "Text.GroupWork.ParticipantAddHint");
            this.buttonParticipantAdd.UseVisualStyleBackColor = false;
            this.buttonParticipantAdd.Click += new System.EventHandler(this.buttonParticipantAdd_Click);
            // 
            // buttonParticipantSort
            // 
            this.buttonParticipantSort.AutoSize = true;
            this.buttonParticipantSort.BackColor = System.Drawing.Color.Transparent;
            this.buttonParticipantSort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonParticipantSort.FlatAppearance.BorderColor =
                System.Drawing.Color.FromArgb(((int) (((byte) (255)))), ((int) (((byte) (255)))),
                    ((int) (((byte) (255)))));
            this.buttonParticipantSort.FlatAppearance.BorderSize = 0;
            this.buttonParticipantSort.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonParticipantSort.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonParticipantSort.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonParticipantSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonParticipantSort.Image =
                ((System.Drawing.Image) (resources.GetObject("buttonParticipantSort.Image")));
            this.buttonParticipantSort.Location = new System.Drawing.Point(263, 114);
            this.buttonParticipantSort.Name = "buttonParticipantSort";
            this.buttonParticipantSort.NotTransparent = false;
            this.buttonParticipantSort.Size = new System.Drawing.Size(39, 31);
            this.buttonParticipantSort.TabIndex = 11;
            this.toolTip.SetToolTip(this.buttonParticipantSort, "Text.GroupWork.ParticipantSortHint");
            this.buttonParticipantSort.UseVisualStyleBackColor = false;
            this.buttonParticipantSort.Click += new System.EventHandler(this.buttonParticipantSort_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom |
                                                        System.Windows.Forms.AnchorStyles.Left) |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (250)))),
                ((int) (((byte) (180)))), ((int) (((byte) (20)))));
            this.buttonStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int) (((byte) (252)))),
                ((int) (((byte) (210)))), ((int) (((byte) (114)))));
            this.buttonStart.FlatAppearance.BorderSize = 3;
            this.buttonStart.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (123)))),
                ((int) (((byte) (87)))), ((int) (((byte) (2)))));
            this.buttonStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (123)))),
                ((int) (((byte) (87)))), ((int) (((byte) (2)))));
            this.buttonStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (141)))),
                ((int) (((byte) (100)))), ((int) (((byte) (3)))));
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStart.Location = new System.Drawing.Point(517, 263);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.NotTransparent = false;
            this.buttonStart.Size = new System.Drawing.Size(171, 36);
            this.buttonStart.TabIndex = 22;
            this.buttonStart.Text = "Text.GroupWork.Start";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // labelTips
            // 
            this.labelTips.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left) |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.labelTips.BackColor = System.Drawing.Color.Transparent;
            this.labelTips.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelTips.Font = new System.Drawing.Font("Calibri", 9.75F,
                ((System.Drawing.FontStyle) ((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))),
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.labelTips.ForeColor = System.Drawing.Color.Lavender;
            this.labelTips.Location = new System.Drawing.Point(231, 54);
            this.labelTips.Name = "labelTips";
            this.labelTips.Size = new System.Drawing.Size(457, 59);
            this.labelTips.TabIndex = 17;
            this.labelTips.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelTips.Click += new System.EventHandler(this.labelTips_Click);
            // 
            // buttonConfiguration
            // 
            this.buttonConfiguration.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConfiguration.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (32)))),
                ((int) (((byte) (32)))), ((int) (((byte) (32)))));
            this.buttonConfiguration.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonConfiguration.FlatAppearance.BorderSize = 0;
            this.buttonConfiguration.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonConfiguration.FlatAppearance.MouseDownBackColor =
                System.Drawing.Color.FromArgb(((int) (((byte) (32)))), ((int) (((byte) (32)))),
                    ((int) (((byte) (32)))));
            this.buttonConfiguration.FlatAppearance.MouseOverBackColor =
                System.Drawing.Color.FromArgb(((int) (((byte) (32)))), ((int) (((byte) (32)))),
                    ((int) (((byte) (32)))));
            this.buttonConfiguration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfiguration.Image =
                ((System.Drawing.Image) (resources.GetObject("buttonConfiguration.Image")));
            this.buttonConfiguration.Location = new System.Drawing.Point(535, 0);
            this.buttonConfiguration.Name = "buttonConfiguration";
            this.buttonConfiguration.NotTransparent = true;
            this.buttonConfiguration.Size = new System.Drawing.Size(50, 50);
            this.buttonConfiguration.TabIndex = 23;
            this.toolTip.SetToolTip(this.buttonConfiguration, "Text.GroupWork.ConfigurationHint");
            this.buttonConfiguration.UseVisualStyleBackColor = false;
            this.buttonConfiguration.Click += new System.EventHandler(this.buttonConfiguration_Click);
            // 
            // FormGroupWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 400);
            this.Controls.Add(this.buttonConfiguration);
            this.Controls.Add(this.labelTips);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonParticipantSort);
            this.Controls.Add(this.textBoxAddParticipant);
            this.Controls.Add(this.buttonParticipantAdd);
            this.Controls.Add(this.panelParticipants);
            this.Controls.Add(this.labelBreakStartsAfterHowManyRounds_Part2);
            this.Controls.Add(this.numericUpDownBreakStartsAfterHowManyRounds);
            this.Controls.Add(this.labelBreakStartsAfterHowManyRounds_Part1);
            this.Controls.Add(this.labelDurationOfEachBreak_Part2);
            this.Controls.Add(this.numericUpDownDurationOfEachBreak);
            this.Controls.Add(this.labelDurationOfEachBreak_Part1);
            this.Controls.Add(this.labelDurationOfEachRound_Part2);
            this.Controls.Add(this.numericUpDownDurationOfEachRound);
            this.Controls.Add(this.labelDurationOfEachRound_Part1);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "FormGroupWork";
            this.ShowLogo = true;
            this.Text = "Text.GroupWork.WindowTitle";
            this.Controls.SetChildIndex(this.labelDurationOfEachRound_Part1, 0);
            this.Controls.SetChildIndex(this.numericUpDownDurationOfEachRound, 0);
            this.Controls.SetChildIndex(this.labelDurationOfEachRound_Part2, 0);
            this.Controls.SetChildIndex(this.labelDurationOfEachBreak_Part1, 0);
            this.Controls.SetChildIndex(this.numericUpDownDurationOfEachBreak, 0);
            this.Controls.SetChildIndex(this.labelDurationOfEachBreak_Part2, 0);
            this.Controls.SetChildIndex(this.labelBreakStartsAfterHowManyRounds_Part1, 0);
            this.Controls.SetChildIndex(this.numericUpDownBreakStartsAfterHowManyRounds, 0);
            this.Controls.SetChildIndex(this.labelBreakStartsAfterHowManyRounds_Part2, 0);
            this.Controls.SetChildIndex(this.panelParticipants, 0);
            this.Controls.SetChildIndex(this.buttonParticipantAdd, 0);
            this.Controls.SetChildIndex(this.textBoxAddParticipant, 0);
            this.Controls.SetChildIndex(this.buttonParticipantSort, 0);
            this.Controls.SetChildIndex(this.buttonStart, 0);
            this.Controls.SetChildIndex(this.labelTips, 0);
            this.Controls.SetChildIndex(this.buttonConfiguration, 0);
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDownDurationOfEachRound)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDownDurationOfEachBreak)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDownBreakStartsAfterHowManyRounds)).EndInit();
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
        private Cabster.Components.MyButton buttonParticipantAdd;
        private Cabster.Components.MyTextBox textBoxAddParticipant;
        private Cabster.Components.MyFlowPanel panelParticipants;
        private System.Windows.Forms.Label labelTips;
        private Cabster.Components.MyButton buttonStart;
        private Cabster.Components.MyButton buttonParticipantSort;
        private Cabster.Components.MyButton buttonConfiguration;
    }
}