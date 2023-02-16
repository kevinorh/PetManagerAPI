using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Breeds
{
    public class Details
    {
        public class Query : IRequest<Breed>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Breed>
        {
            private DataContext _context { get; }
            public Handler(DataContext context){
                _context=context;
            }
            public async Task<Breed> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Breeds.FindAsync(request.Id);
            }
        }
    }
}