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
    public partial class AddCategoryForm : Form
    {
        public AddCategoryForm()
        {
            InitializeComponent();
        }

        private void OnClickSubmit(object sender, EventArgs e)
        {
            if(textBox1.Text=="" || textBox2.Text=="" || textBox2.Text.Any(char.IsLetter))
            {
                return;
            }

            CategoryManager.AddCategory(textBox1.Text, Convert.ToInt32(textBox2.Text));

            string query = "INSERT INTO category (CategoryName, BudgetLimit) VALUES (@CategoryName, @BudgetLimit)";

            using (MySqlConnection connection = DataBaseConnection.GetConnection())
            {
                try
                {

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryName", textBox1.Text);
                        command.Parameters.AddWithValue("@BudgetLimit", Convert.ToInt32(textBox2.Text));

                        command.ExecuteNonQuery();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

                
            }

            this.Close();
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
