using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Breeds
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Breed Breed { get; set; }
        }
        public class CommnadValidator : AbstractValidator<Command>
        {
            public CommnadValidator()
            {
                RuleFor(x => x.Breed).SetValidator(new BreedValidator());
            }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var breed = await _context.Breeds.FindAsync(request.Breed.Id);

                if (breed == null) return null;

                _mapper.Map(request.Breed, breed);
                // breed.Name = request.Breed.Name ?? breed.Name;
                // breed.Description = request.Breed.Description ?? breed.Description;

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to edit breed");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}