using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Pets
{
    public class Edit
    {
        public class Command : IRequest {
            public Guid Id {get;set;}
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
                var pet = await _context.Pets.FindAsync(request.Id);
                _mapper.Map(request.Pet,pet);

                // _context.Pets.Update(pet);
                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}