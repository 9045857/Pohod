using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;

namespace CostSharing
{
    [Serializable]
    public class Product
    {
        public string Name { get; set; }

        public string Description { get; set; }//TODO пока нигде не используется

        public List<Payer> Payers { get; private set; }
        public List<Debtor> Debtors { get; private set; }

        public double Cost//Может быть правильнее сделать пересчет цены только когда меняется список участников или еще когда-нибудь, привязать с событиям
        {
            get
            {
                double cost = 0;
                foreach (Payer payer in Payers)
                {
                    cost += payer.Payment;
                }

                return cost;
            }
        }

        public bool IsPersonInDebtors(Person person)
        {
            foreach (Debtor debtor in Debtors)
            {
                if (Equals(debtor.Person, person))
                {
                    return true;
                }
            }

            return false;
        }

        public void AddDebtor(Person person, double debtFactor)
        {
            if (!IsPersonInDebtors(person))
            {
                Debtor debtor = new Debtor(person, debtFactor);
                Debtors.Add(debtor);

                RecountDebtorsData();
            }
        }

        public void AddDebtorWithFixedDebt(Person person, double debt)
        {
            if (!IsPersonInDebtors(person))
            {
                Debtor debtor = new Debtor(person, GeneralInfo.FixedDebtFactor, debt);
                Debtors.Add(debtor);

                RecountDebtorsData();
            }
        }

        public Debtor GetDebtor(Person person)
        {
            foreach (Debtor debtor in Debtors)
            {
                if (Equals(debtor.Person, person))
                {
                    return debtor;
                }
            }

            return null;
        }

        public Payer GetPayer(Person person)
        {
            foreach (Payer payer in Payers)
            {
                if (Equals(payer.Person, person))
                {
                    return payer;
                }
            }

            return null;
        }

        public void RemoveDebtor(Person person)
        {
            Debtor debtor = GetDebtor(person);

            if (debtor != null)
            {
                Debtors.Remove(debtor);
                RecountDebtorsData();
            }
        }

        private double GetStandartDebtorsDebtsSum()
        {
            double fixedDebtsSum = 0;
            foreach (Debtor debtor in Debtors)
            {
                if (debtor.Factor == GeneralInfo.FixedDebtFactor)
                {
                    fixedDebtsSum += debtor.Debt;
                }
            }

            return Cost - fixedDebtsSum;
        }

        private double GetStandartAndPersonalDebtorsFaсtorsSum()
        {
            double standartAndPersonalFaсtorsSum = 0;
            foreach (Debtor debtor in Debtors)
            {
                if (debtor.Factor != GeneralInfo.FixedDebtFactor)
                {
                    standartAndPersonalFaсtorsSum += debtor.Factor;
                }
            }

            return standartAndPersonalFaсtorsSum;
        }

        public void RecountDebtorsData()
        {
            double standartDebtorsDebtsSum = GetStandartDebtorsDebtsSum();
            double standartAndPersonalDebtorsFaсtorsSum = GetStandartAndPersonalDebtorsFaсtorsSum();

            double weightedDebt = standartDebtorsDebtsSum / standartAndPersonalDebtorsFaсtorsSum;

            foreach (Debtor debtor in Debtors)
            {
                if (debtor.Factor != GeneralInfo.FixedDebtFactor)
                {
                    debtor.Debt = weightedDebt * debtor.Factor;
                }
            }
        }

        public Product(string name)
        {
            Name = name;

            Debtors = new List<Debtor>();
            Payers = new List<Payer>();
        }

        public bool IsPersonInPayers(Person person)
        {
            foreach (Payer payer in Payers)
            {
                if (Equals(payer.Person, person))
                {
                    return true;
                }
            }

            return false;
        }

        public void AddPayer(Person person, double payment)
        {
            if (!IsPersonInPayers(person))
            {
                Payer payer = new Payer(person, payment);
                Payers.Add(payer);
            }
            else
            {
                GetPayer(person).Payment = payment;
            }

            RecountDebtorsData();
        }

        public void RemovePayer(Person person)
        {
            Payer payer = GetPayer(person);

            if (payer != null)
            {
                Payers.Remove(payer);

                RecountDebtorsData();
            }
        }























        //public Trip CurrentTrip { get; set; }

        //[DataMember]
        //public Dictionary<Person, double> Payers { get; private set; }

        //[DataMember]
        //public Dictionary<Person, Debtor> Debtors { get; private set; }

        ////  public Dictionary<Person, double> DebtPersonFactors { get; private set; }

        //// сумма приходящаяся на стандартных должников и с индивидуальной суммой
        //private double PersonalDebtsSum
        //{
        //    get
        //    {
        //        double personalDebtCost = 0;
        //        foreach (Debtor debtor in Debtors.Values)
        //        {
        //            if (debtor.Factor == GeneralInfo.FixedDebtFactor)
        //            {
        //                personalDebtCost += debtor.Factor;
        //            }
        //        }

        //        return personalDebtCost;
        //    }
        //}

        //private double StandartDebtsSum
        //{
        //    get
        //    {
        //        return Cost - PersonalDebtsSum;
        //    }
        //}

