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
    public class DebtsList
    {
        public AllTrips allTrips;//Пока параметр открытый, если не нужен будет, нужно будет закрыть.

        public ListBox Trips { get;  set; }

        public DebtsList(ListBox listBox)
        {
            Trips = listBox;
            allTrips = new AllTrips();
        }

        public void AddTrip(Debts debts)
        {
            Trips.Items.Add(debts);
            allTrips.AddTrip(debts.trip);
        }

        public void RemoveTrip(Debts debts)
        {
            Trips.Items.Remove(debts);
            allTrips.RemoveTrip(debts.trip);
        }

        public void SaveAll(string fileName)
        {
            allTrips.Save(fileName);
        }

        public void OpenAll(string fileName)
        {
            allTrips.Open(fileName);

         //   MessageBox.Show(allTrips.Trips.Count.ToString());
            //FillListBoxTrips();
            //FillListBoxPeople();
            //FillListBoxProducts();
        }
    }
}
