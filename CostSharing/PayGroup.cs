using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostSharing
{
    public class PayGroup
    {
        //TODO попробуем логику групп засунуть в персон
        public int ID { get; private set; }
        public string Name { get; set; }//TODO не нужен
        public Person GroupManager { get; private set; }

        public List<int> PeopleID;

        public PayGroup(int id, Person person )
        {
            ID = id;
            GroupManager = person;

            PeopleID = new List<int>();
          //  PeopleID.Add(person.ID);
        }

        public void AddPersonInGroup(int persontId)
        {
            PeopleID.Add(persontId);
        }




    }
}
