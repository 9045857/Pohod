using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CostSharing
{
    [Serializable]
    public class Product
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; set; }//TODO пока нигде не используется

        public Trip CurrentTrip { get; }

        public Dictionary<Person, double> Payers { get; private set; }
        public Dictionary<Person, Debtor> Debtors { get; private set; }

        //  public Dictionary<Person, double> DebtPersonFactors { get; private set; }

        // сумма приходящаяся на стандартных должников и с индивидуальной суммой
        private double PersonalDebtsSum
        {
            get
            {
                double personalDebtCost = 0;
                foreach (Debtor debtor in Debtors.Values)
                {
                    if (debtor.Factor == GeneralInfo.PersonalDebtFactor)
                    {
                        personalDebtCost += debtor.Factor;
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

        private double StandartAndPersonalFaсtorsSum
        {
            get
            {
                double factorsSum = 0;
                foreach (Debtor debtor in Debtors.Values)
                {
                    if (debtor.Factor != GeneralInfo.PersonalDebtFactor)
                    {
                        factorsSum += debtor.Factor;
                    }
                }

                return factorsSum;
            }
        }

        
        public Product(Trip trip, string name)
        {
            Name = name;
            CurrentTrip = trip;

            Debtors = new Dictionary<Person, Debtor>();
            Payers = new Dictionary<Person, double>();
        }
        
        public double Cost
        {
            get
            {
                double cost = 0;
                foreach (double payment in Payers.Values)
                {
                    cost += payment;
                }

                return cost;
            }
        }

        public void AddPayers(Person person, double moneyCount)
        {
            if (!Payers.ContainsKey(person))
            {
                Payers.Add(person, moneyCount);
            }
            else
            {
                //TODO что делаем если такой плательщик есть? меняем сумму? или добавляем ее ? или ничего не делаем?
            }

            RecountDebtData();
        }

        public bool TryRemovePaidPerson(Person person)
        {
            if (!Payers.ContainsKey(person))
            {
                return false;
            }

            Payers.Remove(person);
            return true;
        }

        public bool TryRemoveDebtPerson(Person person)
        {
            if (!Debtors.ContainsKey(person))
            {
                return false;
            }

            Debtors.Remove(person);
            return true;
        }

        public bool TryChangePayment(Person person, double moneyCount)
        {
            if (!Payers.ContainsKey(person))
            {
                return false;
            }

            Payers[person] = moneyCount;
            return true;
        }

        public void AddDebtor(Person person)
        {
            if (Debtors.Count == 0 || !Debtors.ContainsKey(person))
            {
                AddPersonWithOwnFactor(person, GeneralInfo.StandartDebtFactor);
            }
        }

        private void RecountDebtData()
        {
            double weightedDebt = StandartDebtsSum / StandartAndPersonalFaсtorsSum;

            //  MessageBox.Show(weightedDebt + "  " + standartAndPersonalFactorCost + "  " + sumStandartAndPersonalFaсtors);

            foreach (Debtor debtor in Debtors.Values.ToList())
            {
                if (debtor.Factor != GeneralInfo.PersonalDebtFactor)
                {
                    debtor.Debt = weightedDebt * debtor.Factor;
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
            if (Debtors.Count == 0)
            {
                AddPersonDebtAndFactor(person, debt);
            }
            else if (!Debtors.ContainsKey(person))
            {
                AddPersonDebtAndFactor(person, debt);
                RecountDebtData();
            }
            else
            {
                Debtors[person].Factor = GeneralInfo.PersonalDebtFactor;
                Debtors[person].Debt = debt;

                RecountDebtData();
            }
        }

        private void AddPersonDebtAndFactor(Person person, double debt)
        {
            Debtor debtor = new Debtor(this, person);
            debtor.Debt = debt;
            Debtors.Add(person, debtor);
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
            if (Debtors.Count == 0 )
            {
                Debtor debtor = new Debtor(this, person,factor);
                debtor.Debt = Cost;
                Debtors.Add(person, debtor);
            }
            else if (!Debtors.ContainsKey(person))
            {
                AddPersonWithOwnFactor(person, factor);
            }
            else
            {
                Debtors[person].Factor = factor;
                RecountDebtData();
            }
        }

        private void AddPersonWithOwnFactor(Person person, double factor)
        {
            Debtor debtor = new Debtor(this,person,factor);
            double nullDebt = 0;
            debtor.Debt = nullDebt;

            Debtors.Add(person, debtor);

            RecountDebtData();
        }

        public override string ToString()
        {
            return string.IsNullOrEmpty(Name) ? "NonameProduct" : Name;
        }
    }
}
