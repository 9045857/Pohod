using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostSharing
{
    public class Buy
    {
        public Product Product { get; set; }
        public List<Payer> Payers { get; set; }
        public List<Debtor> Debtors { get; set; }

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

        private bool IsPersonInDebtors(Person person)
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
            }
        }

        private Debtor GetDebtor(Person person)
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

        public void RemoveDebtor(Person person)
        {
            Debtor debtor = GetDebtor(person);

            if (debtor != null)
            {
                Debtors.Remove(debtor);
            }
        }

        private double GetStandartDebtsSum()
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

        private double GetStandartAndPersonalFaсtorsSum()
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

        private void RecountDebtorsData()
        {
            double standartDebtsSum = GetStandartDebtsSum();
            double standartAndPersonalFaсtorsSum= GetStandartAndPersonalFaсtorsSum();

            double weightedDebt = standartDebtsSum / standartAndPersonalFaсtorsSum;
                      
            foreach (Debtor debtor in Debtors)
            {
                if (debtor.Factor != GeneralInfo.FixedDebtFactor)
                {
                    debtor.Debt = weightedDebt * debtor.Factor;
                }
            }
        }


        public Buy(Product product)
        {
            Product = product;
        }

        private bool IsPersonInPayers(Person person)
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
        }

        private Payer GetPayer(Person person)
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

        public void RemovePayer(Person person)
        {
            Payer payer = GetPayer(person);

            if (payer != null)
            {
                Payers.Remove(payer);
            }
        }





    }
}