        //private double StandartAndPersonalFaсtorsSum
        //{
        //    get
        //    {
        //        double factorsSum = 0;
        //        foreach (Debtor debtor in Debtors.Values)
        //        {
        //            if (debtor.Factor != GeneralInfo.FixedDebtFactor)
        //            {
        //                factorsSum += debtor.Factor;
        //            }
        //        }

        //        return factorsSum;
        //    }
        //}


        //public Product(Trip trip, string name)
        //{
        //    Name = name;
        //    CurrentTrip = trip;

        //    Debtors = new Dictionary<Person, Debtor>();
        //    Payers = new Dictionary<Person, double>();
        //}

        //public double Cost
        //{
        //    get
        //    {
        //        double cost = 0;
        //        foreach (double payment in Payers.Values)
        //        {
        //            cost += payment;
        //        }

        //        return cost;
        //    }
        //}

        //public void AddPayers(Person person, double moneyCount)
        //{
        //    if (!Payers.ContainsKey(person))
        //    {
        //        Payers.Add(person, moneyCount);
        //    }
        //    else
        //    {
        //        //TODO что делаем если такой плательщик есть? меняем сумму? или добавляем ее ? или ничего не делаем?
        //    }

        //    RecountDebtData();
        //}

        //public bool TryRemovePaidPerson(Person person)
        //{
        //    if (!Payers.ContainsKey(person))
        //    {
        //        return false;
        //    }

        //    Payers.Remove(person);
        //    return true;
        //}

        //public bool TryRemoveDebtPerson(Person person)
        //{
        //    if (!Debtors.ContainsKey(person))
        //    {
        //        return false;
        //    }

        //    Debtors.Remove(person);
        //    return true;
        //}

        //public bool TryChangePayment(Person person, double moneyCount)
        //{
        //    if (!Payers.ContainsKey(person))
        //    {
        //        return false;
        //    }

        //    Payers[person] = moneyCount;
        //    return true;
        //}

        //public void AddDebtor(Person person)
        //{
        //    if (Debtors.Count == 0 || !Debtors.ContainsKey(person))
        //    {
        //        AddPersonWithOwnFactor(person, GeneralInfo.StandartDebtFactor);
        //    }
        //}

        //private void RecountDebtData()
        //{
        //    double weightedDebt = StandartDebtsSum / StandartAndPersonalFaсtorsSum;

        //    //  MessageBox.Show(weightedDebt + "  " + standartAndPersonalFactorCost + "  " + sumStandartAndPersonalFaсtors);

        //    foreach (Debtor debtor in Debtors.Values.ToList())
        //    {
        //        if (debtor.Factor != GeneralInfo.FixedDebtFactor)
        //        {
        //            debtor.Debt = weightedDebt * debtor.Factor;
        //        }
        //    }
        //}

        ///// <summary>
        ///// Изменения суммы должника по товару на индивидуальную 
        ///// Или добавление должнака в список на этих условиях, если его нет в нем.
        ///// При этом пересчитывается и корректируется вся группа должников.
        ///// </summary>
        ///// <param name="person"></param>
        ///// <param name="debt"></param>
        //public void InsertPersonalDebt(Person person, double debt)
        //{
        //    if (Debtors.Count == 0)
        //    {
        //        AddPersonDebtAndFactor(person, debt);
        //    }
        //    else if (!Debtors.ContainsKey(person))
        //    {
        //        AddPersonDebtAndFactor(person, debt);
        //        RecountDebtData();
        //    }
        //    else
        //    {
        //        Debtors[person].Factor = GeneralInfo.FixedDebtFactor;
        //        Debtors[person].Debt = debt;

        //        RecountDebtData();
        //    }
        //}

        //private void AddPersonDebtAndFactor(Person person, double debt)
        //{
        //    Debtor debtor = new Debtor(this, person);
        //    debtor.Debt = debt;
        //    Debtors.Add(person, debtor);
        //}

        ///// <summary>
        ///// Измененения суммы должника путем введения коэффициента
        ///// Или добавление должника в список на этих условиях, если его нет в нем.
        ///// При этом пересчитывается и корректируется вся группа должников.
        ///// </summary>
        ///// <param name="person"></param>
        ///// <param name="factor"></param>
        //public void InsertPersonalFactor(Person person, double factor)
        //{
        //    if (Debtors.Count == 0 )
        //    {
        //        Debtor debtor = new Debtor(this, person,factor);
        //        debtor.Debt = Cost;
        //        Debtors.Add(person, debtor);
        //    }
        //    else if (!Debtors.ContainsKey(person))
        //    {
        //        AddPersonWithOwnFactor(person, factor);
        //    }
        //    else
        //    {
        //        Debtors[person].Factor = factor;
        //        RecountDebtData();
        //    }
        //}

        //private void AddPersonWithOwnFactor(Person person, double factor)
        //{
        //    Debtor debtor = new Debtor(this,person,factor);
        //    double nullDebt = 0;
        //    debtor.Debt = nullDebt;

        //    Debtors.Add(person, debtor);

        //    RecountDebtData();
        //}

        public override string ToString()
        {
            return string.IsNullOrEmpty(Name) ? "NonameProduct" : Name;
        }
    }
}
