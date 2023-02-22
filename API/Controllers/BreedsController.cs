using Application.Breeds;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BreedsController : BaseApiController
    {
        [HttpGet] //api/breeds
        public async Task<ActionResult<List<Breed>>> GetBreeds()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }
        [HttpGet("{id}")] //api/breeds/{id}
        public async Task<ActionResult> GetBreed(Guid id)
        {
            // var result = await Mediator.Send(new Details.Query { Id = id });
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
            // if (result.IsSuccess && result.Value!=null) return Ok(result.Value);
            // if (result.IsSuccess && result.Value==null) return NotFound();
            // return BadRequest(result.Error);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBreed(Breed breed)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Breed = breed }));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBreed(Guid id, Breed breed)
        {

            breed.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Breed = breed }));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBreed(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}