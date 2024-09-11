using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oraiFel0911
{
    internal class PeopleWithDogs
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ID { get; set; }
        public List<Dog> Dogs { get; set; }

        public PeopleWithDogs(string firstName, string lastName, string id)
        {
            FirstName = firstName;
            LastName = lastName;
            ID = id;
            Dogs = new List<Dog>();
        }
    }
}
