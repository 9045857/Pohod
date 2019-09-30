using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CostSharing
{

    /// <summary>
    /// Список всех походов и др. групповых мероприятий.
    /// Основная задача данного класса - сериализация и десериализация все информации.
    /// </summary>
    [Serializable]
    public class TravelLists
    {       
        public List<Trip> Trips;
           
       // public int CurrenrtripID { get; set; }

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

        public void Save()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("Trips.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Trips);
            }
        }

        public void Open()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("Trips.dat", FileMode.OpenOrCreate))
            {
                List<Trip> Trips = (List<Trip>)formatter.Deserialize(fs);
            }
        }
    }
}
