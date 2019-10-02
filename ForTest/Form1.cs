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

        private string fileName = "Trips.json";

        public Form1()
        {
            InitializeComponent();
            debtsList = new DebtsList(listBoxTrips);
            debtsList.OpenAll(fileName);
        }

        private void buttonAddTrip_Click(object sender, EventArgs e)
        {
            string tripName = string.IsNullOrEmpty(textBoxTripName.Text) ? "NonameTrip" : textBoxTripName.Text;
            Trip trip = new Trip(tripName);
            Debts debts = new Debts(trip, panelDebts, listBoxPeople);

            debtsList.AddTrip(debts);
        }

        private void buttonAddPerson_Click(object sender, EventArgs e)
        {
            if (listBoxTrips.SelectedItems.Count == 1)
            {
                Debts selectedDebts = debtsList.Trips.SelectedItem as Debts;

                string personName = string.IsNullOrEmpty(textBoxPerson.Text) ? "NoNamePerson" : textBoxPerson.Text;
                Person person = new Person(selectedDebts.trip, personName);

                (debtsList.Trips.SelectedItem as Debts).AddDebt(person);
            }
        }

        private void SetProduct(Debts debts, Product product)
        {
            foreach (Debt debt in debts.listBox.Items)
            {
                Person person = debt.Person;

                if (debt.CheckBox.Checked)
                {
                    product.AddDebtor(person);

                    double.TryParse(debt.TextBoxFactor.Text, out double factor);
                    product.InsertPersonalFactor(person, factor);
                }

                string textBoxPayment = debt.TextBoxMoney.Text;

                if (textBoxPayment != "" && double.TryParse(textBoxPayment, out double paymentMoney))
                {
                    Economy.DoPayment(product, person, paymentMoney);
                }
            }
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            if (debtsList.Trips.SelectedItems.Count == 1 && !string.IsNullOrEmpty(textBoxProduct.Text))
            {
                Debts debts = debtsList.Trips.SelectedItem as Debts;
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
                builder.AppendLine("Стоимость " + product.Cost);
                builder.AppendLine();
                builder.AppendLine("Плательщики ");

                foreach (Person person in product.Payers.Keys)
                {
                    builder.AppendLine(person.Name + "  " + product.Payers[person]);
                }

                builder.AppendLine();
                builder.AppendLine("Должники ");

                foreach (Person person in product.Debtors.Keys)
                {
                    builder.AppendLine(person.Name + product.Debtors[person].Factor + "  " + product.Debtors[person].Debt);
                }

                textBoxProductInfo.Text = builder.ToString();
            }
            else
            {
                MessageBox.Show("Выберите продукт из списка.");
            }
        }

        private void buttonShowPerson_Click(object sender, EventArgs e)
        {
            textBoxPersonInfo.Text = "";

            if (listBoxPeople.SelectedItems.Count == 1)
            {
                Person person = (listBoxPeople.SelectedItem as Debt).Person;

                StringBuilder builder = new StringBuilder();
                builder.AppendLine("Человек: " + person.Name);
                builder.AppendLine("Сумма оплат: " + person.TotalPayments);
                builder.AppendLine("Сумма задолженностей: " + person.TotalDebt);
                builder.AppendLine();
                builder.AppendLine("Список долгов:  товар/коэффициент/сумма ");

                foreach (Product product in person.ProductsDebts)
                {
                    builder.Append(product.Name);
                    builder.Append(" / ");
                    builder.Append(product.Debtors[person].Factor);
                    builder.Append(" / ");
                    builder.AppendLine(product.Debtors[person].Debt.ToString());
                }

                builder.AppendLine();
                builder.AppendLine("Список оплат: товар /сумма ");

                foreach (Product product in person.ProductsPaid)
                {
                    builder.Append(product.Name);
                    builder.Append(" / ");
                    builder.Append(product.Payers[person]);
                }

                textBoxPersonInfo.Text = builder.ToString();
            }
            else
            {
                MessageBox.Show("Выберите человека из списка.");
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            debtsList.SaveAll(fileName);
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            debtsList.OpenAll(fileName);

            MessageBox.Show(debtsList.allTrips.testNumber.ToString());
        }

        private void buttonTripsClear_Click(object sender, EventArgs e)
        {
            debtsList.allTrips.Trips.Clear();
            debtsList.Trips.Items.Clear();
        }
    }
}
