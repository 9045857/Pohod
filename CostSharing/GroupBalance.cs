using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostSharing
{
    [Serializable]
    public class GroupBalance
    {
        public enum BalanceStatus { Payer, Debtor, Neutral };
        public BalanceStatus Status { get; set; }

        private const double epsilon = 1.0e-10;

        public Trip Trip { get; private set; }
        public Person Leader { get; private set; }
        public List<GroupBalanceCompensator> Compensators { get; set; }

        public GroupBalance(Trip trip, Person leader)
        {
            Trip = trip;
            Leader = leader.PayGroupLeader;
            SetStatus();

            Compensators = new List<GroupBalanceCompensator>();
        }

        //public GroupBalanceCompensator GetCompensator(Person leader)
        //{
        //    foreach (GroupBalanceCompensator compensator in Compensators)
        //    {
        //        if (Equals(leader, compensator.Leader))
        //        {
        //            return compensator;
        //        }
        //    }

        //    return null;
        //}



        /// <summary>
        /// Метод забирает из коллекции Должников, "перекладывая" их в коллекцию Плательщика.
        /// Если долг превышает сумму платежа, то должник дублируется с долгом равным платежу, 
        /// а в исходном объекте долг уменьшается на платеж. 
        /// Метод применяется только к Плательщикам.
        /// </summary>
        /// <param name="debtorsCompensators"></param>
        /// <returns></returns>
        public void GiveDebtorsCompensators(List<GroupBalanceCompensator> debtorsCompensators)
        {
            if (Status == BalanceStatus.Debtor || Status == BalanceStatus.Neutral)
            {
                return;
            }

            if (debtorsCompensators == null || debtorsCompensators.Count == 0)
            {
                return;
            }

            Compensators.Clear();

            double balance = PayDebtBalance;
            foreach (GroupBalanceCompensator compensator in debtorsCompensators.ToArray())
            {
                if (compensator.BalanceStatus == BalanceStatus.Debtor)
                {
                    if (IsFirstGreaterSecond(Math.Abs(compensator.MoneyCount), balance))
                    {
                        compensator.MoneyCount += balance;
                        Compensators.Add(new GroupBalanceCompensator(Trip, compensator.Leader, BalanceStatus.Debtor, balance));
                        return;
                    }
                    else if (IsFirstGreaterSecond(balance, Math.Abs(compensator.MoneyCount)))
                    {
                        MoveCompensator(debtorsCompensators, compensator);
                    }
                    else
                    {
                        MoveCompensator(debtorsCompensators, compensator);
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


        /// <summary>
        /// Свойство показывает разницу между групповой оплатой и долгом
        /// Для глобального плательщика - положительная.
        /// Для глобального должника - отрицательная.
        /// </summary>
        public double PayDebtBalance
        {
            get
            {
                return Trip.GetPayGroupTotalPayment(Leader) - Trip.GetPayGroupTotalDebt(Leader);
            }
        }

        //public double Balance//TODO пока не понятно нужно ли это свойство
        //{
        //    get
        //    {
        //        double compensatorsSum = 0;
        //        foreach (GroupBalanceCompensator compensator in Compensators)
        //        {
        //            compensatorsSum += compensator.MoneyCount;
        //        }
        //        return PayDebtBalance - compensatorsSum; ;
        //    }
        //}
    }
}
