using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostSharing
{
    public class TravelLists
    {
        public List<Trip> Trips;
        private int _currenrtripID;

        public TravelLists()
        {
            Trips = new List<Trip>();
        }

        public void AddTrip(string tripName)
        {
            Trips.Add(new Trip(_currenrtripID, tripName));
            _currenrtripID++;
        }
              
        public void RemoveTrip()
        {
            //TODO сделать метод

        }

    }
}
