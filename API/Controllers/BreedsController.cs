using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Breeds;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class BreedsController : BaseApiController
    {
        [HttpGet] //api/breeds
        public async Task<ActionResult<List<Breed>>> GetBreeds()
        {
            return await Mediator.Send(new List.Query());
        }
        [HttpGet("{id}")] //api/breeds/{id}
        public async Task<ActionResult<Breed>> GetBreed(Guid id)
        {
            return await Mediator.Send(new Details.Query { Id = id });
        }
        [HttpPost]
        public async Task<IActionResult> CreateBreed(Breed breed)
        {
            return Ok(await Mediator.Send(new Create.Command { Breed = breed }));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBreed(Guid id, Breed breed)
        {

            breed.Id = id;
            return Ok(await Mediator.Send(new Edit.Command { Breed = breed }));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBreed(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}