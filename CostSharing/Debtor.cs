using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CostSharing
{
    [DataContract]
    public class Debtor
    {
        [DataMember]
        public Person Person { get; private set; }

        [DataMember]
        public double Factor { get; set; }

        [DataMember]
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
