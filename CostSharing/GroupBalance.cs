using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostSharing
{
    public class GroupBalance
    {
        public enum BalanceStatus { Payer, Debtor, Neutral };
        public BalanceStatus Status { get; private set; }

        private const double epsilon = 1.0e-10;

        private Trip _trip;
        public Person Leader { get; private set; }
        public List<GroupBalanceCompensator> Compensators { get; private set; }

        /// <summary>
        /// Метод забирает из коллекции должников для Спонсора(плательщика), "перекладывая" их в свою коллекцию.
        /// Если долг превышает сумму платежа, то должник дублируется с долгом равным платежу, 
        /// а в исходном объекте долг уменьшается на платеж. 
        /// Метод применяется только к плательщикам.
        /// </summary>
        /// <param name="innerCompensators"></param>
        /// <returns></returns>
        public void TakeDebtorsCompensators(List<GroupBalanceCompensator> innerCompensators)
        {
            if (Status == BalanceStatus.Debtor || Status == BalanceStatus.Neutral)
            {
                return;
            }

            if (innerCompensators == null || innerCompensators.Count == 0)
            {
                return;
            }

            double balance = PayDebtBalance;
            foreach (GroupBalanceCompensator compensator in innerCompensators.ToArray())
            {
                if (compensator.BalanceStatus == BalanceStatus.Debtor)
                {
                    if (IsFirstGreaterSecond(Math.Abs(compensator.MoneyCount), balance))
                    {
                        compensator.MoneyCount += balance;
                        Compensators.Add(new GroupBalanceCompensator(_trip, compensator.Leader,BalanceStatus.Debtor, balance));
                        return;
                    }
                    else if (IsFirstGreaterSecond(balance, Math.Abs(compensator.MoneyCount)))
                    {
                        MoveCompensator(innerCompensators, compensator);
                    }
                    else
                    {
                        MoveCompensator(innerCompensators, compensator);
                        return;
                    }
                }
            }
        }

        private void MoveCompensator(List<GroupBalanceCompensator> innerCompensators, GroupBalanceCompensator compensator)
        {
            innerCompensators.Remove(compensator);
            Compensators.Add(compensator);
        }

        private bool AreEqual(double firstNumber, double secondNumber)
        {
            return Math.Abs(firstNumber - secondNumber) <= epsilon;
        }

        private bool IsFirstGreaterSecond(double firstNumber, double secondNumber)
        {
            return (firstNumber - secondNumber) > epsilon;
        }

        public GroupBalance(Trip trip, Person leader)
        {
            _trip = trip;
            Leader = leader.PayGroupLeader;
            SetStatus();

            Compensators = new List<GroupBalanceCompensator>();
        }

        private void SetStatus()
        {
            double payDebtBalance = PayDebtBalance;
            if (IsFirstGreaterSecond(payDebtBalance, 0))
            {
                Status = BalanceStatus.Payer;
            }
            else if (IsFirstGreaterSecond(0, payDebtBalance))
            {
                Status = BalanceStatus.Debtor;
            }
            else
            {
                Status = BalanceStatus.Neutral;
            }
        }

        public double PayDebtBalance
        {
            get
            {
                return _trip.GetPayGroupTotalPayment(Leader) - _trip.GetPersonalTotalDebt(Leader);
            }
        }

        public double Balance//TODO пока не понятно нужно ли это свойство
        {
            get
            {
                double compensatorsSum = 0;
                foreach (GroupBalanceCompensator compensator in Compensators)
                {
                    compensatorsSum += compensator.MoneyCount;
                }
                return PayDebtBalance - compensatorsSum; ;
            }
        }
    }
}
