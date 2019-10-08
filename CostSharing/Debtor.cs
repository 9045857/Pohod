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
        public Person Person { get; set; }
        public double Factor { get; set; }
        public double Debt { get; set; }

        public Debtor(Person person)
        {
            Person = person;
            Factor = person.DebtFactor;

            int beginDebt = 0;
            Debt = beginDebt;
        }

        public Debtor(Person person, double factor)
        {
            Person = person;
            Factor = factor;

            int beginDebt = 0;
            Debt = beginDebt;
        }

        public Debtor(Person person, double factor, double debt)
        {
            Person = person;
            Factor = factor;
            Debt = debt;
        }
    }
}
