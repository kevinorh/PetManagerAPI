using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Breeds
{
    public class List
    {
        public class Query : IRequest<List<Breed>> { }

        public class Handler : IRequestHandler<Query, List<Breed>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;

            }
            public async Task<List<Breed>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Breeds.ToListAsync();
            }
        }
    }
}