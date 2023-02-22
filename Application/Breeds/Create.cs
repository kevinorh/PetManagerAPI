using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Breeds
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Breed Breed { get; set; }
        }
        public class CommnadValidator : AbstractValidator<Command>
        {
            public CommnadValidator(){
                RuleFor(x=>x.Breed).SetValidator(new BreedValidator());
            }
        }
        public class Handler : IRequestHandler<Command,Result<Unit>>
        {
            private DataContext _context { get; }
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Breeds.Add(request.Breed);

                //SaveChangesAsync returns the number of state entries written to the database
                var result = await _context.SaveChangesAsync() > 0;

                if(!result) return Result<Unit>.Failure("Failed to create breed");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}