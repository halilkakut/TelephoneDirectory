using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneDirectory
{
    public class Person
    {
        public string Name;
        public string Surname;
        public string PhoneNumber;

        public Person(string name, string surName, string phoneNumber)
        {
            this.Name = name;
            this.Surname = surName;
            this.PhoneNumber = phoneNumber;
        }
    }
}
