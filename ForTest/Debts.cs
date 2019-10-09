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
        public List<Debt> TripDebts { get; private set; }
        public Trip trip;

        public Panel panel;
        public ListBox listBoxWithDebts;

        public int Count
        {
            get
            {
                return TripDebts.Count;
            }
        }

        public void ReloadListBoxPeopleAndDebtsPanel()
        {
            listBoxWithDebts.Items.Clear();
            panel.Controls.Clear();

            int debtIndex = 0;
            foreach (Debt debt in TripDebts)
            {
                listBoxWithDebts.Items.Add(debt);
                debt.CreateUnit(debtIndex);

                debtIndex++;
            }
        }

        public void ReloadDebtsPanel()
        {
            panel.Controls.Clear();

            int debtIndex = 0;
            foreach (Debt debt in TripDebts)
            {
                debt.CreateUnit(debtIndex);
                debtIndex++;
            }
        }

        public Debts(Trip trip, Panel panel, ListBox listBox)
        {
            this.trip = trip;
            this.panel = panel;
            this.listBoxWithDebts = listBox;

            TripDebts = new List<Debt>();
            FillDebtsListFromTrip();
        }

        private void FillDebtsListFromTrip()
        {
            foreach (Person person in trip.People)
            {
                Debt debt = new Debt(panel, person);
                TripDebts.Add(debt);
            }
        }

        public void AddDebtInListAndListBox(Person person)
        {
            Debt debt = new Debt(panel, person, Count);
            TripDebts.Add(debt);
            listBoxWithDebts.Items.Add(debt);
        }

        public void AddDebt(Debt debt)
        {
            TripDebts.Add(debt);
        }

        public void CorrectFactor(Debt debt, double factor)
        {
            if (TripDebts.Contains(debt))
            {
                trip.CorrectFactor(debt.Person, factor);
            }
        }

        public void CorrectPersonNameAndListBox(Debt debt, string name)
        {
            if (TripDebts.Contains(debt))
            {
                debt.Person.Name = name == "" ? "Noname" : name;
            }
        }

        public void RemoveDebtAndPersonFromListAndTrip(Debt debt)
        {
            TripDebts.Remove(debt);
            trip.RemovePerson(debt.Person);
            listBoxWithDebts.Items.Remove(debt);
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
            return trip.ToString();
        }
    }
}
