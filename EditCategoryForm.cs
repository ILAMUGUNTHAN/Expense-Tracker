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
    public partial class EditCategoryForm : Form
    {
        public EditCategoryForm()
        {
            InitializeComponent();

            comboBox1.DataSource = CategoryManager.categoryNameList;
            

            comboBox1.SelectedValueChanged += OnSelectedValueChanged;
        }

        private int selectedId;
        private int modifiedLimit;

        private void OnSelectedValueChanged(object sender, EventArgs e)
        {
            SetSelectedId(comboBox1.Text);


            for (int ind = 0; ind < CategoryManager.categoryNameList.Count; ind++)
            {

                int checkId=0;
                string queryCategory = $"select CategoryID from category where CategoryName='{CategoryManager.categoryNameList[ind]}'";

                using (MySqlCommand command = new MySqlCommand(queryCategory, DataBaseConnection.GetConnection()))
                {
                    object res = command.ExecuteScalar();

                    checkId = Convert.ToInt32(res);
                }

                if (checkId == selectedId)
                {
                    int fetchedLimit = 0;
                    string queryC = $"select BudgetLimit from category where CategoryName='{CategoryManager.categoryNameList[ind]}'";

                    using (MySqlCommand command = new MySqlCommand(queryC, DataBaseConnection.GetConnection()))
                    {
                        object res = command.ExecuteScalar();

                        fetchedLimit = Convert.ToInt32(res);
                    }



                    textBox1.Text = fetchedLimit + "";
                    comboBox1.DataSource = CategoryManager.categoryNameList;
                  
                }
            }



        }

        private void OnClickRemoveBtn(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                return;
            }

            CategoryManager.RemoveCategory(comboBox1.Text);



            SetSelectedId(comboBox1.Text);
            try
            {

                string disable = "SET FOREIGN_KEY_CHECKS = 0";
                string queryCategory = "delete from category where CategoryId = @CatId";
                string enable = "SET FOREIGN_KEY_CHECKS = 1";

                using (MySqlCommand command = new MySqlCommand(queryCategory, DataBaseConnection.GetConnection()))
                {
                    MySqlCommand disCmd = new MySqlCommand(disable, DataBaseConnection.GetConnection());
                    MySqlCommand enbCmd = new MySqlCommand(enable, DataBaseConnection.GetConnection());



                    command.Parameters.AddWithValue("@CatId", selectedId);

                    disCmd.ExecuteNonQuery();

                    int rowsAffected = command.ExecuteNonQuery();

                    enbCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Successfully Removed.");
                    }
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            CategoryManager.categoryNameList = ExpenseManager.SetCategoryDataFromDb();
            this.Close();

        }

        private void OnClickModifyBtn(object sender, EventArgs e)
        {
            if (selectedId == 0 || textBox1.Text == "" || (textBox1.Text).Any(char.IsLetter))
            {
                return;
            }

            modifiedLimit = Convert.ToInt32(textBox1.Text);

            CategoryManager.ModifyCategory(selectedId, modifiedLimit);


            MySqlConnection connection = DataBaseConnection.GetConnection();

            try
            {

                string queryCategory = "UPDATE category SET  BudgetLimit = @NewBudgetLimit WHERE CategoryId = @CategoryId";

                using (MySqlCommand command = new MySqlCommand(queryCategory, connection))
                {
                    command.Parameters.AddWithValue("@NewBudgetLimit", modifiedLimit);
                    command.Parameters.AddWithValue("@CategoryId", selectedId);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        
                    }
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            


            this.Close();
        }

        private void OnLoadEditCategoryForm(object sender, EventArgs e)
        {

            //SetSelectedId(comboBox1.Text);
            comboBox1.Text = "";
        }

        private void OnKeyPressAmountTextBox(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void SetSelectedId(string txt)
        {
            string queryCategory = $"select CategoryID from category where CategoryName='{txt}'";

            using (MySqlCommand command = new MySqlCommand(queryCategory, DataBaseConnection.GetConnection()))
            {
                object res = command.ExecuteScalar();

                selectedId = Convert.ToInt32(res);
            }
        }
    }
}
