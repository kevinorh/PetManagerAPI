using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options): base(options){

        }
        
        public DbSet<Breed> Breeds {get;set;}
        public DbSet<Pet> Pets {get;set;}
    }
}