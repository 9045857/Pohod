using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CostSharing
{
    [Serializable]
    public class Debtor
    {
        public enum FactorType { Standart, SpecialForProduct, WithoutFactor };

        public Person Person { get; set; }
        public double Factor { get; set; }
        public double Debt { get; set; }

        private FactorType _factorType;
        public FactorType Factor_Type
        {
            get
            {
                return _factorType;
            }
            set
            {
                if (value == FactorType.Standart)
                {
                    _factorType = FactorType.Standart;
                    Factor = Person.DebtFactor;
                }
                else if (value == FactorType.WithoutFactor)
                {
                    _factorType = FactorType.WithoutFactor;
                    Factor = GeneralInfo.FixedDebtFactor;
                }
                else
                {
                    _factorType = FactorType.SpecialForProduct;
                   // Factor = Person.DebtFactor;
                }
            }
        }

        public Debtor(Person person)
        {
            Person = person;
            Factor = person.DebtFactor;
            Factor_Type = FactorType.Standart;

            int beginDebt = 0;
            Debt = beginDebt;
        }

        public Debtor(Person person, FactorType factorType, double value)
        {
            Person = person;
            this.Factor_Type = factorType;

            if (factorType == FactorType.SpecialForProduct)
            {
                Factor = value;
                int beginDebt = 0;
                Debt = beginDebt;
            }
            else if (factorType == FactorType.WithoutFactor)
            {
                Factor = GeneralInfo.FixedDebtFactor;
                Debt = value;
            }
            else
            {
                Factor = Person.DebtFactor;
                int beginDebt = 0;
                Debt = beginDebt;
            }         
        }

        //public Debtor(Person person, double factor, double debt)
        //{
        //    Person = person;
        //    Factor = factor;
        //    Debt = debt;
        //}
    }
}
