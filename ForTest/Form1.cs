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
        public TravelLists travelLists;
        public Debts debts;

        public Form1()
        {
            InitializeComponent();
            travelLists = new TravelLists();
            debts = new Debts(panelDebts);
        }

        private void buttonAddTrip_Click(object sender, EventArgs e)
        {
            Trip trip = travelLists.AddTrip(textBoxTripName.Text);
            listBoxTrips.Items.Add(trip);
        }

        private void buttonAddPerson_Click(object sender, EventArgs e)
        {
           // int tripID = listBoxTrips.SelectedIndex;

            if (listBoxTrips.SelectedItems.Count==1)
            {
                Trip currentTrip = listBoxTrips.SelectedItem as Trip;

                string personName = textBoxPerson.Text;
                currentTrip.AddPerson(personName);

                listBoxPeople.Items.Add(personName);

                debts.AddDebt(currentTrip.People[currentTrip.People.Count - 1]);
            }
        }

        private void SetLastProduct(Trip trip)
        {
            Product product = trip.Products[trip.Products.Count - 1];
            List<Person> people = trip.People;

            foreach (Person person in people)
            {
                string checkboxName = string.Format("Person{0}", person.ID);
                string factorValue = string.Format("PersonFactor{0}", person.ID);
                string payment = string.Format("PersonPayment{0}", person.ID);

                if ((panelDebts.Controls[checkboxName] as CheckBox).Checked)
                {
                    product.AddPersonInDebts(person);

                    double.TryParse((panelDebts.Controls[factorValue] as TextBox).Text, out double factor);
                    product.InsertPersonalFactor(person, factor);
                }

                TextBox textBoxPayment = panelDebts.Controls[payment] as TextBox;
               // MessageBox.Show(textBoxPayment.Text);

                if (textBoxPayment.Text != "" && double.TryParse(textBoxPayment.Text, out double paymentMoney))
                {
                    product.AddPaidPerson(person, paymentMoney);
                }

                //   MessageBox.Show(checkboxName+" "+ factorValue+" "+ payment);
            }
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            // listBoxProducts.Items.Clear();

            int tripID = listBoxTrips.SelectedIndex;

            if (travelLists.GetTrip(tripID) != null)
            {
                Trip currentTrip = travelLists.GetTrip(tripID);

                string productName = textBoxProduct.Text;
                currentTrip.AddProduct(productName);

                listBoxProducts.Items.Add(productName);

                SetLastProduct(currentTrip);
            }
        }

        private void buttonShowProduct_Click(object sender, EventArgs e)
        {
            textBoxProductInfo.Text = "";

            if (listBoxProducts.SelectedItems.Count == 1)
            {
                int tripID = listBoxTrips.SelectedIndex;
                Trip trip = travelLists.GetTrip(tripID);

                int productID = listBoxProducts.SelectedIndex;
                Product product = trip.Products[productID];

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
