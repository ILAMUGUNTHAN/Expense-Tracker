namespace Expense_Tracker_Application
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.AddCategoryBtn = new System.Windows.Forms.Button();
            this.EditCategoryBtn = new System.Windows.Forms.Button();
            this.ClearFilterBtn = new System.Windows.Forms.Button();
            this.FilterBtn = new System.Windows.Forms.Button();
            this.TotExpenseBtn = new System.Windows.Forms.Button();
            this.EditBtn = new System.Windows.Forms.Button();
            this.RemoveExpenseBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.AddCategoryBtn);
            this.panel1.Controls.Add(this.EditCategoryBtn);
            this.panel1.Controls.Add(this.ClearFilterBtn);
            this.panel1.Controls.Add(this.FilterBtn);
            this.panel1.Controls.Add(this.TotExpenseBtn);
            this.panel1.Controls.Add(this.EditBtn);
            this.panel1.Controls.Add(this.RemoveExpenseBtn);
            this.panel1.Controls.Add(this.AddBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(517, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 450);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(283, 58);
            this.panel2.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Sitka Text", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 58);
            this.label1.TabIndex = 13;
            this.label1.Text = "Expense Tracker";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddCategoryBtn
            // 
            this.AddCategoryBtn.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddCategoryBtn.Location = new System.Drawing.Point(8, 286);
            this.AddCategoryBtn.Name = "AddCategoryBtn";
            this.AddCategoryBtn.Size = new System.Drawing.Size(130, 40);
            this.AddCategoryBtn.TabIndex = 11;
            this.AddCategoryBtn.Text = "Add Category";
            this.AddCategoryBtn.UseVisualStyleBackColor = true;
            this.AddCategoryBtn.Click += new System.EventHandler(this.OnClickAddCategory);
            // 
            // EditCategoryBtn
            // 
            this.EditCategoryBtn.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditCategoryBtn.Location = new System.Drawing.Point(145, 286);
            this.EditCategoryBtn.Name = "EditCategoryBtn";
            this.EditCategoryBtn.Size = new System.Drawing.Size(130, 40);
            this.EditCategoryBtn.TabIndex = 11;
            this.EditCategoryBtn.Text = "Edit Category";
            this.EditCategoryBtn.UseVisualStyleBackColor = true;
            this.EditCategoryBtn.Click += new System.EventHandler(this.OnClickEditCategory);
            // 
            // ClearFilterBtn
            // 
            this.ClearFilterBtn.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearFilterBtn.Location = new System.Drawing.Point(145, 332);
            this.ClearFilterBtn.Name = "ClearFilterBtn";
            this.ClearFilterBtn.Size = new System.Drawing.Size(130, 40);
            this.ClearFilterBtn.TabIndex = 2;
            this.ClearFilterBtn.Text = "Clear Filter";
            this.ClearFilterBtn.UseVisualStyleBackColor = true;
            this.ClearFilterBtn.Click += new System.EventHandler(this.OnClickClearExpense);
            // 
            // FilterBtn
            // 
            this.FilterBtn.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterBtn.Location = new System.Drawing.Point(9, 332);
            this.FilterBtn.Name = "FilterBtn";
            this.FilterBtn.Size = new System.Drawing.Size(130, 40);
            this.FilterBtn.TabIndex = 2;
            this.FilterBtn.Text = "Filter Expense";
            this.FilterBtn.UseVisualStyleBackColor = true;
            this.FilterBtn.Click += new System.EventHandler(this.OnClickFilterExpense);
            // 
            // TotExpenseBtn
            // 
            this.TotExpenseBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotExpenseBtn.Location = new System.Drawing.Point(8, 380);
            this.TotExpenseBtn.Name = "TotExpenseBtn";
            this.TotExpenseBtn.Size = new System.Drawing.Size(270, 61);
            this.TotExpenseBtn.TabIndex = 2;
            this.TotExpenseBtn.Text = "View Total Expense";
            this.TotExpenseBtn.UseVisualStyleBackColor = true;
            this.TotExpenseBtn.Click += new System.EventHandler(this.OnClickTotalExpense);
            // 
            // EditBtn
            // 
            this.EditBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditBtn.Location = new System.Drawing.Point(7, 211);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(270, 65);
            this.EditBtn.TabIndex = 1;
            this.EditBtn.Text = "Edit Expense";
            this.EditBtn.UseVisualStyleBackColor = true;
            this.EditBtn.Click += new System.EventHandler(this.OnClickEditExpense);
            // 
            // RemoveExpenseBtn
            // 
            this.RemoveExpenseBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveExpenseBtn.Location = new System.Drawing.Point(7, 139);
            this.RemoveExpenseBtn.Name = "RemoveExpenseBtn";
            this.RemoveExpenseBtn.Size = new System.Drawing.Size(270, 65);
            this.RemoveExpenseBtn.TabIndex = 1;
            this.RemoveExpenseBtn.Text = "Remove Expense";
            this.RemoveExpenseBtn.UseVisualStyleBackColor = true;
            this.RemoveExpenseBtn.Click += new System.EventHandler(this.OnClickRemoveExpense);
            // 
            // AddBtn
            // 
            this.AddBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddBtn.Location = new System.Drawing.Point(7, 67);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(270, 65);
            this.AddBtn.TabIndex = 0;
            this.AddBtn.Text = "Add Expense";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.OnClickAddExpense);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(517, 450);
            this.dataGridView1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.OnLoadForm);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button RemoveExpenseBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button TotExpenseBtn;
        private System.Windows.Forms.Button EditCategoryBtn;
        private System.Windows.Forms.Button FilterBtn;
        private System.Windows.Forms.Button ClearFilterBtn;
        private System.Windows.Forms.Button AddCategoryBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

