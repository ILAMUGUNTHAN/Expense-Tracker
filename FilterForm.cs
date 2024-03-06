using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expense_Tracker_Application
{
    public partial class FilterForm : Form
    {
        public FilterForm()
        {
            InitializeComponent();

            dateTimePicker1.CustomFormat = dateTimePicker2.CustomFormat = " ";
            dateTimePicker1.Format = dateTimePicker2.Format = DateTimePickerFormat.Custom;

            FilterComboBox.DataSource = CategoryManager.categoryNameList;
  
        }

        private string category;
        private int month;
        private DateTime from = DateTime.MinValue;
        private DateTime to = DateTime.MaxValue;
        private int categoryId;

        private void OnClickRestDate(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = dateTimePicker2.CustomFormat = " ";
            dateTimePicker1.Format = dateTimePicker2.Format = DateTimePickerFormat.Custom;
        }

        private void OnValueChangedDateTimePicker(object sender, EventArgs e)
        {
            DateTimePicker dateTimePicker = (DateTimePicker)sender;
            if (dateTimePicker.Value != DateTime.MinValue)
            {
                dateTimePicker.CustomFormat = "dd-MM-yyyy";
                dateTimePicker.Format = DateTimePickerFormat.Custom;
            }
        }

        private void OnClickSubmit(object sender, EventArgs e)
        {
            List<ExpenseData> tempList = ExpenseManager.expenseList;
            category = FilterComboBox.Text;
            string[] str = (MonthFilterComboBox.Text).Split('.');
            if (str[0].Any(char.IsDigit))
            {
                month = Convert.ToInt32(str[0]);
            }

            if (dateTimePicker1.CustomFormat != " ")
            {
                from = dateTimePicker1.Value.Date;
            }
            if (dateTimePicker2.CustomFormat != " ")
            {
                to = dateTimePicker2.Value.Date;
            }


            string queryCategory = $"select CategoryID from category where CategoryName='{category}'";

            using (MySqlCommand command = new MySqlCommand(queryCategory, DataBaseConnection.GetConnection()))
            {
                object res = command.ExecuteScalar();

                categoryId = Convert.ToInt32(res);
            }


            StringBuilder queryBuilder = new StringBuilder("SELECT e1.ExpenseID as ID, c1.CategoryName as Category, e1.Amount as Amount, e1.ExpenseDate FROM expenses e1 LEFT JOIN category c1 ON e1.ExpenseCategory = c1.CategoryID WHERE ");

            if (!string.IsNullOrEmpty(category))
            {
                queryBuilder.Append($"e1.ExpenseCategory = '{categoryId}' AND ");
            }
            if (month != 0)
            {
                queryBuilder.Append($"MONTH(e1.ExpenseDate) = {month} AND ");
            }
            if (from != DateTime.MinValue)
            {
                queryBuilder.Append($"e1.ExpenseDate >= '{from:yyyy-MM-dd}' AND ");
            }
            if (to != DateTime.MinValue)
            {
                queryBuilder.Append($"e1.ExpenseDate <= '{to:yyyy-MM-dd}' AND ");
            }

            if (queryBuilder.ToString().EndsWith("AND "))
            {
                queryBuilder.Remove(queryBuilder.Length - 5, 5);
            }

            string finalQuery = queryBuilder.ToString();


            DataTable table = new DataTable();
            try
            {
                using (MySqlConnection connection = DataBaseConnection.GetConnection())
                {

                    using (MySqlCommand command = new MySqlCommand(finalQuery, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {

                            table.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            foreach (DataRow row in table.Rows)
            {
                if (Convert.ToString(row[1]) == "")
                {
                    row[1] = (object)"Others";
                }

            }

            ExpenseManager.dataGridView.DataSource = table ;
            ExpenseManager.InitializeDataGridView();

            //ExpenseManager.dataGridView.Rows.Clear();

            //foreach(ExpenseData data in tempList)
            //{

            //    string dataCategory = data.category;
            //    int dataMonth = data.date.Month;
            //    DateTime dataDate = data.date;

            //    // need to add if condition to filter 

            //    //with all filter
            //    if (category != "" && month != 0 && from!= DateTime.MinValue  && to !=DateTime.MaxValue)
            //    {
            //        if (category == dataCategory && month == dataMonth && (from.Date <= dataDate && to.Date >= dataDate))
            //        {
            //            ExpenseManager.dataGridView.Rows.Add(data.id,data.category, data.amount, data.date.ToString("dd/MM/yyyy"));
            //        }

            //    }
            //    else if(category=="" && month != 0 && from != DateTime.MinValue && to != DateTime.MaxValue)//without category alone
            //    {
            //        if ( month == dataMonth && (from.Date <= dataDate && to.Date >= dataDate))
            //        {
            //            ExpenseManager.dataGridView.Rows.Add(data.id,data.category, data.amount, data.date.ToString("dd/MM/yyyy"));
            //        }
            //    }
            //    else if(category != "" && month == 0 && from != DateTime.MinValue && to != DateTime.MaxValue)//without month alone
            //    {
            //        if (category == dataCategory  && (from.Date <= dataDate && to.Date >= dataDate))
            //        {
            //            ExpenseManager.dataGridView.Rows.Add(data.id,data.category, data.amount, data.date.ToString("dd/MM/yyyy"));
            //        }
            //    }
            //    else if(category != "" && month != 0 && from == DateTime.MinValue && to == DateTime.MaxValue)//without from and to date
            //    {
            //        if (category == dataCategory && month == dataMonth)
            //        {
            //            ExpenseManager.dataGridView.Rows.Add(data.id,data.category, data.amount, data.date.ToString("dd/MM/yyyy"));
            //        }
            //    }
            //    else if (category == "" && month == 0 && from != DateTime.MinValue && to != DateTime.MaxValue)//without category and month
            //    {
            //        if ((from.Date <= dataDate && to.Date >= dataDate))
            //        {
            //            ExpenseManager.dataGridView.Rows.Add(data.id,data.category, data.amount, data.date.ToString("dd/MM/yyyy"));
            //        }
            //    }
            //    else if(category != "" )//with only category
            //    {
            //        if (category == dataCategory )
            //        {
            //            ExpenseManager.dataGridView.Rows.Add(data.id,data.category, data.amount, data.date.ToString("dd/MM/yyyy"));
            //        }
            //    }
            //    else if (month != 0)//with only month
            //    {
            //        if (month == dataMonth)
            //        {
            //            ExpenseManager.dataGridView.Rows.Add(data.id,data.category, data.amount, data.date.ToString("dd/MM/yyyy"));
            //        }
            //    }
            //    else
            //    {
            //        ExpenseManager.dataGridView.Rows.Add(data.id,data.category, data.amount, data.date.ToString("dd/MM/yyyy"));
            //    }

            //}

            this.Close();
        }
    }
}
