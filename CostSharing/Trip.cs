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

        private int _personID;
        private int _productID;

        public List<PayGroup> PayGroups { get; private set; }

        public List<Product> Products { get; private set; }
        public List<Person> People { get; private set; }

        public Trip(int tripId, string tripName)
        {
            ID = tripId;
            Name = tripName;

            Products = new List<Product>();
            People = new List<Person>();
            PayGroups = new List<PayGroup>();

            _personID = 0;
            _productID = 0;
        }

        public void AddProduct(string productName)
        {
            Products.Add(new Product(_productID, this, productName));
            _productID++;
        }

        public void AddPerson(string personName)
        {
            People.Add(new Person(_personID, this, personName));
            _personID++;
        }

        public bool TryRemoveProduct(Product product)
        {
            if (!Products.Contains(product))
            {
                return false;
            }

            Products.Remove(product);

            foreach (Person person in product.PaidPeople.Keys)
            {
                person.TryRemovePaidProducts(product);
            }

            foreach (Person person in product.DebtInEachPerson.Keys)
            {
                person.TryRemoveProductDebt(product);
            }

            return true;
        }

        public bool TryRemovePerson(Person person)
        {
            if (!People.Contains(person))
            {
                return false;
            }

            People.Remove(person);
            person.PayGroupLeader.TryRemoveFromPayGroup(person);

            foreach (Product product in person.PaidProducts)
            {
                product.TryRemoveDebtPerson(person);
            }

            return true;
        }
    }
}
