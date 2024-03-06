using MySql.Data.MySqlClient;
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
    public partial class ExpenseInputForm : Form
    {
        public ExpenseInputForm()
        {
            InitializeComponent();
            CategoryComboBox.DataSource = CategoryManager.categoryNameList;
           
        }


        public EventHandler SubmitClick;

        private void OnClickSubmit(object sender, EventArgs e)
        {
            if(CategoryComboBox.Text==""||AmountTextBox.Text=="" || (AmountTextBox.Text).Any(char.IsLetter))
            {
                MessageBox.Show("Enter Valid Inputs");
                return;
            }

            MySqlConnection connection = DataBaseConnection.GetConnection();
            int Id = 0;

            try
            {

                string query = $"select CategoryID from category where CategoryName = '{CategoryComboBox.Text}'";
                

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {

                    object res = cmd.ExecuteScalar();
                    Id = Convert.ToInt32(res);

                }

                string query1 = $"INSERT INTO expenses (ExpenseCategory, Amount, ExpenseDate) VALUES ({Id}, {Convert.ToDouble(AmountTextBox.Text)}, '{dateTimePicker1.Value.Date.ToString("yyyy-MM-dd")}') ";

                MySqlCommand command = new MySqlCommand(query1, connection);
                command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }




            //ExpenseManager.expenseList.Add(data);
            DateTime today = dateTimePicker1.Value.Date;
            int Year = today.Year;
            int Month = today.Month;


            DateTime StartDate = new DateTime(Year, Month, 1);
            DateTime EndDate = StartDate.AddMonths(1).AddDays(-1);

            double amount = 0;

            try
            {


                string query1 = $"SELECT SUM(Amount) AS TotalAmount FROM expenses WHERE ExpenseCategory = {Id} AND ExpenseDate >= '{StartDate:yyyy-MM-dd}' And ExpenseDate <='{EndDate:yyyy-MM-dd}'";

                using (MySqlCommand command = new MySqlCommand(query1, connection))
                {

                    object res = command.ExecuteScalar();
                    amount += Convert.ToDouble(res);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            string query2 = $"select BudgetLimit from category where categoryName = '{CategoryComboBox.Text}'";
            double limitAmout = 0;

            using (MySqlCommand command = new MySqlCommand(query2, connection))
            {

                object res = command.ExecuteScalar();
                limitAmout = Convert.ToDouble(res);

            }

            if(amount>limitAmout)
            {
                MessageBox.Show("Limit Exceeded");
            }

            ExpenseManager.dataGridView.DataSource = ExpenseManager.SetExpenseDataFromDb();


            //foreach (CategoryData cData in CategoryManager.categoryNameList)
            //{
            //    if (CategoryComboBox.Text == cData.name)
            //    {

            //        int amtToCheck = 0;
            //        foreach (ExpenseData eData in ExpenseManager.expenseList)
            //        {

            //            if (eData.category == data.category && eData.date.Month == data.date.Month && eData.date.Year == data.date.Year)
            //            {
            //                amtToCheck += eData.amount;
            //            }

            //            if (amtToCheck > cData.limit)
            //            {
            //                MessageBox.Show("Limit Exceeded");
            //            }
            //        }


            //    }
            //}





            SubmitClick?.Invoke(sender, e);

            this.Close();
        }

        private void ExpenseInputForm_Load(object sender, EventArgs e)
        {

        }

        private void OnClickEditCategoryBtn(object sender, EventArgs e)
        {
           
        }

        private void OnKeyPressAmountTextBox(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
