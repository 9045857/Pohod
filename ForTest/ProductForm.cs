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
    public partial class ProductForm : Form
    {
        Debts debts;
        Product product;
        ListBox listBoxProduct;
        Form mainForm;
        int index;

        private List<PersonOnPanel> peopleOnPanelCorrection = new List<PersonOnPanel>();

        public ProductForm(Debts debts, Product product, ListBox listBoxProduct, Form mainForm, int index)
        {
            this.debts = debts;
            this.product = product;
            this.listBoxProduct = listBoxProduct;
            this.mainForm = mainForm;
            this.index = index;

            InitializeComponent();
            CreateAndFillAndDoVisiblePeoplePanel();
            Location = MousePosition;
            Show();
        }

        private void CreateAndFillAndDoVisiblePeoplePanel()
        {
            textBoxProductName.Text = product.Name;

            for (int i = 0; i < debts.trip.People.Count; i++)
            {
                PersonOnPanel personOnPanel = new PersonOnPanel(panelDebts,i);
                Person person = debts.trip.People[i];

                Debtor debtor = product.GetDebtor(person);

                personOnPanel.CheckBoxIsDebtor.Text = person.Name;

                if (debtor != null)
                {
                    personOnPanel.CheckBoxIsDebtor.Checked = true;
                                       
                    if (debtor.factorType == Debtor.FactorType.WithoutFactor)
                    {
                        personOnPanel.TextBoxFactor.Text = person.DebtFactor.ToString();
                        personOnPanel.TextBoxDebt.Text = debtor.Debt.ToString();
                    }
                    else
                    {
                        personOnPanel.TextBoxFactor.Text = debtor.Factor.ToString();
                        personOnPanel.TextBoxDebt.Text = "";
                    }
                }
                else
                {
                    personOnPanel.TextBoxFactor.Text = person.DebtFactor.ToString();
                }

                Payer payer = product.GetPayer(person);
                    if (payer != null)
                    {
                        personOnPanel.TextBoxPayment.Text = payer.Payment.ToString();
                    }
                    else
                    {
                        personOnPanel.TextBoxPayment.Text = "";
                    }               

                personOnPanel.Visible = true;
            }
        }



    }
}
