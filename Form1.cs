using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expense_Tracker_Application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
            ExpenseManager.SetDataGridView(dataGridView1);


        }

        private EditCategoryForm editCategoryForm;
        private FilterForm filterForm;
        private AddCategoryForm addCatForm;


        private void OnClickAddExpense(object sender, EventArgs e)
        {
            ExpenseManager.AddExpense();
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void OnClickRemoveExpense(object sender, EventArgs e)
        {
            ExpenseManager.RemoveExpense();
        }
       

        private void OnClickTotalExpense(object sender, EventArgs e)
        {
            MessageBox.Show("Total expense: "+ExpenseManager.GetTotalExpense());
        }

               

        private void OnClickEditCategory(object sender, EventArgs e)
        {
            editCategoryForm = new EditCategoryForm();
            editCategoryForm.Location = new Point(600, 400);
            editCategoryForm.Show();
        }

        private void OnClickFilterExpense(object sender, EventArgs e)
        {
            filterForm = new FilterForm();
            filterForm.Location = new Point(600, 400);
            filterForm.Show();
        }

        private void OnClickAddCategory(object sender, EventArgs e)
        {
            addCatForm = new AddCategoryForm();
            addCatForm.Location = new Point(600, 400);

            addCatForm.Show();

        }

        private void OnClickClearExpense(object sender, EventArgs e)
        {

            dataGridView1.DataSource = ExpenseManager.SetExpenseDataFromDb();

        }

       

        private void OnClickEditExpense(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0 || Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value) == 0)
            {
                
                return;
            }

            int selectedId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            int rowInd = dataGridView1.CurrentCell.RowIndex;

            ExpenseManager.EditExpense(selectedId,rowInd);
        }

        private void OnLoadForm(object sender, EventArgs e)
        {
            CategoryManager.categoryNameList = ExpenseManager.SetCategoryDataFromDb();
            dataGridView1.DataSource = ExpenseManager.SetExpenseDataFromDb();
            ExpenseManager.InitializeDataGridView();



        }
        
    }
}
