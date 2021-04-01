namespace JimsMacros
{
    partial class AutoClickControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTimesBeforeRest = new System.Windows.Forms.TextBox();
            this.txtTimeBeforeBreak = new System.Windows.Forms.TextBox();
            this.rdbClick = new System.Windows.Forms.RadioButton();
            this.rdbButton = new System.Windows.Forms.RadioButton();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.chkHoldShift = new System.Windows.Forms.CheckBox();
            this.chkAutoStart = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtHoldTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(3, 46);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(146, 42);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(155, 46);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(146, 42);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(3, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 3;
            this.txtName.Text = "Click";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(400, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Times Before Rest";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(626, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Break Time (ms)";
            // 
            // txtTimesBeforeRest
            // 
            this.txtTimesBeforeRest.Location = new System.Drawing.Point(500, 20);
            this.txtTimesBeforeRest.Name = "txtTimesBeforeRest";
            this.txtTimesBeforeRest.Size = new System.Drawing.Size(100, 20);
            this.txtTimesBeforeRest.TabIndex = 6;
            this.txtTimesBeforeRest.Text = "10";
            // 
            // txtTimeBeforeBreak
            // 
            this.txtTimeBeforeBreak.Location = new System.Drawing.Point(715, 21);
            this.txtTimeBeforeBreak.Name = "txtTimeBeforeBreak";
            this.txtTimeBeforeBreak.Size = new System.Drawing.Size(100, 20);
            this.txtTimeBeforeBreak.TabIndex = 7;
            this.txtTimeBeforeBreak.Text = "5000";
            // 
            // rdbClick
            // 
            this.rdbClick.AutoSize = true;
            this.rdbClick.Checked = true;
            this.rdbClick.Location = new System.Drawing.Point(325, 49);
            this.rdbClick.Name = "rdbClick";
            this.rdbClick.Size = new System.Drawing.Size(48, 17);
            this.rdbClick.TabIndex = 8;
            this.rdbClick.TabStop = true;
            this.rdbClick.Text = "Click";
            this.rdbClick.UseVisualStyleBackColor = true;
            // 
            // rdbButton
            // 
            this.rdbButton.AutoSize = true;
            this.rdbButton.Location = new System.Drawing.Point(438, 50);
            this.rdbButton.Name = "rdbButton";
            this.rdbButton.Size = new System.Drawing.Size(56, 17);
            this.rdbButton.TabIndex = 9;
            this.rdbButton.Text = "Button";
            this.rdbButton.UseVisualStyleBackColor = true;
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(500, 47);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(100, 20);
            this.txtKey.TabIndex = 10;
            this.txtKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKey_KeyDown);
            // 
            // chkHoldShift
            // 
            this.chkHoldShift.AutoSize = true;
            this.chkHoldShift.Location = new System.Drawing.Point(629, 49);
            this.chkHoldShift.Name = "chkHoldShift";
            this.chkHoldShift.Size = new System.Drawing.Size(72, 17);
            this.chkHoldShift.TabIndex = 13;
            this.chkHoldShift.Text = "Hold Shift";
            this.chkHoldShift.UseVisualStyleBackColor = true;
            // 
            // chkAutoStart
            // 
            this.chkAutoStart.AutoSize = true;
            this.chkAutoStart.Checked = true;
            this.chkAutoStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoStart.Location = new System.Drawing.Point(127, 20);
            this.chkAutoStart.Name = "chkAutoStart";
            this.chkAutoStart.Size = new System.Drawing.Size(174, 17);
            this.chkAutoStart.TabIndex = 14;
            this.chkAutoStart.Text = "Start when \"Run All\" is pressed";
            this.chkAutoStart.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Action";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(773, 81);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(59, 22);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtHoldTime
            // 
            this.txtHoldTime.Location = new System.Drawing.Point(500, 73);
            this.txtHoldTime.Name = "txtHoldTime";
            this.txtHoldTime.Size = new System.Drawing.Size(100, 20);
            this.txtHoldTime.TabIndex = 18;
            this.txtHoldTime.Text = "10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(417, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Hold Time (ms)";
            // 
            // AutoClickControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.txtHoldTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkAutoStart);
            this.Controls.Add(this.chkHoldShift);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.rdbButton);
            this.Controls.Add(this.rdbClick);
            this.Controls.Add(this.txtTimeBeforeBreak);
            this.Controls.Add(this.txtTimesBeforeRest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "AutoClickControl";
            this.Size = new System.Drawing.Size(835, 106);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTimesBeforeRest;
        private System.Windows.Forms.TextBox txtTimeBeforeBreak;
        private System.Windows.Forms.RadioButton rdbClick;
        private System.Windows.Forms.RadioButton rdbButton;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.CheckBox chkHoldShift;
        private System.Windows.Forms.CheckBox chkAutoStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtHoldTime;
        private System.Windows.Forms.Label label4;
    }
}
