namespace SmartH2O_SeeApp
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.submitHourlyParameterButton = new System.Windows.Forms.Button();
            this.parameterHourlyDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.submitDailyParameterButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toDailyDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.fromDailyDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.weekComboBox = new System.Windows.Forms.ComboBox();
            this.submitWeeklyParameterButton = new System.Windows.Forms.Button();
            this.weeklyDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.button3 = new System.Windows.Forms.Button();
            this.parametersCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.From = new System.Windows.Forms.Label();
            this.optionsAlarmsComboBox = new System.Windows.Forms.ComboBox();
            this.submitAlarmsButton = new System.Windows.Forms.Button();
            this.toAlarmsDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.fromAlarmsDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.listView2 = new System.Windows.Forms.ListView();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.listBoxParametersValues = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(602, 569);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Tag = "fsd";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listBoxParametersValues);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.tabControl2);
            this.tabPage1.Controls.Add(this.parametersCheckedListBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(594, 543);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Parameters Values";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 26);
            this.label4.TabIndex = 13;
            this.label4.Text = "Select the parameter that \r\nyou want to visualize.\r\n";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Location = new System.Drawing.Point(150, 19);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(425, 147);
            this.tabControl2.TabIndex = 12;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.submitHourlyParameterButton);
            this.tabPage3.Controls.Add(this.parameterHourlyDateTimePicker);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(417, 121);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Infor. Hourly";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Select a day to show";
            // 
            // submitHourlyParameterButton
            // 
            this.submitHourlyParameterButton.Location = new System.Drawing.Point(339, 92);
            this.submitHourlyParameterButton.Name = "submitHourlyParameterButton";
            this.submitHourlyParameterButton.Size = new System.Drawing.Size(75, 23);
            this.submitHourlyParameterButton.TabIndex = 1;
            this.submitHourlyParameterButton.Text = "Submit";
            this.submitHourlyParameterButton.UseVisualStyleBackColor = true;
            this.submitHourlyParameterButton.Click += new System.EventHandler(this.submitHourlyParameterButton_Click);
            // 
            // parameterHourlyDateTimePicker
            // 
            this.parameterHourlyDateTimePicker.Location = new System.Drawing.Point(143, 40);
            this.parameterHourlyDateTimePicker.Name = "parameterHourlyDateTimePicker";
            this.parameterHourlyDateTimePicker.Size = new System.Drawing.Size(174, 20);
            this.parameterHourlyDateTimePicker.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Controls.Add(this.submitDailyParameterButton);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.toDailyDateTimePicker);
            this.tabPage4.Controls.Add(this.fromDailyDateTimePicker);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(417, 121);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Infor. Daily";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Select a specific threshold";
            // 
            // submitDailyParameterButton
            // 
            this.submitDailyParameterButton.Location = new System.Drawing.Point(339, 92);
            this.submitDailyParameterButton.Name = "submitDailyParameterButton";
            this.submitDailyParameterButton.Size = new System.Drawing.Size(75, 23);
            this.submitDailyParameterButton.TabIndex = 17;
            this.submitDailyParameterButton.Text = "Submit";
            this.submitDailyParameterButton.UseVisualStyleBackColor = true;
            this.submitDailyParameterButton.Click += new System.EventHandler(this.submitDailyParameterButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "From";
            // 
            // toDailyDateTimePicker
            // 
            this.toDailyDateTimePicker.Location = new System.Drawing.Point(85, 78);
            this.toDailyDateTimePicker.Name = "toDailyDateTimePicker";
            this.toDailyDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.toDailyDateTimePicker.TabIndex = 14;
            // 
            // fromDailyDateTimePicker
            // 
            this.fromDailyDateTimePicker.Location = new System.Drawing.Point(85, 38);
            this.fromDailyDateTimePicker.Name = "fromDailyDateTimePicker";
            this.fromDailyDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.fromDailyDateTimePicker.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.label10);
            this.tabPage5.Controls.Add(this.label9);
            this.tabPage5.Controls.Add(this.label8);
            this.tabPage5.Controls.Add(this.weekComboBox);
            this.tabPage5.Controls.Add(this.submitWeeklyParameterButton);
            this.tabPage5.Controls.Add(this.weeklyDateTimePicker);
            this.tabPage5.Controls.Add(this.button3);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(417, 121);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Infor. Weekly";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Select a week";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Select a year";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Select a specific week";
            // 
            // weekComboBox
            // 
            this.weekComboBox.FormattingEnabled = true;
            this.weekComboBox.Location = new System.Drawing.Point(92, 79);
            this.weekComboBox.Name = "weekComboBox";
            this.weekComboBox.Size = new System.Drawing.Size(235, 21);
            this.weekComboBox.TabIndex = 3;
            // 
            // submitWeeklyParameterButton
            // 
            this.submitWeeklyParameterButton.Location = new System.Drawing.Point(339, 92);
            this.submitWeeklyParameterButton.Name = "submitWeeklyParameterButton";
            this.submitWeeklyParameterButton.Size = new System.Drawing.Size(75, 23);
            this.submitWeeklyParameterButton.TabIndex = 2;
            this.submitWeeklyParameterButton.Text = "Submit";
            this.submitWeeklyParameterButton.UseVisualStyleBackColor = true;
            this.submitWeeklyParameterButton.Click += new System.EventHandler(this.submitWeeklyParameterButton_Click);
            // 
            // weeklyDateTimePicker
            // 
            this.weeklyDateTimePicker.CustomFormat = "yyyy";
            this.weeklyDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.weeklyDateTimePicker.Location = new System.Drawing.Point(92, 44);
            this.weeklyDateTimePicker.Name = "weeklyDateTimePicker";
            this.weeklyDateTimePicker.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.weeklyDateTimePicker.ShowUpDown = true;
            this.weeklyDateTimePicker.Size = new System.Drawing.Size(235, 20);
            this.weeklyDateTimePicker.TabIndex = 1;
            this.weeklyDateTimePicker.ValueChanged += new System.EventHandler(this.weeklyDateTimePicker_ValueChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(262, 121);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // parametersCheckedListBox
            // 
            this.parametersCheckedListBox.FormattingEnabled = true;
            this.parametersCheckedListBox.Items.AddRange(new object[] {
            "PH",
            "HN3",
            "CI2"});
            this.parametersCheckedListBox.Location = new System.Drawing.Point(41, 79);
            this.parametersCheckedListBox.Name = "parametersCheckedListBox";
            this.parametersCheckedListBox.Size = new System.Drawing.Size(58, 49);
            this.parametersCheckedListBox.TabIndex = 11;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.From);
            this.tabPage2.Controls.Add(this.optionsAlarmsComboBox);
            this.tabPage2.Controls.Add(this.submitAlarmsButton);
            this.tabPage2.Controls.Add(this.toAlarmsDateTimePicker);
            this.tabPage2.Controls.Add(this.fromAlarmsDateTimePicker);
            this.tabPage2.Controls.Add(this.listView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(594, 543);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Parameters Alarms";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Select a option below";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(217, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "To";
            // 
            // From
            // 
            this.From.AutoSize = true;
            this.From.Location = new System.Drawing.Point(214, 29);
            this.From.Name = "From";
            this.From.Size = new System.Drawing.Size(30, 13);
            this.From.TabIndex = 5;
            this.From.Text = "From";
            // 
            // optionsAlarmsComboBox
            // 
            this.optionsAlarmsComboBox.FormattingEnabled = true;
            this.optionsAlarmsComboBox.Items.AddRange(new object[] {
            "All Alarms",
            "Between to dates"});
            this.optionsAlarmsComboBox.Location = new System.Drawing.Point(28, 57);
            this.optionsAlarmsComboBox.Name = "optionsAlarmsComboBox";
            this.optionsAlarmsComboBox.Size = new System.Drawing.Size(150, 21);
            this.optionsAlarmsComboBox.TabIndex = 4;
            this.optionsAlarmsComboBox.SelectedIndexChanged += new System.EventHandler(this.optionsAlarmsComboBox_SelectedIndexChanged);
            // 
            // submitAlarmsButton
            // 
            this.submitAlarmsButton.Location = new System.Drawing.Point(495, 59);
            this.submitAlarmsButton.Name = "submitAlarmsButton";
            this.submitAlarmsButton.Size = new System.Drawing.Size(75, 23);
            this.submitAlarmsButton.TabIndex = 3;
            this.submitAlarmsButton.Text = "Submit";
            this.submitAlarmsButton.UseVisualStyleBackColor = true;
            this.submitAlarmsButton.Click += new System.EventHandler(this.submitAlarmsButton_Click);
            // 
            // toAlarmsDateTimePicker
            // 
            this.toAlarmsDateTimePicker.Enabled = false;
            this.toAlarmsDateTimePicker.Location = new System.Drawing.Point(260, 59);
            this.toAlarmsDateTimePicker.Name = "toAlarmsDateTimePicker";
            this.toAlarmsDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.toAlarmsDateTimePicker.TabIndex = 2;
            // 
            // fromAlarmsDateTimePicker
            // 
            this.fromAlarmsDateTimePicker.Enabled = false;
            this.fromAlarmsDateTimePicker.Location = new System.Drawing.Point(260, 23);
            this.fromAlarmsDateTimePicker.Name = "fromAlarmsDateTimePicker";
            this.fromAlarmsDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.fromAlarmsDateTimePicker.TabIndex = 1;
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(6, 100);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(564, 395);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(594, 543);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "Graphicall Information";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // listBoxParametersValues
            // 
            this.listBoxParametersValues.FormattingEnabled = true;
            this.listBoxParametersValues.Location = new System.Drawing.Point(9, 175);
            this.listBoxParametersValues.Name = "listBoxParametersValues";
            this.listBoxParametersValues.Size = new System.Drawing.Size(562, 355);
            this.listBoxParametersValues.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 575);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "SmartH20";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckedListBox parametersCheckedListBox;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button submitHourlyParameterButton;
        private System.Windows.Forms.DateTimePicker parameterHourlyDateTimePicker;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker toDailyDateTimePicker;
        private System.Windows.Forms.DateTimePicker fromDailyDateTimePicker;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DateTimePicker weeklyDateTimePicker;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button submitAlarmsButton;
        private System.Windows.Forms.DateTimePicker toAlarmsDateTimePicker;
        private System.Windows.Forms.DateTimePicker fromAlarmsDateTimePicker;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox optionsAlarmsComboBox;
        private System.Windows.Forms.Button submitDailyParameterButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label From;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox weekComboBox;
        private System.Windows.Forms.Button submitWeeklyParameterButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox listBoxParametersValues;
    }
}

