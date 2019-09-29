using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostSharing
{
    public class Payer
    {
        public Person Person { get; private set; }
        public double Payment { get; set; }

        public Payer(Product product, Person person)
        {
            Person = person;
            person.AddProductInPaidList(product);

            int beginPayment = 0;
            Payment = beginPayment;
        }

        public Payer(Product product, Person person, double payment)
        {
            Person = person;
            person.AddProductInPaidList(product);
            Payment = payment;
        }
    }
}
