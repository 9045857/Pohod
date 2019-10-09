using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CostSharing;

namespace ForTest
{
    public partial class PersonForm : Form
    {
        Debt debt;
        Debts debts;
        ListBox listBoxPeople;
        Form1 main;
        int index;

        public PersonForm(Debts debts, Debt debt, ListBox listBoxPeople, Form1 main,int index)
        {
            Location = MousePosition;
            InitializeComponent();
            this.debt = debt;
            this.debts = debts;

            this.listBoxPeople = listBoxPeople;
            this.main = main;
            this.index = index;

            textBoxPersonName.Text = debt.Person.Name;
            textBoxPersonFactor.Text = debt.Person.DebtFactor.ToString();

            Show();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxPersonFactor.Text, out double factor))
            {
                debts.CorrectFactor(debt, factor);
                debts.CorrectPersonNameAndListBox(debt, textBoxPersonName.Text);

                listBoxPeople.Items[index] = listBoxPeople.Items[index];

                main.ShowSelectedPersonInfo();
                main.ShowSelectedProductInfo();

                debts.ReloadDebtsPanel();

                Dispose();
            }
            else
            {
                MessageBox.Show("Введите корректный коэффициент участия в платежах");
            }
        }
    }
}
