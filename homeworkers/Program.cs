using System;
using System.ComponentModel.Design;


namespace homeworkers
{

    class Program
    {
        static void PrintMenu()
        {
            Console.WriteLine("Enter -1 instead of a name to cancel adding a person.");
            Console.WriteLine("1.Print menu");
            Console.WriteLine("2.Add person");
            Console.WriteLine("3.Show names");
            Console.WriteLine("4.Delete name");
            Console.WriteLine("5.Make changes");
            Console.WriteLine("0.Exit");
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            PrintMenu();
            var personManager = new PersonManager();
            while (true)
            {

                Console.WriteLine("---------------------");
                Console.Write("Select an option:");
                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    switch (option)
                    {
                        case 0:
                            return;
                        case 1:
                            PrintMenu();
                            break;
                        case 2:
                            personManager.TakePerson();
                            break;
                        case 3:
                            personManager.ShowPersonsWithIndexes();
                            break;
                        case 4:
                            personManager.DeletePerson();
                            break;
                        case 5:
                            personManager.MakeChanges();
                            break;
                        default:
                            Console.WriteLine("This option does not exist.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Try again");
                }

            }
        }

    }

}