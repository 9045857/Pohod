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
    public partial class Form1 : Form
    {
        public AllDebtses debtsList;
        private List<PersonOnPanel> peopleOnPanel = new List<PersonOnPanel>();
       
        //private string fileName = "Trips.json";
        private string fileName = "trips.dat";

        private void CreatePeolpleOnPanel()
        {
            int itemsCount = 40;

            for (int i = 0; i < itemsCount; i++)
            {
                peopleOnPanel.Add(new PersonOnPanel(panelDebts,i));
            }
        }

        public Form1()
        {
            InitializeComponent();
            
            CreatePeolpleOnPanel();
            debtsList = new AllDebtses(listBoxTrips, listBoxPeople, peopleOnPanel, listBoxProducts);
            debtsList.OpenAll(fileName);
        }

        private void buttonAddTrip_Click(object sender, EventArgs e)
        {
            string tripName = string.IsNullOrEmpty(textBoxTripName.Text) ? "NonameTrip" : textBoxTripName.Text;
            Trip trip = new Trip(tripName);
            Debts debts = new Debts(trip, peopleOnPanel, listBoxPeople);

            debtsList.AddDebtsAndTrip(debts);
            textBoxTripName.Text = "";
        }


        private void FillPayGroupLeaderListBox(Debts debts)
        {
            listBoxPayGroupLeader.Items.Clear();

            if (listBoxTrips.SelectedItems.Count == 1)
            {
                List<Person> leaders = debts.trip.GetPayGroupLeaders();

                foreach (Person person in leaders)
                {
                    listBoxPayGroupLeader.Items.Add(person);
                }
            }
        }

        private void buttonAddPerson_Click(object sender, EventArgs e)
        {
            if (listBoxTrips.SelectedItems.Count == 1)
            {
                Debts selectedDebts = debtsList.ListBoxDebts.SelectedItem as Debts;

                string personName = string.IsNullOrEmpty(textBoxPerson.Text) ? "NoNamePerson" : textBoxPerson.Text;
                Person person = new Person(personName);

                selectedDebts.AddDebtInListAndListBox(person);
                selectedDebts.trip.AddPerson(person);
                textBoxPerson.Text = "";
            }
        }

        private void SetProduct(Debts debts, Product product)
        {
            foreach (Debt debt in debts.TripDebts)
            {
                Person person = debt.Person;

                if (debt.CheckBoxIsDebtor.Checked)
                {
                    if (debt.TextBoxDebt.Text != "" && double.TryParse(debt.TextBoxDebt.Text, out double fixedDebt))
                    {
                        product.AddDebtorWithFixedDebt(person, fixedDebt);
                    }
                    else
                    {
                        double.TryParse(debt.TextBoxFactor.Text, out double factor);
                        product.AddDebtorWithFactor(person, factor);
                    }
                }

                string textBoxPayment = debt.TextBoxPayment.Text;

                if (textBoxPayment != "" && double.TryParse(textBoxPayment, out double paymentMoney))
                {
                    product.AddPayer(person, paymentMoney);
                }
            }
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            if (debtsList.ListBoxDebts.SelectedItems.Count == 1 && !string.IsNullOrEmpty(textBoxProduct.Text))
            {
                Debts debts = debtsList.ListBoxDebts.SelectedItem as Debts;
                Trip currentTrip = debts.trip;

                string productName = textBoxProduct.Text;
                Product product = new Product(productName);

                currentTrip.AddProduct(product);
                listBoxProducts.Items.Add(product);

                SetProduct(debts, product);

                textBoxProduct.Text = "";

                ShowSelectedPersonInfo();
            }
        }

        public void ShowSelectedProductInfo()
        {
            textBoxProductInfo.Text = "";

            if (listBoxProducts.SelectedItems.Count == 1)
            {
                Product product = listBoxProducts.SelectedItem as Product;

                StringBuilder builder = new StringBuilder();
                builder.AppendLine("Продукт " + product.Name);
                builder.AppendLine("Стоимость " + product.Cost);
                builder.AppendLine();
                builder.AppendLine("Плательщики ");

                foreach (Payer payer in product.Payers)
                {
                    builder.AppendLine(payer.Person.Name + "  " + Math.Round(payer.Payment, 2));
                }

                builder.AppendLine();
                builder.AppendLine("Должники ");

                foreach (Debtor debtor in product.Debtors)
                {
                    builder.AppendLine(debtor.Person.Name + "(" + debtor.Factor + "):  " + Math.Round(debtor.Debt, 2));
                }

                textBoxProductInfo.Text = builder.ToString();
            }
        }

        public void ShowSelectedPersonInfo()
        {
            textBoxPersonInfo.Text = "";

            if (listBoxPeople.SelectedItems.Count == 1)
            {
                Person person = (listBoxPeople.SelectedItem as Debt).Person;
                Trip trip = (listBoxTrips.SelectedItem as Debts).trip;

                StringBuilder builder = new StringBuilder();
                builder.AppendLine("Человек: " + person.Name);
                builder.AppendLine("Лидер группы: " + person.PayGroupLeader.Name);
                builder.AppendLine("Сумма оплат группы: " + Math.Round(trip.GetPayGroupTotalPayment(person.PayGroupLeader), 2));
                builder.AppendLine("Сумма оплат человека: " + Math.Round(trip.GetPersonalTotalPayment(person), 2));
                builder.AppendLine("Список оплат: товар /сумма ");

                foreach (Product product in trip.GetPayerProducts(person))
                {
                    builder.Append(product.Name);
                    builder.Append(" / ");
                    builder.Append(product.GetPayer(person).Payment);
                    builder.AppendLine();
                }

                builder.AppendLine();
                builder.AppendLine("Сумма задолженностей группы: " + Math.Round(trip.GetPayGroupTotalDebt(person.PayGroupLeader), 2));
                builder.AppendLine("Сумма задолженностей человека: " + Math.Round(trip.GetPersonalTotalDebt(person), 2));
                builder.AppendLine("Список долгов:  товар/коэффициент/сумма ");

                foreach (Product product in trip.GetDebtProducts(person))
                {
                    builder.Append(product.Name);
                    builder.Append(" / ");

                    Debtor debtor = product.GetDebtor(person);
                    builder.Append(debtor.Factor);
                    builder.Append(" / ");
                    builder.Append(Math.Round(debtor.Debt, 2));
                    builder.AppendLine();
                }

                textBoxPersonInfo.Text = builder.ToString();
            }
        }
        
        private void listBoxPersonalPayGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FillListBoxProductsFromDebts(Debts debts)
        {
            listBoxProducts.Items.Clear();
            foreach (Product product in debts.trip.Products)
            {
                listBoxProducts.Items.Add(product);
            }
        }

        private void listBoxTrips_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxProductInfo.Text = "";
            textBoxPersonInfo.Text = "";

            if (listBoxTrips.SelectedItems.Count == 1)
            {
                Debts debts = (sender as ListBox).SelectedItem as Debts;

                debts.ReloadListBoxPeopleAndDebtsPanel();
                FillListBoxProductsFromDebts(debts);
                FillPayGroupLeaderListBox(debts);
            }
            
        }

        private void listBoxPeople_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowSelectedPersonInfo();
        }

        private void listBoxPeople_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void listBoxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowSelectedProductInfo();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            debtsList.SaveAll(fileName);
        }

        private void buttonDeletTrip_Click(object sender, EventArgs e)
        {
            if (listBoxTrips.SelectedItems.Count == 1)
            {
                Debts debts = listBoxTrips.SelectedItem as Debts;

                string dialogCaption = string.Format("Удаляем \"{0}\"", debts.trip.Name);
                if (MessageBox.Show("Вы уверены?", dialogCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    debtsList.RemoveDebtsAndTpripAndRemoveFromListBox(debts);

                    listBoxPeople.Items.Clear();
                    listBoxProducts.Items.Clear();
                    panelDebts.Controls.Clear();
                    textBoxPersonInfo.Text = "";
                    textBoxProductInfo.Text = "";
                }
            }
        }

        private void buttonProductDelete_Click(object sender, EventArgs e)
        {
            if (listBoxProducts.SelectedItems.Count == 1)
            {
                Product product = listBoxProducts.SelectedItem as Product;

                string dialogCaption = string.Format("Удаляем \"{0}\"", product.Name);
                if (MessageBox.Show("Вы уверены?", dialogCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Debts debts = listBoxTrips.SelectedItem as Debts;
                    debts.trip.RemoveProduct(product);
                    listBoxProducts.Items.Remove(product);
                    textBoxProductInfo.Text = "";
                }
            }
        }

        private void buttonDeletePerson_Click(object sender, EventArgs e)
        {
            if (listBoxPeople.SelectedItems.Count == 1)
            {
                Debt debt = listBoxPeople.SelectedItem as Debt;

                string dialogCaption = string.Format("Удаляем \"{0}\"", debt.Person.Name);
                if (MessageBox.Show("Вы уверены?", dialogCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Debts debts = listBoxTrips.SelectedItem as Debts;

                    debts.RemoveDebtAndPersonFromListAndTrip(debt);

                    textBoxPersonInfo.Text = "";

                    debt.PersonOnPanelMain.Clear();
                    debts.ReloadDebtsPanel();

                    ShowSelectedProductInfo();
                }
            }
            else if (listBoxPeople.SelectedItems.Count > 1)
            {
                
                string dialogCaption = string.Format("Удаляем людей.");
                if (MessageBox.Show("Вы уверены?", dialogCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Debts debts = listBoxTrips.SelectedItem as Debts;

                    List<Debt> removingDebts = new List<Debt>();
                    foreach (Debt debt in listBoxPeople.SelectedItems)
                    {
                        removingDebts.Add(debt);
                    }
                    
                    foreach (Debt debt in removingDebts)
                    {
                        debts.RemoveDebtAndPersonFromListAndTrip(debt);
                        debt.PersonOnPanelMain.Clear();
                    }                   

                    textBoxPersonInfo.Text = "";
                    debts.ReloadDebtsPanel();
                    ShowSelectedProductInfo();
                }
            }
        }

        private void listBoxPeople_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = this.listBoxPeople.IndexFromPoint(e.Location);
                if (index != ListBox.NoMatches)
                {
                    Debts debts = listBoxTrips.SelectedItem as Debts;

                    listBoxPeople.SelectedIndex = index;
                    Debt debt = listBoxPeople.Items[index] as Debt;

                    PersonForm personForm = new PersonForm(debts, debt, listBoxPeople, this, index);
                }
            }
        }

        private void listBoxProducts_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = this.listBoxProducts.IndexFromPoint(e.Location);
                if (index != ListBox.NoMatches)
                {
                    Debts debts = listBoxTrips.SelectedItem as Debts;

                    listBoxProducts.SelectedIndex = index;
                    Product product = listBoxProducts.Items[index] as Product;

                    ProductForm productForm =new ProductForm(debts, product, listBoxProducts, this, index);
                }
            }
        }
    }
}
