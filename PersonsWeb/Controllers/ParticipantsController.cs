using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.PersonEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PersonsWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        [HttpGet]
        public IPerson Get(int id)
        {
             PersonFactory factory = new PersonFactory();
             factory.SelectPerson(id);
            return factory.Person;
        }
        [HttpPost]
        public void Post(IPerson person)
        {
            PersonFactory factory = new PersonFactory(person);
            factory.AddPerson();
        }
        [HttpPut]
        public void Put(IPerson person)
        {
            PersonFactory factory = new PersonFactory(person);
            factory.UpdatePerson();
        }
        [HttpDelete]
        public void Delete(IPerson person)
        {
            PersonFactory factory = new PersonFactory(person);
            factory.Delete();
        }
    }
}