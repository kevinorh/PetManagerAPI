using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Breeds
{
    public class Details
    {
        public class Query : IRequest<Result<Breed>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<Breed>>
        {
            private DataContext _context { get; }
            public Handler(DataContext context){
                _context=context;
            }
            public async Task<Result<Breed>> Handle(Query request, CancellationToken cancellationToken)
            {
                var breed = await _context.Breeds.FindAsync(request.Id);

                return Result<Breed>.Success(breed);
            }
        }
    }
}