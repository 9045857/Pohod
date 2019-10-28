using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace CostSharing
{
    [Serializable]
    public class Trip
    {
        public string Name { get; set; }

        public List<Person> People { get; private set; }

        public List<Product> Products { get; private set; }
        public List<Person> PayGroupsLeaders { get; set; }

        public List<GroupBalance> DebtorsGroupBalances { get; private set; }
        public List<GroupBalance> PayersGroupBalances { get; private set; }
        public List<GroupBalance> NeutralsGroupBalances { get; private set; }

        public List<GroupBalanceCompensator> DebtorsCompensators { get; private set; }



        public GroupBalance GetGroupBalance(Person leader)
        {
            if (!People.Contains(leader) || !Equals(leader, leader.PayGroupLeader))
            {
                return null;
            }



        }

        public Trip(string tripName)
        {
            Name = tripName;

            Products = new List<Product>();
            People = new List<Person>();
            PayGroupsLeaders = new List<Person>();

            DebtorsGroupBalances = new List<GroupBalance>();
            PayersGroupBalances = new List<GroupBalance>();
            NeutralsGroupBalances = new List<GroupBalance>();

            DebtorsCompensators = new List<GroupBalanceCompensator>();
        }

        public void CorrectFactor(Person person, double factor)
        {
            if (People.Contains(person))
            {
                person.DebtFactor = factor;

                foreach (Product product in Products)
                {
                    if (product.IsPersonInDebtors(person))
                    {
                        product.RecountDebtorsData();
                    }
                }
            }
        }

        public void RemovePerson(Person person)
        {
            People.Remove(person);

            foreach (Product product in Products)
            {
                if (product.IsPersonInDebtors(person))
                {
                    product.RemoveDebtor(person);
                }

                if (product.IsPersonInPayers(person))
                {
                    product.RemovePayer(person);
                }
            }

            Person personLeader = person.PayGroupLeader;
            personLeader.TryRemoveFromPayGroup(person);
        }

        public void RemoveProduct(Product product)
        {
            Products.Remove(product);
        }

        public List<Person> GetPayGroupLeaders()
        {
            List<Person> leaders = new List<Person>();

            foreach (Person person in People)
            {
                if (!leaders.Contains(person.PayGroupLeader))
                {
                    leaders.Add(person.PayGroupLeader);
                }
            }

            return leaders;
        }

        public double GetPayGroupTotalPayment(Person leader)
        {
            if (!Equals(leader.PayGroupLeader, leader))
            {
                return 0;
            }

            double payGroupTotalPayment = 0;
            foreach (Product product in Products)
            {
                payGroupTotalPayment += GetProductPayGroupPayment(leader, product);
            }

            return payGroupTotalPayment;
        }

        public double GetProductPayGroupPayment(Person leader, Product product)
        {
            if (!Equals(leader.PayGroupLeader, leader))
            {
                return 0;
            }

            double productPayGroupPayment = 0;
            foreach (Payer payer in product.Payers)
            {
                if (Equals(payer.Person.PayGroupLeader, leader))
                {
                    productPayGroupPayment += payer.Payment;
                }
            }

            return productPayGroupPayment;
        }

        public double GetPersonalTotalPayment(Person person)
        {
            if (!People.Contains(person))
            {
                return 0;
            }

            double personalTotalPayment = 0;
            foreach (Product product in Products)
            {
                personalTotalPayment += GetProductPersonalPayment(person, product);
            }

            return personalTotalPayment;
        }

        public double GetProductPersonalPayment(Person person, Product product)
        {
            if (!People.Contains(person))
            {
                return 0;
            }

            foreach (Payer payer in product.Payers)
            {
                if (Equals(payer.Person, person))
                {
                    // MessageBox.Show(payer.Person.Name+" "+payer.Payment);
                    return payer.Payment;
                }
            }

            return 0;
        }


        public double GetPersonalTotalDebt(Person person)
        {
            if (!People.Contains(person))
            {
                return 0;
            }

            double personalTotalDebt = 0;
            foreach (Product product in Products)
            {
                personalTotalDebt += GetProductPersonalDebt(person, product);
            }

            return personalTotalDebt;
        }

        public double GetProductPersonalDebt(Person person, Product product)
        {
            if (!People.Contains(person))
            {
                return 0;
            }

            foreach (Debtor debtor in product.Debtors)
            {
                if (Equals(debtor.Person, person))
                {
                    return debtor.Debt;
                }
            }

            return 0;
        }

        public double GetPayGroupTotalDebt(Person leader)
        {
            if (!Equals(leader.PayGroupLeader, leader))
            {
                return 0;
            }

            double totalDebtPayGroup = 0;
            foreach (Product product in Products)
            {
                totalDebtPayGroup += GetProductPayGroupDebt(leader, product);
            }

            return totalDebtPayGroup;
        }

        public double GetProductPayGroupDebt(Person leader, Product product)
        {
            if (!Equals(leader.PayGroupLeader, leader))
            {
                return 0;
            }

            double productDebtPayGroup = 0;

            foreach (Person person in leader.PayGroupPeople)
            {
                if (product.IsPersonInDebtors(person))
                {
                    productDebtPayGroup += product.GetDebtor(person).Debt;
                }
            }

            return productDebtPayGroup;
        }

        public List<Product> GetDebtProducts(Person person)
        {
            //if (person == null || !People.Contains(person))
            //{
            //    return null;
            //}

            List<Product> products = new List<Product>();

            foreach (Product product in Products)
            {
                foreach (Debtor debtor in product.Debtors)
                {
                    if (Equals(person, debtor.Person))
                    {
                        products.Add(product);
                        break;
                    }

                }
            }

            return products;
        }

        public List<Product> GetPayerProducts(Person person)
        {
            //if (person == null || !People.Contains(person))
            //{
            //    return null;
            //}

            List<Product> products = new List<Product>();

            foreach (Product product in Products)
            {
                foreach (Payer payer in product.Payers)
                {
                    if (Equals(person, payer.Person))
                    {
                        products.Add(product);
                        break;
                    }

                }
            }

            return products;
        }

        private void RefillPayGroupsLeaders()//TODO метод непонятный, скорее всего не нужный, как и список лидеров
        {
            PayGroupsLeaders.Clear();
            foreach (Person person in People)
            {
                if (Equals(person, person.PayGroupLeader))
                {
                    PayGroupsLeaders.Add(person);
                }
            }
        }

        public List<Person> GetPayGroupsLeaders()
        {
            List<Person> leaders = new List<Person>();
            foreach (Person person in People)
            {
                if (Equals(person, person.PayGroupLeader))
                {
                    leaders.Add(person);
                }
            }

            return leaders;
        }

        public void AddProduct(string productName)
        {
            Products.Add(new Product(productName));
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void CreateAndAddPerson(string personName)
        {
            Person person = new Person(personName);
            People.Add(person);
        }

        public void AddPerson(Person person)
        {
            People.Add(person);
        }




        //public bool TryRemoveProduct(Product product)
        //{
        //    if (!Products.Contains(product))
        //    {
        //        return false;
        //    }

        //    Products.Remove(product);

        //    foreach (Person person in product.Payers.Keys)
        //    {
        //        person.TryRemoveProductPaid(product);
        //    }

        //    foreach (Person person in product.Debtors.Keys)
        //    {
        //        person.TryRemoveProductDebt(product);
        //    }

        //    return true;
        //}

        //public bool TryRemovePerson(Person person)
        //{
        //    if (!People.Contains(person))
        //    {
        //        return false;
        //    }

        //    People.Remove(person);
        //    person.PayGroupLeader.TryRemoveFromPayGroup(person);

        //    foreach (Product product in person.ProductsPaid)
        //    {
        //        product.TryRemoveDebtPerson(person);
        //    }

        //    return true;
        //}


        //public 


        public override string ToString()
        {
            return string.IsNullOrEmpty(Name) ? "NonameTrip" : Name;
        }
    }
}
