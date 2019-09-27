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
        public int CurrenrtripID { get; set; }

        public TravelLists()
        {
            Trips = new List<Trip>();
        }

        public Trip AddTrip(string tripName)
        {

            Trip trip = new Trip(CurrenrtripID, tripName);
            Trips.Add(trip);
            CurrenrtripID++;
            return trip;
        }

        public Trip GetTrip(int id)
        {
            foreach (Trip trip in Trips)
            {
                if (trip.ID==id)
                {
                    return trip;
                }
            }

            return null;
        }

        public void RemoveTrip()
        {
            //TODO сделать метод

        }

    }
}
