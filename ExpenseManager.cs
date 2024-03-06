using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using MySql.Data.MySqlClient;
using System.Data;

namespace Expense_Tracker_Application
{
    static class ExpenseManager
    {

        public static List<ExpenseData> expenseList = new List<ExpenseData>();

        public static DataGridView dataGridView;
        private static ExpenseInputForm expenseInputForm;
        private static EditExpenseForm editExpenseForm;
        private static int selectedId;
        public static int curId = 1;

        public static void SetDataGridView(DataGridView datagrid)
        {
            dataGridView = datagrid;
        }

        public static void InitializeDataGridView()
        {

            DataGridViewCellStyle d = new DataGridViewCellStyle();
            d.Alignment = DataGridViewContentAlignment.MiddleCenter;
            d.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Pixel);
            d.BackColor = Color.Gold;
            d.ForeColor = Color.Black;
            dataGridView.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle(d);

            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


        }

        public static void AddExpense()
        {

            expenseInputForm = new ExpenseInputForm()
            {
                Location = new Point(600, 400)

            };
            expenseInputForm.SubmitClick += OnClickSubmit;

            expenseInputForm.Show();
        }

        public static void RemoveExpense()
        {
            int rowIndex;
            int expId;
            if (dataGridView.SelectedRows.Count > 0)
            {
                if (dataGridView.SelectedRows[0].IsNewRow)
                {
                    
                    return;
                }

                rowIndex = dataGridView.SelectedRows[0].Index;

                expId = Convert.ToInt32(dataGridView.Rows[rowIndex].Cells[0].Value);

                dataGridView.Rows.RemoveAt(rowIndex);


                MySqlConnection connection = DataBaseConnection.GetConnection();

                try
                {
       

                    string queryCategory = "delete from expenses where ExpenseID = @ExpId";

                    using (MySqlCommand command = new MySqlCommand(queryCategory, connection))
                    {
                        command.Parameters.AddWithValue("@ExpId", expId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine($"Successfully deleted {rowsAffected} row(s) with expenseId {expId}.");
                        }
                        else
                        {
                            Console.WriteLine($"No rows deleted. No matching expenseId found: {expId}");
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
               
            }
            else
            {
                MessageBox.Show("Select Entire Row");
            }

            
        }

        public static int GetTotalExpense()
        {
            int tot = 0;
            string query = "SELECT SUM(Amount) AS TotalAmount FROM expenses";

            try
            {
                using (MySqlConnection connection = DataBaseConnection.GetConnection())
                {

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            tot = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return tot;
        }

        public static void EditExpense(int id, int rowInd)
        {

            editExpenseForm = new EditExpenseForm()
            {
                Location = new Point(600, 400)

            };
            //myvalue = dgvList.Rows[rowindex].Cells[columnindex].Value.ToString();


            editExpenseForm.CategoryComboBox.Text = dataGridView.Rows[rowInd].Cells[1].Value.ToString();
            editExpenseForm.AmountTextBox.Text = dataGridView.Rows[rowInd].Cells[2].Value.ToString();
            editExpenseForm.dateTimePicker1.Value = Convert.ToDateTime(dataGridView.Rows[rowInd].Cells[3].Value);



            editExpenseForm.SaveClick += OnClickSaveEditForm;

            editExpenseForm.Show();
            



        }

        public static void DisplayAllExpense()
        {
            dataGridView.Rows.Clear();
            foreach (ExpenseData data in expenseList)
            {
                dataGridView.Rows.Add(data.id, data.category, data.amount, data.date.ToString("dd/MM/yyyy"));
            }
        }

        public static DataTable SetExpenseDataFromDb()
        {

            DataTable table = new DataTable();
            try
            {
                string commandString = "SELECT e1.ExpenseID as ID, c1.CategoryName as Category, e1.Amount as Amount, e1.ExpenseDate FROM expenses e1 LEFT JOIN category c1 ON e1.ExpenseCategory = c1.CategoryID;";

                using (MySqlCommand command = new MySqlCommand(commandString, DataBaseConnection.GetConnection()))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {

                        table.Load(reader);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e);
            }


            foreach (DataRow row in table.Rows)
            {
                if (Convert.ToString(row[1])=="")
                {
                    row[1] = (object)"Others";
                }

            }

            return table;
        }
        
        public static List<string> SetCategoryDataFromDb()
        {
            List<string> source = new List<string>();

            DataTable table = new DataTable();
            try
            {
                string commandString = "SELECT CategoryName FROM category;";

                using (MySqlCommand command = new MySqlCommand(commandString, DataBaseConnection.GetConnection()))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            source.Add(reader[0].ToString());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("error: "+e);
            }

            return source;


            //MySqlConnection connection = DataBaseConnection.GetConnection();

            //try
            //{
            //    connection.Open();


            //    string queryCategory = "select * from category";

            //    using (MySqlCommand command = new MySqlCommand(queryCategory, connection))
            //    {
            //        MySqlDataReader reader = command.ExecuteReader();


            //        while (reader.Read())
            //        {
            //            CategoryData cData = new CategoryData();
            //            cData.categoryId = Convert.ToInt32(reader["CategoryID"]);
            //            cData.name = reader["CategoryName"]+"";
            //            cData.limit = Convert.ToInt32(reader["BudgetLimit"]);

            //            CategoryManager.categoryList.Add(cData);

            //        }



            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error: " + ex.Message);
            //}
            //finally
            //{
            //    connection.Close();
            //}


        }

        private static void OnClickSaveEditForm(object sender, EventArgs e)
        {


            int rowIndex;
            int expId;
            if (dataGridView.SelectedRows.Count > 0)
            {
                if (dataGridView.SelectedRows[0].IsNewRow)
                {
                    return;
                }

                rowIndex = dataGridView.SelectedRows[0].Index;

                expId = Convert.ToInt32(dataGridView.Rows[rowIndex].Cells[0].Value);


                foreach (DataGridViewRow dRow in dataGridView.Rows)
                {
                    if (dRow.Cells[0].Value?.ToString() == selectedId + "")
                    {
                        dRow.Cells[1].Value = editExpenseForm.category;
                        dRow.Cells[2].Value = editExpenseForm.amount;

                        DateTime date = editExpenseForm.date;

                        dRow.Cells[3].Value = date.ToString("dd/MM/yyyy");
                    }
                }
                int Id = 0;
                string query = $"select CategoryID from category where CategoryName = '{editExpenseForm.category}'";


                using (MySqlCommand cmd = new MySqlCommand(query, DataBaseConnection.GetConnection()))
                {

                    object res = cmd.ExecuteScalar();
                    Id = Convert.ToInt32(res);

                }

                string query1 = $"update expenses set ExpenseCategory = {Id}, Amount = {Convert.ToDouble(editExpenseForm.amount)}, ExpenseDate = '{editExpenseForm.dateTimePicker1.Value.ToString("yyyy-MM-dd")}' where ExpenseID = {expId} ";
                MySqlCommand command = new MySqlCommand(query1, DataBaseConnection.GetConnection());
                command.ExecuteNonQuery();



            }
            dataGridView.DataSource = SetExpenseDataFromDb();

        }

        

        private static void OnClickSubmit(object sender, EventArgs e)
        {
            

            //dataGridView.Rows.Add(expenseList.Last().id,expenseList.Last().category, expenseList.Last().amount, expenseList.Last().date.ToString("dd/MM/yyyy"));


        }
    }
}
