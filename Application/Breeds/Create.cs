using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Breeds
{
    public class Create
    {
        public class Command : IRequest
        {
            public Breed Breed { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private DataContext _context { get; }
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Breeds.Add(request.Breed);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}