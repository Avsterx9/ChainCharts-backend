using FluentValidation;

namespace Users.API.Commands.CreateUser;

public class CreateUserValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
        RuleFor(x => x.RoleId).NotNull().NotEqual(0);
    }
}
