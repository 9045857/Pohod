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
        public AllTrips allTrips;//Пока параметр открытый, если не нужен будет, нужно будет закрыть.
        public List<Debts> Debtses;

        public ListBox ListBoxDebts { get; set; }

        private ListBox listBoxPeople;
        private List<PersonOnPanel> peopleOnPanels;

        private Panel panelUnits;
        private ListBox listBoxProduct;

        //public AllDebtses(ListBox listBoxTrips, ListBox listBoxPeople, Panel panelUnits, List<PersonOnPanel> peopleOnPanels, ListBox listBoxProduct)
        //{
        //    ListBoxDebts = listBoxTrips;
        //    allTrips = new AllTrips();
        //    Debtses = new List<Debts>();

        //    this.listBoxPeople = listBoxPeople;
        //    this.panelUnits = panelUnits;//TODO prepare to remove
        //    this.peopleOnPanels = peopleOnPanels;
        //    this.listBoxProduct = listBoxProduct;
        //}

        public AllDebtses(ListBox listBoxTrips, ListBox listBoxPeople, List<PersonOnPanel> peopleOnPanels, ListBox listBoxProduct)
        {
            ListBoxDebts = listBoxTrips;
            allTrips = new AllTrips();
            Debtses = new List<Debts>();

            this.listBoxPeople = listBoxPeople;
           // this.panelUnits = panelUnits;//TODO prepare to remove
            this.peopleOnPanels = peopleOnPanels;
            this.listBoxProduct = listBoxProduct;
        }
        public void AddDebtsAndTrip(Debts debts)
        {
            ListBoxDebts.Items.Add(debts);
            Debtses.Add(debts);//TODO тут возможно нужно будет делать проверку на наличие в списках
            allTrips.AddTrip(debts.Trip);//TODO тут возможно нужно будет делать проверку на наличие в списках
        }

        private void FillDebtsesFromAllTrips()
        {
            foreach (Trip trip in allTrips.Trips)
            {
                //Debts debts = new Debts(trip, panelUnits, peopleOnPanels, listBoxPeople);
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
            allTrips.RemoveTrip(debts.Trip);
        }

        public void SaveAll(string fileName)
        {
            allTrips.Save(fileName);
        }

        private bool IsDebtsExist(Trip trip)
        {
            foreach (Debts debts in ListBoxDebts.Items)
            {
                if (Equals(debts.Trip, trip))
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
                if (Equals(debts.Trip, trip))
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
