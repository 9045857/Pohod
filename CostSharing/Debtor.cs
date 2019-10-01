using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostSharing
{
    [Serializable]
    public class Debtor
    {
        public Person Person { get; private set; }
        public double Factor { get; set; }
        public double Debt { get; set; }

        public Debtor(Product product, Person person)
        {
            Person = person;
            person.TryAddProductDebt(product);

            Factor = person.DebtFactor;

            int beginDebt = 0;
            Debt = beginDebt;
        }

        public Debtor(Product product, Person person, double factor)
        {
            Person = person;
            person.TryAddProductDebt(product);

            Factor = factor;

            int beginDebt = 0;
            Debt = beginDebt;
        }
    }
}
