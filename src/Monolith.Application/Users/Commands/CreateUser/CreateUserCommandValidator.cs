using FluentValidation;

namespace Monolith.Application.Users.Commands.CreateUser;

internal sealed class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(user => user.Name).NotNull().NotEmpty().WithMessage("Name of user can't be null or empty");

        // RuleFor(user => user.Bio).NotNull().NotEmpty().WithMessage("Name of user can't be null or empty");

        RuleFor(user => user.UserName).NotNull().NotEmpty().WithMessage("UserName of user can't be null or empty");

        RuleFor(user => user.Email).NotNull().NotEmpty().WithMessage("Email of user can't be null or empty");

        RuleFor(user => user.Password).NotNull().NotEmpty().WithMessage("Password of user can't be null or empty");
    }
}
