using System;
using System.Collections.Generic;


namespace TelephoneDirectory
{
    public enum Sorting
    {
        Increasing,
        Decreasing
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            people.Add(new Person("Halil", "Kakut", "123456789"));
            people.Add(new Person("Burak", "Yılmaz", "23456196"));
            people.Add(new Person("Emre", "Mor", "435678912"));

            PersonOperation personOperation = new PersonOperation(people);
            while (true)
            {
                Console.WriteLine("----------------");
                Console.WriteLine("İşlemler");
                Console.WriteLine("(1).Telefon Numarası Kaydet");
                Console.WriteLine("(2).Telefon Numarası Sil");
                Console.WriteLine("(3).Telefon Numarası Güncelle");
                Console.WriteLine("(4).Rehber Listele");
                Console.WriteLine("(5).Rehberde Arama");
                Console.WriteLine("(6).Sonlandır");
                Console.WriteLine("----------------");

                Console.Write("\nİşlem seçiniz:");

                try
                {
                    int optNumber = Convert.ToInt16(Console.ReadLine());

                    if (optNumber < 1 || optNumber > 6)
                    {
                        Console.WriteLine("\nLütfen 1-6 arası işlem seçiniz!");
                        continue;
                    }
                    else if (optNumber == 6)
                    {
                        Console.WriteLine("İşlem Sonlandırıldı.");
                        break;
                    }

                    Console.Clear();

                    switch (optNumber)
                    {
                        case 1:
                            {
                                Console.Write(" Lütfen İsim giriniz:");
                                string name = Console.ReadLine();
                                Console.Write(" Lütfen Soyadı giriniz:");
                                string surname = Console.ReadLine();
                                Console.Write(" Lütfen Telefon numarası giriniz:");
                                string phone = Console.ReadLine();
                                Person person1 = new Person(name, surname, phone);

                                people.Add(person1);

                                Console.WriteLine("Kayıt işlemi gerçekleştirildi.");

                                break;
                            }
                        case 2:
                            {
                                while (true)
                                {
                                    Console.Write("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz:");
                                    string input = Console.ReadLine();
                                    int index = -1;

                                    if (personOperation.IsPhonenumber(input, out index))
                                    {
                                        Console.WriteLine("-->" + input + " değerinizle eşleşen kayıt silinmek üzere onaylıyor musunuz?(y/n)");
                                        Console.Write("Seçiminiz:");
                                        string islem = Console.ReadLine();

                                        if (islem == "y")
                                        {
                                            personOperation.DeleteNumber(index);
                                            break;
                                        }
                                        else
                                            break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen işlem seçiniz.");
                                        Console.WriteLine(" *İşlemi sonlandırmak için: (1)");
                                        Console.WriteLine(" *Yeniden denemek için: (2)");

                                        Console.Write("Seçiminiz:");
                                        int newSelect = Convert.ToInt16(Console.ReadLine());
                                        if (newSelect == 1)
                                            break;
                                    }
                                }
                                break;
                            }
                        case 3:
                            {
                                while (true)
                                {
                                    Console.Write("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz:");
                                    string input = Console.ReadLine();
                                    int index = -1;

                                    if (personOperation.IsPhonenumber(input, out index))
                                    {
                                        Console.Write("-->" + input + " değerinizle eşleşen kaydı güncellemek için yeni numara giriniz:");
                                        string yeniNo = Console.ReadLine();

                                        personOperation.UpdatePhonenumber(index, yeniNo);

                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen işlem seçiniz.");
                                        Console.WriteLine(" *Güncellemeyi sonlandırmak için: (1)");
                                        Console.WriteLine(" *Yeniden denemek için: (2)");

                                        Console.Write("Seçiminiz:");
                                        int yeniSecim = Convert.ToInt16(Console.ReadLine());
                                        if (yeniSecim == 1)
                                            break;
                                    }
                                }
                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine("Hangi düzende sıralamak istediğinizi seçiniz.");
                                Console.WriteLine(" *A-Z için: (1)");
                                Console.WriteLine(" *Z-A için: (2)");
                                Console.Write("Seçiminiz:");
                                int sortOrder = Convert.ToInt16(Console.ReadLine());

                                if (sortOrder == 1)
                                    personOperation.List(Sorting.Increasing);
                                else
                                    personOperation.List(Sorting.Decreasing);

                                
                                break;
                            }
                        case 5:
                            {
                                Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
                                Console.WriteLine(" *İsim veya Soyisme göre arama yapmak için  : (1)");
                                Console.WriteLine(" *Telefon numarasına göre arama yapmak için : (2)");

                                Console.Write("Seçiminiz:");
                                int newSelect = Convert.ToInt16(Console.ReadLine());

                                if (newSelect == 1)
                                {
                                    Console.Write("İsim veya Soyisim giriniz:");
                                    string searchedName = Console.ReadLine();
                                    personOperation.NameSurnameSearch(searchedName);
                                }
                                else
                                {
                                    Console.Write("Telefon giriniz:");
                                    string searchedNumber = Console.ReadLine();
                                    personOperation.PhoneNumberSearch(searchedNumber);
                                }

                                break;
                            }
                    }
                    Console.WriteLine("\nYeni işlem için bir tuşa basınız");
                    Console.ReadKey();
                    Console.Clear();
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Hatalı giriş yapıldı!\n");
                }
            }
            Console.ReadKey();
        }
    }
}
