using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Pets
{
    public class List
    {
        public class Query: IRequest<List<Pet>>{ }
        public class Handler : IRequestHandler<Query, List<Pet>>
        {
            private readonly DataContext _context;
            private readonly ILogger<List> _logger;

            public Handler(DataContext context, ILogger<List> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async Task<List<Pet>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Pets.ToListAsync(cancellationToken);
            }
        }
    }
}