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
    public class Debts
    {
        //public List<Person> People { get; private set; }

        public Trip Trip { get; private set; }
        public List<Person> People { get; private set; }
        public List<PersonOnPanel> PersonOnPanels { get; set; }

        public Panel panel;
        public ListBox ListBoxPeople { get; set; }

        public int Count
        {
            get
            {
                return Trip.People.Count;
            }
        }

        public void ReloadListBoxPeople()
        {
            ListBoxPeople.Items.Clear();
            // panel.Controls.Clear();

            int debtIndex = 0;
            foreach (Person person in People)
            {
                ListBoxPeople.Items.Add(person);
                //  debt.CreateUnit(debtIndex);

                debtIndex++;
            }
        }

        //public void ReloadDebtsPanel()
        //{
        //    panel.Controls.Clear();

        //    int debtIndex = 0;
        //    foreach (Debt debt in TripDebts)
        //    {
        //        debt.CreateUnit(debtIndex);
        //        debtIndex++;
        //    }
        //}

        public Debts(Trip trip, List<PersonOnPanel> personOnPanels, ListBox listBox)
        {
            this.Trip = trip;
            this.ListBoxPeople = listBox;

            People = trip.People;
            PersonOnPanels = personOnPanels;

            FillDebtsListFromTrip();
        }

        private void FillDebtsListFromTrip()
        {
            int index = 0;
            foreach (Person person in People)
            {
                //  Debt debt = new Debt(panel, person);

                PersonOnPanel personOnPanel = new PersonOnPanel(panel,index);
                personOnPanel.LoadDebtData(person);
                PersonOnPanels.Add(personOnPanel);

                ListBoxPeople.Items.Add(person);

                index++;
            }
        }

        public void AddDebtInListAndListBox(Debt debt)
        {
            People.Add(debt);
            ListBoxPeople.Items.Add(debt);
        }


        //public void AddDebtInListAndListBox(Person person)
        //{
        //    Debt debt = new Debt(panel, person, Count);
        //    TripDebts.Add(debt);
        //    listBoxWithDebts.Items.Add(debt);
        //}

        public void AddDebt(Debt debt)
        {
            People.Add(debt);
        }

        public void CorrectFactor(Debt debt, double factor)
        {
            if (People.Contains(debt))
            {
                Trip.CorrectFactor(debt.Person, factor);
            }
        }

        public void CorrectPersonNameAndListBox(Debt debt, string name)
        {
            if (People.Contains(debt))
            {
                debt.Person.Name = name == "" ? "Noname" : name;
            }
        }

        public void RemoveDebtAndPersonFromListAndTrip(Debt debt)
        {
            People.Remove(debt);
            Trip.RemovePerson(debt.Person);
            ListBoxPeople.Items.Remove(debt);
        }

        //public void AddListDebt(List<Person> people)
        //{
        //    foreach (Person person in people)
        //    {
        //        CreateUnit(person, _positionX, _currentY);
        //        _currentY += _deltaY;
        //    }
        //}

        public override string ToString()
        {
            return Trip.ToString();
        }
    }
}
