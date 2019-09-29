using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CostSharing
{
    public class Product
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; set; }//TODO пока нигде не используется

        public Trip CurrentTrip { get; }

        /// <summary>
        /// Коэффициент участия в платеже (вес участия).
        /// Если человек вносит не долю от общей суммы, а какую-нибудь определенную сумму,
        /// то коэффициент -1.
        /// </summary>
        private readonly int personalDebtFactor = -1; 
        private readonly int standartDebtFactor = 1;

        public Dictionary<Person, double> PaidPeople { get; private set; }

        public Dictionary<Person, double> DebtInEachPerson { get; private set; }
        public Dictionary<Person, double> DebtPersonFactors { get; private set; }

        // сумма приходящаяся на стандартных должников и с индивидуальной суммой
        private double PersonalDebtsSum
        {
            get
            {
                double personalDebtCost = 0;
                foreach (Person person in DebtPersonFactors.Keys)
                {
                    if (DebtPersonFactors[person] == personalDebtFactor)
                    {
                        personalDebtCost += DebtInEachPerson[person];
                    }
                }

                return personalDebtCost;
            }
        }

        private double StandartDebtsSum
        {
            get
            {
                return Cost - PersonalDebtsSum;
            }
        }

        public Product(int id, Trip trip, string name)
        {
            ID = id;
            Name = name;
            DebtInEachPerson = new Dictionary<Person, double>();
            DebtPersonFactors = new Dictionary<Person, double>();

            PaidPeople = new Dictionary<Person, double>();

            CurrentTrip = trip;
        }

        public Product(Trip trip, string name)
        {
            // ID = id;
            Name = name;
            DebtInEachPerson = new Dictionary<Person, double>();
            DebtPersonFactors = new Dictionary<Person, double>();

            PaidPeople = new Dictionary<Person, double>();

            CurrentTrip = trip;
        }


        public double Cost
        {
            get
            {
                double cost = 0;
                foreach (double paid in PaidPeople.Values)//TODO убедиться, что пробегаемся по всем значениям
                {
                    cost += paid;
                }

                return cost;
            }
        }

        public void AddPaidPerson(Person person, double moneyCount)
        {
            PaidPeople.Add(person, moneyCount);
            RecountDebtData();
        }

        public bool TryRemovePaidPerson(Person person)
        {
            if (!PaidPeople.ContainsKey(person))
            {
                return false;
            }

            PaidPeople.Remove(person);
            return true;
        }

        public bool TryRemoveDebtPerson(Person person)
        {
            if (!DebtInEachPerson.ContainsKey(person))
            {
                return false;
            }

            DebtInEachPerson.Remove(person);
            DebtPersonFactors.Remove(person);
            return true;
        }

        public bool TryChangePaymentCount(Person person, double moneyCount)
        {
            if (!PaidPeople.ContainsKey(person))
            {
                return false;
            }

            PaidPeople[person] = moneyCount;
            return true;
        }

        //сумма коэффициентов участия в доле суммы для всех кроме ИндивидуальноСуммых
        private double StandartAndPersonalFaсtorsSum
        {
            get
            {
                double factorsSum = 0;
                foreach (double factor in DebtPersonFactors.Values)
                {
                    if (factor != personalDebtFactor)
                    {
                        factorsSum += factor;
                    }
                }

                return factorsSum;
            }
        }

        public void AddPersonInDebts(Person person)
        {
            if (DebtInEachPerson.Count == 0 || !DebtInEachPerson.ContainsKey(person))
            {
                AddPersonWithOwnFactor(person, standartDebtFactor);
            }
        }

        private void RecountDebtData()
        {
            double weightedDebt = StandartDebtsSum / StandartAndPersonalFaсtorsSum;

            //  MessageBox.Show(weightedDebt + "  " + standartAndPersonalFactorCost + "  " + sumStandartAndPersonalFaсtors);

            foreach (Person person in DebtInEachPerson.Keys.ToList())
            {
                if (DebtPersonFactors[person] != personalDebtFactor)
                {
                    DebtInEachPerson[person] = weightedDebt * DebtPersonFactors[person];
                }
            }
        }

        /// <summary>
        /// Изменения суммы должника по товару на индивидуальную 
        /// Или добавление должнака в список на этих условиях, если его нет в нем.
        /// При этом пересчитывается и корректируется вся группа должников.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="debt"></param>
        public void InsertPersonalDebt(Person person, double debt)
        {
            if (DebtInEachPerson.Count == 0)
            {
                AddPersonDebtAndFactor(person, debt);
            }
            else if (!DebtInEachPerson.ContainsKey(person))
            {
                AddPersonDebtAndFactor(person, debt);
                RecountDebtData();
            }
            else
            {
                DebtPersonFactors[person] = personalDebtFactor;
                DebtInEachPerson[person] = debt;

                RecountDebtData();
            }
        }

        private void AddPersonDebtAndFactor(Person person, double debt)
        {
            DebtPersonFactors.Add(person, personalDebtFactor);
            DebtInEachPerson.Add(person, debt);
        }

        /// <summary>
        /// Измененения суммы должника путем введения коэффициента
        /// Или добавление должника в список на этих условиях, если его нет в нем.
        /// При этом пересчитывается и корректируется вся группа должников.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="factor"></param>
        public void InsertPersonalFactor(Person person, double factor)
        {
            if (DebtInEachPerson.Count == 0 && DebtPersonFactors.Count == 0)
            {
                DebtInEachPerson.Add(person, Cost);
                DebtPersonFactors.Add(person, factor);
            }
            else if (!DebtInEachPerson.ContainsKey(person))
            {
                AddPersonWithOwnFactor(person, factor);
            }
            else
            {
                DebtPersonFactors[person] = factor;
                RecountDebtData();
            }
        }

        private void AddPersonWithOwnFactor(Person person, double factor)
        {
            double nullDebt = 0;
            DebtInEachPerson.Add(person, nullDebt);
            DebtPersonFactors.Add(person, factor);

            RecountDebtData();
        }

        public override string ToString()
        {
            return string.IsNullOrEmpty(Name) ? "NonameProduct" : Name;
        }
    }
}
