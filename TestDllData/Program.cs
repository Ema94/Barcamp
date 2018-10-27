using BusinessLogicLayer.PersonEntity;
using System;

namespace TestDllData
{
    class Program
    {
        static void Main(string[] args)
        {
            IPerson person = new Person()
            {
                Name = "Juan",
                Age = 28,
                Adress = "Calle123"
            };
            PersonFactory factory = new PersonFactory(person);
            factory.AddPerson();
            factory.SelectPerson(factory.Person.Id);
            Console.WriteLine(person.Id);
            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);
            Console.WriteLine(person.Adress);
            factory.Person.Name = "Rolando";
            factory.UpdatePerson();
            factory.SelectPerson(factory.Person.Id);
            Console.WriteLine(person.Id);
            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);
            Console.WriteLine(person.Adress);
            factory.Delete();
            factory.SelectPerson(factory.Person.Id);
            if (factory.Person != null)
            {
                
                Console.WriteLine(person.Id);
                Console.WriteLine(person.Name);
                Console.WriteLine(person.Age);
                Console.WriteLine(person.Adress);
            }
         
            Console.WriteLine("Hello World!");
        }
    }
}
