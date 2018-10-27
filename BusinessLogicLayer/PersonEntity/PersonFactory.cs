
using DataAccesLayer;
using DataAccesLayer.DataManagers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.PersonEntity
{
    public class PersonFactory
    {
        public IPerson Person { get; private set; }
        public List<IPerson> PersonList { get; private set; }
        public PersonFactory() { }
        public PersonFactory(IPerson person)
        {
            Person = person;
        }
        private void DataPersonToPerson(DataEntityPerson person)
        {
            if (person == null) person = null;
            person.Id = person.Id;
            Person.Name = person.Name;
            person.Age = person.Age;
            person.Adress = person.Adress;
        }
        private DataEntityPerson PersonToDataEntyPerson(IPerson person)
        {
            DataEntityPerson entity = new DataEntityPerson()
            {
                Id = person.Id,
                Name = person.Name,
                Age = person.Age,
                Adress = person.Adress
            };
            return entity;
        }
        public void AddPerson()
        {
            try
            {
                var id = PersonDataManager.AddPerson(PersonToDataEntyPerson(Person));
                Person.Id = id;
            }catch(Exception e)
            {
                throw;
            }
           
        }
        public void UpdatePerson()
        {
            try
            {
                PersonDataManager.UpdatePerson(PersonToDataEntyPerson(Person));
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public void Delete()
        {
            try
            {
                PersonDataManager.DeletePerson(PersonToDataEntyPerson(Person));
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public void SelectPerson(int id)
        {
            try
            {
                DataPersonToPerson(PersonDataManager.GetPersonById(id));
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
