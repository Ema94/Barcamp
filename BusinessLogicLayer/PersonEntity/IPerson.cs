using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.PersonEntity
{
    public interface IPerson
    {
         int Id { get; set; }
         string Name { get; set; }
         int Age { get; set; }
         string Adress { get; set; }
    }
}
