
using Domain;
using FluentValidation;

namespace Application.Breeds
{
    public class BreedValidator : AbstractValidator<Breed>
    {
        public BreedValidator()
        {
            RuleFor(x=>x.Name).NotEmpty();
            RuleFor(x=>x.Description).NotEmpty();
        }
    }
}