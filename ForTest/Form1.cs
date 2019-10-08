﻿using System;
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
        public DebtsList debtsList;

        //private string fileName = "Trips.json";

        private string fileName = "trips.dat";

        public Form1()
        {
            InitializeComponent();
            debtsList = new DebtsList(listBoxTrips, listBoxPeople, panelDebts, listBoxProducts);
            debtsList.OpenAll(fileName);
        }

        private void buttonAddTrip_Click(object sender, EventArgs e)
        {
            string tripName = string.IsNullOrEmpty(textBoxTripName.Text) ? "NonameTrip" : textBoxTripName.Text;
            Trip trip = new Trip(tripName);
            Debts debts = new Debts(trip, panelDebts, listBoxPeople);

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
            foreach (Debt debt in debts.DebtsList)
            {
                Person person = debt.Person;

                if (debt.CheckBox.Checked)
                {
                    double.TryParse(debt.TextBoxFactor.Text, out double factor);
                    product.AddDebtor(person, factor);
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
            }
        }

        private void ShowSelectedProductInfo()
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
            else
            {
                MessageBox.Show("Выберите продукт из списка.");
            }
        }

        private void buttonShowProduct_Click(object sender, EventArgs e)
        {

        }

        private void ShowSelectedPersonInfo()
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
            else
            {
                MessageBox.Show("Выберите человека из списка.");
            }
        }

        private void buttonShowPerson_Click(object sender, EventArgs e)
        {
            ShowSelectedPersonInfo();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            debtsList.SaveAll(fileName);
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            debtsList.OpenAll(fileName);
        }

        private void buttonTripsClear_Click(object sender, EventArgs e)
        {
            debtsList.allTrips.Trips.Clear();
            debtsList.ListBoxDebts.Items.Clear();
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
            if (listBoxTrips.SelectedItems.Count == 1)
            {
                Debts debts = (sender as ListBox).SelectedItem as Debts;

                debts.ReloadListBoxPeople();
                FillListBoxProductsFromDebts(debts);
                FillPayGroupLeaderListBox(debts);
            }
            else
            {
                MessageBox.Show("Выберите поход");
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
    }
}
