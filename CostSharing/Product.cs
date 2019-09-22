using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostSharing
{
    public class Product
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; set; }

        public Trip CurrentTrip { get; }

        private readonly int factorForPersonalDebt = 0; //TODO: пока коэфициент для Суммщиков 0, но возможно нужно -1 для более явного отличия
        private readonly int standartDebtFactor = 1;

        public Product(int id, Trip trip,string name)
        {
            ID = id;
            Name = name;
            DebtInEachPerson = new Dictionary<int, double>();
            DebtPersonFactors = new Dictionary<int, double>();

            CurrentTrip = trip;
        }

        public double Cost { get; private set; }// TODO нужно будет переделать на словарь платильщиков

        public void SetCost(double newCost)
        {
            Cost = newCost;
            //TODO: добавbnm метод пересчета сумм стандартных вычетов и других при изменении цены.
        }

        public Dictionary<int, double> DebtInEachPerson { get; private set; }
        public Dictionary<int, double> DebtPersonFactors { get; private set; }

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
            if (DebtInEachPerson.Count == 0 || !DebtInEachPerson.ContainsKey(person.ID))
            {
                AddPersonWithFactor(person, standartDebtFactor);
            }
        }

        private void RecountDebtData()
        {
            double weightedDebt = standartAndPersonalFactorCost / sumStandartAndPersonalFaсtors;

            foreach (int personId in DebtInEachPerson.Keys)
            {
                if (DebtPersonFactors[personId] != factorForPersonalDebt)
                {
                    DebtInEachPerson[personId] = weightedDebt * DebtPersonFactors[personId];
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
            else if (!DebtInEachPerson.ContainsKey(person.ID))
            {
                RefillDictionariesAfterInsertPersonalDebt(person, debt);
                RecountDebtData();

            }
            else if (DebtPersonFactors[person.ID] == factorForPersonalDebt)
            {
                personalDebtCost -= DebtInEachPerson[person.ID];
                RecountCostSummAfterIncreasePersonalDebt(debt);
                ChangePersonalDebtAndRecountDebtData(person, debt);
            }
            else
            {
                sumStandartAndPersonalFaсtors--;
                RecountCostSummAfterIncreasePersonalDebt(debt);
                DebtPersonFactors[person.ID] = factorForPersonalDebt;
                ChangePersonalDebtAndRecountDebtData(person, debt);
            }
        }

        private void ChangePersonalDebtAndRecountDebtData(Person person, double debt)
        {
            DebtInEachPerson[person.ID] = debt;
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

            DebtPersonFactors.Add(person.ID, factorForPersonalDebt);
            DebtInEachPerson.Add(person.ID, debt);
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
                DebtInEachPerson[person.ID] = Cost;
            }
            else if (!DebtInEachPerson.ContainsKey(person.ID))
            {
                AddPersonWithFactor(person, factor);
            }
            else if (DebtPersonFactors[person.ID] == factorForPersonalDebt)
            {
                double pastDebt = DebtInEachPerson[person.ID];
                DebtPersonFactors[person.ID] = factor;

                personalDebtCost -= pastDebt;
                CountStandartAndPersonalFactorCost();

                RecountDebtData();
            }
            else
            {
                DebtPersonFactors[person.ID] = factor;
                RecountDebtData();
            }
        }

        private void AddPersonWithFactor(Person person, double factor)
        {
            DebtPersonFactors.Add(person.ID, factor);
            sumStandartAndPersonalFaсtors++;

            double nullDebt = 0;
            DebtInEachPerson.Add(person.ID, nullDebt);

            RecountDebtData();
        }        
    }
}
