using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Breeds
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Breed Breed { get; set; }
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
                    var breed = await _context.Breeds.FindAsync(request.Breed.Id);

                    _mapper.Map(request.Breed, breed);
                    // breed.Name = request.Breed.Name ?? breed.Name;
                    // breed.Description = request.Breed.Description ?? breed.Description;

                    await _context.SaveChangesAsync();

                    return Unit.Value;
                }
            }
        }
    }
}