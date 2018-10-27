using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.PersonEntity
{
    public class Person : IPerson
    {
        public Person() { }
        public Person(IPerson person)
        {
            Id = person.Id;
            Name = person.Name;
            Age = person.Age;
            Adress = person.Adress;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Adress { get; set; }
    }
}
