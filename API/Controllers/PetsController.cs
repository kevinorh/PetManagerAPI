using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class PetsController : BaseApiController
    {
        private readonly DataContext _context;
        public PetsController(DataContext context)
        {
            _context = context;
        }
        [HttpGet] //api/pets
        public async Task<ActionResult<List<Pet>>> GetPets(){
            return await _context.Pets.ToListAsync();
        }
        [HttpGet("{id}")] //api/pets/{id}
        public async Task<ActionResult<Pet>> GetPet(Guid Id){
            return await _context.Pets.FindAsync(Id);
        }
    }
}