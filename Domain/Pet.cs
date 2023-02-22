using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Pet
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public string Photos { get; set; }

        public Guid BreedId {get;set;}
        public virtual Breed Breed {get;set;}
    }
}