using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostSharing
{
    public class Person
    {
        public int ID { get; private set; }
        public string Name { get; set; }


        public List<Product> ProductsDebts { get; private set; }
        public List<Product> ProductsPays { get; private set; }


        //public Dictionary<Product, double> ProductsAndDebts { get; private set; }

        //public bool TryAddProduct(Product product)
        //{
        //    if (ProductsAndDebts.ContainsKey(product))
        //    {
        //        return false;
        //    }

        //    ProductsAndDebts.Add(product, product.DebtInEachPerson[this]);
        //    return true;
        //}

        //public bool TryRemoveProduct(Product product)
        //{
        //    if (!ProductsAndDebts.ContainsKey(product))
        //    {
        //        return false;
        //    }

        //    Products.Remove(product);
        //    return true;
        //}

        public double PersonalDebt
        {
            get
            {
                double totalDebt = 0;
                foreach (Product product in ProductsDebts)
                {
                    totalDebt += product.DebtInEachPerson[this.ID];//TODO передалать ключи у продуктов на человека
                }

                return totalDebt;
            }
        }

        /// <summary>
        /// Сумма групповой задолженности.
        /// Применяется только к лидеру группы, у других участников будет равно 0.
        /// </summary>
        public double PayGroupDebt
        {
            get
            {
                if (!Equals(this, PayGroupLeader))
                {
                    int resultUsualPerson = 0;
                    return resultUsualPerson;
                }

                double totalDebt = 0;
                foreach (Person person in PayGroupPeople)
                {
                    totalDebt += person.PersonalDebt;
                }

                return totalDebt;
            }
        }

        public bool TryAddProductDebt(Product product)
        {
            if (ProductsDebts.Contains(product))
            {
                return false;
            }

            ProductsDebts.Add(product);
            return true;
        }

        public bool TryRemoveProductDebt(Product product)
        {
            if (!ProductsDebts.Contains(product))
            {
                return false;
            }

            ProductsDebts.Remove(product);
            return true;
        }

        ////public bool TryAddProductDebt(Product product)
        ////{
        ////    if (ProductsDebts.Contains(product))
        ////    {
        ////        return false;
        ////    }

        ////    ProductsDebts.Add(product);
        ////    return true;
        ////}

        ////public bool TryRemoveProductDebt(Product product)
        ////{
        ////    if (!ProductsDebts.Contains(product))
        ////    {
        ////        return false;
        ////    }

        ////    ProductsDebts.Remove(product);
        ////    return true;
        ////}

        //public Dictionary<Product, double> GetListDebts()
        //{



        //}

        /// <summary>
        /// "Вес" при расчете вклада в покупку, по умолчанию равен 1.
        /// </summary>
        public double PersonalPayWeight { get; set; }

        public Person PayGroupLeader { get; private set; }

        /// <summary>
        /// Список участников "подчиненной" группы плательщиков.
        /// Если текущий Person не является лидером группы, то список пустой.
        /// При создании Person является лидером группы, где один участник - он сам.
        /// </summary>
        public List<Person> PayGroupPeople { get; private set; }

        public Trip CurrentTrip { get; }

        public Person(int id,Trip trip ,string name)
        {
            ID = id;
            Name = name;
            CurrentTrip = trip;

            PayGroupLeader = this;
            PayGroupPeople = new List<Person>
            {
                this
            };

            // ProductList = new List<Product>();
            DebtInEachProduct = new Dictionary<int, double>();

            int defaultWeight = 1;
            PersonalPayWeight = defaultWeight;

            ProductsDebts = new List<Product>();
        }

        /// <summary>
        /// Добавление в рядовые члены группы плательщиков.
        /// При добавлении лидера другой группы, он становиться рядовым участником текущей группы,
        /// а в группе, от куда он ушел, лидером становиться первый по списку член.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public bool TryAddInPayGroup(Person person)
        {
            if (Equals(this.PayGroupLeader, this))
            {
                return false;
            }

            if (person.PayGroupPeople.Count == 1)
            {
                person.PayGroupLeader = this.PayGroupLeader;
                person.PayGroupPeople.Clear();
                this.PayGroupPeople.Add(person);

                return true;
            }
            else if (Equals(person, person.PayGroupLeader))
            {
                person.PayGroupPeople.Remove(person);

                int firstPersonIndex = 0;
                Person newLeader = person.PayGroupPeople[firstPersonIndex];

                ChangeGroupLeader(person, newLeader);

                person.PayGroupPeople.Clear();
                person.PayGroupLeader = this;

                return true;
            }
            else
            {
                person.PayGroupLeader.PayGroupPeople.Remove(person);
                person.PayGroupLeader = this;

                return true;
            }
        }

        /// <summary>
        /// Смена Лидера группы плательщиков.
        /// Новый Лидер должен состоять в группе.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public bool TryChangeGroupLeager(Person person)
        {
            if (!PayGroupPeople.Contains(person) || Equals(person, PayGroupLeader))
            {
                return false;
            }

            ChangeGroupLeader(PayGroupLeader, person);

            return true;
        }

        private static void ChangeGroupLeader(Person oldLeader, Person newLeader)
        {
            foreach (Person person in oldLeader.PayGroupPeople)
            {
                person.PayGroupLeader = newLeader;
                newLeader.PayGroupPeople.Add(person);
            }
        }

        /// <summary>
        /// Удаление (роспуск) группы. Все участники становятся независими, лидерами себя. 
        /// Удалять можно только от Лидера группы.
        /// </summary>
        public bool TryDeletePayGroup()
        {
            int singlePersonInGroup = 1;
            if (!Equals(this, PayGroupLeader) || PayGroupPeople.Count == singlePersonInGroup)
            {
                return false;
            }

            foreach (Person person in PayGroupPeople)
            {
                if (!Equals(person, PayGroupLeader))
                {
                    PayGroupPeople.Remove(person);

                    person.PayGroupPeople.Add(person);
                    person.PayGroupLeader = person;
                }
            }

            return true;
        }

        /// <summary>
        /// Удаляет Person из группы плательщиков - переводит в статус единоличного плательщика.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public bool TryRemoveFromPayGroup(Person person)
        {
            if (!PayGroupPeople.Contains(person) || person.PayGroupPeople.Count == 1)
            {
                return false;
            }

            if (Equals(PayGroupLeader, person))
            {
                PayGroupPeople.Remove(person);

                int firstPesonInListIndex = 0;
                Person newLeader = PayGroupPeople[firstPesonInListIndex];

                foreach (Person man in PayGroupPeople)
                {
                    man.PayGroupLeader = newLeader;
                    newLeader.PayGroupPeople.Add(man);
                }

                PayGroupLeader = this;
                PayGroupPeople.Clear();
                PayGroupPeople.Add(this);

                return true;
            }
            else
            {
                PayGroupPeople.Remove(person);
                person.PayGroupLeader = person;
                person.PayGroupPeople.Add(person);

                return true;
            }
        }



        //суммарная оплата, которую сделал человек
        public double Payment { get; private set; }//TODO переделать в виде словаря оплат по товарам

        // public List<Product> ProductList;// нужен не список продуктов, а коллекция оплат по продуктам!!!
        public Dictionary<int, double> DebtInEachProduct;//Список задолженностей по продуктам

        public double Debt
        {
            get
            {
                double debt = 0;

                foreach (int productDebt in DebtInEachProduct.Values)
                {
                    debt += productDebt;
                }

                return 0;
            }
        }


        //возможно нужно будет вести список оплат за что человек оплатил
        public void AddPayment(double moneyCount)
        {
            Payment += moneyCount;
        }

        public void ReducePayment(double moneyCount)
        {
            Payment -= moneyCount;
        }
    }
}
