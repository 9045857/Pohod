using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostSharing
{
    [Serializable]
    public class Trip
    {
        public string Name { get; set; }

        public List<PayGroup> PayGroups { get; private set; }

        public List<Product> Products { get; private set; }
        public List<Person> People { get; private set; }

        public Trip(string tripName)
        {
            Name = tripName;

            Products = new List<Product>();
            People = new List<Person>();
            PayGroups = new List<PayGroup>();
        }


        public void AddProduct(string productName)
        {
            Products.Add(new Product(this, productName));
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public Person AddPerson(string personName)
        {
            Person person = new Person(this, personName);
            People.Add(person);

            return person;
        }

        public bool TryRemoveProduct(Product product)
        {
            if (!Products.Contains(product))
            {
                return false;
            }

            Products.Remove(product);

            foreach (Person person in product.Payers.Keys)
            {
                person.TryRemoveProductPaid(product);
            }

            foreach (Person person in product.Debtors.Keys)
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

            foreach (Product product in person.ProductsPaid)
            {
                product.TryRemoveDebtPerson(person);
            }

            return true;
        }

        public override string ToString()
        {
            return string.IsNullOrEmpty(Name) ? "NonameTrip" : Name;
        }
    }
}
