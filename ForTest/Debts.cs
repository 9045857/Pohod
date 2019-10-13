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

        private List<PersonOnPanel> peopleOnPanel;

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

            int debtIndex = 0;
            foreach (Debt debt in TripDebts)
            {
                listBoxWithDebts.Items.Add(debt);
                debt.SetDebtIDAndDraw(debtIndex);

                debtIndex++;
            }

            ClearPeopleOnPanelFrom(debtIndex);
        }

        public void ReloadDebtsPanel()
        {
            int debtIndex = 0;
            foreach (Debt debt in TripDebts)
            {
                debt.SetDebtIDAndDraw(debtIndex);
                debtIndex++;
            }

            ClearPeopleOnPanelFrom(debtIndex);
        }

        private void ClearPeopleOnPanelFrom(int index)
        {
            for (int i = index; i < peopleOnPanel.Count; i++)
            {
                if (peopleOnPanel[i].CheckBoxIsDebtor.Visible)
                {
                    peopleOnPanel[i].Clear();
                }
                else
                {
                    return;
                }
            }
        }

        public Debts(Trip trip, List<PersonOnPanel> peopleOnPanel, ListBox listBox)
        {
            this.trip = trip;

            this.peopleOnPanel = peopleOnPanel;

            listBoxWithDebts = listBox;

            TripDebts = new List<Debt>();
            FillDebtsListFromTrip();
        }

        private void ClearPeoplesOnPanel()
        {
            foreach (PersonOnPanel personOnPanel in peopleOnPanel.ToArray())
            {
                if (personOnPanel.Visible)
                {
                    personOnPanel.Clear();
                }
                else
                {
                    return;
                }
            }
        }

        private void FillDebtsListFromTrip()
        {
            int debtId = 0;
            ClearPeoplesOnPanel();

            foreach (Person person in trip.People)
            {
                Debt debt = new Debt(peopleOnPanel/*peopleOnPanel[debtId]*/, person, debtId);

                TripDebts.Add(debt);

                debtId++;
            }
        }

        public void AddDebtInListAndListBox(Person person)
        {
            Debt debt = new Debt(peopleOnPanel/*[Count]*/, person, Count);
            debt.PersonOnPanelMain.Visible = true;

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

        public override string ToString()
        {
            return trip.ToString();
        }
    }
}
