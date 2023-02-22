using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Breed
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description {get;set;}

        public virtual List<Pet> Pets {get;set;}
    }
}