using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace CostSharing
{
    /// <summary>
    /// Список всех походов и др. групповых мероприятий.
    /// Основная задача данного класса - сериализация и десериализация всей информации.
    /// </summary>
    [Serializable]
    public class AllTrips
    {
        public List<Trip> Trips;

        public AllTrips()
        {
            Trips = new List<Trip>();
        }

        public Trip AddTrip(string tripName)
        {

            Trip trip = new Trip(tripName);
            Trips.Add(trip);

            return trip;
        }

        public void AddTrip(Trip trip)
        {
            Trips.Add(trip);
        }

        public Trip GetTrip(int id)
        {
            foreach (Trip trip in Trips)
            {
                if (trip.ID == id)
                {
                    return trip;
                }
            }

            return null;
        }

        public void RemoveTrip(Trip trip)
        {
            Trips.Remove(trip);
        }

        public void Save(string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate,FileAccess.Write))
            {
                MessageBox.Show(Trips.Count.ToString());
                formatter.Serialize(fs, Trips);
            }
        }

        public void Open(string fileName)
        {
            //if (File.Exists(fileName))
            //{
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(fileName, FileMode.Open,FileAccess.Read))
                {
                    List<Trip> Trips = (List<Trip>)formatter.Deserialize(fs);
                }


            //}
            //else
            //{
            //    return null;
            //}
        }
    }
}
