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
    public class DebtsList
    {
        public AllTrips allTrips;//Пока параметр открытый, если не нужен будет, нужно будет закрыть.
        public List<Debts> Debtses;

        public ListBox ListBoxDebts { get; set; }

        private ListBox listBoxPeople;
        private Panel panelUnits;
        private ListBox listBoxProduct;

        public DebtsList(ListBox listBoxTrips, ListBox listBoxPeople, Panel panelUnits, ListBox listBoxProduct)
        {
            ListBoxDebts = listBoxTrips;
            allTrips = new AllTrips();
            Debtses = new List<Debts>();

            this.listBoxPeople = listBoxPeople;
            this.panelUnits = panelUnits;
            this.listBoxProduct = listBoxProduct;
        }

        public void AddDebtsAndTrip(Debts debts)
        {
            ListBoxDebts.Items.Add(debts);
            Debtses.Add(debts);//TODO тут возможно нужно будет делать проверку на наличие в списках
            allTrips.AddTrip(debts.trip);//TODO тут возможно нужно будет делать проверку на наличие в списках
        }

        private void FillDebtsesFromAllTrips()
        {
            foreach (Trip trip in allTrips.Trips)
            {
                Debts debts = new Debts(trip, panelUnits, listBoxPeople);
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


        public void RemoveDebts(Debts debts)
        {
            ListBoxDebts.Items.Remove(debts);
            allTrips.RemoveTrip(debts.trip);
        }

        public void SaveAll(string fileName)
        {
            allTrips.Save(fileName);
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

            //TODO we need fill debts and debt 
            //FillListBoxTrips();
            //FillListBoxPeople();
            //FillListBoxProducts();
        }

        public void OpenAll(string fileName)
        {
            if (File.Exists(fileName))
            {
                allTrips.Open(fileName);

                LoadDebtsesAndListBoxAfterDeserialization();
            }
        }
    }
}
