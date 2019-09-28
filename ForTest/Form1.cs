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
        // public TravelLists travelLists;//?
        public DebtsList debtsList;

        public Form1()
        {
            InitializeComponent();
            // travelLists = new TravelLists();
            debtsList = new DebtsList(listBoxTrips);
        }

        private void buttonAddTrip_Click(object sender, EventArgs e)
        {
            string tripName = string.IsNullOrEmpty(textBoxTripName.Text) ? "NonameTrip" : textBoxTripName.Text;
            Trip trip = new Trip(tripName);
            Debts debts = new Debts(trip, panelDebts, listBoxPeople);

            debtsList.listBox.Items.Add(debts);
        }

        private void buttonAddPerson_Click(object sender, EventArgs e)
        {
            if (listBoxTrips.SelectedItems.Count == 1)
            {
                Debts selectedDebts = debtsList.listBox.SelectedItem as Debts;

                string personName = string.IsNullOrEmpty(textBoxPerson.Text) ? "NoNamePerson" : textBoxPerson.Text;
                Person person = new Person(selectedDebts.trip, personName);

                (debtsList.listBox.SelectedItem as Debts).AddDebt(person);
            }
        }

        private void SetProduct(Debts debts, Product product)
        {
            foreach (Debt debt in debts.listBox.Items)
            {
                Person person = debt.Person;

                if (debt.CheckBox.Checked)
                {
                    product.AddPersonInDebts(person);

                    double.TryParse(debt.TextBoxFactor.Text, out double factor);
                    product.InsertPersonalFactor(person, factor);
                }

                string textBoxPayment = debt.TextBoxMoney.Text;

                if (textBoxPayment != "" && double.TryParse(textBoxPayment, out double paymentMoney))
                {
                    product.AddPaidPerson(person, paymentMoney);
                }
            }
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            if (debtsList.listBox.SelectedItems.Count == 1 && !string.IsNullOrEmpty(textBoxProduct.Text))
            {
                Debts debts = debtsList.listBox.SelectedItem as Debts;
                Trip currentTrip = debts.trip;

                string productName = textBoxProduct.Text;
                Product product = new Product(currentTrip, productName);

                currentTrip.AddProduct(product);
                listBoxProducts.Items.Add(product);

                SetProduct(debts, product);
            }
        }

        private void buttonShowProduct_Click(object sender, EventArgs e)
        {
            textBoxProductInfo.Text = "";

            if (listBoxProducts.SelectedItems.Count == 1)
            {
                Product product = listBoxProducts.SelectedItem as Product;

                StringBuilder builder = new StringBuilder();
                builder.AppendLine("Продукт " + product.Name);
                builder.AppendLine("ID " + product.ID);
                builder.AppendLine("Стоимость " + product.Cost);
                builder.AppendLine();
                builder.AppendLine("Плательщики ");

                foreach (Person person in product.PaidPeople.Keys)
                {
                    builder.AppendLine(person.Name + "  " + product.PaidPeople[person]);
                }

                builder.AppendLine();
                builder.AppendLine("Должники ");

                foreach (Person person in product.DebtInEachPerson.Keys)
                {
                    builder.AppendLine(person.Name + product.DebtPersonFactors[person] + "  " + product.DebtInEachPerson[person]);
                }

                textBoxProductInfo.Text = builder.ToString();
            }
            else
            {
                MessageBox.Show("Выберите продукт из списка.");
            }
        }
    }
}
