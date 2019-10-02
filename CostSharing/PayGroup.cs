using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CostSharing
{
    [DataContract]
    public class PayGroup
    {
        //TODO попробуем логику групп засунуть в персон
             
        public string Name { get; set; }
        public Person GroupManager { get; private set; }
        public List<Person> People { get; set; }

        public PayGroup(Person person )
        {
            GroupManager = person;
            People = new List<Person>();
            People.Add(person);
            Name = person.Name;
        }        
    }
}
