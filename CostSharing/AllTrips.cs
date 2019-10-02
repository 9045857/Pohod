using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace CostSharing
{
    /// <summary>
    /// Список всех походов и др. групповых мероприятий.
    /// Основная задача данного класса - сериализация и десериализация всей информации.
    /// </summary>
    [DataContract]
    public class AllTrips
    {
        [DataMember]
        public List<Trip> Trips;

        public int testNumber;

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

        public void RemoveTrip(Trip trip)
        {
            Trips.Remove(trip);
        }

        public void Save(string fileName)
        {
            //testNumber = 100;

            //BinaryFormatter formatter = new BinaryFormatter();

            //using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate,FileAccess.Write))
            //{
            //    MessageBox.Show(Trips.Count.ToString());
            //    formatter.Serialize(fs, Trips);
            //}

            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Trip>));

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, Trips);
            }
        }

        public void Open(string fileName)
        {
            if (File.Exists(fileName))
            {
                //BinaryFormatter formatter = new BinaryFormatter();

                //using (FileStream fs = new FileStream(fileName, FileMode.Open,FileAccess.Read))
                //    {
                //        List<Trip> Trips = (List<Trip>)formatter.Deserialize(fs);
                //    }

                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Trip>));

                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    Trips = (List<Trip>)jsonFormatter.ReadObject(fs);
                }
            }
        }
    }
}
