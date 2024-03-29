﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CostSharing
{
    [Serializable]
    public class Person
    {
        public string Name { get; set; }

        /// <summary>
        /// Лидер группы плательщиков. 
        /// Если Person не состоит в группе, он сам является Лидером.
        /// </summary>
        public Person PayGroupLeader { get; private set; }

        /// <summary>
        /// Список участников "подчиненной" группы плательщиков.
        /// Если текущий Person не является лидером группы, то список пустой.
        /// При создании Person является лидером группы, где один участник - он сам.
        /// </summary>
        public List<Person> PayGroupPeople { get; private set; }

        /// <summary>
        /// Вес участия в доле оплаты товара (коэффициент оплаты). 
        /// По умолчанию вес равен 1.
        /// </summary>
        public double DebtFactor { get; set; }

        /// <summary>
        /// Задаем коэффицент оплаты.
        /// </summary>
        public void SetDebtFactor(double debtFactor)
        {
            DebtFactor = debtFactor;
        }


        public Person(string name)//TODO данный трансформер будем делать основным
        {
            Name = name;

            PayGroupLeader = this;
            PayGroupPeople = new List<Person>
            {
                this
            };

            DebtFactor = GeneralInfo.StandartDebtFactor;
        }


        /// <summary>
        /// Добавление в рядовые члены группы плательщиков.
        /// При добавлении лидера другой группы, он становиться рядовым участником текущей группы,
        /// а в группе, от куда он ушел, лидером становиться первый по списку член.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public bool TryAddInPayGroup(Person person)
        {
            if (PayGroupLeader.PayGroupPeople.Contains(person))
            {
                return false;
            }

            if (person.PayGroupPeople.Count == 1)
            {
                person.PayGroupLeader = this.PayGroupLeader;
                PayGroupLeader.PayGroupPeople.Add(person);
                person.PayGroupPeople.Clear();

                return true;
            }
            else if (Equals(person, person.PayGroupLeader))
            {
                person.PayGroupPeople.Remove(person);

                int firstPersonIndex = 0;
                Person newLeader = person.PayGroupPeople[firstPersonIndex];

                ChangeGroupLeader(person, newLeader);

                person.PayGroupPeople.Clear();
                person.PayGroupLeader = this.PayGroupLeader;

                return true;
            }
            else
            {
                person.PayGroupLeader.PayGroupPeople.Remove(person);
                person.PayGroupLeader = this.PayGroupLeader;

                return true;
            }
        }

        /// <summary>
        /// Смена Лидера группы плательщиков.
        /// Новый Лидер должен состоять в группе.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public bool TryChangeGroupLeager(Person person)
        {
            if (!PayGroupPeople.Contains(person) || Equals(person, PayGroupLeader))
            {
                return false;
            }

            ChangeGroupLeader(PayGroupLeader, person);

            return true;
        }

        private static void ChangeGroupLeader(Person oldLeader, Person newLeader)
        {
            foreach (Person person in oldLeader.PayGroupPeople)
            {
                person.PayGroupLeader = newLeader;
                newLeader.PayGroupPeople.Add(person);
            }
        }

        /// <summary>
        /// Удаление (роспуск) группы. Все участники становятся независими, лидерами себя. 
        /// Удалять можно только от Лидера группы.
        /// </summary>
        public bool TryDeletePayGroup()
        {
            int singlePersonInGroup = 1;
            if (!Equals(this, PayGroupLeader) || PayGroupPeople.Count == singlePersonInGroup)
            {
                return false;
            }

            foreach (Person person in PayGroupPeople)
            {
                if (!Equals(person, PayGroupLeader))
                {
                    PayGroupPeople.Remove(person);

                    person.PayGroupPeople.Add(person);
                    person.PayGroupLeader = person;
                }
            }
            return true;
        }

        /// <summary>
        /// Удаляет Person из группы плательщиков - переводит в статус единоличного плательщика.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public bool TryRemoveFromPayGroup(Person person)
        {
            if (!PayGroupPeople.Contains(person) || person.PayGroupPeople.Count == 1)
            {
                return false;
            }

            if (Equals(PayGroupLeader, person))
            {
                PayGroupPeople.Remove(person);

                int firstPesonInListIndex = 0;
                Person newLeader = PayGroupPeople[firstPesonInListIndex];

                foreach (Person man in PayGroupPeople)
                {
                    man.PayGroupLeader = newLeader;
                    newLeader.PayGroupPeople.Add(man);
                }

                PayGroupLeader = this;
                PayGroupPeople.Clear();
                PayGroupPeople.Add(this);

                return true;
            }
            else
            {
                PayGroupPeople.Remove(person);
                person.PayGroupLeader = person;
                person.PayGroupPeople.Add(person);

                return true;
            }
        }

        public override string ToString()
        {
            string name = string.IsNullOrEmpty(Name) ? "NonamePerson" : Name;
            return PayGroupPeople.Count == 0 || PayGroupPeople.Count == 1 ? name : string.Format("{0} ({1})", name, PayGroupPeople.Count);
        }
    }
}
