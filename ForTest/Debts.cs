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
        public string Name { get; private set; }

        public Trip trip;

        public Panel panel;
        public ListBox listBox;
        
        public int Count
        {
            get
            {
                return listBox.Items.Count;
            }
        }
        
        public Debts(Trip trip, Panel panel, ListBox listBox)
        {
            this.trip = trip;
            this.panel = panel;
            this.listBox = listBox;

            Name = trip.Name;
        }
                
        public void AddDebt(Person person)
        {            
            Debt debt = new Debt(panel,person,Count);
            listBox.Items.Add(debt);
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
