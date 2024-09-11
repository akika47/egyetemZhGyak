using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oraiFel0911
{
    internal class Dog
    {
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Age { get; set; }
        public string OwnerID { get; set; }

        public Dog(string name, string breed, string age, string ownerID)
        {
            Name = name;
            Breed = breed;
            Age = age;
            OwnerID = ownerID;
        }
    }
}
