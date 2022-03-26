using System;
using System.Collections.Generic;
using System.Text;

namespace CSHCONSOLE
{
    /// <summary>
    /// WAP to read and print person details using Function. You should pass person object to function to print details
    /// </summary>
    public class ClassExample
    {
        public void Execute()
        {
            Person person = new Person();
            Console.Write("Enter Person id:");
            person.PersonId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter first name:");
            person.FirstName = Console.ReadLine();
            Console.WriteLine("Enter last name:");
            person.LastName = Console.ReadLine();
            PrintPerson(person);
        }

        private void PrintPerson(Person person)
        {
            Console.WriteLine("Below are person details");
            Console.Write($"Person id: {person.PersonId}, First name: {person.FirstName} , Last name: {person.LastName}");
        }
    }
}
