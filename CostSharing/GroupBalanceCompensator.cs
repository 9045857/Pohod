using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostSharing
{
    public class GroupBalanceCompensator
    {
        public Person Leader { get; private set; }
        public double MoneyCount { get; set; }
        public double BeginngMoneyCount { get; private set; }
        private readonly Trip _trip;
        public GroupBalance.BalanceStatus BalanceStatus { get; private set; }

        public GroupBalanceCompensator(Trip trip, Person person)
        {
            Leader = person.PayGroupLeader;
            BeginngMoneyCount = trip.GetPayGroupTotalPayment(Leader) - trip.GetPayGroupTotalDebt(Leader);
            _trip = trip;
            MoneyCount = BeginngMoneyCount;
            BalanceStatus = GetStatus();
        }

        public GroupBalanceCompensator(Trip trip, Person person,double moneyCount)
        {
            Leader = person.PayGroupLeader;
            BeginngMoneyCount = trip.GetPayGroupTotalPayment(Leader) - trip.GetPayGroupTotalDebt(Leader);
            _trip = trip;
            MoneyCount = moneyCount;
            BalanceStatus = GetStatus();
        }

        public GroupBalanceCompensator(Trip trip, Person person, GroupBalance.BalanceStatus status, double moneyCount)
        {
            Leader = person.PayGroupLeader;
            BeginngMoneyCount = trip.GetPayGroupTotalPayment(Leader) - trip.GetPayGroupTotalDebt(Leader);
            _trip = trip;
            BalanceStatus = status;
            MoneyCount = SetMoneyCount(moneyCount);
        }

        private double SetMoneyCount(double moneyCount)
        {
            if (BalanceStatus == GroupBalance.BalanceStatus.Debtor)
            {
                return -Math.Abs(moneyCount);
            }
            else if (BalanceStatus == GroupBalance.BalanceStatus.Payer)
            {
                return Math.Abs(moneyCount);
            }
            else
            {
                double neutralMoneyCount = 0;
                return neutralMoneyCount;
            }
        }

        private GroupBalance.BalanceStatus GetStatus()
        {
            if (BeginngMoneyCount > 0)
            {
                return GroupBalance.BalanceStatus.Payer;
            }
            else if (BeginngMoneyCount < 0)
            {
                return GroupBalance.BalanceStatus.Debtor;
            }
            else
            {
                return GroupBalance.BalanceStatus.Neutral;
            }
        }
    }
}
