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
                peopleOnPanel.Add(new PersonOnPanel(panelDebts, i));
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

        private void FillGroupList(Person leader)
        {
            listBoxPayGroupDoing.Items.Clear();

            foreach (Person person in leader.PayGroupPeople)
            {
                listBoxPayGroupDoing.Items.Add(person);
            }

            labelLeader.Text = leader.Name;
        }

        private void listBoxPersonalPayGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPayGroupLeader.SelectedItems.Count == 1)
            {
                Person leader = listBoxPayGroupLeader.SelectedItem as Person;

                StringBuilder stringBuilder = new StringBuilder();

                foreach (Person person in leader.PayGroupPeople )
                {
                    stringBuilder.AppendLine(person.Name);
                }

                textBoxPayGroup.Text = stringBuilder.ToString();
            }
            else if (listBoxPayGroupLeader.SelectedItems.Count > 1)
            {
                //listBoxPayGroupDoing.Items.Clear();
                //labelLeader.Text = "";
            }
        }

        private void AddPersonToPayGroupDoingList(Person leader)
        {
            foreach (Person person in leader.PayGroupPeople)
            {
                listBoxPayGroupDoing.Items.Add(person);
            }
        }

        private Person _potentialPayGroupLeader;

        private Person PotentialPayGroupLeader
        {
            get
            {
                return _potentialPayGroupLeader;
            }
            set
            {
                _potentialPayGroupLeader = value;

                if (_potentialPayGroupLeader == null)
                {
                    labelLeader.Text = "";
                }
                else
                {
                    labelLeader.Text = _potentialPayGroupLeader.Name;
                }
            }
        }

        private void MovePersonToPayGroupLeaderList(Person person)
        {
            person.PayGroupLeader.TryRemoveFromPayGroup(person);
            listBoxPayGroupLeader.Items.Add(person);

            if (Equals(person, _potentialPayGroupLeader))
            {
                _potentialPayGroupLeader = null;
                labelLeader.Text = "";
            }
        }

        private void listBoxPayGroupDoing_SelectedIndexChanged(object sender, EventArgs e)
        {
            // sd
        }

        private void listBoxPayGroupDoing_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBoxPayGroupDoing.SelectedItems.Count == 1)
            {
                int currentItemIndex = listBoxPayGroupDoing.SelectedIndex;
                Person person = listBoxPayGroupDoing.SelectedItem as Person;
                listBoxPayGroupDoing.Items.RemoveAt(currentItemIndex);
                MovePersonToPayGroupLeaderList(person);
            }
        }

        private void listBoxPayGroupLeader_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PersonMovingFromLeaderListToGroupDoingList();
        }

        private void PersonMovingFromLeaderListToGroupDoingList()
        {
            if (listBoxPayGroupLeader.SelectedItems.Count == 1)
            {
                int currentItemIndex = listBoxPayGroupLeader.SelectedIndex;
                Person leader = listBoxPayGroupLeader.SelectedItem as Person;

                listBoxPayGroupLeader.Items.RemoveAt(currentItemIndex);

                AddPersonToPayGroupDoingList(leader);
            }
        }

        private void PeopleMovingFromLeaderListToGroupDoingList()
        {
            if (listBoxPayGroupLeader.SelectedItems.Count > 1)
            {
                foreach (Person person in listBoxPayGroupLeader.SelectedItems)
                {
                    AddPersonToPayGroupDoingList(person);
                }

                int[] array = new int[listBoxPayGroupLeader.SelectedItems.Count];
                listBoxPayGroupLeader.SelectedIndices.CopyTo(array, 0);


                for (int i = 0; i < array.Count(); i++)
                {
                    listBoxPayGroupLeader.Items.RemoveAt(array[array.Count() - i - 1]);
                }
            }
        }

        private void PeopleMovingFromGroupDoingListToLeaderList()
        {
            if (listBoxPayGroupDoing.SelectedItems.Count > 0)
            {
                foreach (Person person in listBoxPayGroupDoing.SelectedItems)
                {
                    MovePersonToPayGroupLeaderList(person);
                }

                int[] array = new int[listBoxPayGroupDoing.SelectedItems.Count];
                listBoxPayGroupDoing.SelectedIndices.CopyTo(array, 0);


                for (int i = 0; i < array.Count(); i++)
                {
                    listBoxPayGroupDoing.Items.RemoveAt(array[array.Count() - i - 1]);
                }
            }
        }

        private void buttonInGroup_Click(object sender, EventArgs e)
        {
            PersonMovingFromLeaderListToGroupDoingList();
            PeopleMovingFromLeaderListToGroupDoingList();
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
            listBoxPayGroupDoing.Items.Clear();
            PotentialPayGroupLeader = null;

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
                listBoxPeople.ClearSelected();

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

                    ProductForm productForm = new ProductForm(debts, product, listBoxProducts, this, index);
                }
            }
        }

        private void listBoxPayGroupDoing_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = this.listBoxPayGroupDoing.IndexFromPoint(e.Location);

                if (index != ListBox.NoMatches)
                {
                    Person person = listBoxPayGroupDoing.Items[index]  as Person;

                    string dialogCaption = string.Format("Назначение лидера");
                    string dialogQuestion = string.Format("Назначаем лидером \"{0}\"?", person.Name);

                    if (MessageBox.Show(dialogQuestion, dialogCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        PotentialPayGroupLeader = person;
                    }
                }
            }
        }

        private void buttonDoPayGroup_Click(object sender, EventArgs e)
        {
            if (PotentialPayGroupLeader == null)
            {
                MessageBox.Show("выберете лидера группы");
            }
            else
            {
                string dialogCaption = string.Format("Формируем группу");
                string dialogQuestion = string.Format("Подтрверждаете формирование группы?");

                if (MessageBox.Show(dialogQuestion, dialogCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!Equals(PotentialPayGroupLeader, PotentialPayGroupLeader.PayGroupLeader))
                    {
                        PotentialPayGroupLeader.PayGroupLeader.TryRemoveFromPayGroup(PotentialPayGroupLeader);
                    }

                    Person[] newPayGroup = new Person[listBoxPayGroupDoing.Items.Count];
                    listBoxPayGroupDoing.Items.CopyTo(newPayGroup,0);

                    foreach (Person person in newPayGroup)
                    {
                        PotentialPayGroupLeader.TryAddInPayGroup(person);
                        listBoxPayGroupDoing.Items.Remove(person);
                    }

                    listBoxPayGroupLeader.Items.Add(PotentialPayGroupLeader);
                    listBoxPayGroupLeader.SelectedItem = PotentialPayGroupLeader;
                    PotentialPayGroupLeader = null;                    
                }
            }
        }
    }
}
