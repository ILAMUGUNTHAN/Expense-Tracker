namespace Expense_Tracker_Application
{
    partial class FilterForm
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
            this.MonthFilterComboBox = new System.Windows.Forms.ComboBox();
            this.ResetDateBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.FilterComboBox = new System.Windows.Forms.ComboBox();
            this.FilterBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MonthFilterComboBox
            // 
            this.MonthFilterComboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.MonthFilterComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MonthFilterComboBox.FormattingEnabled = true;
            this.MonthFilterComboBox.Items.AddRange(new object[] {
            "0. None",
            "1. January",
            "2. February",
            "3. March",
            "4. April",
            "5. May",
            "6. June",
            "7. July",
            "8. August",
            "9. September",
            "10. October",
            "11. November",
            "12. December"});
            this.MonthFilterComboBox.Location = new System.Drawing.Point(0, 28);
            this.MonthFilterComboBox.Name = "MonthFilterComboBox";
            this.MonthFilterComboBox.Size = new System.Drawing.Size(265, 28);
            this.MonthFilterComboBox.TabIndex = 18;
            this.MonthFilterComboBox.Text = "select month";
            // 
            // ResetDateBtn
            // 
            this.ResetDateBtn.BackColor = System.Drawing.Color.Gray;
            this.ResetDateBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.ResetDateBtn.Location = new System.Drawing.Point(0, 106);
            this.ResetDateBtn.Name = "ResetDateBtn";
            this.ResetDateBtn.Size = new System.Drawing.Size(265, 31);
            this.ResetDateBtn.TabIndex = 17;
            this.ResetDateBtn.Text = "Reset Date";
            this.ResetDateBtn.UseVisualStyleBackColor = false;
            this.ResetDateBtn.Click += new System.EventHandler(this.OnClickRestDate);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(138, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "To";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd-mm-yyyy";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(141, 21);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(120, 20);
            this.dateTimePicker2.TabIndex = 15;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.OnValueChangedDateTimePicker);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "From";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(6, 22);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(120, 20);
            this.dateTimePicker1.TabIndex = 13;
            this.dateTimePicker1.Value = new System.DateTime(2024, 2, 26, 12, 28, 58, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.OnValueChangedDateTimePicker);
            // 
            // FilterComboBox
            // 
            this.FilterComboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.FilterComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterComboBox.FormattingEnabled = true;
            this.FilterComboBox.Items.AddRange(new object[] {
            "None"});
            this.FilterComboBox.Location = new System.Drawing.Point(0, 0);
            this.FilterComboBox.Name = "FilterComboBox";
            this.FilterComboBox.Size = new System.Drawing.Size(265, 28);
            this.FilterComboBox.TabIndex = 12;
            this.FilterComboBox.Text = "select category";
            // 
            // FilterBtn
            // 
            this.FilterBtn.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.FilterBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilterBtn.Location = new System.Drawing.Point(0, 137);
            this.FilterBtn.Name = "FilterBtn";
            this.FilterBtn.Size = new System.Drawing.Size(265, 52);
            this.FilterBtn.TabIndex = 17;
            this.FilterBtn.Text = "Submit";
            this.FilterBtn.UseVisualStyleBackColor = false;
            this.FilterBtn.Click += new System.EventHandler(this.OnClickSubmit);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 50);
            this.panel1.TabIndex = 19;
            // 
            // FilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 189);
            this.Controls.Add(this.FilterBtn);
            this.Controls.Add(this.ResetDateBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MonthFilterComboBox);
            this.Controls.Add(this.FilterComboBox);
            this.Name = "FilterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FilterForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox MonthFilterComboBox;
        private System.Windows.Forms.Button ResetDateBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox FilterComboBox;
        private System.Windows.Forms.Button FilterBtn;
        private System.Windows.Forms.Panel panel1;
    }
}