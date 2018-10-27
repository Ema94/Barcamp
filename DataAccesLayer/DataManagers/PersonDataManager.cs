using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccesLayer.DataManagers
{
    public static class PersonDataManager
    {
        public static int AddPerson(DataEntityPerson person)
        {
            using (var db = new Database())
            {
                try
                {
                    if (person == null) new System.ArgumentException("No se ah ingresado ninguna persona a la cual agregar");
                    db.Persons.AddAsync(person);
                    db.SaveChanges();
                    return person.Id; 
                }
                catch(Exception e)
                {
                    throw new System.ArgumentException("Se produjo un error al crear la persona", e);
                }
               
            }
            
        }
        public static void UpdatePerson(DataEntityPerson person)
        {
            using (var db = new Database())
            {
                if(person?.Id != 0)
                {
                    var toUpdate = db.Persons.Find(person.Id);
                    try
                    {
                        if (toUpdate == null)  new System.ArgumentException("No se encontro la persona que quiere actualizar");
                        toUpdate.Name = !string.IsNullOrEmpty(person.Name)? person.Name : toUpdate.Name;
                        toUpdate.Age = person.Age != 0 ? person.Age : toUpdate.Age;
                        toUpdate.Adress = !string.IsNullOrEmpty(person.Adress) ? person.Adress : toUpdate.Adress;
                        db.SaveChanges();
                        
                    }
                    catch(Exception e)
                    {
                        new System.ArgumentException("Se produjo un error al editar la persona", e);
                    }
                }
                else
                {
                     new System.ArgumentException("Referencie el Id de la persona que desea editar");
                }
                
            }

        }
        public static void DeletePerson(DataEntityPerson person)
        {
            using(var db = new Database())
            {
                if(person?.Id != 0)
                {
                    try
                    {
                        var toDelete = db.Persons.Find(person.Id);
                        if (toDelete == null) throw new System.ArgumentException("No se encontro la persona que quiere eliminar");
                        db.Persons.Remove(toDelete);
                        db.SaveChanges();
                    }catch(Exception e)
                    {
                        new System.ArgumentException("Se produjo un error al eliminar la persona", e);
                    }
                    
                }
                else
                {
                     new System.ArgumentException("Porfavor ingrese el Id de la persona que desea eliminar");
                }
            }
        }
        public static DataEntityPerson GetPersonById(int id)
        {
            using(var db = new Database())
            {
                try
                {
                    var person = db.Persons.Find(id);
                    if (person == null) new System.ArgumentException("No se encontro la persona con id: " + id);
                    return person;
                }catch(Exception e)
                {
                    throw new System.ArgumentException("Error al intentar comunicarse con la base de datos ",e);
                }
            }
        }
        public static int GetPersonsNumber()
        {
            using (var db = new Database())
            {
                try
                {
                    IQueryable<DataEntityPerson> person = db.Persons;
                   
                    return person.Count();
                }
                catch (Exception e)
                {
                    throw new System.ArgumentException("Error al intentar comunicarse con la base de datos ", e);
                }
            }
        }
    }
}
