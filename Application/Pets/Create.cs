using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Pets
{
    public class Create
    {
        public class Command : IRequest
        {
            public Pet Pet { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var breed = _context.Breeds.Find(request.Pet.BreedId);
                var newPet = new Pet();

                _mapper.Map(request.Pet, newPet);
                _mapper.Map(breed, newPet.Breed);

                if (breed.Pets == null)
                {
                    breed.Pets = new List<Pet>();
                }
                // _context.Attach(newPet);

                _context.Pets.Add(newPet);
                breed.Pets.Add(newPet);
                
                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}