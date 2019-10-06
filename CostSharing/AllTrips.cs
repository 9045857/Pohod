using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace CostSharing
{
    [Serializable]
    public class AllTrips 
    {
        public List<Trip> Trips { get; set; }

        public int testNumber;

        public AllTrips()
        {
            Trips = new List<Trip>();
        }

        public Trip CreateAndAddTrip(string tripName)
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
         //   testNumber = 100;//TODO after test remove

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
             //   MessageBox.Show(Trips.Count.ToString());
                formatter.Serialize(fs, Trips);
            }

            //DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Trip>));

            //using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            //{
            //    jsonFormatter.WriteObject(fs, Trips);
            //}
        }

        public void Open(string fileName)
        {
            if (File.Exists(fileName))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    List<Trip> Trips = (List<Trip>)formatter.Deserialize(fs);
                 //   MessageBox.Show(Trips.Count.ToString());
                }

                //DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Trip>));

                //using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                //{
                //    Trips = (List<Trip>)jsonFormatter.ReadObject(fs);
                //}
            }
        }
    }
}
