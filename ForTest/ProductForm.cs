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
                PersonOnPanel personOnPanel = new PersonOnPanel(panelDebts, i);
                Person person = debts.trip.People[i];
                personOnPanel.SetPerson(person);

                peopleOnPanelCorrection.Add(personOnPanel);
                
                Debtor debtor = product.GetDebtor(person);

                personOnPanel.CheckBoxIsDebtor.Text = person.Name;

                if (debtor != null)
                {
                    personOnPanel.CheckBoxIsDebtor.Checked = true;

                    if (debtor.Factor_Type == Debtor.FactorType.WithoutFactor)
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

        private void FillDataFromPeolpeOnPanelToProduct()
        {
            foreach (PersonOnPanel personOnPanel in peopleOnPanelCorrection)
            {
                Person person = personOnPanel.Person;
                if (personOnPanel.CheckBoxIsDebtor.Checked)
                {

                    Debtor debtor = product.GetDebtor(person);
                    if (debtor != null)
                    {
                        if (personOnPanel.TextBoxDebt.Text != "" && double.TryParse(personOnPanel.TextBoxDebt.Text, out double currentDebt))
                        {
                            debtor.Debt = currentDebt;
                            debtor.Factor_Type = Debtor.FactorType.WithoutFactor;
                        }
                        else
                        {
                            if (personOnPanel.TextBoxFactor.Text != "" && double.TryParse(personOnPanel.TextBoxFactor.Text, out double currentFactor))
                            {
                                if (currentFactor == debtor.Person.DebtFactor)
                                {
                                    debtor.Factor_Type = Debtor.FactorType.Standart;
                                }
                                else
                                {
                                    debtor.Factor_Type = Debtor.FactorType.SpecialForProduct;
                                    debtor.Factor = currentFactor;
                                }
                            }
                            else
                            {
                                debtor.Factor_Type = Debtor.FactorType.Standart;
                            }
                        }
                    }
                    else
                    {
                        if (personOnPanel.TextBoxDebt.Text != "" && double.TryParse(personOnPanel.TextBoxDebt.Text, out double currentDebt))
                        {
                            debtor = new Debtor(person, Debtor.FactorType.WithoutFactor, currentDebt);
                        }
                        else
                        {
                            if (personOnPanel.TextBoxFactor.Text != "" && double.TryParse(personOnPanel.TextBoxFactor.Text, out double currentFactor))
                            {
                                if (currentFactor == person.DebtFactor)
                                {
                                    int anyNumber = 0;
                                    debtor = new Debtor(person, Debtor.FactorType.Standart, anyNumber);
                                }
                                else
                                {
                                    debtor = new Debtor(person, Debtor.FactorType.SpecialForProduct, currentFactor);
                                }
                            }
                            else
                            {
                                int anyNumber = 0;
                                debtor = new Debtor(person, Debtor.FactorType.Standart, anyNumber);
                            }
                        }

                        product.Debtors.Add(debtor);//TODO maybe do method insert dy index inner list. this is for number order.
                    }
                }
                else
                {
                    if (product.IsPersonInDebtors(person))
                    {
                        product.RemoveDebtor(person);
                    }
                }

                if (personOnPanel.TextBoxPayment.Text != "" && double.TryParse(personOnPanel.TextBoxPayment.Text, out double currentPayment))
                {
                    Payer payer = product.GetPayer(person);

                    if (payer != null)
                    {
                        payer.Payment = currentPayment;
                    }
                    else
                    {
                        //payer = new Payer(person, currentPayment);
                        product.AddPayer(person, currentPayment);
                    }
                }
                else
                {
                    if (product.IsPersonInPayers(person))
                    {
                        product.RemovePayer(person);
                    }
                }
            }

            product.RecountDebtorsData();
        }


        private void FillDataToProductAndRedrawListProducts()
        {
            product.Name = textBoxProductName.Text;
            FillDataFromPeolpeOnPanelToProduct();
            listBoxProduct.Items[index] = listBoxProduct.Items[index];
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            FillDataToProductAndRedrawListProducts();
        }

        private void buttonSaveAndClose_Click(object sender, EventArgs e)
        {
            FillDataToProductAndRedrawListProducts();
            Dispose();
        }
    }
}
