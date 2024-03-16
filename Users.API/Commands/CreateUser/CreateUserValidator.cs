using FluentValidation;

namespace Users.API.Commands.CreateUser;

public class CreateUserValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.RegistrationDto.Email).EmailAddress();
        RuleFor(x => x.RegistrationDto.FirstName).NotEmpty();
        RuleFor(x => x.RegistrationDto.LastName).NotEmpty();
        RuleFor(x => x.RegistrationDto.Password).NotEmpty();
        RuleFor(x => x.RegistrationDto.RoleId).NotNull().NotEqual(0);
    }
}
