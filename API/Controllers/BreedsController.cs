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
    public class BreedsController : BaseApiController
    {
        private readonly DataContext _context;
        public BreedsController(DataContext context){
            _context = context;
        }
        [HttpGet] //api/breeds
        public async Task<ActionResult<List<Breed>>> GetBreeds(){
            return await _context.Breeds.ToListAsync();
        }
        [HttpGet("{id}")] //api/breeds/{id}
        public async Task<ActionResult<Breed>> GetBreed(Guid Id){
            return await _context.Breeds.FindAsync(Id);
        }

    }
}