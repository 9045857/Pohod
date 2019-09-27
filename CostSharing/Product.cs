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

        private readonly int factorForPersonalDebt = 0; //TODO: пока коэфициент для Суммщиков 0, но возможно нужно -1 для более явного отличия
        private readonly int standartDebtFactor = 1;

        public Product(int id, Trip trip, string name)
        {
            ID = id;
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

        public Dictionary<Person, double> PaidPeople { get; private set; }

        public void AddPaidPerson(Person person, double moneyCount)
        {
            PaidPeople.Add(person, moneyCount);
            standartAndPersonalFactorCost += moneyCount;
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

        public Dictionary<Person, double> DebtInEachPerson { get; private set; }
        public Dictionary<Person, double> DebtPersonFactors { get; private set; }

        // сумма приходящаяся на стандартных должников и с индивидуальной суммой
        private double personalDebtCost;
        private double standartAndPersonalFactorCost;

        private void CountStandartAndPersonalFactorCost()
        {
            standartAndPersonalFactorCost = Cost - personalDebtCost;
        }

        //сумма коэффициентов участия в доле суммы для всех кроме ИндивидуальноСуммых
        private double sumStandartAndPersonalFaсtors;

        public void AddPersonInDebts(Person person)
        {
            if (DebtInEachPerson.Count == 0 || !DebtInEachPerson.ContainsKey(person))
            {
                AddPersonWithFactor(person, standartDebtFactor);
            }
        }

        private void RecountDebtData()
        {
            double weightedDebt = standartAndPersonalFactorCost / sumStandartAndPersonalFaсtors;

            // MessageBox.Show(weightedDebt +"  "+ standartAndPersonalFactorCost + "  " + sumStandartAndPersonalFaсtors);

            foreach (Person person in DebtInEachPerson.Keys.ToList())
            {
                if (DebtPersonFactors[person] != factorForPersonalDebt)
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
                RefillDictionariesAfterInsertPersonalDebt(person, debt);
            }
            else if (!DebtInEachPerson.ContainsKey(person))
            {
                RefillDictionariesAfterInsertPersonalDebt(person, debt);
                RecountDebtData();

            }
            else if (DebtPersonFactors[person] == factorForPersonalDebt)
            {
                personalDebtCost -= DebtInEachPerson[person];
                RecountCostSummAfterIncreasePersonalDebt(debt);
                ChangePersonalDebtAndRecountDebtData(person, debt);
            }
            else
            {
                sumStandartAndPersonalFaсtors--;
                RecountCostSummAfterIncreasePersonalDebt(debt);
                DebtPersonFactors[person] = factorForPersonalDebt;
                ChangePersonalDebtAndRecountDebtData(person, debt);
            }
        }

        private void ChangePersonalDebtAndRecountDebtData(Person person, double debt)
        {
            DebtInEachPerson[person] = debt;
            RecountDebtData();
        }

        private void RecountCostSummAfterIncreasePersonalDebt(double debt)
        {
            personalDebtCost += debt;
            CountStandartAndPersonalFactorCost();
        }

        private void RefillDictionariesAfterInsertPersonalDebt(Person person, double debt)
        {
            personalDebtCost += debt;
            CountStandartAndPersonalFactorCost();

            DebtPersonFactors.Add(person, factorForPersonalDebt);
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
            if (DebtInEachPerson.Count == 0)
            {
                sumStandartAndPersonalFaсtors += factor;
                DebtInEachPerson[person] = Cost;
            }
            else if (!DebtInEachPerson.ContainsKey(person))
            {
                AddPersonWithFactor(person, factor);
            }
            else if (DebtPersonFactors[person] == factorForPersonalDebt)
            {
                double pastDebt = DebtInEachPerson[person];
                DebtPersonFactors[person] = factor;

                personalDebtCost -= pastDebt;
                CountStandartAndPersonalFactorCost();

                RecountDebtData();
            }
            else
            {
                DebtPersonFactors[person] = factor;
                RecountDebtData();
            }
        }

        private void AddPersonWithFactor(Person person, double factor)
        {
            DebtPersonFactors.Add(person, factor);
            sumStandartAndPersonalFaсtors++;

            double nullDebt = 0;
            DebtInEachPerson.Add(person, nullDebt);

            RecountDebtData();
        }

        public override string ToString()
        {
            return string.IsNullOrEmpty(Name) ? "NonameProduct" : Name;
        }
    }
}
