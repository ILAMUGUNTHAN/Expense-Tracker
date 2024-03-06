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
    public partial class EditExpenseForm : Form
    {
        public EditExpenseForm()
        {
            InitializeComponent();
            CategoryComboBox.DataSource = CategoryManager.categoryNameList;
        }

        public EventHandler SaveClick;

        public string category;
        public int amount;
        public DateTime date;

        private void OnClickSaveBtn(object sender, EventArgs e)
        {
            if (CategoryComboBox.Text == "" || AmountTextBox.Text == "" || (AmountTextBox.Text).Any(char.IsLetter))
            {
                MessageBox.Show("Enter Valid Inputs");
                return;
            }

            category = CategoryComboBox.Text;
            amount = Convert.ToInt32(AmountTextBox.Text);
            date = dateTimePicker1.Value;

            SaveClick?.Invoke(sender, e);


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
