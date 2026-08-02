using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Globalization;
namespace homeworkers
{
    internal class PersonManager
    {
        List<Person> persons = new List<Person>();
        public void TakePerson()
        {
            Person person = new Person();
            Console.WriteLine("---------------------");
            Console.WriteLine("Add Name");
            Console.WriteLine("---------------------");
            while (true)
            {
                Console.Write("Name:");
                string input = Console.ReadLine();
                if(input=="-1")
                {
                    return;
                }
                else if (!string.IsNullOrWhiteSpace(input) && char.IsUpper(input[0]))
                {
                    person.name = input;
                    break;
                }
                Console.WriteLine("Name cannot be empty and must start with a capital letter.");
            }
            while (true)
            {
                Console.WriteLine("---------------------");
                Console.WriteLine("Date of birth");
                Console.WriteLine("---------------------");
                Console.Write("dd.mm.yyyy:");
                string input = Console.ReadLine();
                string formatDateOfBirth = "dd.MM.yyyy";
                bool isValidDate = DateTime.TryParseExact(input, formatDateOfBirth, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime birthDate);
                if (isValidDate && birthDate <= DateTime.Today && !string.IsNullOrWhiteSpace(input))
                {
                    person.geburt = birthDate.ToString("dd.MM.yyyy");
                    break;
                }
                Console.WriteLine("Enter a valid date in dd.MM.yyyy format.");
            }
            Console.WriteLine("---------------------");
            Console.WriteLine("Add Phon");
            Console.WriteLine("---------------------");
            Console.Write("Phon:");
            person.phon = Console.ReadLine();
            Console.WriteLine("---------------------");
            Console.WriteLine("Add Address:");
            Console.WriteLine("---------------------");
            while(true)
            {
                Console.Write("Address:");
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input) && char.IsUpper(input[0]))
                {
                    person.address = input;
                    break;
                }
                Console.WriteLine("Address cannot be empty and must start with a capital letter.");
            }
            Console.WriteLine("---------------------");
            Console.WriteLine("Add City");
            Console.WriteLine("---------------------");
            while(true)
            {
                Console.Write("City:");
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input) && char.IsUpper(input[0]))
                {
                    person.city = input;
                    break;
                }
                Console.WriteLine("City cannot be empty and must start with a capital letter.");
            }
            Console.WriteLine("---------------------");
            Console.WriteLine("Add E-Mail");
            Console.WriteLine("---------------------");
            Console.Write("E-Mail:");
            person.email = Console.ReadLine();
            persons.Add(person);
        }
        public void ShowPerson()
        {
            if (persons.Count == 0)
            {
                Console.WriteLine("Person is not on the list");
            }
            else
            {
                foreach (Person person in persons)
                {
                    Console.WriteLine("---------------------");
                    Console.WriteLine(person);
                    Console.WriteLine("---------------------");
                }
            }
        }
        public void DeletePerson()
        {
            if (persons.Count == 0)
            {
                Console.WriteLine("There are no persons in the list.");
                return;
            }
            for (int i = 0; i < persons.Count; i++)
            {
                Console.WriteLine("---------------------");
                Console.WriteLine($"Index of person:{i}");
                Console.WriteLine("---------------------");
                Console.WriteLine(persons[i]);
                Console.WriteLine("---------------------");
            }
            Console.WriteLine("Select the index of the person you want to remove");
            Console.Write("Your choice: ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int yourChoice))
                {
                    if(yourChoice == -1)
                    {
                        return;
                    }
                    else if (yourChoice >= 0 && yourChoice < persons.Count)
                    {
                        persons.RemoveAt(yourChoice);
                        Console.WriteLine("Person successfully removed.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("This index does not exist.");

                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number.");
                }
            }
           
        }
    }
}
