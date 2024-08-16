using System.Data;
using dapper_api.Entities;
using FluentValidation;

class ClientValidator : AbstractValidator<Client>
{
    public ClientValidator()
    {
        RuleFor(x => x.Id)
        .NotNull()
        .NotEqual(0)        
        .WithMessage("{Id} must have a number other than 0");

        RuleFor(x => x.Name)
        .NotEmpty()
        .NotNull()
        .Length(2,100)
        .WithMessage("{Name} must have value between 2 to 100 lenght");

        RuleFor(x => x.Surname)
        .NotEmpty()
        .NotNull()
        .Length(2,150)
        .WithMessage("{Surname} must have value between 2 to 100 lenght");
    }
}