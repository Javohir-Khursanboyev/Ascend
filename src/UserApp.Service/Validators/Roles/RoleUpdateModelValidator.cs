using FluentValidation;
using UserApp.Service.DTOs.Roles;

namespace UserApp.Service.Validators.Roles;

public class RoleUpdateModelValidator : AbstractValidator<RoleUpdateModel>
{
    public RoleUpdateModelValidator()
    {
        RuleFor(role => role.Name)
            .NotNull()
            .WithMessage(role => $"{nameof(role.Name)} is not specified");
    }
}