namespace XInputReporter
{
    partial class MainForm
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
            this.picController1 = new System.Windows.Forms.PictureBox();
            this.picController2 = new System.Windows.Forms.PictureBox();
            this.picController3 = new System.Windows.Forms.PictureBox();
            this.picController4 = new System.Windows.Forms.PictureBox();
            this.pollingWorker = new System.ComponentModel.BackgroundWorker();
            this.checkShoulderRight = new System.Windows.Forms.CheckBox();
            this.checkShoulderLeft = new System.Windows.Forms.CheckBox();
            this.checkY = new System.Windows.Forms.CheckBox();
            this.checkX = new System.Windows.Forms.CheckBox();
            this.checkB = new System.Windows.Forms.CheckBox();
            this.checkA = new System.Windows.Forms.CheckBox();
            this.checkStart = new System.Windows.Forms.CheckBox();
            this.checkBack = new System.Windows.Forms.CheckBox();
            this.checkStickRight = new System.Windows.Forms.CheckBox();
            this.checkStickLeft = new System.Windows.Forms.CheckBox();
            this.checkDPadUp = new System.Windows.Forms.CheckBox();
            this.checkDPadRight = new System.Windows.Forms.CheckBox();
            this.checkDPadDown = new System.Windows.Forms.CheckBox();
            this.checkDPadLeft = new System.Windows.Forms.CheckBox();
            this.labelTriggerLeft = new System.Windows.Forms.Label();
            this.labelTriggerRight = new System.Windows.Forms.Label();
            this.checkLink = new System.Windows.Forms.CheckBox();
            this.labelStickLeftX = new System.Windows.Forms.Label();
            this.labelStickLeftY = new System.Windows.Forms.Label();
            this.labelStickRightX = new System.Windows.Forms.Label();
            this.labelStickRightY = new System.Windows.Forms.Label();
            this.comboDeadZone = new System.Windows.Forms.ComboBox();
            this.labelDeadZone = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timerBack = new System.Windows.Forms.Timer(this.components);
            this.timerStart = new System.Windows.Forms.Timer(this.components);
            this.picStickLeft = new System.Windows.Forms.PictureBox();
            this.picStickRight = new System.Windows.Forms.PictureBox();
            this.checkGuide = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picController2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picController3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picController4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStickLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStickRight)).BeginInit();
            this.SuspendLayout();
            // 
            // picController1
            // 
            this.picController1.BackColor = System.Drawing.Color.Transparent;
            this.picController1.Image = global::XInputReporter.Properties.Resources.connected_controller1;
            this.picController1.Location = new System.Drawing.Point(792, 44);
            this.picController1.Margin = new System.Windows.Forms.Padding(0);
            this.picController1.Name = "picController1";
            this.picController1.Size = new System.Drawing.Size(81, 90);
            this.picController1.TabIndex = 0;
            this.picController1.TabStop = false;
            // 
            // picController2
            // 
            this.picController2.BackColor = System.Drawing.Color.Transparent;
            this.picController2.BackgroundImage = global::XInputReporter.Properties.Resources.connected_controller2;
            this.picController2.Location = new System.Drawing.Point(875, 44);
            this.picController2.Margin = new System.Windows.Forms.Padding(0);
            this.picController2.Name = "picController2";
            this.picController2.Size = new System.Drawing.Size(84, 90);
            this.picController2.TabIndex = 2;
            this.picController2.TabStop = false;
            // 
            // picController3
            // 
            this.picController3.BackColor = System.Drawing.Color.Transparent;
            this.picController3.BackgroundImage = global::XInputReporter.Properties.Resources.connected_controller3;
            this.picController3.Location = new System.Drawing.Point(792, 135);
            this.picController3.Margin = new System.Windows.Forms.Padding(4);
            this.picController3.Name = "picController3";
            this.picController3.Size = new System.Drawing.Size(81, 84);
            this.picController3.TabIndex = 4;
            this.picController3.TabStop = false;
            // 
            // picController4
            // 
            this.picController4.BackColor = System.Drawing.Color.Transparent;
            this.picController4.BackgroundImage = global::XInputReporter.Properties.Resources.connected_controller4;
            this.picController4.Location = new System.Drawing.Point(875, 135);
            this.picController4.Margin = new System.Windows.Forms.Padding(4);
            this.picController4.Name = "picController4";
            this.picController4.Size = new System.Drawing.Size(84, 84);
            this.picController4.TabIndex = 6;
            this.picController4.TabStop = false;
            // 
            // pollingWorker
            // 
            this.pollingWorker.WorkerSupportsCancellation = true;
            this.pollingWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.pollingWorker_DoWork);
            // 
            // checkShoulderRight
            // 
            this.checkShoulderRight.AutoSize = true;
            this.checkShoulderRight.BackColor = System.Drawing.Color.Transparent;
            this.checkShoulderRight.Enabled = false;
            this.checkShoulderRight.Location = new System.Drawing.Point(647, 161);
            this.checkShoulderRight.Margin = new System.Windows.Forms.Padding(4);
            this.checkShoulderRight.Name = "checkShoulderRight";
            this.checkShoulderRight.Size = new System.Drawing.Size(18, 17);
            this.checkShoulderRight.TabIndex = 8;
            this.checkShoulderRight.UseVisualStyleBackColor = false;
            // 
            // checkShoulderLeft
            // 
            this.checkShoulderLeft.AutoSize = true;
            this.checkShoulderLeft.BackColor = System.Drawing.Color.Transparent;
            this.checkShoulderLeft.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkShoulderLeft.Enabled = false;
            this.checkShoulderLeft.Location = new System.Drawing.Point(127, 161);
            this.checkShoulderLeft.Margin = new System.Windows.Forms.Padding(4);
            this.checkShoulderLeft.Name = "checkShoulderLeft";
            this.checkShoulderLeft.Size = new System.Drawing.Size(18, 17);
            this.checkShoulderLeft.TabIndex = 9;
            this.checkShoulderLeft.UseVisualStyleBackColor = false;
            // 
            // checkY
            // 
            this.checkY.AutoSize = true;
            this.checkY.BackColor = System.Drawing.Color.Transparent;
            this.checkY.Enabled = false;
            this.checkY.Location = new System.Drawing.Point(633, 215);
            this.checkY.Margin = new System.Windows.Forms.Padding(4);
            this.checkY.Name = "checkY";
            this.checkY.Size = new System.Drawing.Size(18, 17);
            this.checkY.TabIndex = 10;
            this.checkY.UseVisualStyleBackColor = false;
            // 
            // checkX
            // 
            this.checkX.AutoSize = true;
            this.checkX.BackColor = System.Drawing.Color.Transparent;
            this.checkX.Enabled = false;
            this.checkX.Location = new System.Drawing.Point(561, 270);
            this.checkX.Margin = new System.Windows.Forms.Padding(4);
            this.checkX.Name = "checkX";
            this.checkX.Size = new System.Drawing.Size(18, 17);
            this.checkX.TabIndex = 11;
            this.checkX.UseVisualStyleBackColor = false;
            // 
            // checkB
            // 
            this.checkB.AutoSize = true;
            this.checkB.BackColor = System.Drawing.Color.Transparent;
            this.checkB.Enabled = false;
            this.checkB.Location = new System.Drawing.Point(677, 341);
            this.checkB.Margin = new System.Windows.Forms.Padding(4);
            this.checkB.Name = "checkB";
            this.checkB.Size = new System.Drawing.Size(18, 17);
            this.checkB.TabIndex = 12;
            this.checkB.UseVisualStyleBackColor = false;
            // 
            // checkA
            // 
            this.checkA.AutoSize = true;
            this.checkA.BackColor = System.Drawing.Color.Transparent;
            this.checkA.Enabled = false;
            this.checkA.Location = new System.Drawing.Point(609, 388);
            this.checkA.Margin = new System.Windows.Forms.Padding(4);
            this.checkA.Name = "checkA";
            this.checkA.Size = new System.Drawing.Size(18, 17);
            this.checkA.TabIndex = 13;
            this.checkA.UseVisualStyleBackColor = false;
            // 
            // checkStart
            // 
            this.checkStart.AutoSize = true;
            this.checkStart.BackColor = System.Drawing.Color.Transparent;
            this.checkStart.Enabled = false;
            this.checkStart.Location = new System.Drawing.Point(473, 336);
            this.checkStart.Margin = new System.Windows.Forms.Padding(4);
            this.checkStart.Name = "checkStart";
            this.checkStart.Size = new System.Drawing.Size(18, 17);
            this.checkStart.TabIndex = 14;
            this.checkStart.UseVisualStyleBackColor = false;
            // 
            // checkBack
            // 
            this.checkBack.AutoSize = true;
            this.checkBack.BackColor = System.Drawing.Color.Transparent;
            this.checkBack.Enabled = false;
            this.checkBack.Location = new System.Drawing.Point(307, 336);
            this.checkBack.Margin = new System.Windows.Forms.Padding(4);
            this.checkBack.Name = "checkBack";
            this.checkBack.Size = new System.Drawing.Size(18, 17);
            this.checkBack.TabIndex = 15;
            this.checkBack.UseVisualStyleBackColor = false;
            // 
            // checkStickRight
            // 
            this.checkStickRight.AutoSize = true;
            this.checkStickRight.BackColor = System.Drawing.Color.Transparent;
            this.checkStickRight.Enabled = false;
            this.checkStickRight.Location = new System.Drawing.Point(497, 439);
            this.checkStickRight.Margin = new System.Windows.Forms.Padding(4);
            this.checkStickRight.Name = "checkStickRight";
            this.checkStickRight.Size = new System.Drawing.Size(18, 17);
            this.checkStickRight.TabIndex = 16;
            this.checkStickRight.UseVisualStyleBackColor = false;
            // 
            // checkStickLeft
            // 
            this.checkStickLeft.AutoSize = true;
            this.checkStickLeft.BackColor = System.Drawing.Color.Transparent;
            this.checkStickLeft.Enabled = false;
            this.checkStickLeft.Location = new System.Drawing.Point(140, 335);
            this.checkStickLeft.Margin = new System.Windows.Forms.Padding(4);
            this.checkStickLeft.Name = "checkStickLeft";
            this.checkStickLeft.Size = new System.Drawing.Size(18, 17);
            this.checkStickLeft.TabIndex = 17;
            this.checkStickLeft.UseVisualStyleBackColor = false;
            // 
            // checkDPadUp
            // 
            this.checkDPadUp.AutoSize = true;
            this.checkDPadUp.BackColor = System.Drawing.Color.Transparent;
            this.checkDPadUp.Enabled = false;
            this.checkDPadUp.Location = new System.Drawing.Point(272, 388);
            this.checkDPadUp.Margin = new System.Windows.Forms.Padding(4);
            this.checkDPadUp.Name = "checkDPadUp";
            this.checkDPadUp.Size = new System.Drawing.Size(18, 17);
            this.checkDPadUp.TabIndex = 18;
            this.checkDPadUp.UseVisualStyleBackColor = false;
            // 
            // checkDPadRight
            // 
            this.checkDPadRight.AutoSize = true;
            this.checkDPadRight.BackColor = System.Drawing.Color.Transparent;
            this.checkDPadRight.Enabled = false;
            this.checkDPadRight.Location = new System.Drawing.Point(321, 421);
            this.checkDPadRight.Margin = new System.Windows.Forms.Padding(4);
            this.checkDPadRight.Name = "checkDPadRight";
            this.checkDPadRight.Size = new System.Drawing.Size(18, 17);
            this.checkDPadRight.TabIndex = 19;
            this.checkDPadRight.UseVisualStyleBackColor = false;
            // 
            // checkDPadDown
            // 
            this.checkDPadDown.AutoSize = true;
            this.checkDPadDown.BackColor = System.Drawing.Color.Transparent;
            this.checkDPadDown.Enabled = false;
            this.checkDPadDown.Location = new System.Drawing.Point(280, 452);
            this.checkDPadDown.Margin = new System.Windows.Forms.Padding(4);
            this.checkDPadDown.Name = "checkDPadDown";
            this.checkDPadDown.Size = new System.Drawing.Size(18, 17);
            this.checkDPadDown.TabIndex = 20;
            this.checkDPadDown.UseVisualStyleBackColor = false;
            // 
            // checkDPadLeft
            // 
            this.checkDPadLeft.AutoSize = true;
            this.checkDPadLeft.BackColor = System.Drawing.Color.Transparent;
            this.checkDPadLeft.Enabled = false;
            this.checkDPadLeft.Location = new System.Drawing.Point(233, 421);
            this.checkDPadLeft.Margin = new System.Windows.Forms.Padding(4);
            this.checkDPadLeft.Name = "checkDPadLeft";
            this.checkDPadLeft.Size = new System.Drawing.Size(18, 17);
            this.checkDPadLeft.TabIndex = 21;
            this.checkDPadLeft.UseVisualStyleBackColor = false;
            // 
            // labelTriggerLeft
            // 
            this.labelTriggerLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTriggerLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTriggerLeft.Location = new System.Drawing.Point(172, 95);
            this.labelTriggerLeft.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTriggerLeft.Name = "labelTriggerLeft";
            this.labelTriggerLeft.Size = new System.Drawing.Size(79, 28);
            this.labelTriggerLeft.TabIndex = 22;
            this.labelTriggerLeft.Text = "1.0";
            this.labelTriggerLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTriggerRight
            // 
            this.labelTriggerRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTriggerRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTriggerRight.Location = new System.Drawing.Point(541, 95);
            this.labelTriggerRight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTriggerRight.Name = "labelTriggerRight";
            this.labelTriggerRight.Size = new System.Drawing.Size(79, 28);
            this.labelTriggerRight.TabIndex = 23;
            this.labelTriggerRight.Text = "1.0";
            this.labelTriggerRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkLink
            // 
            this.checkLink.AutoSize = true;
            this.checkLink.BackColor = System.Drawing.Color.Transparent;
            this.checkLink.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkLink.Location = new System.Drawing.Point(311, 98);
            this.checkLink.Margin = new System.Windows.Forms.Padding(4);
            this.checkLink.Name = "checkLink";
            this.checkLink.Size = new System.Drawing.Size(182, 38);
            this.checkLink.TabIndex = 24;
            this.checkLink.Text = "Link triggers to vibration\r\n(Hold Back button)";
            this.checkLink.UseVisualStyleBackColor = false;
            this.checkLink.CheckedChanged += new System.EventHandler(this.checkLink_CheckedChanged);
            // 
            // labelStickLeftX
            // 
            this.labelStickLeftX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelStickLeftX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStickLeftX.Location = new System.Drawing.Point(107, 258);
            this.labelStickLeftX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStickLeftX.Name = "labelStickLeftX";
            this.labelStickLeftX.Size = new System.Drawing.Size(79, 28);
            this.labelStickLeftX.TabIndex = 25;
            this.labelStickLeftX.Text = "1.0";
            this.labelStickLeftX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelStickLeftY
            // 
            this.labelStickLeftY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelStickLeftY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStickLeftY.Location = new System.Drawing.Point(9, 324);
            this.labelStickLeftY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStickLeftY.Name = "labelStickLeftY";
            this.labelStickLeftY.Size = new System.Drawing.Size(79, 28);
            this.labelStickLeftY.TabIndex = 26;
            this.labelStickLeftY.Text = "1.0";
            this.labelStickLeftY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelStickRightX
            // 
            this.labelStickRightX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelStickRightX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStickRightX.Location = new System.Drawing.Point(468, 377);
            this.labelStickRightX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStickRightX.Name = "labelStickRightX";
            this.labelStickRightX.Size = new System.Drawing.Size(79, 28);
            this.labelStickRightX.TabIndex = 27;
            this.labelStickRightX.Text = "1.0";
            this.labelStickRightX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelStickRightY
            // 
            this.labelStickRightY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelStickRightY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStickRightY.Location = new System.Drawing.Point(375, 428);
            this.labelStickRightY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStickRightY.Name = "labelStickRightY";
            this.labelStickRightY.Size = new System.Drawing.Size(79, 28);
            this.labelStickRightY.TabIndex = 28;
            this.labelStickRightY.Text = "1.0";
            this.labelStickRightY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboDeadZone
            // 
            this.comboDeadZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDeadZone.FormattingEnabled = true;
            this.comboDeadZone.Location = new System.Drawing.Point(881, 258);
            this.comboDeadZone.Margin = new System.Windows.Forms.Padding(4);
            this.comboDeadZone.Name = "comboDeadZone";
            this.comboDeadZone.Size = new System.Drawing.Size(160, 24);
            this.comboDeadZone.TabIndex = 29;
            this.comboDeadZone.SelectedValueChanged += new System.EventHandler(this.comboDeadZone_SelectedValueChanged);
            // 
            // labelDeadZone
            // 
            this.labelDeadZone.AutoSize = true;
            this.labelDeadZone.BackColor = System.Drawing.Color.Transparent;
            this.labelDeadZone.Location = new System.Drawing.Point(795, 262);
            this.labelDeadZone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDeadZone.Name = "labelDeadZone";
            this.labelDeadZone.Size = new System.Drawing.Size(77, 17);
            this.labelDeadZone.TabIndex = 30;
            this.labelDeadZone.Text = "Dead zone";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(879, 288);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 17);
            this.label1.TabIndex = 31;
            this.label1.Text = "(Hold Start button)";
            // 
            // timerBack
            // 
            this.timerBack.Interval = 1000;
            this.timerBack.Tick += new System.EventHandler(this.timerBack_Tick);
            // 
            // timerStart
            // 
            this.timerStart.Interval = 1000;
            this.timerStart.Tick += new System.EventHandler(this.timerStart_Tick);
            // 
            // picStickLeft
            // 
            this.picStickLeft.BackColor = System.Drawing.Color.Transparent;
            this.picStickLeft.Image = global::XInputReporter.Properties.Resources.thumbstick;
            this.picStickLeft.Location = new System.Drawing.Point(799, 422);
            this.picStickLeft.Margin = new System.Windows.Forms.Padding(4);
            this.picStickLeft.Name = "picStickLeft";
            this.picStickLeft.Size = new System.Drawing.Size(85, 79);
            this.picStickLeft.TabIndex = 32;
            this.picStickLeft.TabStop = false;
            // 
            // picStickRight
            // 
            this.picStickRight.BackColor = System.Drawing.Color.Transparent;
            this.picStickRight.Image = global::XInputReporter.Properties.Resources.thumbstick;
            this.picStickRight.Location = new System.Drawing.Point(969, 422);
            this.picStickRight.Margin = new System.Windows.Forms.Padding(4);
            this.picStickRight.Name = "picStickRight";
            this.picStickRight.Size = new System.Drawing.Size(85, 79);
            this.picStickRight.TabIndex = 33;
            this.picStickRight.TabStop = false;
            // 
            // checkGuide
            // 
            this.checkGuide.AutoSize = true;
            this.checkGuide.BackColor = System.Drawing.Color.Transparent;
            this.checkGuide.Enabled = false;
            this.checkGuide.Location = new System.Drawing.Point(391, 324);
            this.checkGuide.Margin = new System.Windows.Forms.Padding(4);
            this.checkGuide.Name = "checkGuide";
            this.checkGuide.Size = new System.Drawing.Size(18, 17);
            this.checkGuide.TabIndex = 34;
            this.checkGuide.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::XInputReporter.Properties.Resources.background1;
            this.ClientSize = new System.Drawing.Size(1132, 581);
            this.Controls.Add(this.checkGuide);
            this.Controls.Add(this.picStickRight);
            this.Controls.Add(this.picStickLeft);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboDeadZone);
            this.Controls.Add(this.labelStickRightY);
            this.Controls.Add(this.labelStickRightX);
            this.Controls.Add(this.labelStickLeftY);
            this.Controls.Add(this.labelStickLeftX);
            this.Controls.Add(this.checkLink);
            this.Controls.Add(this.labelTriggerRight);
            this.Controls.Add(this.labelTriggerLeft);
            this.Controls.Add(this.checkDPadLeft);
            this.Controls.Add(this.checkDPadDown);
            this.Controls.Add(this.checkDPadRight);
            this.Controls.Add(this.checkDPadUp);
            this.Controls.Add(this.checkStickLeft);
            this.Controls.Add(this.checkStickRight);
            this.Controls.Add(this.checkBack);
            this.Controls.Add(this.checkStart);
            this.Controls.Add(this.checkA);
            this.Controls.Add(this.checkB);
            this.Controls.Add(this.checkX);
            this.Controls.Add(this.checkY);
            this.Controls.Add(this.checkShoulderLeft);
            this.Controls.Add(this.checkShoulderRight);
            this.Controls.Add(this.picController4);
            this.Controls.Add(this.picController3);
            this.Controls.Add(this.picController2);
            this.Controls.Add(this.picController1);
            this.Controls.Add(this.labelDeadZone);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XInput.NET Reporter";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picController2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picController3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picController4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStickLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStickRight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picController1;
        private System.Windows.Forms.PictureBox picController2;
        private System.Windows.Forms.PictureBox picController3;
        private System.Windows.Forms.PictureBox picController4;
        private System.ComponentModel.BackgroundWorker pollingWorker;
        private System.Windows.Forms.CheckBox checkShoulderRight;
        private System.Windows.Forms.CheckBox checkShoulderLeft;
        private System.Windows.Forms.CheckBox checkY;
        private System.Windows.Forms.CheckBox checkX;
        private System.Windows.Forms.CheckBox checkB;
        private System.Windows.Forms.CheckBox checkA;
        private System.Windows.Forms.CheckBox checkStart;
        private System.Windows.Forms.CheckBox checkBack;
        private System.Windows.Forms.CheckBox checkStickRight;
        private System.Windows.Forms.CheckBox checkStickLeft;
        private System.Windows.Forms.CheckBox checkDPadUp;
        private System.Windows.Forms.CheckBox checkDPadRight;
        private System.Windows.Forms.CheckBox checkDPadDown;
        private System.Windows.Forms.CheckBox checkDPadLeft;
        private System.Windows.Forms.Label labelTriggerLeft;
        private System.Windows.Forms.Label labelTriggerRight;
        private System.Windows.Forms.CheckBox checkLink;
        private System.Windows.Forms.Label labelStickLeftX;
        private System.Windows.Forms.Label labelStickLeftY;
        private System.Windows.Forms.Label labelStickRightX;
        private System.Windows.Forms.Label labelStickRightY;
        private System.Windows.Forms.ComboBox comboDeadZone;
        private System.Windows.Forms.Label labelDeadZone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerBack;
        private System.Windows.Forms.Timer timerStart;
        private System.Windows.Forms.PictureBox picStickLeft;
        private System.Windows.Forms.PictureBox picStickRight;
        private System.Windows.Forms.CheckBox checkGuide;
    }
}

