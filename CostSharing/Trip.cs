using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostSharing
{
    public class Trip
    {
        public int ID { get; private set; }
        public string Name { get; set; }

        public Dictionary<int, Product> Products { get; private set; }
        public Dictionary<int, Person> People { get; private set; }
        public List<PayGroup> PayGroups { get; private set; }

        public List<Product> ProductList { get; private set; }//TODO вариант с простыми списками
        public List< Person> PeopleList { get; private set; }// вариант с простыми списками


        public bool TryAddProductInList(Product product)
        {
            if (ProductList.Contains(product))
            {
                ProductList.Add(product);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool TryAddPersonInList(Person person)
        {
            if (PeopleList.Contains(person))
            {
                PeopleList.Add(person);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Trip(int tripId, string tripName)
        {
            ID = tripId;
            Name = tripName;
            Products = new Dictionary<int, Product>();
            People = new Dictionary<int, Person>();
            PayGroups = new List<PayGroup>();
        }

        /// <summary>
        /// Добавляет продукт в список и возвращает присвоенный ID.
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        public int AddProduct(string productName)
        {
            int productId = GetProductId();
            Products.Add(productId, new Product(productId, productName));

            return productId;
        }

        private int GetProductId()
        {
            int currentId = 0;

            while (Products.ContainsKey(currentId))
            {
                currentId++;
            }

            return currentId;
        }

        public void RemoveProduct(int productId)
        {
            //TODO нужно убрать продукт у всех людей из списков и 
        }


        /// <summary>
        /// Добавляет человека в список людей и присваевает ID.
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        public int AddPerson(string personName)
        {
            int personId = GetPersonId();
            People.Add(personId, new Person(personId, this,personName));

            return personId;
        }

        private int GetPersonId()
        {
            int currentId = 0;

            while (People.ContainsKey(currentId))
            {
                currentId++;
            }

            return currentId;
        }

        public void RemovePerson(int productId)
        {
            //TODO нужно убрать человека из всех списков 
        }


       // public void

    }
}
