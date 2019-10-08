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
        public List<Debt> DebtsList { get; set; }
        public Trip trip;

        public Panel panel;
        public ListBox listBox;

        public int Count
        {
            get
            {
                return DebtsList.Count;
            }
        }

        public void ReloadListBoxPeople()
        {
            listBox.Items.Clear();
            panel.Controls.Clear();

            int debtIndex = 0;
            foreach (Debt debt in DebtsList)
            {
                listBox.Items.Add(debt);
                debt.CreateUnit(debtIndex);

                debtIndex++;
            }
        }

        public Debts(Trip trip, Panel panel, ListBox listBox)
        {
            this.trip = trip;
            this.panel = panel;
            this.listBox = listBox;

            DebtsList = new List<Debt>();
            FillDebtsListFromTrip();
        }

        private void FillDebtsListFromTrip()
        {
            foreach (Person person in trip.People)
            {
                Debt debt = new Debt(panel, person);
                DebtsList.Add(debt);
            }
        }

        public void AddDebtInListAndListBox(Person person)
        {
            Debt debt = new Debt(panel, person, Count);
            DebtsList.Add(debt);
            listBox.Items.Add(debt);
        }

        public void AddDebt(Debt debt)
        {
            DebtsList.Add(debt);
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
