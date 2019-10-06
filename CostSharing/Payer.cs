using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CostSharing
{
    [Serializable]
    public class Payer
    {
        public Person Person { get;  set; }
        public double Payment { get; set; }

        public Payer(Person person)
        {
            Person = person;
            Payment = 0;
        }

        public Payer(Person person, double payment)
        {
            Person = person;
            Payment = payment;
        }
    }
}
