using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostSharing;

namespace ForTest
{
    public class FormLogic
    {
        public Dictionary<int, Product> Products { get; private set; }
        public Dictionary<int, Person> People { get; private set; }
        public List<PayGroup> PayGroups { get; private set; }


    }
}
