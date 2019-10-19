using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostSharing
{
    class GroupBalance
    {
        public Trip Trip;
        public Person Leader { get; set; }

        public double PayDebtBalance
        {
            get
            {
                return Trip.GetPayGroupTotalPayment(Leader) - Trip.GetPersonalTotalDebt(Leader);
            }
        }

        public List<GroupBalanceCompensator> Compensators { get; set; }

        private double _balance;
        public double Balance
        {
            get
            {
                return _balance;
            }
            set
            {
                double compensatorsSum = 0;
                foreach (GroupBalanceCompensator compensator in Compensators)
                {
                    compensatorsSum += compensator.MoneyCount;
                }

                _balance = PayDebtBalance - compensatorsSum;
            }
        }
    }
}
