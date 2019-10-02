using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CostSharing
{
    [DataContract]
    public class Payer
    {
        [DataMember]
        public Person Person { get; private set; }

        [DataMember]
        public double Payment { get; set; }

        public Payer(Product product, Person person)
        {
            Person = person;
            person.AddPaidProduct(product);

            int beginPayment = 0;
            Payment = beginPayment;
        }

        public Payer(Product product, Person person, double payment)
        {
            Person = person;
            person.AddPaidProduct(product);
            Payment = payment;
        }
    }
}
