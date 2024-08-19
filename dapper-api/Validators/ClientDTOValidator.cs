using dapper_api.DTOs;
using FluentValidation;

class ClientDTOValidator : AbstractValidator<ClientDTO>
{
    public ClientDTOValidator()
    {
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