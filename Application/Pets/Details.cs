using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Pets
{
    public class Details
    {
        public class Query : IRequest<Pet>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Pet>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Pet> Handle(Query request, CancellationToken cancellationToken)
            {
                var pet = await _context.Pets.FindAsync(request.Id);
                // var breed = await _context.Breeds.FindAsync(pet.BreedId);
                // pet.Breed = breed;
                return pet;
            }
        }
    }
}