using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneDirectory
{
    public class PersonOperation
    {
        List<Person> people = new List<Person>();

        public PersonOperation(List<Person> people)
        {
            this.people = people;
        }

        public void PersonView(Person person)
        {
            Console.WriteLine("-->İsim: " + person.Name);
            Console.WriteLine("   Soyisim: " + person.Surname);
            Console.WriteLine("   Telefon numarası: " + person.PhoneNumber);
            Console.WriteLine();
        }

        public void NameSurnameSearch(string str)
        {
            Console.WriteLine();
            bool isRecord = false;

            for (int i = 0; i < people.Count; i++)
            {
                if (str == people[i].Name || str == people[i].Surname)
                {
                    PersonView(people[i]);
                    isRecord = true;
                }
            }

            if (!isRecord)
            {
                ProcessResult("Aradığınız ifadeyle eşleşen sonuç bulunamamıştır.");
            }
        }
        public void PhoneNumberSearch(string str)
        {
            Console.WriteLine();
            bool isRecord = false;

            for (int i = 0; i < people.Count; i++)
            {
                if (str == people[i].PhoneNumber)
                {
                    PersonView(people[i]);
                    isRecord = true;
                }
            }
            if (!isRecord)
            {
                ProcessResult("Aradığınız ifadeyle eşleşen sonuç bulunamamıştır.");
            }

        }

        public bool IsPhonenumber(string str, out int index)
        {
            for (int i = 0; i < people.Count; i++)
            {
                if (str == people[i].Name || str == people[i].Surname)
                {
                    index = i;
                    return true;
                }
            }
            index = -1;
            return false;
        }
        public void DeleteNumber(int index)
        {
            people.RemoveAt(index);
            ProcessResult("Silme İşlemi Başarıyla Gerçekleşti.");
        }
        public void UpdatePhonenumber(int index, string newPhoneNumber)
        {
            people[index].PhoneNumber = newPhoneNumber;
            ProcessResult("Güncelleme İşlemi Başarıyla Gerçekleşti.");
        }

        public void List(Sorting select)
        {
            people.Sort((u1, u2) => u1.Name.CompareTo(u2.Name));//İsme göre sırala

            if (select == Sorting.Decreasing)//eğer azalan isteniyorsa listeyi ters çevir
            {
                people.Reverse();
            }

            Console.WriteLine();
            for (int i = 0; i < people.Count; i++)
            {
                PersonView(people[i]);
            }
        }
        void ProcessResult(string procesResult)
        {
            Console.WriteLine(procesResult);
        }
    }
}
