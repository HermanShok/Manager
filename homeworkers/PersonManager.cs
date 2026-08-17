using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace homeworkers
{
    internal class PersonManager
    {
        List<Person> persons = new List<Person>();
       
        public bool NotSpice(string input)
        {
            return !string.IsNullOrWhiteSpace(input) && char.IsUpper(input[0]);
        }
        public bool IsValidPhone(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Phone number cannot be empty ");
                return false;
            }
            if (input[0] != '+' && input[0] != '0')
            {
                Console.WriteLine("The first character must be + or 0");
                return false;
            }
            if (input.Length < 2)
            {
                Console.WriteLine("There must be at least one digit after + or 0");
                return false;
            }
            for (int i = 1; i < input.Length; i++)
            {
                if (!char.IsDigit(input[i]))
                {
                    Console.WriteLine("This is not a number");
                    return false;
                }
            }
            return true;
        }
        public static bool IsValidEmail(string input)
        {
            int countOfAt = 0;
            int indexOfAt = -1;
            int indexOfDot = -1;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '@')
                {
                    countOfAt++;
                }
            }
            if (countOfAt != 1)
            {
                Console.WriteLine("Erro. There is no '@' sign.");
                return false;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '@')
                {
                    indexOfAt = i;
                }
                if (input[i] == '.')
                {
                    {
                        indexOfDot = i;
                    }
                }
            }
            if (indexOfAt == 0)
            {
                Console.WriteLine("@ cannot be at the beginnig");
                return false;
            }
            if (indexOfDot < indexOfAt || indexOfDot == input.Length - 1)
            {
                Console.WriteLine(". is not placed after @ or only at the end ");
                return false;
            }
            if (indexOfDot - indexOfAt <= 1)
            {
                Console.WriteLine("There must be a character between the dot and the @ symbol");
                return false;
            }
            Console.WriteLine("It's okay");
            return true;
        }
        public void TakePerson()
        {
            Person person = new Person();

            Console.WriteLine("---------------------");
            Console.WriteLine("Add Name");
            Console.WriteLine("---------------------");
            while (true) // Prüfung von Name
            {
                Console.Write("Name:");
                string input = Console.ReadLine();
                if (input == "-1")
                {
                    return;
                }
                else if (NotSpice(input))
                {
                    person.name = input;
                    break;
                }
                Console.WriteLine("Name cannot be empty and must start with a capital letter.");
            }
            Console.WriteLine("---------------------");
            Console.WriteLine("Add Phon. If there is no number, press Enter.");
            Console.WriteLine("---------------------");
            Console.Write("Phon:");
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "")
                {
                    break;
                }
                else if (IsValidPhone(input))
                {
                    person.phon = input;
                    break;
                }
            }
            Console.WriteLine("---------------------");
            Console.WriteLine("Add Address:");
            Console.WriteLine("---------------------");
            while (true)// Prüfung von Adresse 
            {
                Console.Write("Address:");
                string input = Console.ReadLine();
                if (NotSpice(input))
                {
                    person.address = input;
                    break;
                }
                Console.WriteLine("Address cannot be empty and must start with a capital letter.");
            }
            Console.WriteLine("---------------------");
            Console.WriteLine("Add City");
            Console.WriteLine("---------------------");
            while (true)// Prüfing von Stad
            {
                Console.Write("City:");
                string input = Console.ReadLine();
                if (NotSpice(input))
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
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "")
                {
                    break;
                }
                else if (IsValidEmail(input))
                {
                    person.email = input;
                    break;
                }

            }
            persons.Add(person);
        }
        public void ShowPersonsWithIndexes()
        {
            if (persons.Count == 0)
            {
                Console.WriteLine("Person is not on the list");
            }
            for (int i = 0; i < persons.Count; i++)
            {
                Console.WriteLine("---------------------");
                Console.WriteLine($"Index of person:{i}");
                Console.WriteLine("---------------------");
                Console.WriteLine(persons[i]);
                Console.WriteLine("---------------------");
            }
        }
        public void DeletePerson() // Es räumt Menschen
        {
            if (persons.Count == 0)
            {
                Console.WriteLine("There are no persons in the list.");
                return;
            }
            ShowPersonsWithIndexes();
            Console.WriteLine("Select the index of the person you want to remove");
            Console.Write("Your choice: ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int yourChoice))
                {
                    if (yourChoice == -1)
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
        static void PrintMenuForChanges()
        {
            Console.WriteLine("Enter -1 instead of a name to cancel adding a person.");
            Console.WriteLine("1.Change name");
            Console.WriteLine("2.Change phon");
            Console.WriteLine("3.Change addresse");
            Console.WriteLine("4.Change city");
            Console.WriteLine("5.Change e-mail");
            Console.WriteLine("0.Exit");
        }
        public void MakeChanges()
        {
            if (persons.Count == 0)
            {
                Console.WriteLine("There are no persons in the list.");
                return;
            }
            ShowPersonsWithIndexes();
            Console.WriteLine("Select the index of the person you want to change");
            Console.Write("Your choice: ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int personChoice))
                {
                    if (personChoice == -1)
                    {

                        return;
                    }
                    else if (personChoice >= 0 && personChoice < persons.Count)
                    {

                        PrintMenuForChanges();
                        while (true)
                        {
                            Console.Write("Your choice: ");
                            if (int.TryParse(Console.ReadLine(), out int fieldChoice))
                            {
                                switch (fieldChoice)
                                {
                                    case 0:
                                        return;
                                    case 1:
                                        while (true) 
                                        {
                                            Console.Write("Name:");
                                            string input = Console.ReadLine();
                                            if (NotSpice(input))
                                            {
                                                persons[personChoice].name = input;
                                                break;
                                            }
                                            Console.WriteLine("Name cannot be empty and must start with a capital letter.");
                                        }
                                        break;
                                    case 2:
                                        while(true)
                                        {
                                            Console.Write("Phon:");
                                            string input = Console.ReadLine();
                                            if (IsValidPhone(input))
                                            {
                                                persons[personChoice].phon = input;
                                                break;
                                            }
                                            Console.WriteLine("Phon cannot be empty and must start with a capital letter.");
                                        }
                                        break;
                                    case 3:
                                        while (true)
                                        {
                                            Console.Write("Address:");
                                            string input = Console.ReadLine();
                                            if(NotSpice(input))
                                            {
                                                persons[personChoice].address = input;
                                                break;
                                            }
                                        }
                                        break;
                                    case 4:
                                        while (true)
                                        {
                                            Console.Write("City:");
                                            string input = Console.ReadLine();
                                            if (NotSpice(input))
                                            {
                                                persons[personChoice].city = input;
                                                break;
                                            }
                                        }
                                        break;
                                    case 5:
                                        while (true)
                                        {
                                            Console.Write("E-mail::");
                                            string input = Console.ReadLine();
                                            if (IsValidEmail(input))
                                            {
                                                persons[personChoice].email = input;
                                                break;
                                            }
                                        }
                                        break;
                                    default:
                                        Console.WriteLine("This option does not exist.");
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please enter a number.");
                            }
                        }
                        
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
