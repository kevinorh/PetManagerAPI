using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Pets;
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
        public async Task<ActionResult<List<Pet>>> GetPets(CancellationToken token)
        {
            return await Mediator.Send(new List.Query(), token);
        }
        [HttpGet("{id}")] //api/pets/{id}
        public async Task<ActionResult<Pet>> GetPet(Guid id)
        {
            return await Mediator.Send(new Details.Query { Id = id });
        }
        [HttpPost]
        public async Task<IActionResult> CreatePet(Pet pet)
        {
            return Ok(await Mediator.Send(new Create.Command { Pet = pet }));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditPet(Guid id, Pet pet)
        {
            return Ok(await Mediator.Send(new Edit.Command { Id = id, Pet = pet }));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}