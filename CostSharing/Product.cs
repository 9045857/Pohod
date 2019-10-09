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

        public void AddDebtorWithFactor(Person person, double debtFactor)
        {
            if (!IsPersonInDebtors(person))
            {
                Debtor debtor = new Debtor(person, Debtor.FactorType.SpecialForProduct, debtFactor);
                Debtors.Add(debtor);

                RecountDebtorsData();
            }
        }

        public void AddUsualDebtor(Person person)
        {
            if (!IsPersonInDebtors(person))
            {
                Debtor debtor = new Debtor(person, Debtor.FactorType.Standart, person.DebtFactor);
                Debtors.Add(debtor);

                RecountDebtorsData();
            }
        }

        public void AddDebtorWithFixedDebt(Person person, double debt)
        {
            if (!IsPersonInDebtors(person))
            {
                Debtor debtor = new Debtor(person, Debtor.FactorType.WithoutFactor, debt);
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

        public override string ToString()
        {
            return string.IsNullOrEmpty(Name) ? "NonameProduct" : Name;
        }
    }
}
