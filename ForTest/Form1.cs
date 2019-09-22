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
        
    
        public Form1()
        {
            InitializeComponent();
            travelLists = new TravelLists();
        }

        private void buttonAddTrip_Click(object sender, EventArgs e)
        {
            int tripId=travelLists.AddTripAndGetID(textBoxTripName.Text);
            comboBoxTripList.Items.Add(tripId);
            listBoxTrips.Items.Add(tripId+"  " +textBoxTripName.Text);

        }

        private void buttonAddPerson_Click(object sender, EventArgs e)
        {
            int.TryParse(comboBoxTripList.Text,out int tripId);
            string personName = textBoxPerson.Text;
            int personId = travelLists.Travels[tripId].AddPerson(personName);
            
            comboBoxPerson1.Items.Add(personId);
            comboBoxPerson2.Items.Add(personId);

            listBoxPeople.Items.Add(personId + "  " + textBoxEnterPerson.Text);
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            int.TryParse(comboBoxTripList.Text, out int tripId);
            string productName = textBoxPerson.Text;
            int productId = travelLists.Travels[tripId].AddProduct(productName);

            double cost = Convert.ToDouble (textBoxPay1.Text);
            travelLists.Travels[tripId].Products[productId].SetCost(cost);


            //comboBoxPerson1.Items.Add(personId);
            //comboBoxPerson2.Items.Add(personId);

            listBoxProducts.Items.Add(productId + "  " + travelLists.Travels[tripId].Products[productId].Name + "  " + travelLists.Travels[tripId].Products[productId].Cost);
        }
    }
}
