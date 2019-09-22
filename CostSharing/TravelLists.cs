using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostSharing
{
    public class TravelLists
    {
        public Dictionary<int, Trip> Travels;

        public TravelLists()
        {
            Travels = new Dictionary<int, Trip>();
        }

        public int AddTripAndGetID(string tripName)
        {
            int tripID= GetTripId();
            Travels.Add(tripID, new Trip(tripID, tripName));
            return tripID;
        }

        private int GetTripId()
        {
            int currentId = 0;

            while (Travels.ContainsKey(currentId))
            {
                currentId++;
            }

            return currentId;
        }


        public void RemoveTripe()
        {
            //TODO сделать метод

        }

    }
}
