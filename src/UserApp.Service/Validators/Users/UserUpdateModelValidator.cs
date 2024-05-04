using FluentValidation;
using UserApp.Service.Helpers;
using UserApp.Service.DTOs.Users;

namespace UserApp.Service.Validators.Users;

public class UserUpdateModelValidator : AbstractValidator<UserUpdateModel>
{
    public UserUpdateModelValidator()
    {
        RuleFor(user => user.FirstName)
            .NotNull()
            .WithMessage(user => $"{nameof(user.FirstName)} is not specified");

        RuleFor(user => user.LastName)
            .NotNull()
            .WithMessage(user => $"{nameof(user.LastName)} is not specified");

        RuleFor(user => user.Email)
            .Must(ValidationHelper.IsEmailValid);
    }
}