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
using System.IO;

namespace ForTest
{
    public class AllDebtses
    {
        public AllTrips AllTrips { get; set; }
        public List<Debts> Debtses;

        public ListBox ListBoxDebts { get; set; }

        private ListBox listBoxPeople;
        private List<PersonOnPanel> peopleOnPanels;

        private ListBox listBoxProduct;

        public AllDebtses(ListBox listBoxTrips, ListBox listBoxPeople, List<PersonOnPanel> peopleOnPanels, ListBox listBoxProduct)
        {
            ListBoxDebts = listBoxTrips;
            AllTrips = new AllTrips();
            Debtses = new List<Debts>();

            this.listBoxPeople = listBoxPeople;
            this.peopleOnPanels = peopleOnPanels;
            this.listBoxProduct = listBoxProduct;
        }
        public void AddDebtsAndTrip(Debts debts)
        {
            ListBoxDebts.Items.Add(debts);
            Debtses.Add(debts);//TODO тут возможно нужно будет делать проверку на наличие в списках
            AllTrips.AddTrip(debts.trip);//TODO тут возможно нужно будет делать проверку на наличие в списках
        }

        private void FillDebtsesFromAllTrips()
        {
            foreach (Trip trip in AllTrips.Trips)
            {
                Debts debts = new Debts(trip, peopleOnPanels, listBoxPeople);
                Debtses.Add(debts);
            }
        }

        public void FillListBoxTripsFormDebtses()
        {
            foreach (Debts debts in Debtses)
            {
                ListBoxDebts.Items.Add(debts);
            }
        }

        public void RemoveDebtsAndTpripAndRemoveFromListBox(Debts debts)
        {
            ListBoxDebts.Items.Remove(debts);
            Debtses.Remove(debts);
            AllTrips.RemoveTrip(debts.trip);
        }

        public void SaveAll(string fileName)
        {
            AllTrips.Save(fileName);
        }

        private bool IsDebtsExist(Trip trip)
        {
            foreach (Debts debts in ListBoxDebts.Items)
            {
                if (Equals(debts.trip, trip))
                {
                    return true;
                }
            }

            return false;
        }

        private Debts GetDebts(Trip trip)
        {
            foreach (Debts debts in Debtses)
            {
                if (Equals(debts.trip, trip))
                {
                    return debts;
                }
            }

            return null;
        }

        public void LoadDebtsesAndListBoxAfterDeserialization()
        {
            FillDebtsesFromAllTrips();
            FillListBoxTripsFormDebtses();
        }

        public void OpenAll(string fileName)
        {
            if (File.Exists(fileName))
            {
                AllTrips.Open(fileName);

                LoadDebtsesAndListBoxAfterDeserialization();
            }
        }
    }
}
