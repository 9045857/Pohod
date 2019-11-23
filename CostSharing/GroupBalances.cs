using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostSharing
{
    [Serializable]
    public class GroupBalances
    {
        private Trip trip;

        private List<Person> people;
        private List<Product> products;

        private List<GroupBalance> debtorsGroupBalances;
        private List<GroupBalance> payersGroupBalances;
        private List<GroupBalance> neutralsGroupBalances;

        public GroupBalances(Trip trip)
        {
            this.trip = trip;

            people = trip.People;
            products = trip.Products;

            debtorsGroupBalances = new List<GroupBalance>();
            payersGroupBalances = new List<GroupBalance>();
            neutralsGroupBalances = new List<GroupBalance>();

            FillGroupBalances();
        }

        private void GreateAndSeparateGroupBalances()
        {
            foreach (Person person in people)
            {
                if (Equals(person, person.PayGroupLeader))
                {
                    GroupBalance groupBalance = new GroupBalance(trip, person);

                    var a = groupBalance.Status;

                    switch (groupBalance.Status)
                    {
                        case GroupBalance.BalanceStatus.Debtor:
                            debtorsGroupBalances.Add(groupBalance);
                            break;

                        case GroupBalance.BalanceStatus.Neutral:
                            neutralsGroupBalances.Add(groupBalance);
                            break;

                        case GroupBalance.BalanceStatus.Payer:
                            payersGroupBalances.Add(groupBalance);
                            break;
                    }
                }
            }
        }

        private void ClearGroupBalances()
        {
            debtorsGroupBalances.Clear();
            payersGroupBalances.Clear();
            neutralsGroupBalances.Clear();
        }

        private static void SortGroupBalances(List<GroupBalance> groupBalances)//TODO needed test
        {
            for (int i = 0; i < groupBalances.Count - 1; ++i)
            {
                int maxElementIndex = i;//
                for (int j = i + 1; j < groupBalances.Count; j++)
                {
                    if (Math.Abs(groupBalances[j].PayDebtBalance) > Math.Abs(groupBalances[maxElementIndex].PayDebtBalance))
                    {
                        maxElementIndex = j;
                    }
                }

                GroupBalance tempElement = groupBalances[i];
                groupBalances[i] = groupBalances[maxElementIndex];
                groupBalances[maxElementIndex] = tempElement;
            }
        }

        private void SortDebtorsAndPayersGroupBalances()
        {
            SortGroupBalances(debtorsGroupBalances);
            SortGroupBalances(payersGroupBalances);
        }

        private void FillDebtorsCompensators()
        {
            //TODO по сути данный метод и не нужен. Мы расписали должников по плательщиков, обратный вариант нам не нужен.
        }

        /// <summary>
        /// The Mathod is first of two of compensators calculation.
        /// First-payers calculation, second - debtors calculation. 
        /// </summary>
        private void FillPayersCompensators()
        {
            foreach (GroupBalance groupBalance in payersGroupBalances)
            {
                groupBalance.Compensators.Clear();
            }

            List<GroupBalanceCompensator> debtorsCompensators = new List<GroupBalanceCompensator>();

            foreach (GroupBalance groupBalance in debtorsGroupBalances)
            {
                debtorsCompensators.Add(new GroupBalanceCompensator(trip, groupBalance.Leader, groupBalance.Status, groupBalance.PayDebtBalance));
            }

            foreach (GroupBalance groupBalance in payersGroupBalances)
            {
                groupBalance.GiveDebtorsCompensators(debtorsCompensators);
            }
        }

        private void FillCompensators()
        {
            FillPayersCompensators();
            //  FillDebtorsCompensators();
        }

        private void FillGroupBalances()
        {
            ClearGroupBalances();

            GreateAndSeparateGroupBalances();
            SortDebtorsAndPayersGroupBalances();

            FillCompensators();
        }

        public override string ToString()
        {
            FillGroupBalances();

            StringBuilder stringBuilder = new StringBuilder();

            foreach (GroupBalance payersGroup in payersGroupBalances)
            {
                stringBuilder.AppendLine("-----------");

                int numberCountAfterComma = 2;
                stringBuilder.AppendLine(string.Format("{0,-20}{1}", payersGroup.Leader.Name, Math.Round(payersGroup.PayDebtBalance, numberCountAfterComma)));

                foreach (GroupBalanceCompensator debtorsCompensators in payersGroup.Compensators)
                {
                    stringBuilder.AppendLine(string.Format("- {0,-20}{1}", debtorsCompensators.Leader.Name, Math.Round(debtorsCompensators.MoneyCount, numberCountAfterComma)));
                }
            }

            return stringBuilder.ToString();
        }
    }
}
